using Grif;
using static GrifIDE.Common;
using static GrifIDE.Options;
using static GrifIDE.Routines;

namespace GrifIDE;

public partial class FormMain
{
    private void InitTreeView()
    {
        treeView = new TreeView
        {
            Dock = DockStyle.Left,
            Width = TreePanelWidth,
            Font = new Font(TreeFontFamily, TreeFontSize),
            BackColor = Color.FromName(TreeColorBackground),
            ForeColor = Color.FromName(TreeColorForeground),
        };
        panelMain.Controls.Add(treeView);
        treeView.AfterSelect += TreeView_AfterSelect;
    }

    private void TreeView_AfterSelect(object? sender, EventArgs e)
    {
        CurrentKey = null;
        SetEditListBoxSelectedIndex(-1);
        editRichTextBox.Clear();
        if (treeView.SelectedNode != null && !string.IsNullOrEmpty(treeView.SelectedNode.Name))
        {
            CurrentKey = treeView.SelectedNode.Name;
            var tempItem = EditItems.Where(x => x.Key == CurrentKey).FirstOrDefault();
            if (tempItem != null)
            {
                EditLoading = true;
                editRichTextBox.Text = FormatTextForEdit(tempItem.Value);
                EditLoading = false;
            }
            else
            {
                var grodValue = BaseGrod.Get(CurrentKey, true);
                if (grodValue != null)
                {
                    EditLoading = true;
                    editRichTextBox.Text = FormatTextForEdit(grodValue);
                    EditLoading = false;
                }
            }
        }
    }

    private void PopulateTreeView(Grod GrodBase)
    {
        treeView.SuspendLayout();
        treeView.Nodes.Clear();
        var singleKeys = new List<string>();
        var keys = GrodBase.Keys(true, true);
        foreach (var key in keys)
        {
            if (key.StartsWith('@'))
            {
                TreeNode parentNode = FindOrCreateNode(treeView.Nodes, "@", "@");
                parentNode.Nodes.Add(new TreeNode { Name = key, Text = key, Tag = key });
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
                            Text = parts[index],
                            Tag = key
                        };
                        parentNode.Nodes.Add(childNode);
                    }
                    parentNode = childNode;
                    index++;
                }
            }
            else
            {
                singleKeys.Add(key);
            }
        }
        if (singleKeys.Count > 0)
        {
            TreeNode parentNode = FindOrCreateNode(treeView.Nodes, "...", "...");
            foreach (var key in singleKeys)
            {
                parentNode.Nodes.Add(new TreeNode { Name = key, Text = key, Tag = key });
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
