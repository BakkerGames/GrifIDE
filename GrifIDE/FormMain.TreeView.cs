using Grif;

namespace GrifIDE;

public partial class FormMain
{
    private void InitTreeView()
    {
        treeView = new TreeView
        {
            Dock = DockStyle.Left,
            Width = 300,
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
            currentKey = treeView.SelectedNode.Name;
            var tempText = grodEdit.Get(currentKey, true) ?? "";
            if (!grodEdit.ContainsKey(currentKey, false))
            {
                tempText = Dags.PrettyScript(tempText);
            }
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
                TreeNode parentNode = FindOrCreateNode(treeView.Nodes, "@", "@");
                parentNode.Nodes.Add(new TreeNode { Name = key, Text = key });
            }
            else if (key.Contains('.'))
            {
                var parts = key.Split('.');
                TreeNode parentNode = FindOrCreateNode(treeView.Nodes, parts[0], parts[0]);
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
                TreeNode parentNode = FindOrCreateNode(treeView.Nodes, "...", "...");
                parentNode.Nodes.Add(new TreeNode { Name = key, Text = key });
            }
        }
        treeView.ResumeLayout();
    }

    private static TreeNode FindOrCreateNode(TreeNodeCollection nodes, string name, string text)
    {
        foreach (TreeNode node in nodes)
        {
            if (node.Name == name)
            {
                return node;
            }
        }
        var newNode = new TreeNode { Name = name, Text = text };
        nodes.Add(newNode);
        return newNode;
    }
}
