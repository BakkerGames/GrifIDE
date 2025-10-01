namespace GrifIDE
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TreeNode treeNode6 = new TreeNode("@at");
            TreeNode treeNode7 = new TreeNode("@go(x)");
            TreeNode treeNode8 = new TreeNode("@", new TreeNode[] { treeNode6, treeNode7 });
            TreeNode treeNode9 = new TreeNode("item");
            TreeNode treeNode10 = new TreeNode("room");
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            treeView1 = new TreeView();
            listBox1 = new ListBox();
            pictureBox1 = new PictureBox();
            exitToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "&File";
            // 
            // treeView1
            // 
            treeView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            treeView1.BackColor = Color.AliceBlue;
            treeView1.Font = new Font("Consolas", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            treeView1.ForeColor = SystemColors.ControlText;
            treeView1.Location = new Point(0, 27);
            treeView1.Name = "treeView1";
            treeNode6.Name = "Node3";
            treeNode6.Text = "@at";
            treeNode7.Name = "Node4";
            treeNode7.Text = "@go(x)";
            treeNode8.Name = "Node0";
            treeNode8.Text = "@";
            treeNode9.Name = "Node1";
            treeNode9.Text = "item";
            treeNode10.Name = "Node2";
            treeNode10.Text = "room";
            treeView1.Nodes.AddRange(new TreeNode[] { treeNode8, treeNode9, treeNode10 });
            treeView1.Size = new Size(184, 423);
            treeView1.TabIndex = 1;
            // 
            // listBox1
            // 
            listBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            listBox1.BackColor = Color.AliceBlue;
            listBox1.Font = new Font("Consolas", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            listBox1.ForeColor = SystemColors.ControlText;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 14;
            listBox1.Location = new Point(190, 27);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(172, 424);
            listBox1.TabIndex = 2;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.BackColor = Color.AliceBlue;
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            pictureBox1.Location = new Point(368, 27);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(432, 423);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(180, 22);
            exitToolStripMenuItem.Text = "E&xit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBox1);
            Controls.Add(listBox1);
            Controls.Add(treeView1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GRIF IDE";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private TreeView treeView1;
        private ListBox listBox1;
        private PictureBox pictureBox1;
        private ToolStripMenuItem exitToolStripMenuItem;
    }
}
