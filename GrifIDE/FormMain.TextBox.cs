using static GrifIDE.Options;
using static GrifIDE.Routines;

namespace GrifIDE;

public partial class FormMain
{
    private void InitEditText()
    {
        editTextBox = new TextBox
        {
            Multiline = true,
            Dock = DockStyle.Fill,
            ScrollBars = ScrollBars.Vertical,
            Font = new Font(TextFontFamily, TextFontSize),
            AcceptsTab = true,
            WordWrap = true,
            BackColor = Color.FromName(TextColorBackground),
            ForeColor = Color.FromName(TextColorForeground),
        };
        SetTabWidth(editTextBox, TabWidth);
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
                grodEdit.Set(selectedKey, UnformatTextFromEdit(editTextBox.Text));
                return;
            }
        }
        editListBox.Items.Add(selectedKey);
        grodEdit.Set(selectedKey, UnformatTextFromEdit(editTextBox.Text));
    }
}
