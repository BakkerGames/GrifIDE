using static Grif.Grif;
using static GrifIDE.Common;
using static GrifIDE.Options;
using static GrifIDE.Routines;

namespace GrifIDE;

public static class ConfigRoutines
{
    public static void LoadConfig()
    {
        GrodConfig.Clear(true);
        if (File.Exists(GetConfigFilename()))
        {
            var configContent = ReadGrif(GetConfigFilename());
            GrodConfig.AddItems(configContent);
        }
        var lastFile = GrodConfig.Get("LastFilename", false);
        if (!string.IsNullOrEmpty(lastFile) && File.Exists(lastFile))
        {
            Filename = lastFile;
            FilenameEdit = GetEditFilename();
        }
        if (int.TryParse(GrodConfig.Get("TabWidth", true), out int tabWidth))
        {
            TabWidth = tabWidth;
        }
        else
        {
            TabWidth = DEFAULT_TAB_WIDTH;
        }
        if (bool.TryParse(GrodConfig.Get("ShowControlCharacters", true), out bool showControlChars))
        {
            ShowControlCharacters = showControlChars;
        }
        else
        {
            ShowControlCharacters = false;
        }
        // Tree panel settings
        if (int.TryParse(GrodConfig.Get("TreePanelWidth", true), out int treePanelWidth))
        {
            TreePanelWidth = Math.Max(treePanelWidth, MIN_TREE_PANEL_WIDTH);
        }
        else
        {
            TreePanelWidth = DEFAULT_TREE_PANEL_WIDTH;
        }
        TreeColorBackground = GrodConfig.Get("TreeColorBackground", true) ?? DEFAULT_COLOR_BACKGROUND;
        TreeColorForeground = GrodConfig.Get("TreeColorForeground", true) ?? DEFAULT_COLOR_FOREGROUND;
        TreeFontFamily = GrodConfig.Get("TreeFontFamily", true) ?? TreeFontFamily;
        if (int.TryParse(GrodConfig.Get("TreeFontSize", true), out int treeFontSize))
        {
            TreeFontSize = Math.Max(treeFontSize, 6);
        }
        // List panel settings
        if (int.TryParse(GrodConfig.Get("ListPanelWidth", true), out int listPanelWidth))
        {
            ListPanelWidth = Math.Max(listPanelWidth, MIN_TREE_PANEL_WIDTH);
        }
        else
        {
            ListPanelWidth = DEFAULT_TREE_PANEL_WIDTH;
        }
        ListColorBackground = GrodConfig.Get("ListColorBackground", true) ?? DEFAULT_COLOR_BACKGROUND;
        ListColorForeground = GrodConfig.Get("ListColorForeground", true) ?? DEFAULT_COLOR_FOREGROUND;
        ListFontFamily = GrodConfig.Get("ListFontFamily", true) ?? ListFontFamily;
        if (int.TryParse(GrodConfig.Get("ListFontSize", true), out int listFontSize))
        {
            ListFontSize = Math.Max(listFontSize, 6);
        }
        // Text panel settings
        TextColorBackground = GrodConfig.Get("TextColorBackground", true) ?? DEFAULT_COLOR_BACKGROUND;
        TextColorForeground = GrodConfig.Get("TextColorForeground", true) ?? DEFAULT_COLOR_FOREGROUND;
        TextFontFamily = GrodConfig.Get("TextFontFamily", true) ?? TextFontFamily;
        if (int.TryParse(GrodConfig.Get("TextFontSize", true), out int textFontSize))
        {
            TextFontSize = Math.Max(textFontSize, 6);
        }
    }

    public static void SaveConfig()
    {
        // Save configuration settings to a file or other destination
        GrodConfig.Set("!__Version", VERSION);
        GrodConfig.Set("LastFilename", Filename ?? "");
        GrodConfig.Set("TabWidth", TabWidth.ToString());
        GrodConfig.Set("ShowControlCharacters", ShowControlCharacters.ToString().ToLower());
        GrodConfig.Set("TreePanelWidth", TreePanelWidth.ToString());
        GrodConfig.Set("TreeColorBackground", TreeColorBackground);
        GrodConfig.Set("TreeColorForeground", TreeColorForeground);
        GrodConfig.Set("TreeFontFamily", TreeFontFamily);
        GrodConfig.Set("TreeFontSize", TreeFontSize.ToString());
        GrodConfig.Set("ListPanelWidth", ListPanelWidth.ToString());
        GrodConfig.Set("ListColorBackground", ListColorBackground);
        GrodConfig.Set("ListColorForeground", ListColorForeground);
        GrodConfig.Set("ListFontFamily", ListFontFamily);
        GrodConfig.Set("ListFontSize", ListFontSize.ToString());
        GrodConfig.Set("TextColorBackground", TextColorBackground);
        GrodConfig.Set("TextColorForeground", TextColorForeground);
        GrodConfig.Set("TextFontFamily", TextFontFamily);
        GrodConfig.Set("TextFontSize", TextFontSize.ToString());
        WriteGrif(GetConfigFilename(), GrodConfig.Items(true, true), true);
    }
}
