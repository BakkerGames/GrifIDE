using Grif;

namespace GrifIDE;

public static class Common
{
    public const string VERSION = "0.0.1";
    public const string IDE_APP_NAME = "GrifIDE";
    public const string CONFIG_FILENAME = "config.json";

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

    public static Grod GrodBase { get; set; } = new("base");
    public static Grod GrodEdit { get; set; } = new("edit");
    public static Grod GrodConfig { get; set; } = new("config");

    public static string? Filename { get; set; }
    public static string? FilenameEdit { get; set; }
    public static bool EditLoading { get; set; } = false;
    public static string? CurrentKey { get; set; }
}
