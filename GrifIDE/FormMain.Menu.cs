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
        fileMenuItem.DropDownItems.AddRange(
        [
            newMenuItem,
            openMenuItem,
            saveMenuItem,
            saveAsMenuItem,
            new ToolStripSeparator(),
            exitMenuItem
        ]);
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
        // Tools Menu
        var toolsMenuItem = new ToolStripMenuItem("&Tools");
        var optionsMenuItem = new ToolStripMenuItem("&Options", null, OptionsMenuItem_Click);
        toolsMenuItem.DropDownItems.Add(optionsMenuItem);
        // Help Menu
        var helpMenuItem = new ToolStripMenuItem("&Help", null, HelpMenuItem_Click);
        // Add Menus to MenuStrip
        menuStripMain.Items.AddRange(
        [
            fileMenuItem,
            editMenuItem,
            toolsMenuItem,
            helpMenuItem
        ]);
        Controls.Add(menuStripMain);
        menuStripMain.ResumeLayout(false);
        menuStripMain.PerformLayout();
        MainMenuStrip = menuStripMain;
    }

    private void OptionsMenuItem_Click(object? sender, EventArgs e)
    {
        MessageBox.Show("Options are not implemented yet.", "Options", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void HelpMenuItem_Click(object? sender, EventArgs e)
    {
        MessageBox.Show("Help is not implemented yet.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void PasteMenuItem_Click(object? sender, EventArgs e)
    {
        MessageBox.Show("Paste is not implemented yet.", "Paste", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void CopyMenuItem_Click(object? sender, EventArgs e)
    {
        MessageBox.Show("Copy is not implemented yet.", "Copy", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void CutMenuItem_Click(object? sender, EventArgs e)
    {
        MessageBox.Show("Cut is not implemented yet.", "Cut", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void RedoMenuItem_Click(object? sender, EventArgs e)
    {
        MessageBox.Show("Redo is not implemented yet.", "Redo", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void UndoMenuItem_Click(object? sender, EventArgs e)
    {
        MessageBox.Show("Undo is not implemented yet.", "Undo", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void ExitMenuItem_Click(object? sender, EventArgs e)
    {
        this.Close();
    }

    private void SaveAsMenuItem_Click(object? sender, EventArgs e)
    {
        MessageBox.Show("Save As is not implemented yet.", "Save As", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void SaveMenuItem_Click(object? sender, EventArgs e)
    {
        MessageBox.Show("Save is not implemented yet.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void OpenMenuItem_Click(object? sender, EventArgs e)
    {
        MessageBox.Show("Open is not implemented yet.", "Open", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void NewMenuItem_Click(object? sender, EventArgs e)
    {
        MessageBox.Show("New is not implemented yet.", "New", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
