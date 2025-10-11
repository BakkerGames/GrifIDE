using Grif;

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
        treeView.AfterSelect += TreeView_AfterSelect;
    }

    private void TreeView_AfterSelect(object? sender, EventArgs e)
    {
        editLoading = true;
        editListBox.ClearSelected();
        editTextBox.Clear();
        if (treeView.SelectedNode != null)
        {
            var selectedKey = treeView.SelectedNode.Name;
            var tempText = grodEdit.Get(selectedKey, true) ?? "";
            tempText = Dags.PrettyScript(tempText);
            editTextBox.Text = tempText;
        }
        editLoading = false;
    }

    private void PopulateTreeView(Grod grod)
    {
        treeView.SuspendLayout();
        treeView.Nodes.Clear();
        var keys = grod.Keys(true, true);
        foreach (var key in keys)
        {
            if (key.StartsWith('@'))
            {
                TreeNode? parentNode = FindNodeByName(treeView.Nodes, "@");
                if (parentNode == null)
                {
                    parentNode = new TreeNode { Name = "@", Text = "@" };
                    treeView.Nodes.Add(parentNode);
                }
                parentNode.Nodes.Add(new TreeNode { Name = key, Text = key });
            }
            else if (key.Contains('.'))
            {
                var parts = key.Split('.');
                TreeNode? parentNode = FindNodeByName(treeView.Nodes, parts[0]);
                if (parentNode == null)
                {
                    parentNode = new TreeNode { Name = parts[0], Text = parts[0] };
                    treeView.Nodes.Add(parentNode);
                }
                int index = 1;
                while (index < parts.Length)
                {
                    TreeNode? childNode = null;
                    foreach (TreeNode node in parentNode.Nodes)
                    {
                        if (node.Text.Equals(parts[index]))
                        {
                            childNode = node;
                            break;
                        }
                    }
                    if (childNode == null)
                    {
                        childNode = new TreeNode
                        {
                            Name = string.Join('.', parts[..(index + 1)]),
                            Text = parts[index]
                        };
                        parentNode.Nodes.Add(childNode);
                    }
                    parentNode = childNode;
                    index++;
                }
            }
            else
            {
                TreeNode? parentNode = FindNodeByName(treeView.Nodes, "...");
                if (parentNode == null)
                {
                    parentNode = new TreeNode { Name = "...", Text = "..." };
                    treeView.Nodes.Add(parentNode);
                }
                parentNode.Nodes.Add(new TreeNode { Name = key, Text = key });
            }
        }
        treeView.ResumeLayout();
    }

    private static TreeNode? FindNodeByName(TreeNodeCollection nodes, string name)
    {
        foreach (TreeNode node in nodes)
        {
            if (node.Name == name)
                return node;
            var found = FindNodeByName(node.Nodes, name);
            if (found != null)
                return found;
        }
        return null;
    }
}
