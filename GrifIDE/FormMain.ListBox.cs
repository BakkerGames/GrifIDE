using static GrifIDE.Common;
using static GrifIDE.Options;
using static GrifIDE.Routines;

namespace GrifIDE;

public partial class FormMain
{
    private void InitEditList()
    {
        editListBox = new ListBox
        {
            Dock = DockStyle.Left,
            Width = ListPanelWidth,
            Font = new Font(ListFontFamily, ListFontSize),
            BackColor = Color.FromName(ListColorBackground),
            ForeColor = Color.FromName(ListColorForeground),
            Sorted = true
        };
        editListBox.SelectedIndexChanged += EditListBox_SelectedIndexChanged;
        panelMain.Controls.Add(editListBox);
    }

    private void EditListBox_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (editListBox.SelectedIndex >= 0)
        {
            CurrentKey = editListBox.Items[editListBox.SelectedIndex]?.ToString();
            if (!string.IsNullOrEmpty(CurrentKey))
            {
                var tempText = EditItems.Where(x => x.Key == CurrentKey).FirstOrDefault()?.Value ?? "";
                EditLoading = true;
                editRichTextBox.Clear();
                editRichTextBox.Text = FormatTextForEdit(tempText);
                EditLoading = false;
            }
        }
    }

    private void PopulateEditList(List<EditItem> EditItems)
    {
        editListBox.SuspendLayout();
        editListBox.Items.Clear();
        foreach (var item in EditItems)
        {
            editListBox.Items.Add(item.Key);
        }
        editListBox.ResumeLayout();
    }
}
