using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zaba_
{
    public abstract class Stmt { }
    public abstract class Expr { }

    public class ProgramNode
    {
        public List<Stmt> Stmts = new List<Stmt>();
    }
    public class AssignStmt : Stmt
    {
        public string Name;
        public Expr Value;
        public AssignStmt(string name, Expr value) { Name = name; Value = value; }
    }
    public class CreateLabelStmt : Stmt
    {
        public string VarName;
        public string Text;
        public CreateLabelStmt(string var, string text) { VarName = var; Text = text; }
    }
    public class LocalStmt : Stmt
    {
        public string Name;
        public Expr Value;
        public LocalStmt(string name, Expr value) { Name = name; Value = value; }
    }
    public class RemoveStmt : Stmt
    {
        public string ObjectName;
        public RemoveStmt(string obj) { ObjectName = obj; }
    }

    public class MethodCallExpr : Expr
    {
        public string Object;
        public string Method;
        public string Argument;
        public MethodCallExpr(string obj, string method, string arg)
        {
            Object = obj;
            Method = method;
            Argument = arg;
        }
    }
    public class OnClickStmt : Stmt
    {
        public string ObjectName;
        public List<Stmt> Body = new List<Stmt>();
        public OnClickStmt(string objName) { ObjectName = objName; }
    }
    public class OnKeyStmt : Stmt
    {
        public string Key;  // Наприклад "W", "A", "S", "D", "Space"
        public List<Stmt> Body = new List<Stmt>();
        public OnKeyStmt(string key) { Key = key; }
    }

    public class LetStmt : Stmt
    {
        public string Name;
        public Expr Value;
    }
    public class PrinsStmt : Stmt
    {
        public Expr Value;
        public PrinsStmt(Expr value) { Value = value; }
    }

    public class PrintStmt : Stmt
    {
        public Expr E;

    }
    public class PropertyAssignStmt : Stmt
    {
        public string ObjectName;
        public string PropertyName;
        public Expr Value;
        public PropertyAssignStmt(string objName, string propName, Expr value)
        {
            ObjectName = objName;
            PropertyName = propName;
            Value = value;
        }
    }
    public class PringStmt : Stmt
    {
        public Expr Value;
        public PringStmt(Expr value) { Value = value; }

    }
    public class StringExpr : Expr
    {
        public string Value;
        public StringExpr(string value) { Value = value; }
    }


    public class ExprStmt : Stmt
    {
        public Expr E;
    }

    public class IfStmt : Stmt
    {
        public Expr Cond;
        public List<Stmt> Then = new List<Stmt>();
        public List<Stmt>? Else;
    }

    public class NumberExpr : Expr
    {
        public int Value;
        public NumberExpr(int v) { Value = v; }
    }

    public class VarExpr : Expr
    {
        public string Name;
        public VarExpr(string n) { Name = n; }
    }

    public class BinaryExpr : Expr
    {
        public Expr L, R;
        public string Op;
        public BinaryExpr(Expr l, string op, Expr r) { L = l; Op = op; R = r; }
    }
    public class ImportStmt : Stmt
    {
        public string Module;
        public ImportStmt(string module) { Module = module; }
    }

    public class CreateFormStmt : Stmt
    {
        public string VarName;
        public string Title;
        public CreateFormStmt(string var, string title) { VarName = var; Title = title; }
    }

    public class CreateButtonStmt : Stmt
    {
        public string VarName;
        public string Text;
        public CreateButtonStmt(string var, string text) { VarName = var; Text = text; }
    }
    public class WhileStmt : Stmt
    {
        public Expr Cond;
        public List<Stmt> Body = new List<Stmt>();
    }

    public class WaitingStmt : Stmt
    {
        public int Seconds;
        public WaitingStmt(int s) { Seconds = s; }
    }
    public class TickStmt : Stmt
    {
        public int Interval; // мс
        public List<Stmt> Body = new List<Stmt>();
        public TickStmt(int interval) { Interval = interval; }
    }
    public class StopStmt : Stmt { }
    public class ClearStmt : Stmt { }

    // НОВІ КЛАСИ ДЛЯ ФІГУР
    public class CreatePartStmt : Stmt
    {
        public string VarName;
        public string Shape;      // "circle", "rectangle", "triangle"
        public string Color;      // "red", "blue", "#FF0000"
        public int Width;
        public int Height;
        public CreatePartStmt(string var, string shape, string color, int width, int height)
        {
            VarName = var;
            Shape = shape;
            Color = color;
            Width = width;
            Height = height;
        }
    }
    // ТЕКСТУРИ
    public class LoadTextureStmt : Stmt
    {
        public string VarName;
        public string FileName;
        public LoadTextureStmt(string varName, string fileName)
        {
            VarName = varName;
            FileName = fileName;
        }
    }

    public class SetTextureStmt : Stmt
    {
        public string ShapeName;
        public string TextureName;
        public SetTextureStmt(string shapeName, string textureName)
        {
            ShapeName = shapeName;
            TextureName = textureName;
        }
    }

    public class RemoveTextureStmt : Stmt
    {
        public string ShapeName;
        public RemoveTextureStmt(string shapeName)
        {
            ShapeName = shapeName;
        }
    }

    // ЗВУКИ
    public class LoadSoundStmt : Stmt
    {
        public string VarName;
        public string FileName;
        public LoadSoundStmt(string varName, string fileName)
        {
            VarName = varName;
            FileName = fileName;
        }
    }

    public class PlaySoundStmt : Stmt
    {
        public string SoundName;
        public PlaySoundStmt(string soundName)
        {
            SoundName = soundName;
        }
    }

    public class BoolExpr : Expr
    {
        public bool Value;
        public BoolExpr(bool v) { Value = v; }
    }
    public class StopSoundStmt : Stmt
    {
        public string SoundName;
        public StopSoundStmt(string soundName)
        {
            SoundName = soundName;
        }
    }

}