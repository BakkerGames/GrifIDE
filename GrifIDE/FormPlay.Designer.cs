namespace GrifIDE
{
    partial class FormPlay
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
            textBoxMain = new TextBox();
            SuspendLayout();
            // 
            // textBoxMain
            // 
            textBoxMain.BackColor = Color.Black;
            textBoxMain.Dock = DockStyle.Fill;
            textBoxMain.ForeColor = Color.White;
            textBoxMain.Location = new Point(0, 0);
            textBoxMain.Multiline = true;
            textBoxMain.Name = "textBoxMain";
            textBoxMain.ReadOnly = true;
            textBoxMain.ScrollBars = ScrollBars.Vertical;
            textBoxMain.Size = new Size(800, 450);
            textBoxMain.TabIndex = 0;
            // 
            // FormPlay
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBoxMain);
            KeyPreview = true;
            Name = "FormPlay";
            Text = "FormPlay";
            KeyPress += FormPlay_KeyPress;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxMain;
    }
}