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
        var tempItem = EditItems.Where(x => x.Key == CurrentKey).FirstOrDefault();
        var editListText = $"{CurrentKey} [C]";
        if (tempItem != null)
        {
            if (tempItem.Action == "D")
            {
                tempItem.Action = "C";
                editListBox.Items.Remove($"{CurrentKey} [D]");
                editListBox.Items.Add(editListText);
            }
            tempItem.Value = UnformatTextFromEdit(editRichTextBox.Text);
        }
        else
        {
            EditItems.Add(new EditItem
            {
                Action = "C",
                Key = CurrentKey,
                Value = UnformatTextFromEdit(editRichTextBox.Text),
            });
            editListBox.Items.Add(editListText);
        }
        editListBox.SelectedItem = editListText;
        DirtyFlag = true;
    }
}
