using FastColoredTextBoxNS;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zaba_
{
    public class Parser
    {
        List<Token> tokens;
        int pos = 0;
        Token Current => pos < tokens.Count ? tokens[pos] : new Token("EOF", "");

        void Next() => pos++;
        bool Match(string kind) { if (Current.Kind == kind) { Next(); return true; } return false; }
        void Expect(string kind) { if (!Match(kind)) throw new Exception($"Expected {kind}, got {Current.Kind} at line {Current.Line}:{Current.Column}"); }

        public Parser(List<Token> tokens) { this.tokens = tokens; }

        public ProgramNode ParseProgram()
        {
            var prog = new ProgramNode();
            while (Current.Kind != "EOF") prog.Stmts.Add(ParseStmt());
            return prog;
        }

        Stmt ParseStmt()
        {
            // ДОДАНО: Парсинг part
            if (Current.Kind == "PART")
            {
                Next(); // пропускаємо "part"
                var varName = Current.Text;
                Expect("ID");
                Expect("=");

                // Очікуємо формат: shape("форма", "колір", ширина, висота)
                if (Current.Text != "shape")
                    throw new Exception("Expected 'shape' after part assignment");
                Expect("ID");
                Expect("(");

                var shape = Current.Text;
                Expect("STRING");
                Expect(",");

                var color = Current.Text;
                Expect("STRING");
                Expect(",");

                var width = int.Parse(Current.Text);
                Expect("NUM");
                Expect(",");

                var height = int.Parse(Current.Text);
                Expect("NUM");
                Expect(")");

                return new CreatePartStmt(varName, shape, color, width, height);
            }

            if (Current.Kind == "ONKEY")
            {
                Next(); // пропускаємо "onkey"
                Expect("(");

                var key = Current.Text;
                if (Current.Kind == "STRING")
                    Expect("STRING");
                else if (Current.Kind == "ID")
                    Expect("ID");
                else
                    throw new Exception("Expected key name after onkey(");

                Expect(")");
                Expect("[");

                var body = new List<Stmt>();
                while (!Match("]"))
                    body.Add(ParseStmt());

                return new OnKeyStmt(key) { Body = body };
            }
            if (Current.Kind == "ID")
            {
                var objName = Current.Text;
                var nextPos = pos + 1;

                // OnClick
                if (nextPos < tokens.Count && tokens[nextPos].Kind == ":" &&
                    nextPos + 1 < tokens.Count && tokens[nextPos + 1].Kind == "ID" &&
                    tokens[nextPos + 1].Text == "OnClick")
                {
                    Next(); Expect(":"); Expect("ID"); Expect("[");
                    var body = new List<Stmt>();
                    while (!Match("]"))
                        body.Add(ParseStmt());
                    return new OnClickStmt(objName) { Body = body };
                }
                // SetTexture
                if (nextPos < tokens.Count && tokens[nextPos].Kind == ":" &&
                    nextPos + 1 < tokens.Count && tokens[nextPos + 1].Kind == "ID" &&
                    tokens[nextPos + 1].Text == "SetTexture")
                {
                    Next(); Expect(":"); Expect("ID"); Expect("(");
                    var textureName = Current.Text;
                    Expect("ID");
                    Expect(")");
                    return new SetTextureStmt(objName, textureName);
                }

                // RemoveTexture
                if (nextPos < tokens.Count && tokens[nextPos].Kind == ":" &&
                    nextPos + 1 < tokens.Count && tokens[nextPos + 1].Kind == "ID" &&
                    tokens[nextPos + 1].Text == "RemoveTexture")
                {
                    Next(); Expect(":"); Expect("ID");
                    return new RemoveTextureStmt(objName);
                }

                // StartPlay (звуки)
                if (nextPos < tokens.Count && tokens[nextPos].Kind == ":" &&
                    nextPos + 1 < tokens.Count && tokens[nextPos + 1].Kind == "ID" &&
                    tokens[nextPos + 1].Text == "StartPlay")
                {
                    Next(); Expect(":"); Expect("ID"); Expect("("); Expect(")");
                    return new PlaySoundStmt(objName);
                }

                // StopPlay (звуки)
                if (nextPos < tokens.Count && tokens[nextPos].Kind == ":" &&
                    nextPos + 1 < tokens.Count && tokens[nextPos + 1].Kind == "ID" &&
                    tokens[nextPos + 1].Text == "StopPlay")
                {
                    Next(); Expect(":"); Expect("ID"); Expect("("); Expect(")");
                    return new StopSoundStmt(objName);
                }
                // Remove
                if (nextPos < tokens.Count && tokens[nextPos].Kind == ":" &&
                    nextPos + 1 < tokens.Count && tokens[nextPos + 1].Kind == "ID" &&
                    tokens[nextPos + 1].Text == "Remove")
                {
                    Next(); Expect(":"); Expect("ID");
                    return new RemoveStmt(objName);
                }

                // Перевіряємо ObjectName.PropertyName = Value
                if (nextPos < tokens.Count && tokens[nextPos].Kind == "." &&
                    nextPos + 1 < tokens.Count && tokens[nextPos + 1].Kind == "ID")
                {
                    Next(); // пропускаємо ObjectName
                    Expect("."); // пропускаємо "."
                    var propertyName = Current.Text;
                    Expect("ID"); // пропускаємо PropertyName
                    Expect("=");
                    var value = ParseExpr();
                    return new PropertyAssignStmt(objName, propertyName, value);
                }
                // Assignment to variable: name = expr
                if (nextPos < tokens.Count && tokens[nextPos].Kind == "=")
                {
                    Next();            // споживаємо ID
                    Expect("=");       // споживаємо '='
                    var value = ParseExpr();
                    return new AssignStmt(objName, value);
                }

            }


            if (Current.Kind == "LOCAL")
            {
                Next(); // пропускаємо "local"
                var name = Current.Text;
                Expect("ID");
                Expect("=");
                var value = ParseExpr();
                return new LocalStmt(name, value);
            }
            if (Current.Kind == "LET")
            {
                Next();
                var name = Current.Text; Expect("ID");
                Expect("=");
                var value = ParseExpr();
                return new LetStmt { Name = name, Value = value };
            }
            if (Current.Kind == "IMPORT")
            {
                Next();
                var module = Current.Text;
                Expect("ID");
                return new ImportStmt(module);
            }

            else if (Current.Kind == "ID" && Current.Text == "window" || Current.Text == "Window")
            {
                Next();
                Expect(":");
                if (Current.Text == "CreateNewForm")
                {
                    Next();
                    Expect("(");
                    var title = Current.Text;
                    Expect("STRING");
                    Expect(")");
                    return new CreateFormStmt("form", title);
                }
                else if (Current.Text == "CreateButton")
                {
                    Next();
                    Expect("(");
                    var text = Current.Text;
                    Expect("STRING");
                    Expect(")");
                    return new CreateButtonStmt("button", text);
                }
                else if (Current.Text == "CreateLabel")
                {
                    Next();
                    Expect("(");
                    var text = Current.Text;
                    Expect("STRING");
                    Expect(")");
                    return new CreateLabelStmt("label", text);
                }
            }

            else if (Current.Kind == "STOP")
            {
                Next();
                if (Match(":") && Current.Text == "Program")
                    Next();
                return new StopStmt();
            }
            else if (Current.Kind == "WAITING")
            {
                Next();
                Expect("(");
                if (Current.Kind != "NUM")
                    throw new Exception("waiting() потребує число");
                int sec = int.Parse(Current.Text);
                Expect("NUM");
                Expect(")");
                return new WaitingStmt(sec);
            }



            else if (Current.Kind == "CLEAR")
            {
                Next();
                if (Match(":") && Current.Text == "Console")
                    Next();
                return new StopStmt();
            }


            else if (Current.Kind == "WHILE")
            {
                Next();
                var cond = ParseExpr();
                Expect("[");
                var body = new List<Stmt>();
                while (!Match("]"))
                    body.Add(ParseStmt());
                return new WhileStmt { Cond = cond, Body = body };
            }
            else if (Current.Kind == "TICK")
            {
                Next(); // пропускаємо "tick"
                Expect("(");
                if (Current.Kind != "NUM")
                    throw new Exception("tick() needs value in MS");
                int interval = int.Parse(Current.Text);
                Expect("NUM");
                Expect(")");
                Expect("[");
                var body = new List<Stmt>();
                while (!Match("]"))
                    body.Add(ParseStmt());
                return new TickStmt(interval) { Body = body };
            }
            else if (Current.Kind == "PRING")
            {
                Next();
                if (Current.Kind == "EOF" || Current.Kind == "RCURLY" || Current.Kind == "ELSE")
                    throw new Exception("❌ Expected expression after 'pring'");
                var expr = ParseExpr();
                return new PringStmt(expr);
            }

            else if (Current.Kind == "IF")
            {
                Next();
                var cond = ParseExpr();

                var then = new List<Stmt>();
                Expect("[");
                while (!Match("]"))
                    then.Add(ParseStmt());

                List<Stmt>? els = null;
                if (Current.Kind == "ELSE")
                {
                    Next();
                    els = new List<Stmt>();
                    Expect("[");
                    while (!Match("]"))
                        els.Add(ParseStmt());
                }

                return new IfStmt { Cond = cond, Then = then, Else = els };
            }

            else
            {
                var expr = ParseExpr();
                return new ExprStmt { E = expr };
            }

            return new ExprStmt { E = ParseExpr() };


        }

        Expr ParseExpr(int prec = 0)
        {
            Expr left = ParsePrimary();
            while (true)
            {
                int opPrec = GetPrecedence(Current.Kind);
                if (opPrec < prec) break;

                var op = Current.Kind;
                Next();
                Expr right = ParseExpr(opPrec + 1);
                left = new BinaryExpr(left, op, right);
            }
            return left;
        }

        int GetPrecedence(string kind) => kind switch
        {
            "*" or "/" => 20,
            "+" or "-" => 10,
            ">" or "<" or "==" or "!=" => 5,
            _ => -1
        };


        Expr ParsePrimary()
        {
            if (Match("NUM"))
                return new NumberExpr(int.Parse(tokens[pos - 1].Text));

            if (Match("ID"))
            {
                var name = tokens[pos - 1].Text;

                // Перевіряємо чи це виклик методу типу texturemodule.Texture()
                if (Current.Kind == ".")
                {
                    Next(); // пропускаємо "."
                    var methodName = Current.Text;
                    Expect("ID");

                    if (Current.Kind == "(")
                    {
                        Expect("(");
                        var arg = Current.Text;
                        Expect("STRING");
                        Expect(")");

                        // Повертаємо як спеціальний вираз
                        return new MethodCallExpr(name, methodName, arg);
                    }
                }

                // Перевіряємо чи це виклик методу типу window:CreateNewForm()
                if (Current.Kind == ":")
                {
                    Next(); // пропускаємо ":"
                    var methodName = Current.Text;
                    Expect("ID");

                    if (methodName == "CreateNewForm" || methodName == "CreateButton" || methodName == "CreateLabel")
                    {
                        Expect("(");
                        var arg = Current.Text;
                        Expect("STRING");
                        Expect(")");

                        // Повертаємо як спеціальний вираз
                        return new MethodCallExpr(name, methodName, arg);
                    }
                }

                return new VarExpr(name);
            }

            // 🔥 додали підтримку @ ... @
            if (Match("@"))
            {
                var expr = ParseExpr();   // рекурсивно парсимо внутрішній вираз
                if (!Match("@"))
                    throw new Exception("❌ Was waiting for @ to close the group");
                return expr;
            }
            if (Match("TRUE"))
                return new BoolExpr(true);

            if (Match("FALSE"))
                return new BoolExpr(false);
            if (Match("STRING"))
                return new StringExpr(tokens[pos - 1].Text);

            throw new Exception($"Invalid expr at line {Current.Line}:{Current.Column} - '{Current.Text}'");
        }

    }
}