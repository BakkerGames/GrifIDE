using GrifLib;
using static GrifIDE.Common;
using static GrifLib.Common;
using static GrifLib.IO;

namespace GrifIDE;

public partial class FormPlay : Form
{
    private Grod grodBase = new();
    private Grod grodOverlay = new();
    private IFGame? game = null;
    private int outputCount = 0;
    private int maxOutputWidth = 0;
    private static string tabChars = "    ";
    private static bool uppercaseInput = false;
    private string inputBuffer = "";

    private readonly Queue<string> _inputQueue = new();

    public FormPlay()
    {
        InitializeComponent();
        Initialize();
    }

    public void Initialize()
    {
        richTextBoxOutput.Font = new Font(DEFAULT_FONT_FAMILY, DEFAULT_TEXT_FONT_SIZE);
        richTextBoxOutput.ForeColor = Color.FromName(DEFAULT_COLOR_FOREGROUND);
        richTextBoxOutput.BackColor = Color.FromName(DEFAULT_COLOR_BACKGROUND);
        richTextBoxOutput.Clear();
    }

    public void SetGrodBase(Grod grod)
    {
        grodBase = grod;
        maxOutputWidth = (int)(grodBase.GetNumber(OUTPUT_WIDTH, true) ?? 0);
        if ((grod.GetNumber(OUTPUT_TAB_LENGTH, true) ?? 0) > 0)
        {
            tabChars = new string(' ', (int)(grod.GetNumber(OUTPUT_TAB_LENGTH, true) ?? 4));
        }
        uppercaseInput = grod.GetBool(UPPERCASE, true) ?? false;
    }

    public void SetGrodOverlay(Grod grod)
    {
        grodOverlay = grod;
        grodOverlay.Parent = grodBase;
    }

    public void Clear()
    {
        if (game != null)
        {
            game.InputEvent -= Input;
            game.OutputEvent -= Output;
        }
        game = null;
        _inputQueue.Clear();
        richTextBoxOutput.Text = "";
    }

    private async void FormPlay_Shown(object sender, EventArgs e)
    {
        game = new IFGame();
        game.Initialize(grodBase, "savegame.sav");
        game.InputEvent += Input;
        game.OutputEvent += Output;
        Application.DoEvents();
        await game.Intro();
        await game.GameLoop();
    }

    private void Input(object sender)
    {
        OutputText(((IFGame)sender).Prompt() ?? "");
        string? input;
        while (_inputQueue.Count == 0)
        {
            Application.DoEvents();
            if (game?.GameOver ?? false)
            {
                return;
            }
        }
        input = _inputQueue.Dequeue();
        OutputText(input + NL_CHAR);
        if (input != null)
        {
            var message = new GrifMessage(MessageType.Text, input);
            ((IFGame)sender).InputMessages.Enqueue(message);
            OutputText(((IFGame)sender).AfterPrompt() ?? "");
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
        if (text.Contains('\r') || text.Contains('\n'))
        {
            text = text.Replace("\r", "").Replace("\n", NL_CHAR);
        }
        if (text.Contains(TAB_CHAR) || text.Contains('\t'))
        {
            text = text.Replace(TAB_CHAR, tabChars).Replace("\t", tabChars);
        }
        while (text.Contains(NL_CHAR))
        {
            var index = text.IndexOf(NL_CHAR);
            var before = text[..index];
            text = text[(index + 2)..];
            var lines = Wordwrap(before, outputCount, maxOutputWidth);
            foreach (var line in lines)
            {
                richTextBoxOutput.AppendText(line);
                richTextBoxOutput.AppendText(Environment.NewLine);
                outputCount = 0;
            }
        }
        if (!string.IsNullOrEmpty(text))
        {
            var lines = IO.Wordwrap(text, outputCount, maxOutputWidth);
            for (int i = 0; i < lines.Count - 1; i++)
            {
                var line = lines[i];
                richTextBoxOutput.AppendText(line);
                richTextBoxOutput.AppendText(Environment.NewLine);
                outputCount = 0;
            }
            if (lines.Count > 0)
            {
                var lastLine = lines[^1];
                richTextBoxOutput.AppendText(lastLine);
                outputCount = lastLine.Length;
            }
        }
        richTextBoxOutput.ScrollToCaret();
    }

    private void FormPlay_KeyPress(object sender, KeyPressEventArgs e)
    {
        e.Handled = true; // Prevent the beep sound on Enter key press
        if (e.KeyChar == (char)Keys.Enter)
        {
            richTextBoxOutput.Text = richTextBoxOutput.Text[..^inputBuffer.Length];
            richTextBoxOutput.SelectionStart = richTextBoxOutput.TextLength;
            _inputQueue.Enqueue(inputBuffer);
            inputBuffer = "";
        }
        else if (e.KeyChar == (char)Keys.Back)
        {
            if (inputBuffer.Length > 0)
            {
                inputBuffer = inputBuffer[..^1];
                if (richTextBoxOutput.TextLength > 0)
                {
                    richTextBoxOutput.Text = richTextBoxOutput.Text[..^1];
                }
                richTextBoxOutput.SelectionStart = richTextBoxOutput.TextLength;
            }
        }
        else if (!char.IsControl(e.KeyChar))
        {
            if (uppercaseInput)
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
            inputBuffer += e.KeyChar;
            richTextBoxOutput.AppendText(e.KeyChar.ToString());
        }
        else if (e.KeyChar == 0x16) // Ctrl-V
        {
            var clipText = Clipboard.GetText();
            inputBuffer += clipText;
            richTextBoxOutput.AppendText(clipText);
        }
    }

    private void FormPlay_FormClosing(object sender, FormClosingEventArgs e)
    {
        game?.GameOver = true;
    }
}
