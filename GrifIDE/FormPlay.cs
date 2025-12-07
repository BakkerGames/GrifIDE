using System.Text;
using Grif;
using static Grif.Common;
using static GrifIDE.Common;

namespace GrifIDE;

public partial class FormPlay : Form
{
    private Grod grodBase = new();
    private Grod grodOverlay = new();
    private int outputCount = 0;
    private long maxOutputWidth = 0;

    private readonly Queue<string> _inputQueue = new();

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

    public void SetGrodBase(Grod grod)
    {
        grodBase = grod;
        maxOutputWidth = grodBase.GetNumber(OUTPUT_WIDTH, true) ?? 0;
    }

    public void SetGrodOverlay(Grod grod)
    {
        grodOverlay = grod;
        grodOverlay.Parent = grodBase;
    }

    private void TextBoxInput_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)Keys.Enter)
        {
            e.Handled = true; // Prevent the beep sound on Enter key press
            _inputQueue.Enqueue(textBoxInput.Text);
            textBoxInput.Clear();
        }
    }

    private async void FormPlay_Shown(object sender, EventArgs e)
    {
        var game = new Game();
        game.Initialize(grodBase, "savegame.sav");
        game.InputEvent += Input;
        game.OutputEvent += Output;
        Application.DoEvents();
        await game.Intro();
        await game.GameLoop();
    }

    private void Input(object sender)
    {
        OutputText(((Game)sender).Prompt() ?? "");
        string? input;
        while (_inputQueue.Count == 0)
        {
            Application.DoEvents();
        }
        input = _inputQueue.Dequeue();
        OutputText(input + NL_CHAR);
        if (input != null)
        {
            var message = new GrifMessage(MessageType.Text, input);
            ((Game)sender).InputMessages.Enqueue(message);
            OutputText(((Game)sender).AfterPrompt() ?? "");
        }
    }

    private void Output(object sender, GrifMessage e)
    {
        OutputText(e.Value);
    }

    private void OutputText(string text)
    {
        if (text.Contains(SPACE_CHAR))
        {
            text = text.Replace(SPACE_CHAR, " ");
        }
        while (text.Contains(NL_CHAR))
        {
            var index = text.IndexOf(NL_CHAR);
            var before = text[..index];
            text = text[(index + 2)..];
            var lines = Wordwrap(before);
            foreach (var line in lines)
            {
                richTextBoxOutput.AppendText(line);
                richTextBoxOutput.AppendText(Environment.NewLine);
            }
            outputCount = 0;
        }
        if (!string.IsNullOrEmpty(text))
        {
            var lines = Wordwrap(text);
            for (int i = 0; i < lines.Count - 1; i++)
            {
                var line = lines[i];
                richTextBoxOutput.AppendText(line);
                richTextBoxOutput.AppendText(Environment.NewLine);
            }
            var lastLine = lines[^1];
            richTextBoxOutput.AppendText(lastLine);
        }
        richTextBoxOutput.ScrollToCaret();
    }

    private List<string> Wordwrap(string text)
    {
        if (maxOutputWidth <= 0 || string.IsNullOrEmpty(text))
        {
            return [text];
        }
        List<string> result = [];
        StringBuilder currentLine = new();
        var words = text.Split(' ');
        foreach (var word in words)
        {
            if (outputCount + word.Length + 1 > maxOutputWidth)
            {
                // output current line
                result.Add(currentLine.ToString());
                currentLine.Clear();
                outputCount = 0;
            }
            if (currentLine.Length > 0)
            {
                currentLine.Append(' ');
                outputCount++;
            }
            currentLine.Append(word);
            outputCount += word.Length;
        }
        if (currentLine.Length > 0)
        {
            result.Add(currentLine.ToString());
        }
        return result;
    }
}
