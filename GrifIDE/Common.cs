using System.Text.Json;
using GrifLib;

namespace GrifIDE;

public static class Common
{
    public const string VERSION = "2.2026.1.23";
    public const string IDE_APP_NAME = "GrifIDE";
    public const string IDE_APP_TITLE = "Grif IDE";
    public const string CONFIG_FILENAME = "config.json";
    public const string EDIT_EXTENSION = ".grifedit";

    public const int DEFAULT_TAB_WIDTH = 4;
    public const string DEFAULT_COLOR_BACKGROUND = "Black";
    public const string DEFAULT_COLOR_FOREGROUND = "Lime";
    public const string DEFAULT_FONT_FAMILY = "Consolas";
    public const int DEFAULT_FONT_SIZE = 12;
    public const int DEFAULT_TEXT_FONT_SIZE = 16;
    public const int MIN_TREE_PANEL_WIDTH = 200;
    public const int DEFAULT_TREE_PANEL_WIDTH = 300;
    public const int MIN_LIST_PANEL_WIDTH = 200;
    public const int DEFAULT_LIST_PANEL_WIDTH = 300;

    public static Grod BaseGrod { get; set; } = new("base");
    public static Grod ConfigGrod { get; set; } = new("config");

    public static bool DirtyFlag { get; set; } = false;
    public static List<EditItem> EditItems { get; set; } = [];

    public static string? Filename { get; set; }
    public static string? FilenameEdit { get; set; }
    public static bool EditLoading { get; set; } = false;
    public static string? CurrentKey { get; set; }

    public static JsonSerializerOptions JsonOptionsOutput { get; } = new()
    {
        WriteIndented = true,
    };
}
