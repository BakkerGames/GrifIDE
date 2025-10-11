namespace GrifIDE;

public partial class FormMain : Form
{
    private readonly Panel panelMain = new();

    public FormMain()
    {
        InitializeComponent();
    }

    private void FormMain_Load(object sender, EventArgs e)
    {
        panelMain.Dock = DockStyle.Fill;
        Controls.Add(panelMain);
        InitEditText();
        InitEditList();
        InitTreeView();
        InitMenu();
    }
}
