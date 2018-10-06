using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace game_launcher
{
    public partial class EditGamesForm : Form
    {
        bool changed_data = false;
        bool pending_game = false;
        bool ignore_events = false;
        List<Data_Games> game_list;

        public EditGamesForm()
        {
            InitializeComponent();
            game_list = Data_Form.game_list;
            for (int i = 0; i < game_list.Count; i++)
            {
                lbx_games.Items.Add(game_list[i].name);
            }
        }

        private void bt_filedial_Click(object sender, EventArgs e)
        {
            if (sender == bt_target)
            {
                if (dl_file.ShowDialog() == DialogResult.OK)
                    tb_target.Text = dl_file.FileName;
            }
            else if (sender == bt_icon)
            {
                if (dl_ico.ShowDialog() == DialogResult.OK)
                    tb_icon.Text = dl_ico.FileName;
            }
            else //if (sender == bt_work)
            {
                if (dl_fld.ShowDialog() == DialogResult.OK)
                    tb_work.Text = dl_fld.SelectedPath;
            }
        }

        private void bt_games_Click(object sender, EventArgs e)
        {
            if (sender == bt_new)
            {
                if (PendingGameCancel()) return;
                lbx_games.SelectedIndex = -1;
                ClearFields(false);

            }
            else if (sender == bt_add)
            {
                Data_Games game = new Data_Games();
                game.name = tb_name.Text;
                game.target = tb_target.Text;
                game.launch_pars = tb_params.Text;
                game.icon = tb_icon.Text;
                game.work_dir = tb_work.Text;
                lbx_games.Items.Add(game.name);
                game_list.Add(game);
                ClearFields(true);
            }
            else if (sender == bt_del)
            {
                int idx = lbx_games.SelectedIndex;
                if (idx < 0) return;
                lbx_games.Items.RemoveAt(idx);
                game_list.RemoveAt(idx);
                pending_game = false;
                ChangedData(true);
            }
            else if (sender == bt_upd)
            {
                int idx = lbx_games.SelectedIndex;
                if (idx < 0) return;
                Data_Games game = game_list[idx];
                game.name = tb_name.Text;
                game.target = tb_target.Text;
                game.launch_pars = tb_params.Text;
                game.icon = tb_icon.Text;
                game.work_dir = tb_work.Text;
                lbx_games.Items[idx] = game.name;
                ClearFields(true);
            }
            else if (sender == bt_up)
            {
                int idx = lbx_games.SelectedIndex;
                if (idx > 0)
                    ChangeIndexes(idx, idx - 1);
            }
            else //if (sender == bt_down)
            {
                int idx = lbx_games.SelectedIndex;
                if (idx >= 0 && idx < lbx_games.Items.Count - 1)
                    ChangeIndexes(idx, idx + 1);
            }
        }

        private void lbx_games_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lbx_games.SelectedIndex < 0) return;
            if (PendingGameCancel()) return;
            pending_game = false;
            ignore_events = true;
            Data_Games game = game_list[lbx_games.SelectedIndex];
            tb_name.Text = game.name;
            tb_target.Text = game.target;
            tb_params.Text = game.launch_pars;
            tb_icon.Text = game.icon;
            tb_work.Text = game.work_dir;
            ignore_events = false;
        }

        private void tb_name_TextChanged(object sender, EventArgs e)
        {
            if (ignore_events || pending_game) return;
            pending_game = true;
            ts_info.Text = "Game not saved";
        }

        private void bt_save_Click(object sender, EventArgs e)
        {
            SaveChanges();
        }

        private void EditGamesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!changed_data) return;
            if (PendingGameCancel())
            {
                e.Cancel = true;
                return;
            }
            DialogResult res = Program.ShowQuestion("Save changes?", MessageBoxButtons.YesNoCancel);
            if (res == DialogResult.Yes) UpdateGameData();
            else if (res == DialogResult.Cancel) e.Cancel = true;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S))
                SaveChanges();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void ChangeIndexes(int src, int trg)
        {
            Data_Games tmp = game_list[src];
            game_list[src] = game_list[trg];
            game_list[trg] = tmp;
            object tmp2 = lbx_games.Items[src];
            lbx_games.Items[src] = lbx_games.Items[trg];
            lbx_games.Items[trg] = tmp2;
            lbx_games.SelectedIndex = trg;
            ChangedData(true);
        }

        private void ClearFields(bool change)
        {
            pending_game = false;
            ignore_events = true;
            tb_name.Text = string.Empty;
            tb_target.Text = string.Empty;
            tb_params.Text = string.Empty;
            tb_icon.Text = string.Empty;
            tb_work.Text = string.Empty;
            ignore_events = false;
            if (change) ChangedData(change);
        }

        private void ChangedData(bool input)
        {
            changed_data = input;
            ts_info.Text = input ? "Data not saved" : "Data saved";
        }

        private void SaveChanges()
        {
            if (Program.ShowQuestion("Save changes?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                UpdateGameData();
        }

        private bool PendingGameCancel()
        {
            return pending_game &&
                Program.ShowWarning("Ignore saving game data?", MessageBoxButtons.YesNo) == DialogResult.No;
        }

        private void UpdateGameData()
        {
            Data_Form.game_list = game_list;
            MainForm.inst.UpdateStyle();
            Data_Form.inst.Save();
            ChangedData(false);
        }
    }
}