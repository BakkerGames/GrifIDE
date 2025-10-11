using Grif;

namespace GrifIDE;

public partial class FormMain
{
    private ListBox editListBox = new();

    private void InitEditList()
    {
        editListBox = new ListBox
        {
            Dock = DockStyle.Left,
            Width = 200,
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
            var selectedKey = editListBox.Items[editListBox.SelectedIndex].ToString();
            if (selectedKey != null)
            {
                editLoading = true;
                editTextBox.Clear();
                var tempText = grodEdit.Get(selectedKey, true) ?? "";
                tempText = Dags.PrettyScript(tempText);
                editTextBox.Text = tempText;
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
