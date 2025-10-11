
namespace GrifIDE;

public partial class FormMain
{
    private  ListBox editListBox = new();

    private void InitEditList()
    {
        editListBox = new ListBox
        {
            Dock = DockStyle.Left,
            Width = 200,
            Font = new Font("Consolas", 12),
            BackColor = Color.Black,
            ForeColor = Color.Lime,
        };
        panelMain.Controls.Add(editListBox);
        PopulateEditList();
    }

    private void PopulateEditList()
    {
        editListBox.SuspendLayout();
        editListBox.Items.Clear();
        editListBox.Items.Add("Edit Item 1");
        editListBox.Items.Add("Edit Item 2");
        editListBox.Items.Add("Edit Item 3");
        editListBox.ResumeLayout();
    }
}
