namespace GrifIDE
{
    partial class InputBox
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
            label1 = new Label();
            textBoxInput = new TextBox();
            buttonOK = new Button();
            buttonCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(50, 15);
            label1.TabIndex = 0;
            label1.Text = "Prompt:";
            // 
            // textBoxInput
            // 
            textBoxInput.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxInput.Location = new Point(12, 27);
            textBoxInput.Name = "textBoxInput";
            textBoxInput.Size = new Size(480, 23);
            textBoxInput.TabIndex = 1;
            // 
            // buttonOK
            // 
            buttonOK.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonOK.Location = new Point(336, 56);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(75, 23);
            buttonOK.TabIndex = 2;
            buttonOK.Text = "OK";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += ButtonOK_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonCancel.Location = new Point(417, 56);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 3;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += ButtonCancel_Click;
            // 
            // InputBox
            // 
            AcceptButton = buttonOK;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(504, 93);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOK);
            Controls.Add(textBoxInput);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "InputBox";
            StartPosition = FormStartPosition.CenterParent;
            Text = "InputBox";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBoxInput;
        private Button buttonOK;
        private Button buttonCancel;
    }
}