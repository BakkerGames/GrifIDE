using Grif;

namespace GrifIDE;

public partial class FormMain : Form
{
    private Grod grod = new("base");
    private Grod grodEdit = new("edit");

    private Panel panelMain = new();

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
        var filename = "C:\\Users\\Scott\\source\\repos\\Castlequest_GRIF\\Castlequest.grif";
        grod = new Grod(Path.GetFileName(filename));
        var content = Grif.Grif.ReadGrif(filename);
        grod.AddItems(content);
        PopulateTreeView(grod);
        grodEdit.Parent = grod;
        PopulateEditList(grodEdit);
    }
}
