using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zaba_;

namespace Zaba_
{
    // Клас для малювання фігур
    public class ShapePanel : Panel
    {
        public string ShapeType { get; set; }
        public Color ShapeColor { get; set; }
        public Image Texture { get; set; } // ДОДАНО

        public ShapePanel()
        {
            this.DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Якщо є текстура - малюємо її
            if (Texture != null)
            {
                e.Graphics.DrawImage(Texture, 0, 0, Width, Height);
                return; // НЕ малюємо фігуру, тільки текстуру
            }

            // Якщо немає текстури - малюємо фігуру кольором
            using (var brush = new SolidBrush(ShapeColor))
            {
                switch (ShapeType.ToLower())
                {
                    case "circle":
                        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        e.Graphics.FillEllipse(brush, 0, 0, Width, Height);
                        break;

                    case "rectangle":
                        e.Graphics.FillRectangle(brush, 0, 0, Width, Height);
                        break;

                    case "triangle":
                        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        Point[] points = {
                        new Point(Width / 2, 0),
                        new Point(Width, Height),
                        new Point(0, Height)
                    };
                        e.Graphics.FillPolygon(brush, points);
                        break;
                }
            }
        }
    }

    public class ZabkaInterpreter
    {
        Dictionary<string, object> env = new Dictionary<string, object>();
        List<System.Windows.Forms.Timer> intervals = new();
        public string Output { get; private set; } = "";
        private bool windowImported = false;
        private bool stopped = false;
        private Dictionary<string, object> localVars = new();
        private Form activeForm;
        private Dictionary<string, Control> controls = new();
        private CancellationTokenSource cts;
        private SynchronizationContext uiContext;
        private object locker = new object();
        private Dictionary<string, List<Stmt>> keyHandlers = new Dictionary<string, List<Stmt>>();
        public event Action<string>? OnOutputChanged;
        private Dictionary<string, Image> textures = new Dictionary<string, Image>();
        private Dictionary<string, System.Media.SoundPlayer> sounds = new Dictionary<string, System.Media.SoundPlayer>();
        private string projectPath = "";
        public ZabkaInterpreter()
        {
            uiContext = SynchronizationContext.Current ?? new SynchronizationContext();
        }

        public void SetUiContext(SynchronizationContext ctx) => uiContext = ctx;

        void AppendOutput(string text)
        {
            lock (locker)
            {
                Output += text;
            }
            OnOutputChanged?.Invoke(text);
        }
        public void SetProjectPath(string path)
        {
            projectPath = path;
        }
        void RunOnUI(Action a) => uiContext.Send(_ => a(), null);
        void PostToUI(Action a) => uiContext.Post(_ => a(), null);

        // Конвертація назви кольору або HEX в Color
        Color ParseColor(string colorStr)
        {
            colorStr = colorStr.Trim();

            // Якщо це HEX колір
            if (colorStr.StartsWith("#"))
            {
                try
                {
                    return ColorTranslator.FromHtml(colorStr);
                }
                catch
                {
                    AppendOutput($"❌ Invalid HEX color '{colorStr}', using black\n");
                    return Color.Black;
                }
            }

            // Якщо це назва кольору
            try
            {
                return Color.FromName(colorStr);
            }
            catch
            {
                AppendOutput($"❌ Unknown color '{colorStr}', using black\n");
                return Color.Black;
            }
        }

        public void Run(string code)
        {
            // Зупиняємо попередню програму
            StopProgram();

            stopped = false;
            Output = "";
            AppendOutput("✔ Launched Program\n");

            try
            {
                var lexer = new Lexer(code);
                var tokens = lexer.Tokenize();
                var parser = new Parser(tokens);
                var prog = parser.ParseProgram();

                foreach (var stmt in prog.Stmts)
                {
                    if (stopped) break;
                    ExecStmt(stmt);
                }
            }
            catch (Exception ex)
            {
                AppendOutput($"❌ Error: {ex.Message}\n");
                StopProgramByError();
            }
        }

        public void Start(string code)
        {
            // Зупиняємо попередню програму
            StopProgram();

            stopped = false;
            Output = "";

            if (cts != null)
            {
                cts.Cancel();
                cts.Dispose();
            }

            cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;

            var lexer = new Lexer(code);
            var tokens = lexer.Tokenize();
            var parser = new Parser(tokens);
            var prog = parser.ParseProgram();

            Task.Run(() =>
            {
                try
                {
                    foreach (var stmt in prog.Stmts)
                    {
                        if (token.IsCancellationRequested || stopped) break;
                        ExecStmt(stmt);
                    }
                    AppendOutput("✔ Launched Program\n");
                }
                catch (Exception ex)
                {
                    AppendOutput($"❌ Error: {ex.Message}\n");
                    stopped= true;
                }
            }, token);
        }

        void ExecProgram(ProgramNode p)
        {
            foreach (var s in p.Stmts) ExecStmt(s);
        }

        public object Eval(Expr expr)
        {
            switch (expr)
            {
                case NumberExpr n: return n.Value;
                case BoolExpr b: return b.Value;
                case StringExpr s: return s.Value;

                case BinaryExpr b:
                    var l = Eval(b.L);
                    var r = Eval(b.R);

                    if (b.Op == "+" && (l is string || r is string))
                    {
                        return l.ToString() + r.ToString();
                    }

                    return b.Op switch
                    {
                        "+" => Convert.ToDouble(l) + Convert.ToDouble(r),
                        "-" => Convert.ToDouble(l) - Convert.ToDouble(r),
                        "*" => Convert.ToDouble(l) * Convert.ToDouble(r),
                        "/" => Convert.ToDouble(l) / Convert.ToDouble(r),
                        ">" => (Convert.ToDouble(l) > Convert.ToDouble(r)) ? 1 : 0,
                        "<" => (Convert.ToDouble(l) < Convert.ToDouble(r)) ? 1 : 0,
                        "==" => l.Equals(r) ? 1 : 0,
                        "!=" => !l.Equals(r) ? 1 : 0,
                        _ => throw new Exception("Unknown operator " + b.Op)
                    };

                case VarExpr v:
                    if (!env.ContainsKey(v.Name)) throw new Exception($"Undefined var {v.Name}");
                    var val = env[v.Name];
                    if (val is int || val is double) return val;
                    if (double.TryParse(val.ToString(), out double num)) return num;
                    return val;

                default:
                    throw new Exception("Unknown expression");
            }
        }

        void ExecStmt(Stmt s)
        {
            switch (s)
            {
                // НОВИЙ CASE: Створення фігур
                case CreatePartStmt cps:
                    if (!windowImported || activeForm == null)
                    {
                        AppendOutput("❌ Module 'window' not imported or no active form\n");
                        return;
                    }

                    RunOnUI(() =>
                    {
                        var shape = new ShapePanel
                        {
                            ShapeType = cps.Shape,
                            ShapeColor = ParseColor(cps.Color),
                            Size = new Size(cps.Width, cps.Height),
                            Location = new Point(10, 10) // Дефолтна позиція
                        };

                        activeForm.Controls.Add(shape);
                        controls[cps.VarName] = shape;
                    });

                    AppendOutput($"✅ Created {cps.Shape} '{cps.VarName}' ({cps.Color})\n");
                    break;
                case LoadTextureStmt lts:
                    try
                    {
                        string fullPath = Path.Combine(projectPath, lts.FileName);
                        if (!File.Exists(fullPath))
                        {
                            AppendOutput($"❌ Texture file not found: {lts.FileName}\n");
                            return;
                        }

                        var image = Image.FromFile(fullPath);
                        textures[lts.VarName] = image;
                        AppendOutput($"✅ Loaded texture '{lts.FileName}'\n");
                    }
                    catch (Exception ex)
                    {
                        AppendOutput($"❌ Error loading texture: {ex.Message}\n");
                        StopProgramByError();
                    }
                    break;

                case SetTextureStmt sts:
                    if (!controls.ContainsKey(sts.ShapeName))
                    {
                        AppendOutput($"❌ Shape '{sts.ShapeName}' not found\n");
                        return;
                    }
                    if (!textures.ContainsKey(sts.TextureName))
                    {
                        AppendOutput($"❌ Texture '{sts.TextureName}' not found\n");
                        return;
                    }

                    RunOnUI(() =>
                    {
                        var shape = controls[sts.ShapeName];
                        if (shape is ShapePanel sp)
                        {
                            sp.Texture = textures[sts.TextureName]; // Встановлюємо текстуру
                            sp.Invalidate(); // Перемалювати
                            AppendOutput($"✅ Applied texture to '{sts.ShapeName}'\n");
                        }
                    });
                    break;

                case RemoveTextureStmt rts:
                    if (!controls.ContainsKey(rts.ShapeName))
                    {
                        AppendOutput($"❌ Shape '{rts.ShapeName}' not found\n");
                        return;
                    }

                    RunOnUI(() =>
                    {
                        var shape = controls[rts.ShapeName];
                        if (shape is ShapePanel sp)
                        {
                            sp.Texture = null; // Прибираємо текстуру
                            sp.Invalidate(); // Перемалювати
                            AppendOutput($"🗑 Removed texture from '{rts.ShapeName}'\n");
                        }
                    });
                    break;

                case LoadSoundStmt lss:
                    try
                    {
                        string fullPath = Path.Combine(projectPath, lss.FileName);
                        if (!File.Exists(fullPath))
                        {
                            AppendOutput($"❌ Sound file not found: {lss.FileName}\n");
                            return;
                        }

                        var player = new System.Media.SoundPlayer(fullPath);
                        sounds[lss.VarName] = player;
                        AppendOutput($"✅ Loaded sound '{lss.FileName}'\n");
                    }
                    catch (Exception ex)
                    {
                        AppendOutput($"❌ Error loading sound: {ex.Message}\n");
                        StopProgramByError();
                    }
                    break;

                // Замініть case PlaySoundStmt в ZabkaInterpreter.cs

                case PlaySoundStmt pss:
                    if (!sounds.ContainsKey(pss.SoundName))
                    {
                        AppendOutput($"❌ Sound '{pss.SoundName}' not found\n");
                        return;
                    }

                    try
                    {
                        // Перевіряємо чи є loop
                        bool shouldLoop = false;
                        if (env.ContainsKey(pss.SoundName + "_loop"))
                        {
                            var loopValue = env[pss.SoundName + "_loop"];
                            shouldLoop = loopValue.ToString().ToLower() == "true" || loopValue.ToString() == "1";
                        }

                        if (shouldLoop)
                        {
                            // Відтворюємо в циклі
                            sounds[pss.SoundName].PlayLooping();
                            AppendOutput($"🔊 Playing sound '{pss.SoundName}' (looping)\n");
                        }
                        else
                        {
                            // Відтворюємо один раз
                            sounds[pss.SoundName].Play();
                            AppendOutput($"🔊 Playing sound '{pss.SoundName}'\n");
                        }
                    }
                    catch (Exception ex)
                    {
                        AppendOutput($"❌ Error playing sound: {ex.Message}\n");
                        StopProgramByError();
                    }
                    break;

                case StopSoundStmt sss:
                    if (!sounds.ContainsKey(sss.SoundName))
                    {
                        AppendOutput($"❌ Sound '{sss.SoundName}' not found\n");
                        return;
                    }

                    try
                    {
                        sounds[sss.SoundName].Stop();
                        AppendOutput($"🔇 Stopped sound '{sss.SoundName}'\n");
                    }
                    catch (Exception ex)
                    {
                        AppendOutput($"❌ Error stopping sound: {ex.Message}\n");
                        StopProgramByError();
                    }
                    break;
                case OnKeyStmt oks:
                    if (!windowImported || activeForm == null)
                    {
                        AppendOutput("❌ Module 'window' not imported or no active form\n");
                        return;
                    }

                    var keyName = oks.Key.ToUpper();

                    // Зберігаємо обробник клавіші
                    if (!keyHandlers.ContainsKey(keyName))
                        keyHandlers[keyName] = new List<Stmt>();

                    keyHandlers[keyName].AddRange(oks.Body);

                    // Підключаємо обробник до форми (робимо це один раз)
                    if (!activeForm.KeyPreview)
                    {
                        activeForm.KeyPreview = true;

                        activeForm.KeyDown += (sender, e) =>
                        {
                            var pressedKey = e.KeyCode.ToString().ToUpper();

                            if (keyHandlers.ContainsKey(pressedKey))
                            {
                                try
                                {
                                    foreach (var stmt in keyHandlers[pressedKey])
                                    {
                                        if (stopped) break;
                                        ExecStmt(stmt);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    AppendOutput($"❌ OnKey error: {ex.Message}\n");
                                    StopProgramByError();
                                }
                            }
                        };
                    }

                    AppendOutput($"✅ OnKey event attached for '{keyName}'\n");
                    break;
                case ImportStmt im:
                    if (im.Module == "window") windowImported = true;
                    else if (im.Module == "texturemodule")
                    {
                        AppendOutput("✅ Module 'texturemodule' imported\n");
                    }
                    else if (im.Module == "soundservice")
                    {
                        AppendOutput("✅ Module 'soundservice' imported\n");
                    }
                    else AppendOutput($"❌ Unknown module {im.Module}\n");
                    break;

                case CreateFormStmt cf:
                    if (!windowImported) { AppendOutput("❌ Module 'window' not imported\n"); return; }

                    RunOnUI(() =>
                    {
                        activeForm = new Form();
                        activeForm.Text = cf.Title;
                        activeForm.Size = new Size(600, 400);
                        activeForm.Show();
                        controls[cf.VarName] = activeForm;
                    });
                    break;

                case PropertyAssignStmt pas:
                    // Спочатку перевіряємо текстури
                    if (textures.ContainsKey(pas.ObjectName))
                    {
                        var valueTexture = Eval(pas.Value);

                        switch (pas.PropertyName.ToLower())
                        {
                            case "size":
                                // Розмір текстури - зберігаємо в env для подальшого використання
                                env[pas.ObjectName + "_size"] = valueTexture;
                                AppendOutput($"✅ Texture size property set for '{pas.ObjectName}'\n");
                                break;
                            case "pos":
                                env[pas.ObjectName + "_pos"] = valueTexture;
                                AppendOutput($"✅ Texture position property set for '{pas.ObjectName}'\n");
                                break;
                            default:
                                AppendOutput($"⚠ Unknown texture property '{pas.PropertyName}'\n");
                                break;
                        }
                        return;
                    }

                    // Потім перевіряємо звуки
                    if (sounds.ContainsKey(pas.ObjectName))
                    {
                        var valueSound = Eval(pas.Value);

                        switch (pas.PropertyName.ToLower())
                        {
                            case "loop":
                                env[pas.ObjectName + "_loop"] = valueSound;
                                AppendOutput($"✅ Set loop for sound '{pas.ObjectName}'\n");
                                break;
                            case "volume":
                                env[pas.ObjectName + "_volume"] = valueSound;
                                AppendOutput($"✅ Set volume for sound '{pas.ObjectName}'\n");
                                break;
                            default:
                                AppendOutput($"⚠ Unknown sound property '{pas.PropertyName}'\n");
                                break;
                        }
                        return;
                    }

                    // І тільки потім перевіряємо controls
                    if (!controls.ContainsKey(pas.ObjectName))
                    {
                        AppendOutput($"❌ Object '{pas.ObjectName}' not found\n");
                        return;
                    }

                    var controlss = controls[pas.ObjectName];
                    var valueee = Eval(pas.Value);

                    RunOnUI(() =>
                    {
                        switch (pas.PropertyName.ToLower())
                        {
                            case "background":
                            case "bg":
                                if (controlss is Form form)
                                {
                                    form.BackColor = ParseColor(valueee.ToString());
                                    AppendOutput($"✅ Set background of '{pas.ObjectName}' to {valueee}\n");
                                }
                                else
                                {
                                    controlss.BackColor = ParseColor(valueee.ToString());
                                    AppendOutput($"✅ Set background of '{pas.ObjectName}' to {valueee}\n");
                                }
                                break;

                            case "pos":
                                if (valueee is string posStr)
                                {
                                    var parts = posStr.Split(',');
                                    if (parts.Length == 2 &&
                                        int.TryParse(parts[0].Trim(), out int x) &&
                                        int.TryParse(parts[1].Trim(), out int y))
                                    {
                                        controlss.Location = new Point(x, y);
                                    }
                                    else
                                    {
                                        AppendOutput($"❌ Invalid position format. Use 'x,y'\n");
                                    }
                                }
                                break;

                            case "size":
                                if (valueee is string sizeStr)
                                {
                                    var parts = sizeStr.Split(',');
                                    if (parts.Length == 2 &&
                                        int.TryParse(parts[0].Trim(), out int width) &&
                                        int.TryParse(parts[1].Trim(), out int height))
                                    {
                                        controlss.Size = new Size(width, height);
                                        if (controlss is ShapePanel sp)
                                            sp.Invalidate();
                                    }
                                    else
                                    {
                                        AppendOutput($"❌ Invalid size format. Use 'width,height'\n");
                                    }
                                }
                                break;

                            case "color":
                                if (controlss is ShapePanel shapePanel)
                                {
                                    shapePanel.ShapeColor = ParseColor(valueee.ToString());
                                    shapePanel.Invalidate();
                                    AppendOutput($"✅ Changed color of '{pas.ObjectName}'\n");
                                }
                                break;

                            case "textcolor":
                                if (controlss is Label lbl)
                                {
                                    lbl.ForeColor = ParseColor(valueee.ToString());
                                    AppendOutput($"✅ Changed text color of '{pas.ObjectName}'\n");
                                }
                                else if (controlss is Button btn)
                                {
                                    btn.ForeColor = ParseColor(valueee.ToString());
                                }
                                break;

                            case "textbg":
                                if (controlss is Label lblBg)
                                {
                                    if (valueee.ToString().ToLower() == "transparent")
                                    {
                                        lblBg.BackColor = Color.Transparent;
                                    }
                                    else
                                    {
                                        lblBg.BackColor = ParseColor(valueee.ToString());
                                    }
                                    AppendOutput($"✅ Changed text background of '{pas.ObjectName}'\n");
                                }
                                break;

                            case "text":
                                if (controlss is Button but)
                                    but.Text = valueee.ToString();
                                else if (controlss is Form formm)
                                    formm.Text = valueee.ToString();
                                else if (controlss is Label label)
                                    label.Text = valueee.ToString();
                                break;

                            case "fontsize":
                                if (valueee is string fontSizeStr && float.TryParse(fontSizeStr, out float fontSize))
                                {
                                    string currentFontFamily = controlss.Font?.FontFamily?.Name ?? "Microsoft Sans Serif";
                                    controlss.Font = new Font(currentFontFamily, fontSize);
                                }
                                break;

                            case "font":
                                try
                                {
                                    float currentSize = controlss.Font?.Size ?? 9.0f;
                                    string fontName = valueee.ToString();
                                    controlss.Font = new Font(fontName, currentSize);
                                }
                                catch (ArgumentException)
                                {
                                    AppendOutput($"❌ Font '{valueee}' not found\n");
                                }
                                break;

                            default:
                                AppendOutput($"❌ Unknown property '{pas.PropertyName}'\n");
                                break;
                        }
                    });
                    break;

                case WhileStmt ws:
                    while (!stopped && EvalExpr(ws.Cond) != 0)
                    {
                        foreach (var st in ws.Body)
                        {
                            if (stopped) break;
                            ExecStmt(st);
                        }
                    }
                    break;

                case LocalStmt ls:
                    if (ls.Value is MethodCallExpr mce)
                    {
                        if (mce.Object == "window" && mce.Method == "CreateNewForm")
                        {
                            if (!windowImported) { AppendOutput("❌ Module 'window' not imported\n"); return; }

                            RunOnUI(() =>
                            {
                                var form = new Form();
                                form.Text = mce.Argument;
                                form.Size = new Size(600, 400);
                                form.Show();
                                controls[ls.Name] = form;
                                activeForm = form;
                            });

                            AppendOutput($"✅ Created form '{ls.Name}'\n");
                        }
                        else if (mce.Object == "window" && mce.Method == "CreateButton")
                        {
                            if (!windowImported || activeForm == null) { AppendOutput("❌ No form to attach button\n"); return; }

                            RunOnUI(() =>
                            {
                                var button = new Button();
                                button.Text = mce.Argument;
                                button.Size = new Size(100, 40);
                                button.Location = new Point(10, 10);
                                activeForm.Controls.Add(button);
                                controls[ls.Name] = button;
                            });

                            AppendOutput($"✅ Created button '{ls.Name}'\n");
                        }
                        else if (mce.Object == "window" && mce.Method == "CreateLabel")
                        {
                            if (!windowImported || activeForm == null) { AppendOutput("❌ No form to attach label\n"); return; }

                            RunOnUI(() =>
                            {
                                var label = new Label();
                                label.Text = mce.Argument;
                                label.AutoSize = true;
                                label.Location = new Point(10, 60);
                                activeForm.Controls.Add(label);
                                controls[ls.Name] = label;
                            });

                            AppendOutput($"✅ Created label '{ls.Name}'\n");
                        }
                        else if (mce.Object == "texturemodule" && mce.Method == "Texture")
                        {
                            try
                            {
                                string fullPath = Path.Combine(projectPath, mce.Argument);
                                if (!File.Exists(fullPath))
                                {
                                    AppendOutput($"❌ Texture file not found: {mce.Argument}\n");
                                    return;
                                }

                                var image = Image.FromFile(fullPath);
                                textures[ls.Name] = image;
                                env[ls.Name] = ls.Name; // Зберігаємо посилання
                                AppendOutput($"✅ Loaded texture '{mce.Argument}' as '{ls.Name}'\n");
                            }
                            catch (Exception ex)
                            {
                                AppendOutput($"❌ Error loading texture: {ex.Message}\n");
                                StopProgramByError();
                            }
                        }
                        else if (mce.Object == "soundservice" && mce.Method == "Sound")
                        {
                            try
                            {
                                string fullPath = Path.Combine(projectPath, mce.Argument);
                                if (!File.Exists(fullPath))
                                {
                                    AppendOutput($"❌ Sound file not found: {mce.Argument}\n");
                                    return;
                                }

                                var player = new System.Media.SoundPlayer(fullPath);
                                sounds[ls.Name] = player;
                                env[ls.Name] = ls.Name; // Зберігаємо посилання
                                AppendOutput($"✅ Loaded sound '{mce.Argument}' as '{ls.Name}'\n");
                            }
                            catch (Exception ex)
                            {
                                AppendOutput($"❌ Error loading sound: {ex.Message}\n");
                                StopProgramByError();
                            }
                        }
                    }
                    else
                    {
                        var result = Eval(ls.Value);
                        env[ls.Name] = result;
                    }
                    break;

                case OnClickStmt ocs:
                    if (!controls.ContainsKey(ocs.ObjectName))
                    {
                        AppendOutput($"❌ Object '{ocs.ObjectName}' not found\n");
                        return;
                    }

                    var control = controls[ocs.ObjectName];
                    if (control is Button clickableButton)
                    {
                        var commandsToExecute = new List<Stmt>(ocs.Body);

                        clickableButton.Click += (sender, e) =>
                        {
                            try
                            {
                                foreach (var stmt in commandsToExecute)
                                {
                                    if (stopped) break;
                                    ExecStmt(stmt);
                                }
                            }
                            catch (Exception ex)
                            {
                                AppendOutput($"❌ OnClick error: {ex.Message}\n");
                                StopProgramByError();
                            }
                        };

                        AppendOutput($"✅ OnClick event attached to '{ocs.ObjectName}'\n");
                    }
                    break;

                case RemoveStmt rs:
                    if (!controls.ContainsKey(rs.ObjectName))
                    {
                        AppendOutput($"❌ Object '{rs.ObjectName}' not found\n");
                        return;
                    }

                    RunOnUI(() =>
                    {
                        var ctrl = controls[rs.ObjectName];
                        if (ctrl.Parent != null)
                            ctrl.Parent.Controls.Remove(ctrl);
                        controls.Remove(rs.ObjectName);
                    });

                    AppendOutput($"🗑 Removed '{rs.ObjectName}'\n");
                    break;

                case StopStmt:
                    StopProgramByError();
                    RunOnUI(() =>
                    {
                        if (activeForm != null)
                        {
                            activeForm.Close();
                            activeForm = null;
                        }
                    });
                    AppendOutput("🛑 Program stopped\n");
                    break;

                case AssignStmt a:
                    var assigned = Eval(a.Value);
                    env[a.Name] = assigned;
                    break;

                case TickStmt ts:
                    var timer = new System.Windows.Forms.Timer();
                    timer.Interval = ts.Interval;
                    timer.Tick += (s, e) => {
                        if (stopped) // Додай цю перевірку!
                        {
                            timer.Stop();
                            return;
                        }

                        try
                        {
                            foreach (var st in ts.Body)
                            {
                                if (stopped) break;
                                ExecStmt(st);
                            }
                        }
                        catch (Exception ex)
                        {
                            AppendOutput($"❌ Tick error: {ex.Message}\n");
                            StopProgramByError();
                        }
                    };
                    timer.Start();
                    intervals.Add(timer);
                    break;

                case PringStmt p:
                    var valu = Eval(p.Value);
                    AppendOutput(valu.ToString() + Environment.NewLine);
                    break;

                case LetStmt let:
                    var value = Eval(let.Value);
                    env[let.Name] = value;
                    break;

                case IfStmt ifs:
                    var cond = EvalExpr(ifs.Cond);
                    if (cond != 0)
                        foreach (var st in ifs.Then) ExecStmt(st);
                    else if (ifs.Else != null)
                        foreach (var st in ifs.Else) ExecStmt(st);
                    break;

                case ExprStmt es:
                    EvalExpr(es.E);
                    break;

                default:
                    throw new Exception("Unknown stmt type: " + s.GetType().Name);
            }
        }
        // Замініть StopProgramByError в ZabkaInterpreter:

        private void StopProgramByError()
        {
            stopped = true;

            // Очищуємо обробники клавіш
            keyHandlers.Clear();

            // Зупиняємо всі таймери
            foreach (var timer in intervals)
            {
                timer.Stop();
                timer.Dispose();
            }
            intervals.Clear();

            // ДОДАНО: Зупиняємо всі звуки
            foreach (var sound in sounds.Values)
            {
                try
                {
                    sound.Stop();
                }
                catch { }
            }

            cts?.Cancel();

            PostToUI(() =>
            {
                try
                {
                    if (activeForm != null)
                    {
                        activeForm.Close();
                        activeForm = null;
                    }

                    foreach (var kv in controls.ToList())
                    {
                        if (kv.Value?.Parent != null)
                            kv.Value.Parent.Controls.Remove(kv.Value);
                    }
                    controls.Clear();
                }
                catch { }
            });
        }

        // Також оновіть StopProgram():

        public void StopProgram()
        {
            stopped = true;

            // Очищуємо обробники клавіш
            keyHandlers.Clear();

            // Зупиняємо всі таймери
            foreach (var timer in intervals)
            {
                timer.Stop();
                timer.Dispose();
            }
            intervals.Clear();

            // ДОДАНО: Зупиняємо всі звуки
            foreach (var sound in sounds.Values)
            {
                try
                {
                    sound.Stop();
                }
                catch { }
            }

            cts?.Cancel();

            PostToUI(() =>
            {
                try
                {
                    if (activeForm != null)
                    {
                        activeForm.Close();
                        activeForm = null;
                    }

                    foreach (var kv in controls.ToList())
                    {
                        if (kv.Value?.Parent != null)
                            kv.Value.Parent.Controls.Remove(kv.Value);
                    }
                    controls.Clear();
                }
                catch { }
            });

            AppendOutput("🛑 Program stopped\n");
        }


        public void ClearConsole()
        {
            Output = ">";
        }

        int EvalExpr(Expr e)
        {
            switch (e)
            {
                case MethodCallExpr mce:
                    return 0;
                case NumberExpr n:
                    return n.Value;

                case StringExpr s:
                    return string.IsNullOrEmpty(s.Value) ? 0 : 1;
                case VarExpr v:
                    if (!env.ContainsKey(v.Name)) throw new Exception($"Undefined var {v.Name}");
                    var value = env[v.Name];
                    if (value is int) return (int)value;
                    if (value is double) return (int)(double)value;
                    if (int.TryParse(value.ToString(), out int result)) return result;
                    return 0;
                case BinaryExpr b:
                    var L = EvalExpr(b.L);
                    var R = EvalExpr(b.R);
                    return b.Op switch
                    {
                        "+" => L + R,
                        "-" => L - R,
                        "*" => L * R,
                        "/" => R != 0 ? L / R : throw new Exception("Division by zero"),
                        ">" => L > R ? 1 : 0,
                        "<" => L < R ? 1 : 0,
                        "==" => L == R ? 1 : 0,
                        "!=" => L != R ? 1 : 0,
                        _ => throw new Exception("Unknown operator " + b.Op)
                    };
                default:
                    throw new Exception("Unknown expr");
            }
        }
    }
}