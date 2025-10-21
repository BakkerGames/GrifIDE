using Grif;
using static Grif.Grif;
using static GrifIDE.Common;
using static GrifIDE.ConfigRoutines;
using static GrifIDE.Options;
using static GrifIDE.Routines;

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
        var saveMenuItem = new ToolStripMenuItem("&Save", null, SaveMenuItem_Click, Keys.Control | Keys.S);
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
        // View Menu
        var viewMenuItem = new ToolStripMenuItem("&View");
        var showControlCharsMenuItem = new ToolStripMenuItem("Show &Control Characters", null, ShowControlCharsMenuItem_Click, Keys.F7);
        viewMenuItem.DropDownItems.Add(showControlCharsMenuItem);
        showControlCharsMenuItem.Checked = ShowControlCharacters;
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
            viewMenuItem,
            toolsMenuItem,
            helpMenuItem
        ]);
        Controls.Add(menuStripMain);
        menuStripMain.ResumeLayout(false);
        menuStripMain.PerformLayout();
        this.MainMenuStrip = menuStripMain;
    }

    private void ShowControlCharsMenuItem_Click(object? sender, EventArgs e)
    {
        ShowControlCharacters = !ShowControlCharacters;
        if (sender is ToolStripMenuItem menuItem)
        {
            menuItem.Checked = ShowControlCharacters;
        }
        if (string.IsNullOrEmpty(CurrentKey))
        {
            return;
        }
        var tempText = GrodEdit.Get(CurrentKey, true);
        EditLoading = true;
        editTextBox.Clear();
        editTextBox.Text = FormatTextForEdit(tempText);
        EditLoading = false;
    }

    private void NewMenuItem_Click(object? sender, EventArgs e)
    {
        MessageBox.Show("New is not implemented yet.", "New", MessageBoxButtons.OK, MessageBoxIcon.None);
    }

    private void OpenMenuItem_Click(object? sender, EventArgs e)
    {
        OpenFileDialog ofd = new()
        {
            Filter = "Grif Files (*.grif)|*.grif",
            Title = "Open Grif File(s)",
            FilterIndex = 0,
            Multiselect = false,
            FileName = Path.GetFileName(Filename)
        };
        if (ofd.ShowDialog() == DialogResult.OK)
        {
            OpenFile(ofd.FileName);
        }
    }

    private void SaveMenuItem_Click(object? sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(FilenameEdit))
        {
            Grif.Grif.WriteGrif(FilenameEdit, GrodEdit.Items(false, true), false);
            MessageBox.Show($"Saved to {Path.GetFileName(FilenameEdit)}", "Save", MessageBoxButtons.OK, MessageBoxIcon.None);
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
        if (string.IsNullOrEmpty(CurrentKey))
        {
            return;
        }
        var tempText = GrodEdit.Get(CurrentKey, true);
        EditLoading = true;
        editTextBox.Clear();
        editTextBox.Text = FormatTextForEdit(tempText);
        EditLoading = false;
    }

    private void OptionsMenuItem_Click(object? sender, EventArgs e)
    {
        SaveConfig();
        MessageBox.Show("Options saved.", "Options", MessageBoxButtons.OK, MessageBoxIcon.None);
    }

    private void HelpMenuItem_Click(object? sender, EventArgs e)
    {
        MessageBox.Show("Help is not implemented yet.", "Help", MessageBoxButtons.OK, MessageBoxIcon.None);
    }
}
