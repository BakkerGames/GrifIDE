using Grif;

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
        var saveMenuItem = new ToolStripMenuItem("&Save", null, SaveMenuItem_Click, Keys.Control | Keys.S );
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
        var formatMenuItem = new ToolStripMenuItem("&Format", null, FormatMenuItem_Click, Keys.F4);
        editMenuItem.DropDownItems.AddRange(
        [
            formatMenuItem,
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

    private void NewMenuItem_Click(object? sender, EventArgs e)
    {
        MessageBox.Show("New is not implemented yet.", "New", MessageBoxButtons.OK, MessageBoxIcon.None);
    }

    private void OpenMenuItem_Click(object? sender, EventArgs e)
    {
        MessageBox.Show("Open is not implemented yet.", "Open", MessageBoxButtons.OK, MessageBoxIcon.None);
    }

    private void SaveMenuItem_Click(object? sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(filenameEdit))
        {
            Grif.Grif.WriteGrif(filenameEdit, grodEdit.Items(false, true), false);
            MessageBox.Show($"Saved to {Path.GetFileName(filenameEdit)}", "Save", MessageBoxButtons.OK, MessageBoxIcon.None);
        }
    }

    private void SaveAsMenuItem_Click(object? sender, EventArgs e)
    {
        MessageBox.Show("Save As is not implemented yet.", "Save As", MessageBoxButtons.OK, MessageBoxIcon.None);
    }

    private void ExitMenuItem_Click(object? sender, EventArgs e)
    {
        this.Close();
    }

    private void FormatMenuItem_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(currentKey))
        {
            return;
        }
        var tempText = grodEdit.Get(currentKey, true) ?? "";
        editLoading = true;
        editTextBox.Clear();
        editTextBox.Text = FormatTextForEdit(tempText);
        editLoading = false;
    }

    private void OptionsMenuItem_Click(object? sender, EventArgs e)
    {
        MessageBox.Show("Options are not implemented yet.", "Options", MessageBoxButtons.OK, MessageBoxIcon.None);
    }

    private void HelpMenuItem_Click(object? sender, EventArgs e)
    {
        MessageBox.Show("Help is not implemented yet.", "Help", MessageBoxButtons.OK, MessageBoxIcon.None);
    }
}
