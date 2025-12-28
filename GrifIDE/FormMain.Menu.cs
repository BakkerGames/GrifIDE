using GrifLib;
using static GrifIDE.Common;
using static GrifIDE.ConfigRoutines;
using static GrifIDE.Options;
using static GrifIDE.Routines;
using static GrifLib.Common;
using static GrifLib.IO;

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
        var mergeMenuItem = new ToolStripMenuItem("&Merge and save", null, MergeMenuItem_Click, Keys.Control | Keys.M);
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
        var addMenuItem = new ToolStripMenuItem("&Add", null, AddMainMenuItem_Click, Keys.Control | Keys.N);
        var renameMenuItem = new ToolStripMenuItem("&Rename", null, RenameMenuItem_Click, Keys.Control | Keys.R);
        var deleteMenuItem = new ToolStripMenuItem("&Delete", null, DeleteMenuItem_Click);
        var uneditMenuItem = new ToolStripMenuItem("&Unedit", null, UneditMenuItem_Click);
        var formatMenuItem = new ToolStripMenuItem("&Format", null, FormatMenuItem_Click, Keys.F4);
        editMenuItem.DropDownItems.AddRange(
        [
            addMenuItem,
            renameMenuItem,
            deleteMenuItem,
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

    private void UneditMenuItem_Click(object? sender, EventArgs e)
    {
        if (CurrentKey == null)
        {
            return;
        }
        var response = MessageBox.Show($"Are you sure you want to discard changes for {CurrentKey}?", $"Unedit {CurrentKey}", MessageBoxButtons.YesNo);
        if (response == DialogResult.No)
        {
            return;
        }
        var item = EditItems.Where(x => x.Key.Equals(CurrentKey, OIC)).FirstOrDefault();
        if (item == null)
        {
            MessageBox.Show($"Key not found: {CurrentKey}", "Not Found", MessageBoxButtons.OK);
            return;
        }
        SetDirtyFlag(true);
        SetEditListBoxSelectedIndex(-1);
        editListBox.Items.Remove($"{item.Key} [{item.Action}]");
        EditItems.Remove(item);
    }

    private void AddMainMenuItem_Click(object? sender, EventArgs e)
    {
        var newKey = InputBox.Show("Add New Key", "Enter the new key:");
        if (newKey == null)
        {
            return;
        }
        if (string.IsNullOrWhiteSpace(newKey))
        {
            MessageBox.Show("Key cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.None);
            return;
        }
        newKey = newKey.Trim();
        var item = EditItems.Where(x => x.Key.Equals(newKey, OIC)).FirstOrDefault();
        if (BaseGrod.ContainsKey(newKey, true) || (item != null && item.Action != "D"))
        {
            MessageBox.Show("Key already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.None);
            return;
        }
        CurrentKey = null;
        treeView.SelectedNode = null;
        SetEditListBoxSelectedIndex(-1);
        editRichTextBox.Clear();
        SetDirtyFlag(true);
        var newKeyText = "";
        if (item != null)
        {
            item.Action = "C";
            item.Value = "";
            item.OldKey = null;
            editListBox.Items.Remove($"{newKey} [D]");
            newKeyText = $"{newKey} [C]";
            editListBox.Items.Add(newKeyText);
        }
        else
        {
            EditItems.Add(new EditItem
            {
                Key = newKey,
                Action = "A",
                Value = ""
            });
            newKeyText = $"{newKey} [A]";
            editListBox.Items.Add(newKeyText);
        }
        editListBox.SelectedItem = newKeyText;
        editRichTextBox.Focus();
    }

    private void RenameMenuItem_Click(object? sender, EventArgs e)
    {
        if (CurrentKey == null)
        {
            return;
        }
        var newKey = InputBox.Show("Rename Key", $"Enter new key for {CurrentKey}:", CurrentKey);
        if (string.IsNullOrWhiteSpace(newKey))
        {
            return;
        }
        newKey = newKey.Trim();
        if (newKey.Equals(CurrentKey, OIC))
        {
            MessageBox.Show("Must enter a different key to rename", "Keys match", MessageBoxButtons.OK);
            return;
        }
        var newItem = EditItems.Where(x => x.Key.Equals(newKey, OIC)).FirstOrDefault();
        var existingKey = BaseGrod.Keys(true, false).Where(x => x.Equals(newKey, OIC)).FirstOrDefault();
        if (newItem != null || existingKey != null)
        {
            MessageBox.Show("New key already exists", "Error", MessageBoxButtons.OK);
            return;
        }
        SetDirtyFlag(true);
        var oldItem = EditItems.Where(x => x.Key.Equals(CurrentKey, OIC)).FirstOrDefault();
        if (oldItem != null)
        {
            SetEditListBoxSelectedIndex(-1);
            editListBox.Items.Remove($"{oldItem.Key} [{oldItem.Action}]");
            editListBox.Items.Add($"{newKey} [R]");
            if (oldItem.Action != "R")
            {
                oldItem.OldKey = CurrentKey;
            }
            oldItem.Action = "R";
            oldItem.Key = newKey;
            return;
        }
        SetEditListBoxSelectedIndex(-1);
        editListBox.Items.Add($"{newKey} [R]");
        EditItems.Add(new EditItem
        {
            Key = newKey,
            Action = "R",
            Value = BaseGrod.Get(CurrentKey, true),
            OldKey = CurrentKey,
        });
    }

    private void DeleteMenuItem_Click(object? sender, EventArgs e)
    {
        var delKey = InputBox.Show("Delete Key", "Enter key to delete:", CurrentKey);
        if (string.IsNullOrWhiteSpace(delKey))
        {
            return;
        }
        delKey = delKey.Trim();
        var item = EditItems.Where(x => x.Key.Equals(delKey, OIC)).FirstOrDefault();
        var existingKey = BaseGrod.Keys(true, false).Where(x => x.Equals(delKey, OIC)).FirstOrDefault();
        if (item == null && existingKey == null)
        {
            MessageBox.Show("Key does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.None);
            return;
        }
        if (item == null)
        {
            item = new EditItem
            {
                Key = delKey,
                Action = "D",
                Value = null
            };
        }
        else
        {
            if (!EditItems.Remove(item))
            {
                MessageBox.Show("Failed to remove existing edit item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.None);
                return;
            }
            editListBox.Items.Remove($"{delKey} [{item.Action}]");
        }
        SetDirtyFlag(true);
        SetEditListBoxSelectedIndex(-1);
        if (item.Action == "R")
        {
            // If it was renamed, just cancel the rename
            return;
        }
        item.Action = "D";
        item.Value = null;
        item.OldKey = null;
        if (CurrentKey?.Equals(delKey, OIC) ?? false)
        {
            editRichTextBox.Clear();
            CurrentKey = null;
            treeView.SelectedNode = null;
        }
        editListBox.Items.Add($"{delKey} [{item.Action}]");
        EditItems.Add(item);
    }

    private void PlayMenuItem_Click(object? sender, EventArgs e)
    {
        var formPlay = new FormPlay
        {
            StartPosition = FormStartPosition.CenterParent,
            Text = BaseGrod.Get(GAMETITLE, true) ?? BaseGrod.Get(GAMENAME, true) ?? "Play Grif Game"
        };
        var playGrod = new Grod();
        playGrod.AddItems(BaseGrod.Items(true, true));
        MergeEditItems(playGrod);
        formPlay.SetGrodBase(playGrod);
        formPlay.SetGrodOverlay(new Grod());
        formPlay.Show();
    }

    private void MergeMenuItem_Click(object? sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Filename) && EditItems.Count > 0)
        {
            MergeEditItems(BaseGrod);
            WriteGrif(Filename, BaseGrod.Items(true, true), false);
            if (File.Exists(FilenameEdit))
            {
                File.Delete(FilenameEdit);
            }
            CurrentKey = null;
            treeView.SelectedNode = null;
            editRichTextBox.Text = "";
            EditItems.Clear();
            editListBox.Items.Clear();
            SetDirtyFlag(false);
            PopulateTreeView(BaseGrod);
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
        var tempText = EditItems.Where(x => x.Key.Equals(CurrentKey, OIC)).FirstOrDefault()?.Value;
        tempText ??= FormatTextForEdit(BaseGrod.Get(CurrentKey, false) ?? "");
        editRichTextBox.Clear();
        editRichTextBox.Text = tempText;
    }

    private void NewMenuItem_Click(object? sender, EventArgs e)
    {
        SaveFileDialog sfd = new()
        {
            Filter = "Grif Files (*.grif)|*.grif",
            Title = "Create New Grif File",
            FilterIndex = 0,
            FileName = "new.grif"
        };
        if (sfd.ShowDialog() == DialogResult.OK)
        {
            Filename = sfd.FileName;
            BaseGrod = new Grod();
            EditItems.Clear();
            editListBox.Items.Clear();
            editRichTextBox.Clear();
            SetDirtyFlag(false);
            PopulateTreeView(BaseGrod);
        }
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
        SaveEditItems();
        SetDirtyFlag(false);
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
        var item = EditItems.Where(x => x.Key.Equals(CurrentKey, OIC)).FirstOrDefault();
        if (item == null)
        {
            return;
        }
        var tempText = item?.Value;
        tempText ??= BaseGrod.Get(CurrentKey, false) ?? "";
        editRichTextBox.Clear();
        editRichTextBox.Text = FormatTextForEdit(tempText);
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

    #region Private Methods

    private static void MergeEditItems(Grod grod)
    {
        if (grod == null)
        {
            return;
        }
        foreach (var editItem in EditItems)
        {
            if (editItem.Action == "A" || editItem.Action == "C")
            {
                grod.Set(editItem.Key, editItem.Value);
                continue;
            }
            if (editItem.Action == "R")
            {
                grod.Remove(editItem.OldKey!, true);
                grod.Set(editItem.Key, editItem.Value);
                continue;
            }
            if (editItem.Action == "D")
            {
                grod.Remove(editItem.Key, true);
                continue;
            }
        }
    }

    #endregion
}
