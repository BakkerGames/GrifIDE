namespace GrifIDE;

public partial class FormMain : Form
{
    private MenuStrip? menuStripMain;

    public FormMain()
    {
        InitializeComponent();
    }

    private void FormMain_Load(object sender, EventArgs e)
    {
        InitMenu();
    }
}
