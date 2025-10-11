namespace GrifIDE;

public partial class FormMain
{
    private void InitMenu()
    {
        var menuStripMain = new MenuStrip();
        menuStripMain.SuspendLayout();
        menuStripMain.Dock = DockStyle.Top;
        // File Menu
        var fileMenuItem = new ToolStripMenuItem("&File");
        var newMenuItem = new ToolStripMenuItem("&New", null, NewMenuItem_Click);
        var openMenuItem = new ToolStripMenuItem("&Open", null, OpenMenuItem_Click);
        var saveMenuItem = new ToolStripMenuItem("&Save", null, SaveMenuItem_Click);
        var saveAsMenuItem = new ToolStripMenuItem("Save &As", null, SaveAsMenuItem_Click);
        var exitMenuItem = new ToolStripMenuItem("E&xit", null, ExitMenuItem_Click);
        fileMenuItem.DropDownItems.AddRange(new ToolStripItem[]
        {
            newMenuItem,
            openMenuItem,
            saveMenuItem,
            saveAsMenuItem,
            new ToolStripSeparator(),
            exitMenuItem
        });
        // Edit Menu
        var editMenuItem = new ToolStripMenuItem("&Edit");
        var undoMenuItem = new ToolStripMenuItem("&Undo", null, UndoMenuItem_Click);
        var redoMenuItem = new ToolStripMenuItem("&Redo", null, RedoMenuItem_Click);
        var cutMenuItem = new ToolStripMenuItem("Cu&t", null, CutMenuItem_Click);
        var copyMenuItem = new ToolStripMenuItem("&Copy", null, CopyMenuItem_Click);
        var pasteMenuItem = new ToolStripMenuItem("&Paste", null, PasteMenuItem_Click);
        editMenuItem.DropDownItems.AddRange(
        [
            undoMenuItem,
            redoMenuItem,
            new ToolStripSeparator(),
            cutMenuItem,
            copyMenuItem,
            pasteMenuItem
        ]);
        // Help Menu (Placeholder for future implementation)
        var helpMenuItem = new ToolStripMenuItem("&Help", null, HelpMenuItem_Click);
        // Add Menus to MenuStrip
        menuStripMain.Items.AddRange(
        [
            fileMenuItem,
            editMenuItem,
            helpMenuItem
        ]);
        Controls.Add(menuStripMain);
        menuStripMain.ResumeLayout(false);
        menuStripMain.PerformLayout();
        MainMenuStrip = menuStripMain;
    }

    private void HelpMenuItem_Click(object? sender, EventArgs e)
    {
        MessageBox.Show("Help is not implemented yet.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void PasteMenuItem_Click(object? sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    private void CopyMenuItem_Click(object? sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    private void CutMenuItem_Click(object? sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    private void RedoMenuItem_Click(object? sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    private void UndoMenuItem_Click(object? sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    private void ExitMenuItem_Click(object? sender, EventArgs e)
    {
        this.Close();
    }

    private void SaveAsMenuItem_Click(object? sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    private void SaveMenuItem_Click(object? sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    private void OpenMenuItem_Click(object? sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    private void NewMenuItem_Click(object? sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
}