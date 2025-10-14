using Grif;

namespace GrifIDE;

public partial class FormMain
{
    private void InitEditList()
    {
        editListBox = new ListBox
        {
            Dock = DockStyle.Left,
            Width = 300,
            Font = new Font("Consolas", 12),
            BackColor = Color.Black,
            ForeColor = Color.Lime,
            Sorted = true
        };
        editListBox.SelectedIndexChanged += EditListBox_SelectedIndexChanged;
        panelMain.Controls.Add(editListBox);
    }

    private void EditListBox_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (editListBox.SelectedIndex >= 0)
        {
            currentKey = editListBox.Items[editListBox.SelectedIndex].ToString();
            if (!string.IsNullOrEmpty(currentKey))
            {
                var tempText = grodEdit.Get(currentKey, true) ?? "";
                editLoading = true;
                editTextBox.Clear();
                editTextBox.Text = FormatTextForEdit(tempText);
                editLoading = false;
            }
        }
    }

    private void PopulateEditList(Grod grodEdit)
    {
        editListBox.SuspendLayout();
        editListBox.Items.Clear();
        var keys = grodEdit.Keys(false, true);
        foreach (var key in keys)
        {
            editListBox.Items.Add(key);
        }
        editListBox.ResumeLayout();
    }
}
