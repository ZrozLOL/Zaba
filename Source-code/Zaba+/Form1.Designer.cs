namespace Zaba_
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.AdvancedTextBox = new FastColoredTextBoxNS.FastColoredTextBox();
            this.Lunch = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Label();
            this.minimize = new System.Windows.Forms.Label();
            this.Stop = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            this.CopyConsole = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Erase = new System.Windows.Forms.Button();
            this.textBoxFind = new System.Windows.Forms.TextBox();
            this.SearchIcon = new System.Windows.Forms.Button();
            this.Find = new System.Windows.Forms.Button();
            this.panelFindNavigation = new System.Windows.Forms.Panel();
            this.FindUp = new System.Windows.Forms.Button();
            this.FindDown = new System.Windows.Forms.Button();
            this.labelFindCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.AdvancedTextBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelFindNavigation.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Courier New", 12F);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(0, 510);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Console";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // AdvancedTextBox
            // 
            this.AdvancedTextBox.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.AdvancedTextBox.AutoScrollMinSize = new System.Drawing.Size(187, 14);
            this.AdvancedTextBox.BackBrush = null;
            this.AdvancedTextBox.BackColor = System.Drawing.Color.Black;
            this.AdvancedTextBox.CharHeight = 14;
            this.AdvancedTextBox.CharWidth = 8;
            this.AdvancedTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.AdvancedTextBox.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.AdvancedTextBox.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.AdvancedTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.AdvancedTextBox.IndentBackColor = System.Drawing.Color.DimGray;
            this.AdvancedTextBox.IsReplaceMode = false;
            this.AdvancedTextBox.LineNumberColor = System.Drawing.Color.White;
            this.AdvancedTextBox.Location = new System.Drawing.Point(3, 77);
            this.AdvancedTextBox.Name = "AdvancedTextBox";
            this.AdvancedTextBox.Paddings = new System.Windows.Forms.Padding(0);
            this.AdvancedTextBox.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.AdvancedTextBox.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("AdvancedTextBox.ServiceColors")));
            this.AdvancedTextBox.Size = new System.Drawing.Size(1215, 427);
            this.AdvancedTextBox.TabIndex = 2;
            this.AdvancedTextBox.Text = "pring \"Hello world!\"";
            this.AdvancedTextBox.Zoom = 100;
            this.AdvancedTextBox.Load += new System.EventHandler(this.fastColoredTextBox1_Load);
            // 
            // Lunch
            // 
            this.Lunch.BackColor = System.Drawing.Color.Black;
            this.Lunch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Lunch.ForeColor = System.Drawing.Color.Green;
            this.Lunch.Location = new System.Drawing.Point(3, 44);
            this.Lunch.Name = "Lunch";
            this.Lunch.Size = new System.Drawing.Size(29, 27);
            this.Lunch.TabIndex = 3;
            this.Lunch.Text = "▶";
            this.Lunch.UseVisualStyleBackColor = false;
            this.Lunch.Click += new System.EventHandler(this.Lunch_Click);
            // 
            // close
            // 
            this.close.AutoSize = true;
            this.close.BackColor = System.Drawing.Color.Transparent;
            this.close.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.close.ForeColor = System.Drawing.Color.White;
            this.close.Location = new System.Drawing.Point(1199, 10);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(19, 22);
            this.close.TabIndex = 4;
            this.close.Text = "x";
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // minimize
            // 
            this.minimize.AutoSize = true;
            this.minimize.BackColor = System.Drawing.Color.Transparent;
            this.minimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.minimize.ForeColor = System.Drawing.Color.White;
            this.minimize.Location = new System.Drawing.Point(1173, 10);
            this.minimize.Name = "minimize";
            this.minimize.Size = new System.Drawing.Size(20, 22);
            this.minimize.TabIndex = 5;
            this.minimize.Text = "_";
            this.minimize.Click += new System.EventHandler(this.minimize_Click_1);
            // 
            // Stop
            // 
            this.Stop.BackColor = System.Drawing.Color.Black;
            this.Stop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Stop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Stop.Location = new System.Drawing.Point(38, 44);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(29, 27);
            this.Stop.TabIndex = 7;
            this.Stop.Text = "🛑";
            this.Stop.UseVisualStyleBackColor = false;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // Clear
            // 
            this.Clear.BackColor = System.Drawing.Color.Black;
            this.Clear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Clear.Location = new System.Drawing.Point(1115, 504);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(45, 30);
            this.Clear.TabIndex = 8;
            this.Clear.Text = "🧹";
            this.Clear.UseVisualStyleBackColor = false;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // CopyConsole
            // 
            this.CopyConsole.BackColor = System.Drawing.Color.Black;
            this.CopyConsole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.CopyConsole.Location = new System.Drawing.Point(1166, 504);
            this.CopyConsole.Name = "CopyConsole";
            this.CopyConsole.Size = new System.Drawing.Size(47, 30);
            this.CopyConsole.TabIndex = 9;
            this.CopyConsole.Text = "Copy";
            this.CopyConsole.UseVisualStyleBackColor = false;
            this.CopyConsole.Click += new System.EventHandler(this.CopyConsole_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(35, 7);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1135, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Courier New", 9F);
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.saveToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.loadToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = global::Zaba_.Properties.Resources.lol;
            this.pictureBox1.ImageLocation = "Zaba_.Properties.Resources.lol";
            this.pictureBox1.InitialImage = global::Zaba_.Properties.Resources.lol;
            this.pictureBox1.Location = new System.Drawing.Point(3, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(29, 24);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Font = new System.Drawing.Font("Courier New", 9F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1210, 1150);
            this.label2.TabIndex = 11;
            this.label2.Text = ">";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(3, 531);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1228, 79);
            this.panel1.TabIndex = 12;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // Erase
            // 
            this.Erase.BackColor = System.Drawing.Color.Black;
            this.Erase.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Erase.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Erase.Location = new System.Drawing.Point(73, 44);
            this.Erase.Name = "Erase";
            this.Erase.Size = new System.Drawing.Size(29, 27);
            this.Erase.TabIndex = 13;
            this.Erase.Text = "🗑";
            this.Erase.UseVisualStyleBackColor = false;
            this.Erase.Click += new System.EventHandler(this.Erase_Click);
            // 
            // textBoxFind
            // 
            this.textBoxFind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBoxFind.ForeColor = System.Drawing.SystemColors.Info;
            this.textBoxFind.Location = new System.Drawing.Point(143, 49);
            this.textBoxFind.Name = "textBoxFind";
            this.textBoxFind.Size = new System.Drawing.Size(138, 20);
            this.textBoxFind.TabIndex = 15;
            this.textBoxFind.Visible = false;
            // 
            // SearchIcon
            // 
            this.SearchIcon.BackColor = System.Drawing.Color.Black;
            this.SearchIcon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SearchIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.SearchIcon.Location = new System.Drawing.Point(108, 44);
            this.SearchIcon.Name = "SearchIcon";
            this.SearchIcon.Size = new System.Drawing.Size(29, 27);
            this.SearchIcon.TabIndex = 16;
            this.SearchIcon.Text = "🔎";
            this.SearchIcon.UseVisualStyleBackColor = false;
            this.SearchIcon.Click += new System.EventHandler(this.SearchIcon_Click);
            // 
            // Find
            // 
            this.Find.BackColor = System.Drawing.Color.Black;
            this.Find.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Find.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Find.Location = new System.Drawing.Point(332, 44);
            this.Find.Name = "Find";
            this.Find.Size = new System.Drawing.Size(29, 27);
            this.Find.TabIndex = 17;
            this.Find.Text = "🔎";
            this.Find.UseVisualStyleBackColor = false;
            this.Find.Visible = false;
            this.Find.Click += new System.EventHandler(this.Find_Click);
            // 
            // panelFindNavigation
            // 
            this.panelFindNavigation.Controls.Add(this.FindDown);
            this.panelFindNavigation.Controls.Add(this.FindUp);
            this.panelFindNavigation.Location = new System.Drawing.Point(287, 44);
            this.panelFindNavigation.Name = "panelFindNavigation";
            this.panelFindNavigation.Size = new System.Drawing.Size(39, 27);
            this.panelFindNavigation.TabIndex = 18;
            this.panelFindNavigation.Visible = false;
            // 
            // FindUp
            // 
            this.FindUp.BackColor = System.Drawing.Color.Black;
            this.FindUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FindUp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FindUp.Location = new System.Drawing.Point(3, 0);
            this.FindUp.Name = "FindUp";
            this.FindUp.Size = new System.Drawing.Size(20, 27);
            this.FindUp.TabIndex = 19;
            this.FindUp.Text = "↑";
            this.FindUp.UseVisualStyleBackColor = false;
            this.FindUp.Click += new System.EventHandler(this.FindUp_Click);
            // 
            // FindDown
            // 
            this.FindDown.BackColor = System.Drawing.Color.Black;
            this.FindDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FindDown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FindDown.Location = new System.Drawing.Point(21, 0);
            this.FindDown.Name = "FindDown";
            this.FindDown.Size = new System.Drawing.Size(18, 27);
            this.FindDown.TabIndex = 20;
            this.FindDown.Text = "↓";
            this.FindDown.UseVisualStyleBackColor = false;
            this.FindDown.Click += new System.EventHandler(this.FindDown_Click);
            // 
            // labelFindCount
            // 
            this.labelFindCount.AutoSize = true;
            this.labelFindCount.Font = new System.Drawing.Font("Courier New", 12F);
            this.labelFindCount.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelFindCount.Location = new System.Drawing.Point(165, 31);
            this.labelFindCount.Name = "labelFindCount";
            this.labelFindCount.Size = new System.Drawing.Size(68, 18);
            this.labelFindCount.TabIndex = 19;
            this.labelFindCount.Text = "Search";
            this.labelFindCount.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(1230, 614);
            this.Controls.Add(this.labelFindCount);
            this.Controls.Add(this.panelFindNavigation);
            this.Controls.Add(this.Find);
            this.Controls.Add(this.SearchIcon);
            this.Controls.Add(this.textBoxFind);
            this.Controls.Add(this.Erase);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.CopyConsole);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.Stop);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.minimize);
            this.Controls.Add(this.close);
            this.Controls.Add(this.Lunch);
            this.Controls.Add(this.AdvancedTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Zaba+";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AdvancedTextBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panelFindNavigation.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private FastColoredTextBoxNS.FastColoredTextBox AdvancedTextBox;
        private System.Windows.Forms.Button Lunch;
        private System.Windows.Forms.Label close;
        private System.Windows.Forms.Label minimize;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Stop;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.Button CopyConsole;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Erase;
        private System.Windows.Forms.TextBox textBoxFind;
        private System.Windows.Forms.Button SearchIcon;
        private System.Windows.Forms.Button Find;
        private System.Windows.Forms.Panel panelFindNavigation;
        private System.Windows.Forms.Button FindDown;
        private System.Windows.Forms.Button FindUp;
        private System.Windows.Forms.Label labelFindCount;
    }
}

