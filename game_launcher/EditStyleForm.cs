using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace game_launcher
{
    public partial class EditStyleForm : Form
    {
        List<GameBtn> game_btns = new List<GameBtn>();
        bool changed_data = false;
        bool ignore_events = false;

        //Style data
        string frm_img;
        Font gm_fnt;
        string gm_snd_h;
        string gm_snd_c;

        public EditStyleForm()
        {
            InitializeComponent();
            ignore_events = true;
            FillComboWithEnum<FormBorderStyle>(cb_frm_border);
            FillComboWithEnum<ImageLayout>(cb_frm_imglay);
            FillComboWithEnum<ContentAlignment>(cb_gm_textalign);
            FillComboWithEnum<ContentAlignment>(cb_gm_ic_align);
            FillComboWithEnum<FormStartPosition>(cb_startpos);
            cb_gm_cr.SelectedIndex = 0;
            //Enable test mode - no process start
            GameBtn.test_mode = true;
            Data_Form.inst_tmp = new Data_Form();
            Data_Form.CopyData(Data_Form.inst, Data_Form.inst_tmp);
            LoadStyleData();
            ignore_events = false;
            UpdateStyle();
        }

        private void bt_colordial_Click(object sender, EventArgs e)
        {
            if (dl_color.ShowDialog() == DialogResult.OK)
            {
                if (sender == bt_frm_col)
                    lb_frm_col.BackColor = dl_color.Color;
                else if (sender == bt_transkey)
                    lb_transkey.BackColor = dl_color.Color;
                else if (sender == bt_gm_fg_n)
                    lb_gm_fg_n.BackColor = dl_color.Color;
                else if (sender == bt_gm_fg_h)
                    lb_gm_fg_h.BackColor = dl_color.Color;
                else if (sender == bt_gm_fg_c)
                    lb_gm_fg_c.BackColor = dl_color.Color;
                else if (sender == bt_gm_col_n)
                    lb_gm_col_n.BackColor = dl_color.Color;
                else if (sender == bt_gm_col_h)
                    lb_gm_col_h.BackColor = dl_color.Color;
                else if (sender == bt_gm_col_c)
                    lb_gm_col_c.BackColor = dl_color.Color;
                else if (sender == bt_gm_border_n)
                    lb_gm_border_n.BackColor = dl_color.Color;
                else if (sender == bt_gm_border_h)
                    lb_gm_border_h.BackColor = dl_color.Color;
                else //if (sender == bt_gm_border_c)
                    lb_gm_border_c.BackColor = dl_color.Color;
                ChangedData(true);
            }
        }

        private void bt_gm_font_Click(object sender, EventArgs e)
        {
            try
            {
                if (dl_font.ShowDialog() == DialogResult.OK)
                {
                    gm_fnt = dl_font.Font;
                    ChangedData(true);
                }
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void bt_frm_img_Click(object sender, EventArgs e)
        {
            dl_file.Filter = "Images|*.bmp;*.png;*.gif;*.jpg;*.jpeg|All files|*.*";
            if (dl_file.ShowDialog() == DialogResult.OK)
            {
                frm_img = dl_file.FileName;
                ChangedData(true);
            }
        }

        private void bt_filedial_Click(object sender, EventArgs e)
        {
            dl_file.Filter = "wav files|*.wav|All files|*.*";
            if (dl_file.ShowDialog() == DialogResult.OK)
            {

                if (sender == bt_gm_snd_h)
                    gm_snd_h = dl_file.FileName;
                else //if (sender == bt_gm_snd_c)
                    gm_snd_c = dl_file.FileName;
                ChangedData(true);
            }
        }

        private void UpdateStyle()
        {
            Data_Form.UpdateStyle(pn_preview, game_btns, Data_Form.inst_tmp);
        }

        private void bt_save_Click(object sender, EventArgs e)
        {
            if (sender == bt_save)
                SaveChanges();
            else //if (sender == bt_preview)
            {
                PreviewStyle();
                UpdateStyle();
            }
        }

        private void Form_ch_CheckedChanged(object sender, EventArgs e)
        {
            if (!ignore_events) ChangedData(true);
        }

        private void Form_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ignore_events) ChangedData(true);
        }

        private void Form_nm_ValueChanged(object sender, EventArgs e)
        {
            if (!ignore_events) ChangedData(true);
        }

        private void tb_title_TextChanged(object sender, EventArgs e)
        {
            if (!ignore_events) ChangedData(true);
        }

        private void EditStyleForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!changed_data) return;
            DialogResult res = Program.ShowQuestion("Save changes?", MessageBoxButtons.YesNoCancel);
            if (res == DialogResult.Yes) UpdateStyleData();
            else if (res == DialogResult.Cancel) e.Cancel = true;
            else MainForm.inst.UpdateStyle();
        }

        private void EditStyleForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Release resource, reset test mode
            Data_Form.inst_tmp = null;
            GameBtn.test_mode = false;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S))
                SaveChanges();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void LoadStyleData()
        {
            Data_Form data = Data_Form.inst_tmp;
            //Form style
            tb_title.Text = data.title;
            cb_startpos.SelectedItem = data.startpos.ToString();
            nm_frm_x.Value = data.x;
            nm_frm_y.Value = data.y;
            nm_frm_w.Value = data.width;
            nm_frm_h.Value = data.height;
            ch_frm_col.Checked = data.background;
            lb_frm_col.BackColor = data.backg_col;
            ch_frm_img.Checked = data.background_img;
            frm_img = data.backg_img;
            nm_opacity.Value = data.opacity;
            ch_transkey.Checked = data.transkey;
            lb_transkey.BackColor = data.trank_col;
            cb_frm_border.SelectedItem = data.border.ToString();
            cb_frm_imglay.SelectedItem = data.backg_lay.ToString();
            //GameStyle
            cb_gm_textalign.SelectedItem = data.gm_text_align.ToString();
            cb_gm_ic_align.SelectedItem = data.gm_img_align.ToString();
            nm_gm_x.Value = data.gm_x;
            nm_gm_y.Value = data.gm_y;
            nm_gm_w.Value = data.gm_width;
            nm_gm_h.Value = data.gm_height;
            nm_gm_mx.Value = data.gm_right;
            nm_gm_my.Value = data.gm_bottom;
            nm_gm_ic_w.Value = data.gm_ic_w;
            nm_gm_ic_h.Value = data.gm_ic_h;
            ch_gm_close.Checked = data.gm_close;
            nm_gm_snd_wait.Value = data.gm_snd_wait;
            cb_gm_cr.SelectedIndex = data.gm_gen_mode ? 0 : 1;
            nm_gm_cr.Value = data.gm_gen_elem;
            gm_fnt = data.gm_font;
            lb_gm_fg_n.BackColor = data.gm_foreg_col;
            ch_gm_fg_dyn.Checked = data.gm_foreg_dyn;
            ch_gm_fg_h.Checked = data.gm_foreg_h;
            lb_gm_fg_h.BackColor = data.gm_foreg_col_h;
            ch_gm_fg_c.Checked = data.gm_foreg_c;
            lb_gm_fg_c.BackColor = data.gm_foreg_col_c;
            ch_gm_col_n.Checked = data.gm_backg;
            lb_gm_col_n.BackColor = data.gm_backg_col;
            ch_gm_col_tr.Checked = data.gm_backg_col == Color.Transparent;
            ch_gm_col_dyn.Checked = data.gm_backg_dyn;
            ch_gm_col_h.Checked = data.gm_backg_h;
            lb_gm_col_h.BackColor = data.gm_backg_col_h;
            ch_gm_col_c.Checked = data.gm_backg_c;
            lb_gm_col_c.BackColor = data.gm_backg_col_c;
            ch_gm_border_n.Checked = data.gm_border;
            lb_gm_border_n.BackColor = data.gm_border_col;
            ch_gm_border_tr.Checked = data.gm_backg_col == Color.Transparent;
            ch_gm_border_dyn.Checked = data.gm_border_dyn;
            ch_gm_border_h.Checked = data.gm_border_h;
            lb_gm_border_h.BackColor = data.gm_border_col_h;
            ch_gm_border_c.Checked = data.gm_border_c;
            lb_gm_border_c.BackColor = data.gm_border_col_c;
            ch_gm_snd_h.Checked = data.gm_snd_hover;
            gm_snd_h = data.gm_snd_h;
            ch_gm_snd_c.Checked = data.gm_snd_click;
            gm_snd_c = data.gm_snd_c;
        }

        private void PreviewStyle()
        {
            Data_Form data = Data_Form.inst_tmp;
            //Form style
            data.title = tb_title.Text;
            data.startpos = GetEnum<FormStartPosition>(cb_startpos.SelectedItem);
            data.x = (int)nm_frm_x.Value;
            data.y = (int)nm_frm_y.Value;
            data.width = (int)nm_frm_w.Value;
            data.height = (int)nm_frm_h.Value;
            data.background = ch_frm_col.Checked;
            data.backg_col = lb_frm_col.BackColor;
            data.background_img = ch_frm_img.Checked;
            data.backg_img = frm_img;
            data.opacity = (int)nm_opacity.Value;
            data.transkey = ch_transkey.Checked;
            data.trank_col = lb_transkey.BackColor;
            data.border = GetEnum<FormBorderStyle>(cb_frm_border.SelectedItem);
            data.backg_lay = GetEnum<ImageLayout>(cb_frm_imglay.SelectedItem);
            //GameStyle
            data.gm_text_align = GetEnum<ContentAlignment>(cb_gm_textalign.SelectedItem);
            data.gm_img_align = GetEnum<ContentAlignment>(cb_gm_ic_align.SelectedItem);
            data.gm_x = (int)nm_gm_x.Value;
            data.gm_y = (int)nm_gm_y.Value;
            data.gm_width = (int)nm_gm_w.Value;
            data.gm_height = (int)nm_gm_h.Value;
            data.gm_right = (int)nm_gm_mx.Value;
            data.gm_bottom = (int)nm_gm_my.Value;
            data.gm_ic_w = (int)nm_gm_ic_w.Value;
            data.gm_ic_h = (int)nm_gm_ic_h.Value;
            data.gm_close = ch_gm_close.Checked;
            data.gm_snd_wait = (int)nm_gm_snd_wait.Value;
            data.gm_gen_mode = cb_gm_cr.SelectedIndex == 0;
            data.gm_gen_elem = (int)nm_gm_cr.Value;
            data.gm_font = gm_fnt;
            data.gm_foreg_col = lb_gm_fg_n.BackColor;
            data.gm_foreg_dyn = ch_gm_fg_dyn.Checked;
            data.gm_foreg_h = ch_gm_fg_h.Checked;
            data.gm_foreg_col_h = lb_gm_fg_h.BackColor;
            data.gm_foreg_c = ch_gm_fg_c.Checked;
            data.gm_foreg_col_c = lb_gm_fg_c.BackColor;
            data.gm_backg = ch_gm_col_n.Checked;
            data.gm_backg_col = ch_gm_col_tr.Checked ? Color.Transparent : lb_gm_col_n.BackColor;
            data.gm_backg_dyn = ch_gm_col_dyn.Checked;
            data.gm_backg_h = ch_gm_col_h.Checked;
            data.gm_backg_col_h = lb_gm_col_h.BackColor;
            data.gm_backg_c = ch_gm_col_c.Checked;
            data.gm_backg_col_c = lb_gm_col_c.BackColor;
            data.gm_border = ch_gm_border_n.Checked;
            data.gm_border_col = ch_gm_border_tr.Checked ? Color.Transparent : lb_gm_border_n.BackColor;
            data.gm_border_dyn = ch_gm_border_dyn.Checked;
            data.gm_border_h = ch_gm_border_h.Checked;
            data.gm_border_col_h = lb_gm_border_h.BackColor;
            data.gm_border_c = ch_gm_border_c.Checked;
            data.gm_border_col_c = lb_gm_border_c.BackColor;
            data.gm_snd_hover = ch_gm_snd_h.Checked;
            data.gm_snd_h = gm_snd_h;
            data.gm_snd_click = ch_gm_snd_c.Checked;
            data.gm_snd_c = gm_snd_c;
        }

        private void UpdateStyleData()
        {
            PreviewStyle();
            Data_Form.CopyData(Data_Form.inst_tmp, Data_Form.inst);
            Data_Form.inst.Save();
            MainForm.inst.UpdateStyle();
            ChangedData(false);
        }

        private void ChangedData(bool input)
        {
            if (input == changed_data) return;
            changed_data = input;
            ts_info.Text = input ? "Data not saved" : "Data saved";
        }

        private void SaveChanges()
        {
            if (Program.ShowQuestion("Save changes?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                UpdateStyleData();
        }

        private void FillComboWithEnum<T>(ComboBox cb)
        {
            cb.Items.AddRange(Enum.GetNames(typeof(T)));
            cb.SelectedIndex = 0;
        }

        private T GetEnum<T>(object input)
        {
            if (input == null) return default(T);
            return (T)Enum.Parse(typeof(T), (string)input);
        }
    }
}