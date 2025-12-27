using System.Text.Json;
using static GrifIDE.Common;
using static GrifIDE.ConfigRoutines;
using static GrifIDE.Routines;
using static GrifLib.Common;
using static GrifLib.Dags;
using static GrifLib.IO;

namespace GrifIDE;

public partial class FormMain : Form
{
    private Panel panelMain = new();
    private TreeView treeView = new();
    private ListBox editListBox = new();
    private RichTextBox editRichTextBox = new();
    private StatusStrip stripMain = new();

    public FormMain()
    {
        InitializeComponent();
    }

    private void FormMain_Load(object sender, EventArgs e)
    {
        LoadConfig();
        // Add in reverse order for proper placement
        Controls.Add(stripMain);
        panelMain = new Panel
        {
            Dock = DockStyle.Fill
        };
        Controls.Add(panelMain);
        InitEditText();
        InitEditList();
        InitTreeView();
        InitMenu();
        OpenFile(Filename);
    }

    private void OpenFile(string? filename)
    {
        try
        {
            if (string.IsNullOrEmpty(filename))
            {
                return;
            }
            treeView.Nodes.Clear();
            editListBox.Items.Clear();
            editRichTextBox.Clear();
            if (File.Exists(filename))
            {
                Filename = filename;
                FilenameEdit = GetEditFilename(filename);
                SaveConfig();
                var content = ReadGrif(Filename);
                BaseGrod.Clear(true);
                BaseGrod.AddItems(content);
                EditItems.Clear();
                if (File.Exists(FilenameEdit))
                {
                    EditItems = JsonSerializer.Deserialize<List<EditItem>>(File.ReadAllText(FilenameEdit)) ?? [];
                }
                SetDirtyFlag(false);
                PopulateTreeView(BaseGrod);
                PopulateEditList(EditItems);
                editListBox.SuspendLayout();
                foreach (var item in content)
                {
                    if (item != null && item.Value != null && item.Value.StartsWith('@'))
                    {
                        if (!ValidateScript(item.Value))
                        {
                            if (!EditItems.Any(x => x.Key.Equals(item.Key, OIC)))
                            {
                                editListBox.Items.Add($"{item.Key} [C]");
                                EditItems.Add(new EditItem
                                {
                                    Action = "C",
                                    Key = item.Key,
                                    Value = item.Value,
                                });
                                DirtyFlag = true;
                            }
                        }
                    }
                }
                editListBox.ResumeLayout();
                this.Text = $"{IDE_APP_TITLE} - {Path.GetFileName(Filename)}";
            }
        }
        catch (Exception)
        {
            MessageBox.Show($"Error opening file: {filename}", "Error", MessageBoxButtons.OK);
        }
    }

    private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (e.CloseReason == CloseReason.UserClosing && DirtyFlag)
        {
            var result = MessageBox.Show("Do you want to save your edits before exiting?", "Save Edits", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                SaveEditItems();
                SetDirtyFlag(false);
            }
            else if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }
    }

    private void SetDirtyFlag(bool flag)
    {
        DirtyFlag = flag;
        var changed = DirtyFlag ? "*" : "";
        this.Text = $"{IDE_APP_TITLE} - {Path.GetFileName(Filename)}{changed}";

    }
}
