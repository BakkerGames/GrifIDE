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
            TreeNode treeNode1 = new TreeNode("@at");
            TreeNode treeNode2 = new TreeNode("@go(x)");
            TreeNode treeNode3 = new TreeNode("@", new TreeNode[] { treeNode1, treeNode2 });
            TreeNode treeNode4 = new TreeNode("item");
            TreeNode treeNode5 = new TreeNode("e");
            TreeNode treeNode6 = new TreeNode("n");
            TreeNode treeNode7 = new TreeNode("s");
            TreeNode treeNode8 = new TreeNode("w");
            TreeNode treeNode9 = new TreeNode("exit", new TreeNode[] { treeNode5, treeNode6, treeNode7, treeNode8 });
            TreeNode treeNode10 = new TreeNode("1", new TreeNode[] { treeNode9 });
            TreeNode treeNode11 = new TreeNode("room", new TreeNode[] { treeNode10 });
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            treeView1 = new TreeView();
            listBox1 = new ListBox();
            pictureBox1 = new PictureBox();
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
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(93, 22);
            exitToolStripMenuItem.Text = "E&xit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // treeView1
            // 
            treeView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            treeView1.BackColor = Color.FromArgb(30, 30, 30);
            treeView1.Font = new Font("Consolas", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            treeView1.ForeColor = Color.White;
            treeView1.Location = new Point(0, 27);
            treeView1.Name = "treeView1";
            treeNode1.Name = "Node3";
            treeNode1.Text = "@at";
            treeNode2.Name = "Node4";
            treeNode2.Text = "@go(x)";
            treeNode3.Name = "Node0";
            treeNode3.Text = "@";
            treeNode4.Name = "Node1";
            treeNode4.Text = "item";
            treeNode5.Name = "Node7";
            treeNode5.Text = "e";
            treeNode6.Name = "Node8";
            treeNode6.Text = "n";
            treeNode7.Name = "Node9";
            treeNode7.Text = "s";
            treeNode8.Name = "Node10";
            treeNode8.Text = "w";
            treeNode9.Name = "Node6";
            treeNode9.Text = "exit";
            treeNode10.Name = "Node5";
            treeNode10.Text = "1";
            treeNode11.Name = "Node2";
            treeNode11.Text = "room";
            treeView1.Nodes.AddRange(new TreeNode[] { treeNode3, treeNode4, treeNode11 });
            treeView1.Size = new Size(200, 423);
            treeView1.TabIndex = 1;
            // 
            // listBox1
            // 
            listBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            listBox1.BackColor = Color.FromArgb(30, 30, 30);
            listBox1.Font = new Font("Consolas", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            listBox1.ForeColor = Color.White;
            listBox1.FormattingEnabled = true;
            listBox1.IntegralHeight = false;
            listBox1.ItemHeight = 15;
            listBox1.Items.AddRange(new object[] { "@dark", "@go(x)", "item.1.longdesc", "room.1.exit.e" });
            listBox1.Location = new Point(200, 27);
            listBox1.Name = "listBox1";
            listBox1.ScrollAlwaysVisible = true;
            listBox1.Size = new Size(200, 424);
            listBox1.Sorted = true;
            listBox1.TabIndex = 2;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.BackColor = Color.FromArgb(30, 30, 30);
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            pictureBox1.Location = new Point(400, 27);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(400, 423);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
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
