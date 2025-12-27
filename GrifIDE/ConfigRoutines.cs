using static GrifIDE.Common;
using static GrifIDE.Options;
using static GrifIDE.Routines;
using static GrifLib.IO;

namespace GrifIDE;

public static class ConfigRoutines
{
    public static void LoadConfig()
    {
        ConfigGrod.Clear(true);
        if (File.Exists(GetConfigFilename()))
        {
            var configContent = ReadGrif(GetConfigFilename());
            ConfigGrod.AddItems(configContent);
        }
        var lastFile = ConfigGrod.Get("LastFilename", false);
        if (!string.IsNullOrEmpty(lastFile) && File.Exists(lastFile))
        {
            Filename = lastFile;
            FilenameEdit = GetEditFilename(lastFile);
        }
        if (int.TryParse(ConfigGrod.Get("TabWidth", true), out int tabWidth))
        {
            TabWidth = tabWidth;
        }
        else
        {
            TabWidth = DEFAULT_TAB_WIDTH;
        }
        if (bool.TryParse(ConfigGrod.Get("ShowControlCharacters", true), out bool showControlChars))
        {
            ShowControlCharacters = showControlChars;
        }
        else
        {
            ShowControlCharacters = false;
        }
        // Tree panel settings
        if (int.TryParse(ConfigGrod.Get("TreePanelWidth", true), out int treePanelWidth))
        {
            TreePanelWidth = Math.Max(treePanelWidth, MIN_TREE_PANEL_WIDTH);
        }
        else
        {
            TreePanelWidth = DEFAULT_TREE_PANEL_WIDTH;
        }
        TreeColorBackground = ConfigGrod.Get("TreeColorBackground", true) ?? DEFAULT_COLOR_BACKGROUND;
        TreeColorForeground = ConfigGrod.Get("TreeColorForeground", true) ?? DEFAULT_COLOR_FOREGROUND;
        TreeFontFamily = ConfigGrod.Get("TreeFontFamily", true) ?? TreeFontFamily;
        if (int.TryParse(ConfigGrod.Get("TreeFontSize", true), out int treeFontSize))
        {
            TreeFontSize = Math.Max(treeFontSize, 6);
        }
        // List panel settings
        if (int.TryParse(ConfigGrod.Get("ListPanelWidth", true), out int listPanelWidth))
        {
            ListPanelWidth = Math.Max(listPanelWidth, MIN_TREE_PANEL_WIDTH);
        }
        else
        {
            ListPanelWidth = DEFAULT_TREE_PANEL_WIDTH;
        }
        ListColorBackground = ConfigGrod.Get("ListColorBackground", true) ?? DEFAULT_COLOR_BACKGROUND;
        ListColorForeground = ConfigGrod.Get("ListColorForeground", true) ?? DEFAULT_COLOR_FOREGROUND;
        ListFontFamily = ConfigGrod.Get("ListFontFamily", true) ?? ListFontFamily;
        if (int.TryParse(ConfigGrod.Get("ListFontSize", true), out int listFontSize))
        {
            ListFontSize = Math.Max(listFontSize, 6);
        }
        // Text panel settings
        TextColorBackground = ConfigGrod.Get("TextColorBackground", true) ?? DEFAULT_COLOR_BACKGROUND;
        TextColorForeground = ConfigGrod.Get("TextColorForeground", true) ?? DEFAULT_COLOR_FOREGROUND;
        TextFontFamily = ConfigGrod.Get("TextFontFamily", true) ?? TextFontFamily;
        if (int.TryParse(ConfigGrod.Get("TextFontSize", true), out int textFontSize))
        {
            TextFontSize = Math.Max(textFontSize, 6);
        }
    }

    public static void SaveConfig()
    {
        // Save configuration settings to a file or other destination
        ConfigGrod.Set("!Version", VERSION);
        ConfigGrod.Set("LastFilename", Filename ?? "");
        ConfigGrod.Set("TabWidth", TabWidth.ToString());
        ConfigGrod.Set("ShowControlCharacters", ShowControlCharacters.ToString().ToLower());
        ConfigGrod.Set("TreePanelWidth", TreePanelWidth.ToString());
        ConfigGrod.Set("TreeColorBackground", TreeColorBackground);
        ConfigGrod.Set("TreeColorForeground", TreeColorForeground);
        ConfigGrod.Set("TreeFontFamily", TreeFontFamily);
        ConfigGrod.Set("TreeFontSize", TreeFontSize.ToString());
        ConfigGrod.Set("ListPanelWidth", ListPanelWidth.ToString());
        ConfigGrod.Set("ListColorBackground", ListColorBackground);
        ConfigGrod.Set("ListColorForeground", ListColorForeground);
        ConfigGrod.Set("ListFontFamily", ListFontFamily);
        ConfigGrod.Set("ListFontSize", ListFontSize.ToString());
        ConfigGrod.Set("TextColorBackground", TextColorBackground);
        ConfigGrod.Set("TextColorForeground", TextColorForeground);
        ConfigGrod.Set("TextFontFamily", TextFontFamily);
        ConfigGrod.Set("TextFontSize", TextFontSize.ToString());
        WriteGrif(GetConfigFilename(), ConfigGrod.Items(true, true), true);
    }
}
