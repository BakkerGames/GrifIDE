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
            textBoxInput = new TextBox();
            richTextBoxOutput = new RichTextBox();
            SuspendLayout();
            // 
            // textBoxInput
            // 
            textBoxInput.AcceptsReturn = true;
            textBoxInput.BackColor = Color.Black;
            textBoxInput.Dock = DockStyle.Bottom;
            textBoxInput.Font = new Font("Consolas", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxInput.ForeColor = Color.White;
            textBoxInput.Location = new Point(0, 731);
            textBoxInput.Name = "textBoxInput";
            textBoxInput.Size = new Size(1184, 30);
            textBoxInput.TabIndex = 0;
            textBoxInput.KeyPress += TextBoxInput_KeyPress;
            // 
            // richTextBoxOutput
            // 
            richTextBoxOutput.BackColor = Color.Black;
            richTextBoxOutput.Dock = DockStyle.Fill;
            richTextBoxOutput.Font = new Font("Consolas", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            richTextBoxOutput.ForeColor = Color.White;
            richTextBoxOutput.Location = new Point(0, 0);
            richTextBoxOutput.Name = "richTextBoxOutput";
            richTextBoxOutput.ReadOnly = true;
            richTextBoxOutput.Size = new Size(1184, 731);
            richTextBoxOutput.TabIndex = 1;
            richTextBoxOutput.TabStop = false;
            richTextBoxOutput.Text = "";
            // 
            // FormPlay
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 761);
            Controls.Add(richTextBoxOutput);
            Controls.Add(textBoxInput);
            Name = "FormPlay";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FormPlay";
            Shown += FormPlay_Shown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxInput;
        private RichTextBox richTextBoxOutput;
    }
}