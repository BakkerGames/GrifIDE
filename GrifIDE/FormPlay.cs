namespace GrifIDE;

public partial class FormPlay : Form
{
    private string playText = string.Empty;

    public FormPlay()
    {
        InitializeComponent();
    }

    public Font PlayFont
    {
        get => textBoxMain.Font;
        set => textBoxMain.Font = value;

    }

    public Color PlayBackColor
    {
        get => textBoxMain.BackColor;
        set => textBoxMain.BackColor = value;

    }

    public Color PlayForeColor
    {
        get => textBoxMain.ForeColor;
        set => textBoxMain.ForeColor = value;

    }

    private void FormPlay_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == '\b')
        {
            if (playText.Length > 0)
            {
                playText = playText[..^1];
                textBoxMain.Text = textBoxMain.Text[..^1];
                textBoxMain.SelectionStart = textBoxMain.Text.Length;
            }
            return;
        }
        if (e.KeyChar == '\r' || e.KeyChar == '\n')
        {
            if (playText.Length > 0)
            {
               
                textBoxMain.AppendText(Environment.NewLine);
            }
            return;
        }
        if (char.IsControl(e.KeyChar))
        {
            return;
        }
        if (ModifierKeys.HasFlag(Keys.Control))
        {
            return;
        }
        if (ModifierKeys.HasFlag(Keys.Alt))
        {
            return;
        }
        playText += e.KeyChar;
        textBoxMain.AppendText(e.KeyChar.ToString());
    }
}
