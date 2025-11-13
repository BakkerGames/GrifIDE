using System.Text.Json;
using static GrifIDE.Common;
using static GrifIDE.ConfigRoutines;
using static GrifIDE.Options;
using static GrifIDE.Routines;
using static Grif.IO;

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
        var saveMenuItem = new ToolStripMenuItem("&Save Edits", null, SaveMenuItem_Click, Keys.Control | Keys.S);
        var mergeMenuItem = new ToolStripMenuItem("&Merge and save", null, MergeMenuItem_Click);
        var exitMenuItem = new ToolStripMenuItem("E&xit", null, ExitMenuItem_Click);
        fileMenuItem.DropDownItems.AddRange(
        [
            newMenuItem,
            openMenuItem,
            new ToolStripSeparator(),
            saveMenuItem,
            mergeMenuItem,
            new ToolStripSeparator(),
            exitMenuItem
        ]);
        // Edit Menu
        var editMenuItem = new ToolStripMenuItem("&Edit");
        var addMenuItem = new ToolStripMenuItem("&Add", null, AddMainMenuItem_Click);
        var deleteMenuItem = new ToolStripMenuItem("&Delete", null, DeleteMenuItem_Click);
        var renameMenuItem = new ToolStripMenuItem("&Rename", null, RenameMenuItem_Click);
        var formatMenuItem = new ToolStripMenuItem("&Format", null, FormatMenuItem_Click, Keys.F4);
        editMenuItem.DropDownItems.AddRange(
        [
            addMenuItem,
            deleteMenuItem,
            renameMenuItem,
            new ToolStripSeparator(),
            formatMenuItem,
        ]);
        // View Menu
        var viewMenuItem = new ToolStripMenuItem("&View");
        var showControlCharsMenuItem = new ToolStripMenuItem("Show &Control Characters", null, ShowControlCharsMenuItem_Click, Keys.F7);
        viewMenuItem.DropDownItems.Add(showControlCharsMenuItem);
        showControlCharsMenuItem.Checked = ShowControlCharacters;
        // Play Menu
        var playMenuItem = new ToolStripMenuItem("&Play", null, PlayMenuItem_Click);
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
            playMenuItem,
            toolsMenuItem,
            helpMenuItem
        ]);
        Controls.Add(menuStripMain);
        menuStripMain.ResumeLayout(false);
        menuStripMain.PerformLayout();
        this.MainMenuStrip = menuStripMain;
    }

    private void RenameMenuItem_Click(object? sender, EventArgs e)
    {
        MessageBox.Show("Rename is not implemented yet.", "New", MessageBoxButtons.OK, MessageBoxIcon.None);
    }

    private void DeleteMenuItem_Click(object? sender, EventArgs e)
    {
        MessageBox.Show("Delete is not implemented yet.", "New", MessageBoxButtons.OK, MessageBoxIcon.None);
    }

    private void AddMainMenuItem_Click(object? sender, EventArgs e)
    {
        MessageBox.Show("Add is not implemented yet.", "New", MessageBoxButtons.OK, MessageBoxIcon.None);
    }

    private void PlayMenuItem_Click(object? sender, EventArgs e)
    {
        var formPlay = new FormPlay
        {
            StartPosition = FormStartPosition.CenterParent,
            PlayFont = new Font(TextFontFamily, TextFontSize),
            PlayBackColor = Color.FromName(TextColorBackground),
            PlayForeColor = Color.FromName(TextColorForeground)
        };
        formPlay.ShowDialog(this);
    }

    private void MergeMenuItem_Click(object? sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Filename) && EditItems.Count > 0)
        {
            foreach (var editItem in EditItems)
            {
                if (editItem.Action == "A" || editItem.Action == "C")
                {
                    GrodBase.Set(editItem.Key, editItem.Value);
                    continue;
                }
                if (editItem.Action == "R")
                {
                    GrodBase.Remove(editItem.OldKey!, false);
                    GrodBase.Set(editItem.Key, editItem.Value);
                    continue;
                }
                if (editItem.Action == "D")
                {
                    GrodBase.Remove(editItem.Key, false);
                    continue;
                }
                MessageBox.Show($"Invalid Action {editItem.Action}", "Error", MessageBoxButtons.OK, MessageBoxIcon.None);
                return;
            }
            WriteGrif(Filename, GrodBase.Items(true, true), false);
            EditItems.Clear();
            editListBox.Items.Clear();
            if (File.Exists(FilenameEdit))
            {
                File.Delete(FilenameEdit);
            }
            PopulateTreeView(GrodBase);
        }
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
        var tempText = EditItems.Where(x => x.Key == CurrentKey).FirstOrDefault()?.Value;
        tempText ??= GrodBase.Get(CurrentKey, false) ?? "";
        EditLoading = true;
        editRichTextBox.Clear();
        editRichTextBox.Text = FormatTextForEdit(tempText);
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
            File.WriteAllText(FilenameEdit, JsonSerializer.Serialize(EditItems, JsonOptionsOutput));
            MessageBox.Show($"Saved edits to {Path.GetFileName(FilenameEdit)}", "Save Edits", MessageBoxButtons.OK, MessageBoxIcon.None);
        }
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
        var tempText = EditItems.Where(x => x.Key == CurrentKey).FirstOrDefault()?.Value;
        tempText ??= GrodBase.Get(CurrentKey, false) ?? "";
        EditLoading = true;
        editRichTextBox.Clear();
        editRichTextBox.Text = FormatTextForEdit(tempText);
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
