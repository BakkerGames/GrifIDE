using System.ComponentModel;

namespace GrifIDE;

public partial class InputBox : Form
{
    public InputBox()
    {
        InitializeComponent();
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string Prompt
    {
        get => label1.Text;
        set => label1.Text = value;
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string InputText
    {
        get => textBoxInput.Text;
        set => textBoxInput.Text = value;
    }

    public static string? Show(string title, string prompt, string defaultInput = "")
    {
        using var inputBox = new InputBox
        {
            Text = title,
            Prompt = prompt,
            InputText = defaultInput
        };
        return inputBox.ShowDialog() == DialogResult.OK ? inputBox.InputText : null;
    }

    private void ButtonOK_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.OK;
        Close();
    }

    private void ButtonCancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }
}
