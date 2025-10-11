using System.Runtime.InteropServices;

namespace GrifIDE;

public partial class FormMain
{
    private TextBox editTextBox = new();

    private void InitEditText()
    {
        editTextBox = new TextBox
        {
            Multiline = true,
            Dock = DockStyle.Fill,
            ScrollBars = ScrollBars.Both,
            Font = new Font("Consolas", 16),
            AcceptsTab = true,
            WordWrap = false,
            BackColor = Color.Black,
            ForeColor = Color.Lime,
        };
        SetTabWidth(editTextBox, 4);
        panelMain.Controls.Add(editTextBox);
    }

    #region Set Tab Width P/Invoke
    [DllImport("User32.dll", CharSet = CharSet.Auto)]
    private static extern IntPtr SendMessage(IntPtr h, int msg, int wParam, int[] lParam);

    public static void SetTabWidth(TextBox textbox, int tabWidth)
    {
        const int EM_SETTABSTOPS = 0x00CB;
        SendMessage(textbox.Handle, EM_SETTABSTOPS, 1, [tabWidth * 4]);
    }
    #endregion
}
