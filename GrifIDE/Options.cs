namespace GrifIDE;

internal static class Options
{
    internal static int TabWidth { get; set; } = 4;
    internal static bool ShowControlCharacters { get; set; } = false;

    internal static int TreePanelWidth { get; set; } = 300;
    internal static string TreeColorBackground { get; set; } = "Black";
    internal static string TreeColorForeground { get; set; } = "Lime";
    internal static string TreeFontFamily { get; set; } = "Consolas";
    internal static float TreeFontSize { get; set; } = 12.0f;

    internal static int ListPanelWidth { get; set; } = 300;
    internal static string ListColorBackground { get; set; } = "Black";
    internal static string ListColorForeground { get; set; } = "Lime";
    internal static string ListFontFamily { get; set; } = "Consolas";
    internal static float ListFontSize { get; set; } = 12.0f;

    internal static string TextColorBackground { get; set; } = "Black";
    internal static string TextColorForeground { get; set; } = "Lime";
    internal static string TextFontFamily { get; set; } = "Consolas";
    internal static float TextFontSize { get; set; } = 16.0f;
}
