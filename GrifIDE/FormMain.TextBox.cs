using static GrifIDE.Common;
using static GrifIDE.Options;
using static GrifIDE.Routines;

namespace GrifIDE;

public partial class FormMain
{
    private void InitEditText()
    {
        editRichTextBox = new RichTextBox
        {
            Dock = DockStyle.Fill,
            Font = new Font(TextFontFamily, TextFontSize),
            AcceptsTab = true,
            WordWrap = true,
            BackColor = Color.FromName(TextColorBackground),
            ForeColor = Color.FromName(TextColorForeground),
        };
        editRichTextBox.TextChanged += EditTextBox_TextChanged;
        panelMain.Controls.Add(editRichTextBox);
    }

    private void EditTextBox_TextChanged(object? sender, EventArgs e)
    {
        if (EditLoading) return;
        if (CurrentKey == null) return;
        foreach (var item in editListBox.Items)
        {
            if (item.ToString() == CurrentKey)
            {
                GrodEdit.Set(CurrentKey, UnformatTextFromEdit(editRichTextBox.Text));
                return;
            }
        }
        editListBox.Items.Add(CurrentKey);
        GrodEdit.Set(CurrentKey, UnformatTextFromEdit(editRichTextBox.Text));
    }
}
