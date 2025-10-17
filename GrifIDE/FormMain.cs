using Grif;
using static Grif.Grif;
using static GrifIDE.Common;
using static GrifIDE.ConfigRoutines;
using static GrifIDE.Routines;

namespace GrifIDE;

public partial class FormMain : Form
{
    private Panel panelMain = new();
    private TreeView treeView = new();
    private ListBox editListBox = new();
    private TextBox editTextBox = new();

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
        if (File.Exists(Filename))
        {
            GrodBase = new Grod(Path.GetFileNameWithoutExtension(Filename));
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
        }
        PopulateTreeView(GrodBase);
        PopulateEditList(GrodEdit);
    }
}
