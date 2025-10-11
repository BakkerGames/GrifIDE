namespace GrifIDE;

public partial class FormMain
{
    private TreeView treeView = new();

    private void InitTreeView()
    {
        treeView = new TreeView
        {
            Dock = DockStyle.Left,
            Width = 200,
            Font = new Font("Consolas", 12),
            BackColor = Color.Black,
            ForeColor = Color.Lime,
        };
        panelMain.Controls.Add(treeView);
        PopulateTreeView();
    }

    private void PopulateTreeView()
    {
        treeView.SuspendLayout();
        treeView.Nodes.Clear();
        var rootNode = new TreeNode("Root");
        rootNode.Nodes.Add(new TreeNode("Child 1"));
        rootNode.Nodes.Add(new TreeNode("Child 2"));
        treeView.Nodes.Add(rootNode);
        treeView.CollapseAll();
        treeView.ResumeLayout();
    }
}
