using System.Runtime.InteropServices;

namespace GrifIDE;

public partial class FormMain
{
    private void InitEditText()
    {
        editTextBox = new TextBox
        {
            Multiline = true,
            Dock = DockStyle.Fill,
            ScrollBars = ScrollBars.Both,
            Font = new Font("Consolas", 16),
            AcceptsTab = true,
            WordWrap = true,
            BackColor = Color.Black,
            ForeColor = Color.Lime,
        };
        SetTabWidth(editTextBox, 4);
        editTextBox.TextChanged += EditTextBox_TextChanged;
        panelMain.Controls.Add(editTextBox);
    }

    private void EditTextBox_TextChanged(object? sender, EventArgs e)
    {
        if (editLoading) return;
        var selectedKey = treeView.SelectedNode.Name;
        foreach (var item in editListBox.Items)
        {
            if (item.ToString() == selectedKey)
            {
                grodEdit.Set(selectedKey, editTextBox.Text);
                return;
            }
        }
        editListBox.Items.Add(selectedKey);
        grodEdit.Set(selectedKey, editTextBox.Text);
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
