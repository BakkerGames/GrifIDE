using static Grif.Dags;
using static Grif.IO;
using static GrifIDE.Common;
using static GrifIDE.ConfigRoutines;
using static GrifIDE.Routines;

namespace GrifIDE;

public partial class FormMain : Form
{
    private Panel panelMain = new();
    private TreeView treeView = new();
    private ListBox editListBox = new();
    private RichTextBox editRichTextBox = new();

    public FormMain()
    {
        InitializeComponent();
    }

    private void FormMain_Load(object sender, EventArgs e)
    {
        LoadConfig();
        // Add in reverse order for proper placement
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
                FilenameEdit = GetEditFilename();
                SaveConfig();
                var content = ReadGrif(Filename);
                GrodBase.Clear(true);
                GrodBase.AddItems(content);
                GrodEdit.Parent = GrodBase;
                GrodEdit.Clear(false);
                if (File.Exists(FilenameEdit))
                {
                    var editContent = ReadGrif(FilenameEdit);
                    GrodEdit.AddItems(editContent);
                }
                PopulateTreeView(GrodBase);
                PopulateEditList(GrodEdit);
                editListBox.SuspendLayout();
                foreach (var item in content)
                {
                    if (item != null && item.Value != null && item.Value.StartsWith('@'))
                    {
                        if (!ValidateScript(item.Value))
                        {
                            if (!editListBox.Items.Contains(item.Key))
                            {
                                editListBox.Items.Add(item.Key);
                                GrodEdit.Set(item.Key, item.Value);
                            }
                        }
                    }
                    this.Text = $"GrifIDE - {Path.GetFileName(Filename)}";
                    editListBox.ResumeLayout();
                }
            }
        }
        catch (Exception)
        {
            MessageBox.Show($"Error opening file: {filename}", "Error", MessageBoxButtons.OK);
        }
    }
}
