
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zaba_
{
    public class Token
    {
        public string Kind;
        public string Text;
        public int Line;    // ДОДАЙ ЦЕ
        public int Column;  // ДОДАЙ ЦЕ

        public Token(string k, string t, int line = 1, int col = 1)
        {
            Kind = k;
            Text = t;
            Line = line;
            Column = col;
        }
    }

    public class Lexer
    {
        string _code;
        int pos = 0;
        int line = 1;      // ДОДАЙ ЦЕ
        int column = 1;    // ДОДАЙ ЦЕ

        public Lexer(string code) { _code = code; }

        char Current => pos < _code.Length ? _code[pos] : '\0';

        void Next()
        {
            if (Current == '\n') { line++; column = 1; }
            else { column++; }
            pos++;
        }

        public List<Token> Tokenize()
        {
            var res = new List<Token>();
            while (true)
            {
                if (Current == '\0') { res.Add(new Token("EOF", "", line, column)); break; }
                else if (char.IsWhiteSpace(Current)) Next();
                else if (char.IsLetter(Current))
                {
                    var start = pos;
                    var startLine = line;
                    var startCol = column;

                    while (char.IsLetterOrDigit(Current)) Next();
                    var text = _code.Substring(start, pos - start);

                    // ключові слова

                    switch (text)
                    {
                        case "let":
                            res.Add(new Token("LET", text) { Line = line, Column = column });
                            break;
                        case "pring":
                            res.Add(new Token("PRING", text) { Line = line, Column = column });
                            break;
                        case "if":
                            res.Add(new Token("IF", text) { Line = line, Column = column });
                            break;
                        case "tick":
                            res.Add(new Token("TICK", text) { Line = line, Column = column });
                            break;
                        case "local":
                            res.Add(new Token("LOCAL", text) { Line = line, Column = column });
                            break;
                        case "else":
                            res.Add(new Token("ELSE", text) { Line = line, Column = column });
                            break;
                        case "part":
                            res.Add(new Token("PART", text) { Line = line, Column = column });
                            break;
                        case "import":
                            res.Add(new Token("IMPORT", text) { Line = line, Column = column });
                            break;
                        case "while":
                            res.Add(new Token("WHILE", text) { Line = line, Column = column });
                            break;
                        case "waiting":
                            res.Add(new Token("WAITING", text) { Line = line, Column = column });
                            break;
                        case "stop":
                            res.Add(new Token("STOP", text) { Line = line, Column = column });
                            break;
                        case "onkey":
                            res.Add(new Token("ONKEY", text) { Line = line, Column = column });
                            break;
                        case "clear":
                            res.Add(new Token("CLEAR", text) { Line = line, Column = column });
                            break;
                        // ДОДАЙТЕ ЦІ ДВА ВИПАДКИ:
                        case "true":
                            res.Add(new Token("TRUE", text) { Line = line, Column = column });
                            break;
                        case "false":
                            res.Add(new Token("FALSE", text) { Line = line, Column = column });
                            break;
                        default:
                            res.Add(new Token("ID", text) { Line = line, Column = column });
                            break;
                    }
                }
                else if (Current == '"')
                {
                    var startLine = line;
                    var startCol = column;

                    Next(); // пропускаємо "
                    var start = pos;
                    while (Current != '"' && Current != '\0') Next();
                    var text = _code.Substring(start, pos - start);
                    if (Current == '"') Next(); // закриваюча "
                    res.Add(new Token("STRING", text, startLine, startCol));
                }
                else if (char.IsDigit(Current))
                {
                    var startLine = line;
                    var startCol = column;
                    var start = pos;

                    while (char.IsDigit(Current)) Next();
                    var text = _code.Substring(start, pos - start);
                    res.Add(new Token("NUM", text, startLine, startCol));
                }
                else
                {
                    var startLine = line;
                    var startCol = column;

                    // багатосимвольні оператори
                    if (Current == '=' && pos + 1 < _code.Length && _code[pos + 1] == '=')
                    {
                        pos += 2;
                        column += 2;
                        res.Add(new Token("==", "==", startLine, startCol));
                    }
                    else if (Current == '!' && pos + 1 < _code.Length && _code[pos + 1] == '=')
                    {
                        pos += 2;
                        column += 2;
                        res.Add(new Token("!=", "!=", startLine, startCol));
                    }
                    else if (Current == '<' && pos + 1 < _code.Length && _code[pos + 1] == '=')
                    {
                        pos += 2;
                        column += 2;
                        res.Add(new Token("<=", "<=", startLine, startCol));
                    }
                    else if (Current == '>' && pos + 1 < _code.Length && _code[pos + 1] == '=')
                    {
                        pos += 2;
                        column += 2;
                        res.Add(new Token(">=", ">=", startLine, startCol));
                    }
                    else if (Current == '/' && pos + 1 < _code.Length && _code[pos + 1] == '/')
                    {
                        // Пропускаємо коментар до кінця рядка
                        while (Current != '\n' && Current != '\0') Next();
                    }
                    else
                    {
                        var ch = Current.ToString();
                        Next();
                        res.Add(new Token(ch, ch, startLine, startCol));
                    }
                }
            }
            return res;
        }
    }

}