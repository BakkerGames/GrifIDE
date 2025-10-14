using Grif;
using static Grif.Grif;

namespace GrifIDE;

public partial class FormMain : Form
{
    private Grod grod = new("base");
    private Grod grodEdit = new("edit");

    private Panel panelMain = new();
    private TreeView treeView = new();
    private ListBox editListBox = new();
    private TextBox editTextBox = new();

    private string filename = "";
    private string filenameEdit = "";
    private bool editLoading = false;
    private string? currentKey = null;

    public FormMain()
    {
        InitializeComponent();
    }

    private void FormMain_Load(object sender, EventArgs e)
    {
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
        filename = "C:\\Users\\Scott\\source\\repos\\Castlequest_GRIF\\Castlequest.grif";
        filenameEdit = filename + "edit"; // *.grifedit
        grod = new Grod(Path.GetFileNameWithoutExtension(filename));
        var content = ReadGrif(filename);
        grod.AddItems(content);
        PopulateTreeView(grod);
        grodEdit.Clear(false);
        if (File.Exists(filenameEdit))
        {
            grodEdit = new Grod(Path.GetFileNameWithoutExtension(filenameEdit) + ".edit");
            var editContent = ReadGrif(filenameEdit);
            grodEdit.AddItems(editContent);
        }
        grodEdit.Parent = grod;
        PopulateEditList(grodEdit);
    }
}
