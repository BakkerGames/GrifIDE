using static GrifIDE.Common;
using static GrifIDE.Options;
using static GrifIDE.Routines;
using static GrifLib.Common;

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
            Sorted = true,
            IntegralHeight = false
        };
        editListBox.SelectedIndexChanged += EditListBox_SelectedIndexChanged;
        panelMain.Controls.Add(editListBox);
    }

    private void EditListBox_SelectedIndexChanged(object? sender, EventArgs e)
    {
        SetEditListBoxSelectedIndex(editListBox.SelectedIndex);
    }

    private void SetEditListBoxSelectedIndex(int index)
    {
        if (index < 0 && editListBox.SelectedIndex < 0)
        {
            return;
        }
        if (index < 0 || index >= editListBox.Items.Count)
        {
            CurrentKey = null;
            editListBox.SelectedIndex = -1;
            editRichTextBox.Clear();
            return;
        }
        if (treeView.SelectedNode != null && (treeView.SelectedNode.Tag?.ToString() ?? "") != CurrentKey)
        {
            treeView.SelectedNode = null;
        }
        var newKey = GetEditListBoxSelectedKey() ?? "";
        if (newKey.Equals(CurrentKey, OIC))
        {
            return;
        }
        CurrentKey = null;
        editRichTextBox.Clear();
        editListBox.SelectedIndex = index;
        var editListBoxText = editListBox.Items[editListBox.SelectedIndex];
        if (editListBoxText == null || editListBoxText.ToString() == null)
        {
            CurrentKey = null;
            editRichTextBox.Clear();
            return;
        }
        CurrentKey = newKey;
        var item = EditItems.Where(x => x.Key.Equals(CurrentKey, OIC)).FirstOrDefault();
        editRichTextBox.Clear();
        editRichTextBox.Text = FormatTextForEdit(item?.Value);
        editRichTextBox.Focus();
    }

    private string? GetEditListBoxSelectedKey()
    {
        if (editListBox.SelectedIndex < 0 || editListBox.SelectedIndex >= editListBox.Items.Count)
        {
            return null;
        }
        var editListBoxText = (string?)editListBox.Items[editListBox.SelectedIndex];
        if (editListBoxText == null)
        {
            return null;
        }
        return editListBoxText[..editListBoxText.LastIndexOf(" [")].Trim();
    }

    private void PopulateEditList(List<EditItem> EditItems)
    {
        editListBox.SuspendLayout();
        editListBox.Items.Clear();
        foreach (var item in EditItems)
        {
            editListBox.Items.Add($"{item.Key} [{item.Action}]");
        }
        editListBox.ResumeLayout();
    }
}
