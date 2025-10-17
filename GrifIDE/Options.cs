using static GrifIDE.Common;

namespace GrifIDE;

internal static class Options
{
    internal static bool ShowControlCharacters { get; set; } = false;

    internal static int TabWidth { get; set; } = DEFAULT_TAB_WIDTH;

    internal static int TreePanelWidth { get; set; } = DEFAULT_TREE_PANEL_WIDTH;
    internal static string TreeColorBackground { get; set; } = DEFAULT_COLOR_BACKGROUND;
    internal static string TreeColorForeground { get; set; } = DEFAULT_COLOR_FOREGROUND;
    internal static string TreeFontFamily { get; set; } = DEFAULT_FONT_FAMILY;
    internal static int TreeFontSize { get; set; } = DEFAULT_FONT_SIZE;

    internal static int ListPanelWidth { get; set; } = DEFAULT_LIST_PANEL_WIDTH;
    internal static string ListColorBackground { get; set; } = DEFAULT_COLOR_BACKGROUND;
    internal static string ListColorForeground { get; set; } = DEFAULT_COLOR_FOREGROUND;
    internal static string ListFontFamily { get; set; } = DEFAULT_FONT_FAMILY;
    internal static int ListFontSize { get; set; } = DEFAULT_FONT_SIZE;

    internal static string TextColorBackground { get; set; } = DEFAULT_COLOR_BACKGROUND;
    internal static string TextColorForeground { get; set; } = DEFAULT_COLOR_FOREGROUND;
    internal static string TextFontFamily { get; set; } = DEFAULT_FONT_FAMILY;
    internal static int TextFontSize { get; set; } = DEFAULT_TEXT_FONT_SIZE;
}
