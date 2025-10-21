using Grif;
using System.Runtime.InteropServices;
using static Grif.Common;
using static GrifIDE.Options;
using static GrifIDE.Common;

namespace GrifIDE;

internal static class Routines
{
    internal static string FormatTextForEdit(string? text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return "";
        }
        var tempText = text;
        if (text.StartsWith('@'))
        {
            tempText = Dags.PrettyScript(tempText);
        }
        else if (!ShowControlCharacters)
        {
            tempText = tempText.Replace(NL, "\r\n");
            tempText = tempText.Replace(SPACE, " ");
        }
        else
        {
            tempText = UnformatTextFromEdit(tempText);
        }
        return tempText;
    }

    internal static string UnformatTextFromEdit(string text)
    {
        var tempText = text;
        if (text.TrimStart().StartsWith('@'))
        {
            tempText = Dags.CompressScript(tempText);
        }
        else
        {
            tempText = tempText.Replace("\r\n", NL).Replace("\r", NL);
            if (tempText.StartsWith(' '))
            {
                tempText = SPACE + tempText[1..];
            }
            if (tempText.EndsWith(' '))
            {
                tempText = tempText[..^1] + SPACE;
            }
            tempText = tempText.Replace($"{NL} ", $"{NL}{SPACE}");
            tempText = tempText.Replace($" {NL}", $"{SPACE}{NL}");
        }
        return tempText;
    }

    internal static string GetDocumentsFolder()
    {
        var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        path = Path.Combine(path, IDE_APP_NAME);
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        return path;
    }

    internal static string GetConfigFilename()
    {
        var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        path = Path.Combine(path, IDE_APP_NAME);
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        path = Path.Combine(path, CONFIG_FILENAME);
        return path;
    }

    internal static string GetEditFilename()
    {
        return Path.Combine(GetDocumentsFolder(), Path.GetFileNameWithoutExtension(Filename) + ".grifedit");
    }

    #region Set Tab Width P/Invoke

    [DllImport("User32.dll", CharSet = CharSet.Auto)]
    private static extern IntPtr SendMessage(IntPtr h, int msg, int wParam, int[] lParam);

    internal static void SetTabWidth(TextBox textbox, int tabWidth)
    {
        const int EM_SETTABSTOPS = 0x00CB;
        SendMessage(textbox.Handle, EM_SETTABSTOPS, 1, [tabWidth * 4]);
    }

    #endregion
}
