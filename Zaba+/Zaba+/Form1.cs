using FastColoredTextBoxNS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Security.Principal;
using System.Windows.Forms;
using System.Threading;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Zaba_
{
    public partial class Form1 : Form
    {
        // Змінні для перетягування
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        private string currentProjectPath = "";
        // Для пошуку
        private List<Range> foundRanges = new List<Range>();
        private int currentFindIndex = -1;

        private ZabkaInterpreter interp;
        // Обробники миші для форми або панелі (якщо є панель верхня)
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point diff = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(diff));
            }
        }
        // Стилі для ключових слів
        TextStyle prinsStyle = new TextStyle(new SolidBrush(Color.DodgerBlue), null, FontStyle.Bold);
        TextStyle pringStyle = new TextStyle(new SolidBrush(Color.LightSkyBlue), null, FontStyle.Bold);
        TextStyle stopStyle = new TextStyle(new SolidBrush(Color.Red), null, FontStyle.Bold);
        TextStyle clearStyle = new TextStyle(new SolidBrush(Color.White), null, FontStyle.Bold);
        TextStyle importStyle = new TextStyle(new SolidBrush(Color.Yellow), null, FontStyle.Bold);
        TextStyle commentStyle = new TextStyle(new SolidBrush(Color.DimGray), null, FontStyle.Italic);
        TextStyle stringStyle = new TextStyle(new SolidBrush(Color.Orange), null, FontStyle.Italic);
        TextStyle findStyle = new TextStyle(new SolidBrush(Color.Yellow), new SolidBrush(Color.Yellow), FontStyle.Bold);
        TextStyle numberStyle = new TextStyle(new SolidBrush(Color.Lime), null, FontStyle.Regular);
        TextStyle bracketStyle = new TextStyle(new SolidBrush(Color.DeepPink), null, FontStyle.Bold);


        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
        private System.Windows.Forms.Timer timer; // 🔥 уточнили

        public Form1()
        {
            InitializeComponent();

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1;
            timer.Tick += Timer_Tick;
            timer.Start();

            AdvancedTextBox.Language = FastColoredTextBoxNS.Language.Custom;
            AdvancedTextBox.TextChanged += fastColoredTextBox1_TextChanged;

            interp = new ZabkaInterpreter();
            interp.SetUiContext(SynchronizationContext.Current);

            // Встановлюємо дефолтний шлях (папка Projects)
            string projectsFolder = Path.Combine(Application.StartupPath, "Projects");
            Directory.CreateDirectory(projectsFolder);
            currentProjectPath = projectsFolder;
            interp.SetProjectPath(currentProjectPath);

            interp.OnOutputChanged += (textChunk) =>
            {
                this.Invoke((Action)(() =>
                {
                    if (textChunk == null)
                        label2.Text = interp.Output;
                    else
                        label2.Text += textChunk;
                }));
            };
        }

        // Додай новий стиль на початок класу


        private void fastColoredTextBox1_TextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
        {
            e.ChangedRange.ClearStyle(
                prinsStyle, pringStyle, stopStyle, clearStyle,
                importStyle, stringStyle, commentStyle,
                numberStyle, bracketStyle
            );

            e.ChangedRange.SetStyle(prinsStyle, @"\bpring|:Program\b");
            e.ChangedRange.SetStyle(pringStyle, @"\b\b");//no one
            e.ChangedRange.SetStyle(stopStyle, @"\bStop|local|if|else|while\b");
            e.ChangedRange.SetStyle(clearStyle, @"\bClear\b");
            e.ChangedRange.SetStyle(importStyle, @"\bimport|:OnClick|onkey|:Remove|:CreateNewForm|:CreateButton|:CreateLabel\b");
            e.ChangedRange.SetStyle(stringStyle, "\".*?\"");
            e.ChangedRange.SetStyle(commentStyle, @"//.*$", RegexOptions.Multiline);

            // Нове
            e.ChangedRange.SetStyle(numberStyle, @"\b\d+(\.\d+)?\b");
            e.ChangedRange.SetStyle(bracketStyle, @"\[|\]");
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            string text = label2.Text;

            // Шукаємо останні позиції кожного символу
            int lastError = text.LastIndexOf("❌");
            int lastStop = text.LastIndexOf("🛑");
            int lastStart = text.LastIndexOf("✔");

            // Знаходимо який символ був останнім
            if (lastError > lastStop && lastError > lastStart)
                label2.ForeColor = Color.Red;
            else if (lastStop > lastError && lastStop > lastStart)
                label2.ForeColor = Color.Yellow;
            else if (lastStart >= 0) // Якщо є хоча б один ✔
                label2.ForeColor = Color.White;
            else
                label2.ForeColor = Color.White;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        private void fastColoredTextBox1_Load(object sender, EventArgs e)
        {
            Task.Delay(1000);
            AdvancedTextBox.Text = "pring \"Hello frog!\"";
        }

        private void Lunch_Click(object sender, EventArgs e)
        {
            string code = AdvancedTextBox.Text;

            // Перед запуском переконуємося що шлях встановлений
            if (!string.IsNullOrEmpty(currentProjectPath))
            {
                interp.SetProjectPath(currentProjectPath);
            }

            interp.Run(code);
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MouseDown += Form1_MouseDown;
            this.MouseMove += Form1_MouseMove;
            this.MouseUp += Form1_MouseUp;

        }


        private void minimize_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }



        private void Stop_Click(object sender, EventArgs e)
        {
            interp.StopProgram();
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            interp.ClearConsole(); // 👈 теж метод
            label2.Text = interp.Output;
        }

        private void CopyConsole_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(label2.Text);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Створюємо папку Projects біля exe, якщо не існує
            string projectsFolder = Path.Combine(Application.StartupPath, "Projects");
            Directory.CreateDirectory(projectsFolder);

            // Діалог для введення назви проєкту
            string projectName = "";
            using (var inputDialog = new Form())
            {
                inputDialog.Text = "Create Project";
                inputDialog.Size = new Size(400, 150);
                inputDialog.StartPosition = FormStartPosition.CenterParent;
                inputDialog.BackColor = Color.FromArgb(30, 30, 30);
                inputDialog.ForeColor = Color.White;

                Label lblPrompt = new Label()
                {
                    Text = "Enter project name:",
                    Location = new Point(20, 20),
                    Size = new Size(350, 20),
                    ForeColor = Color.White
                };

                TextBox txtProjectName = new TextBox()
                {
                    Location = new Point(20, 50),
                    Size = new Size(340, 25),
                    Text = "MyProject"
                };

                Button btnOk = new Button()
                {
                    Text = "Create",
                    DialogResult = DialogResult.OK,
                    Location = new Point(200, 80),
                    Size = new Size(80, 30),
                    BackColor = Color.FromArgb(0, 122, 204),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat
                };

                Button btnCancel = new Button()
                {
                    Text = "Cancel",
                    DialogResult = DialogResult.Cancel,
                    Location = new Point(290, 80),
                    Size = new Size(80, 30),
                    BackColor = Color.FromArgb(60, 60, 60),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat
                };

                inputDialog.Controls.Add(lblPrompt);
                inputDialog.Controls.Add(txtProjectName);
                inputDialog.Controls.Add(btnOk);
                inputDialog.Controls.Add(btnCancel);
                inputDialog.AcceptButton = btnOk;
                inputDialog.CancelButton = btnCancel;

                if (inputDialog.ShowDialog() == DialogResult.OK)
                {
                    projectName = txtProjectName.Text.Trim();
                }
                else
                {
                    return; // Користувач скасував
                }
            }

            // Перевірка назви проєкту
            if (string.IsNullOrWhiteSpace(projectName))
            {
                MessageBox.Show("❌ Project name cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Видалити заборонені символи з назви папки
            foreach (char c in Path.GetInvalidFileNameChars())
            {
                projectName = projectName.Replace(c, '_');
            }

            // Створити папку проєкту
            string projectFolder = Path.Combine(projectsFolder, projectName);

            if (Directory.Exists(projectFolder))
            {
                var result = MessageBox.Show(
                    $"Project '{projectName}' already exists!\nOverwrite?",
                    "Warning",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.No)
                    return;
            }
            else
            {
                Directory.CreateDirectory(projectFolder);
            }

            // Зберегти файл .zab+ у папку проєкту
            string filePath = Path.Combine(projectFolder, projectName + ".zab+");
            File.WriteAllText(filePath, AdvancedTextBox.Text);

            // Встановити шлях проєкту в інтерпретатор
            currentProjectPath = projectFolder;
            interp.SetProjectPath(projectFolder);

            MessageBox.Show(
                $"✔ Project '{projectName}' saved!\n\nLocation: {projectFolder}",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            // Реєстрація розширення + іконки (один раз)
            RegisterZabFileType();
        }

        private void RegisterZabFileType()
        {
            try
            {
                string ext = ".zab+";
                string progId = "ZabPlusFile";
                string exePath = Application.ExecutablePath;

                // Зберігаємо іконку з ресурсів у файл (біля exe)
                string iconPath = Path.Combine(Application.StartupPath, "zab_icon.ico");
                if (!File.Exists(iconPath))
                {
                    using (var fs = new FileStream(iconPath, FileMode.Create))
                    {
                        Properties.Resources.lol1.Save(fs);
                    }
                }

                // Прив’язка розширення
                Microsoft.Win32.Registry.SetValue(@"HKEY_CLASSES_ROOT\" + ext, "", progId);

                // Опис файлу
                Microsoft.Win32.Registry.SetValue(@"HKEY_CLASSES_ROOT\" + progId, "", "Zaba+ Project File");

                // Іконка
                Microsoft.Win32.Registry.SetValue(@"HKEY_CLASSES_ROOT\" + progId + @"\DefaultIcon", "", iconPath);

                // Команда відкриття
                Microsoft.Win32.Registry.SetValue(@"HKEY_CLASSES_ROOT\" + progId + @"\shell\open\command", "",
                    "\"" + exePath + "\" \"%1\"");
            }
            catch (Exception ex)
            {
                MessageBox.Show("⚠ Не вдалося зареєструвати іконку!\n" + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string projectsFolder = Path.Combine(Application.StartupPath, "Projects");
            Directory.CreateDirectory(projectsFolder);

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.InitialDirectory = projectsFolder;
                ofd.Filter = "Zaba+ Project (*.zab+)|*.zab+";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string code = File.ReadAllText(ofd.FileName);
                    AdvancedTextBox.Text = code;

                    // Встановити шлях проєкту (папка, де знаходиться .zab+ файл)
                    string projectFolder = Path.GetDirectoryName(ofd.FileName);
                    currentProjectPath = projectFolder;  // ДОДАЙТЕ ЦЕ
                    interp.SetProjectPath(projectFolder);

                    MessageBox.Show(
                        $"📂 Project loaded!\n\nFrom: {projectFolder}",
                        "Load",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void Erase_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "You really want to erase code?",
                "Trash can",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information
            );

            if (result == DialogResult.Yes)
            {
                AdvancedTextBox.Text = "";
            }

        }
        private void GoToFindIndex(int index)
        {
            if (index < 0 || index >= foundRanges.Count)
                return;

            var r = foundRanges[index];
            AdvancedTextBox.Selection = r;
            AdvancedTextBox.DoSelectionVisible();
        }
        private void UpdateFindCounter()
        {
            if (foundRanges.Count == 0)
            {
                labelFindCount.Text = "0/0 results";
                labelFindCount.ForeColor = Color.Red;
                return;
            }

            labelFindCount.Text = $"{currentFindIndex + 1}/{foundRanges.Count} results";
            labelFindCount.ForeColor = Color.White;
        }

        private void Find_Click(object sender, EventArgs e)
        {
            string word = textBoxFind.Text.Trim();

            // Очистити старі результати
            AdvancedTextBox.Range.ClearStyle(findStyle);
            foundRanges.Clear();
            currentFindIndex = -1;

            if (string.IsNullOrWhiteSpace(word))
            {
                labelFindCount.Text = "0/0 results";
                labelFindCount.ForeColor = Color.Red;
                return;
            }

            // Знайти всі входження
            foreach (var r in AdvancedTextBox.Range.GetRanges(word, RegexOptions.IgnoreCase))
            {
                foundRanges.Add(r);
                r.SetStyle(findStyle);
            }

            if (foundRanges.Count == 0)
            {
                labelFindCount.Text = "0/0 results";
                labelFindCount.ForeColor = Color.Red;
                return;
            }

            // Є результати
            labelFindCount.Text = foundRanges.Count + " results";
            labelFindCount.ForeColor = Color.White;
            currentFindIndex = 0;
            GoToFindIndex(0);
            UpdateFindCounter();

        }

        private void FindDown_Click(object sender, EventArgs e)
        {
            if (foundRanges.Count == 0) return;

            if (currentFindIndex < foundRanges.Count - 1)
            {
                currentFindIndex++;
                GoToFindIndex(currentFindIndex);
            }

            UpdateFindCounter();
        }


        private void SearchIcon_Click(object sender, EventArgs e)
        {
            bool show = !textBoxFind.Visible;

            // показати/сховати всі елементи пошуку
            textBoxFind.Visible = show;
            labelFindCount.Visible = show;
            panelFindNavigation.Visible = show;
            Find.Visible = show; // ← КНОПКА FIND, ТЕПЕР ПОКАЗУЄТЬСЯ

            if (show)
            {
                textBoxFind.Focus();   // коли відкрили
            }
            else
            {
                // коли закрили — очистити результати
                AdvancedTextBox.Range.ClearStyle(findStyle);
                foundRanges.Clear();
                currentFindIndex = -1;
                labelFindCount.Text = "Search";
            }
        }
        private void FindUp_Click(object sender, EventArgs e)
        {
            if (foundRanges.Count == 0) return;

            if (currentFindIndex > 0)
            {
                currentFindIndex--;
                GoToFindIndex(currentFindIndex);
            }

            UpdateFindCounter();
        }


    }
}
