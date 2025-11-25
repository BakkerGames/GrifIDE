using static GrifIDE.Common;

namespace GrifIDE;

public partial class FormPlay : Form
{
    public FormPlay()
    {
        InitializeComponent();
        Initialize();
    }

    public void Initialize()
    {
        textBoxInput.Font = new Font(DEFAULT_FONT_FAMILY, DEFAULT_TEXT_FONT_SIZE);
        textBoxInput.ForeColor = Color.FromName(DEFAULT_COLOR_FOREGROUND);
        textBoxInput.BackColor = Color.FromName(DEFAULT_COLOR_BACKGROUND);
        textBoxInput.Clear();
        richTextBoxOutput.Font = new Font(DEFAULT_FONT_FAMILY, DEFAULT_TEXT_FONT_SIZE);
        richTextBoxOutput.ForeColor = Color.FromName(DEFAULT_COLOR_FOREGROUND);
        richTextBoxOutput.BackColor = Color.FromName(DEFAULT_COLOR_BACKGROUND);
        richTextBoxOutput.Clear();
    }

    private void textBoxInput_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)Keys.Enter)
        {
            e.Handled = true; // Prevent the beep sound on Enter key press
            richTextBoxOutput.AppendText(textBoxInput.Text);
            richTextBoxOutput.AppendText(Environment.NewLine);
            richTextBoxOutput.ScrollToCaret();
            textBoxInput.Clear();
        }
    }
}
