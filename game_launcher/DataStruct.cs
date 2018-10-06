using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Media;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace game_launcher
{
    class Data_Form
    {
        //Config file
        private const string FILE_CONFIG = "game_launcher.ini";
        private const string FILE_CONFIGTMP = FILE_CONFIG + ".tmp";

        //Delimiters
        public static char[] CHR_DELIM = { ';' };
        public const string STR_DELIM = ";";

        public static Data_Form inst = new Data_Form();
        public static Data_Form inst_tmp;

        //Form style
        public string title = Program.TITLE;
        public FormStartPosition startpos = FormStartPosition.CenterScreen;
        public int x = 0, y = 0, width = 320, height = 240;
        public bool background;
        public Color backg_col;
        public bool background_img;
        public string backg_img;
        public int opacity = 100;
        public bool transkey;
        public Color trank_col;
        public FormBorderStyle border = FormBorderStyle.FixedSingle;
        public ImageLayout backg_lay = ImageLayout.None;

        //Game style
        //Placement, alignment
        public ContentAlignment gm_text_align = ContentAlignment.TopLeft;
        public ContentAlignment gm_img_align = ContentAlignment.TopLeft;
        public int gm_x = 12, gm_y = 12, gm_width = 128, gm_height = 32, gm_right = 4, gm_bottom = 4;
        //Icon size
        public int gm_ic_w = 24, gm_ic_h = 24;
        //Close after launch
        public bool gm_close;
        public int gm_snd_wait;
        //Generation mode (column, row)
        public bool gm_gen_mode = false;
        public int gm_gen_elem = 1;
        //Font
        public Font gm_font = new Font(FontFamily.GenericSansSerif, 12);
        //Foreground
        public Color gm_foreg_col;
        public bool gm_foreg_dyn;
        public bool gm_foreg_h;
        public Color gm_foreg_col_h;
        public bool gm_foreg_c;
        public Color gm_foreg_col_c;
        //Background
        public bool gm_backg;
        public Color gm_backg_col;
        public bool gm_backg_dyn;
        public bool gm_backg_h;
        public Color gm_backg_col_h;
        public bool gm_backg_c;
        public Color gm_backg_col_c;
        //Border
        public bool gm_border;
        public Color gm_border_col;
        public bool gm_border_dyn;
        public bool gm_border_h;
        public Color gm_border_col_h;
        public bool gm_border_c;
        public Color gm_border_col_c;
        //Sound
        public bool gm_snd_hover;
        public string gm_snd_h;
        public bool gm_snd_click;
        public string gm_snd_c;

        public static List<Data_Games> game_list = new List<Data_Games>();

        public void Load()
        {
            try
            {
                //Restore if temp backup exists
                if (File.Exists(FILE_CONFIGTMP))
                {
                    if (File.Exists(FILE_CONFIG)) File.Delete(FILE_CONFIG);
                    File.Move(FILE_CONFIGTMP, FILE_CONFIG);
                }
                if (File.Exists(FILE_CONFIG))
                    using (StreamReader sr = new StreamReader(FILE_CONFIG, Encoding.Default))
                        LoadFile(sr);
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void LoadFile(StreamReader sr)
        {
            Data_Games game;
            string[] tmp;
            int tmpenum;
            float tmpfl;
            //Form style
            //Text
            title = sr.ReadLine();
            //Bounds
            tmp = sr.ReadLine().Split(CHR_DELIM);
            int.TryParse(tmp[0], out x);
            int.TryParse(tmp[1], out y);
            int.TryParse(tmp[2], out width);
            int.TryParse(tmp[3], out height);
            //Background
            tmp = sr.ReadLine().Split(CHR_DELIM);
            bool.TryParse(tmp[0], out background);
            backg_col = HexToColor(tmp[1]);
            bool.TryParse(tmp[2], out background_img);
            backg_img = tmp[3];
            //Transparency
            tmp = sr.ReadLine().Split(CHR_DELIM);
            if (!int.TryParse(tmp[0], out opacity)) opacity = 100;
            bool.TryParse(tmp[1], out transkey);
            trank_col = HexToColor(tmp[2]);
            //Start pos, border style, bacground image layout
            tmp = sr.ReadLine().Split(CHR_DELIM);
            if (int.TryParse(tmp[0], out tmpenum))
                startpos = (FormStartPosition)tmpenum;
            if (int.TryParse(tmp[1], out tmpenum))
                border = (FormBorderStyle)tmpenum;
            if (int.TryParse(tmp[2], out tmpenum))
                backg_lay = (ImageLayout)tmpenum;
            //Game style
            //Alignment
            tmp = sr.ReadLine().Split(CHR_DELIM);
            if (int.TryParse(tmp[0], out tmpenum))
                gm_text_align = (ContentAlignment)tmpenum;
            if (int.TryParse(tmp[1], out tmpenum))
                gm_img_align = (ContentAlignment)tmpenum;
            //Bounds, margin
            tmp = sr.ReadLine().Split(CHR_DELIM);
            int.TryParse(tmp[0], out gm_x);
            int.TryParse(tmp[1], out gm_y);
            int.TryParse(tmp[2], out gm_width);
            int.TryParse(tmp[3], out gm_height);
            int.TryParse(tmp[4], out gm_right);
            int.TryParse(tmp[5], out gm_bottom);
            //Column or row, how many elements
            bool.TryParse(tmp[6], out gm_gen_mode);
            if (!int.TryParse(tmp[7], out gm_gen_elem)) gm_gen_elem = 1;
            //Icon size, close on launch
            tmp = sr.ReadLine().Split(CHR_DELIM);
            int.TryParse(tmp[0], out gm_ic_w);
            int.TryParse(tmp[1], out gm_ic_h);
            bool.TryParse(tmp[2], out gm_close);
            int.TryParse(tmp[3], out gm_snd_wait);
            //Font
            tmp = sr.ReadLine().Split(CHR_DELIM);
            if (!float.TryParse(tmp[1], out tmpfl)) tmpfl = 10;
            if (!int.TryParse(tmp[2], out tmpenum)) tmpenum = 0;
            gm_font = new Font(tmp[0], tmpfl, (FontStyle)tmpenum);
            //Text
            tmp = sr.ReadLine().Split(CHR_DELIM);
            gm_foreg_col = Data_Form.HexToColor(tmp[0]);
            bool.TryParse(tmp[1], out gm_foreg_dyn);
            bool.TryParse(tmp[2], out gm_foreg_h);
            gm_foreg_col_h = Data_Form.HexToColor(tmp[3]);
            bool.TryParse(tmp[4], out gm_foreg_c);
            gm_foreg_col_c = Data_Form.HexToColor(tmp[5]);
            //Background
            tmp = sr.ReadLine().Split(CHR_DELIM);
            bool.TryParse(tmp[0], out gm_backg);
            gm_backg_col = Data_Form.HexToColor(tmp[1]);
            bool.TryParse(tmp[2], out gm_backg_dyn);
            bool.TryParse(tmp[3], out gm_backg_h);
            gm_backg_col_h = Data_Form.HexToColor(tmp[4]);
            bool.TryParse(tmp[5], out gm_backg_c);
            gm_backg_col_c = Data_Form.HexToColor(tmp[6]);
            //Border
            tmp = sr.ReadLine().Split(CHR_DELIM);
            bool.TryParse(tmp[0], out gm_border);
            gm_border_col = Data_Form.HexToColor(tmp[1]);
            bool.TryParse(tmp[2], out gm_border_dyn);
            bool.TryParse(tmp[3], out gm_border_h);
            gm_border_col_h = Data_Form.HexToColor(tmp[4]);
            bool.TryParse(tmp[5], out gm_border_c);
            gm_border_col_c = Data_Form.HexToColor(tmp[6]);
            //Sounds
            tmp = sr.ReadLine().Split(CHR_DELIM);
            bool.TryParse(tmp[0], out gm_snd_hover);
            gm_snd_h = tmp[1];
            tmp = sr.ReadLine().Split(CHR_DELIM);
            bool.TryParse(tmp[0], out gm_snd_click);
            gm_snd_c = tmp[1];
            //Game list
            game_list.Clear();
            while (sr.Peek() > -1)
            {
                game = new Data_Games();
                sr.ReadLine();
                game.name = sr.ReadLine();
                game.target = sr.ReadLine();
                game.launch_pars = sr.ReadLine();
                game.icon = sr.ReadLine();
                game.work_dir = sr.ReadLine();
                game_list.Add(game);
            }
        }

        public void Save()
        {
            try
            {
                //Temp backup
                if (File.Exists(FILE_CONFIG))
                {
                    if (File.Exists(FILE_CONFIGTMP)) File.Delete(FILE_CONFIGTMP);
                    File.Move(FILE_CONFIG, FILE_CONFIGTMP);
                }
                using (StreamWriter sw = new StreamWriter(FILE_CONFIG, false, Encoding.Default))
                    SaveFile(sw);
                //Delete temp backup
                if (File.Exists(FILE_CONFIGTMP)) File.Delete(FILE_CONFIGTMP);
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void SaveFile(StreamWriter sw)
        {
            //Form style
            //Text
            sw.WriteLine(title);
            //Bounds
            sw.WriteLine(x + STR_DELIM + y + STR_DELIM + width + STR_DELIM + height);
            //Background
            sw.WriteLine(background + STR_DELIM + ColorToHex(backg_col) + STR_DELIM +
                background_img + STR_DELIM + backg_img);
            //Transparency
            sw.WriteLine(opacity + STR_DELIM + transkey + STR_DELIM + ColorToHex(trank_col));
            //Start pos, border style, bacground image layout
            sw.WriteLine((int)startpos + STR_DELIM + (int)border + STR_DELIM + (int)backg_lay);
            //Game style
            //Alignment
            sw.WriteLine((int)gm_text_align + STR_DELIM + (int)gm_img_align);
            //Bounds, margin
            sw.WriteLine(gm_x + STR_DELIM + gm_y + STR_DELIM + gm_width + STR_DELIM + gm_height + STR_DELIM +
                gm_right + STR_DELIM + gm_bottom + STR_DELIM + gm_gen_mode + STR_DELIM + gm_gen_elem);
            //Icon size, close on launch
            sw.WriteLine(gm_ic_w + STR_DELIM + gm_ic_h + STR_DELIM + gm_close + STR_DELIM + gm_snd_wait);
            //Font
            sw.WriteLine(gm_font.FontFamily.Name + STR_DELIM + gm_font.Size + STR_DELIM + (int)gm_font.Style);
            //Text
            sw.WriteLine(Data_Form.ColorToHex(gm_foreg_col) + STR_DELIM +
                gm_foreg_dyn + STR_DELIM + gm_foreg_h + STR_DELIM + Data_Form.ColorToHex(gm_foreg_col_h) +
                STR_DELIM + gm_foreg_c + STR_DELIM + Data_Form.ColorToHex(gm_foreg_col_c));
            //Background
            sw.WriteLine(gm_backg + STR_DELIM + Data_Form.ColorToHex(gm_backg_col) + STR_DELIM +
                gm_backg_dyn + STR_DELIM + gm_backg_h + STR_DELIM + Data_Form.ColorToHex(gm_backg_col_h) +
                STR_DELIM + gm_backg_c + STR_DELIM + Data_Form.ColorToHex(gm_backg_col_c));
            //Border
            sw.WriteLine(gm_border + STR_DELIM + Data_Form.ColorToHex(gm_border_col) + STR_DELIM +
                gm_border_dyn + STR_DELIM + gm_border_h + STR_DELIM + Data_Form.ColorToHex(gm_border_col_h) +
                STR_DELIM + gm_border_c + STR_DELIM + Data_Form.ColorToHex(gm_border_col_c));
            //Sounds
            sw.WriteLine(gm_snd_hover + STR_DELIM + gm_snd_h);
            sw.WriteLine(gm_snd_click + STR_DELIM + gm_snd_c);
            //Game list
            foreach (Data_Games game in game_list)
            {
                sw.WriteLine("---");
                sw.WriteLine(game.name);
                sw.WriteLine(game.target);
                sw.WriteLine(game.launch_pars);
                sw.WriteLine(game.icon);
                sw.WriteLine(game.work_dir);
            }
        }

        public static void UpdateStyle(Control cont, List<GameBtn> games, Data_Form stl)
        {
            cont.SuspendLayout();
            bool isform = cont is Form;
            //Form
            cont.Text = stl.title;
            if (stl.background) cont.BackColor = stl.backg_col;
            try
            {
                if (stl.background_img) cont.BackgroundImage = new Bitmap(stl.backg_img);
            }
            catch (Exception ex)
            {
                Program.ShowWarning("Background image error: " + ex.Message, MessageBoxButtons.OK);
            }
            if (isform)
            {
                Form frm = (Form)cont;
                frm.Bounds = new Rectangle(stl.x, stl.y, stl.width, stl.height);
                frm.StartPosition = stl.startpos;
                frm.Opacity = (double)stl.opacity / 100;
                if (stl.transkey) frm.TransparencyKey = stl.trank_col;
                frm.FormBorderStyle = stl.border;
            }
            cont.BackgroundImageLayout = stl.backg_lay;
            //Games
            GameBtn.enable_fg = stl.gm_foreg_dyn;
            GameBtn.fg_unsel = stl.gm_foreg_col;
            GameBtn.enable_fg_h = stl.gm_foreg_h;
            GameBtn.fg_sel = stl.gm_foreg_col_h;
            GameBtn.enable_fg_c = stl.gm_foreg_c;
            GameBtn.fg_click = stl.gm_foreg_col_c;
            GameBtn.enable_bg = stl.gm_backg_dyn;
            GameBtn.bg_unsel = stl.gm_backg_col;
            GameBtn.enable_bg_h = stl.gm_backg_h;
            GameBtn.bg_sel = stl.gm_backg_col_h;
            GameBtn.enable_bg_c = stl.gm_backg_c;
            GameBtn.bg_click = stl.gm_backg_col_c;
            GameBtn.enable_border = stl.gm_border;
            GameBtn.border_unsel = new SolidBrush(stl.gm_border_col);
            GameBtn.enable_border_h = stl.gm_border_h;
            GameBtn.border_sel = new SolidBrush(stl.gm_border_col_h);
            GameBtn.enable_border_c = stl.gm_border_c;
            GameBtn.border_click = new SolidBrush(stl.gm_border_col_c);
            GameBtn.enable_dynborder = stl.gm_border_dyn;
            GameBtn.enable_snd_h = stl.gm_snd_hover;
            GameBtn.enable_snd_c = stl.gm_snd_click;
            if (stl.gm_snd_hover) GameBtn.snd_sel = new SoundPlayer(stl.gm_snd_h);
            if (stl.gm_snd_click) GameBtn.snd_click = new SoundPlayer(stl.gm_snd_c);
            //Game list
            GameBtn btn;
            if (games.Count != game_list.Count)
            {
                cont.Controls.Clear();
                games.Clear();
                for (int i = 0; i < (isform || game_list.Count < 4 ? game_list.Count : 4); i++)
                {
                    btn = new GameBtn();
                    games.Add(btn);
                    cont.Controls.Add(btn);
                }
            }
            bool border = stl.gm_border;
            for (int i = 0; i < games.Count; i++)
            {
                btn = games[i];
                if (stl.gm_gen_mode)
                    btn.Bounds = new Rectangle(
                        stl.gm_x + ((stl.gm_width + stl.gm_right) * (i % stl.gm_gen_elem)),
                        stl.gm_y + ((stl.gm_height + stl.gm_bottom) * (i / stl.gm_gen_elem)),
                        stl.gm_width, stl.gm_height);
                else
                    btn.Bounds = new Rectangle(
                        stl.gm_x + ((stl.gm_width + stl.gm_right) * (i / stl.gm_gen_elem)),
                        stl.gm_y + ((stl.gm_height + stl.gm_bottom) * (i % stl.gm_gen_elem)),
                        stl.gm_width, stl.gm_height);
                //Style
                btn.TextAlign = stl.gm_text_align;
                btn.ImageAlign = stl.gm_img_align;
                btn.Font = stl.gm_font;
                btn.ForeColor = stl.gm_foreg_col;
                if (border) btn.border_curr = GameBtn.border_unsel;
                if (stl.gm_backg) btn.BackColor = stl.gm_backg_col;
                else btn.BackColor = Color.Empty;
                //Text
                UpdateGame(games[i], game_list[i], stl.gm_ic_w, stl.gm_ic_h);
            }
            cont.ResumeLayout(false);
        }

        private static void UpdateGame(GameBtn btn, Data_Games game, int width, int height)
        {
            btn.game = game;
            btn.Text = game.name;
            string icon = game.icon;
            if (icon.Length > 0)
            {
                try
                {
                    int idx = icon.LastIndexOf('.') + 1;
                    if (idx == 0) return;
                    switch (icon.Substring(idx).ToLower())
                    {
                        case "ico":
                        case "exe":
                        case "dll":
                            btn.Image = new Bitmap(Icon.ExtractAssociatedIcon(icon).ToBitmap(), width, height);
                            break;
                        default:
                            btn.Image = new Bitmap(new Bitmap(icon), width, height);
                            break;
                    }
                }
                catch
                {
                }
            }
        }

        public static string ColorToHex(Color col)
        {
            return col.ToArgb().ToString("X8");
        }

        public static Color HexToColor(string hex)
        {
            return Color.FromArgb(int.Parse(hex, System.Globalization.NumberStyles.HexNumber));
        }

        public static void CopyData(Data_Form src, Data_Form trg)
        {
            trg.title = src.title;
            trg.startpos = src.startpos;
            trg.x = src.x;
            trg.y = src.y;
            trg.width = src.width;
            trg.height = src.height;
            trg.background = src.background;
            trg.backg_col = src.backg_col;
            trg.background_img = src.background_img;
            trg.backg_img = src.backg_img;
            trg.opacity = src.opacity;
            trg.transkey = src.transkey;
            trg.trank_col = src.trank_col;
            trg.border = src.border;
            trg.backg_lay = src.backg_lay;
            trg.gm_text_align = src.gm_text_align;
            trg.gm_img_align = src.gm_img_align;
            trg.gm_x = src.gm_x;
            trg.gm_y = src.gm_y;
            trg.gm_width = src.gm_width;
            trg.gm_height = src.gm_height;
            trg.gm_right = src.gm_right;
            trg.gm_bottom = src.gm_bottom;
            trg.gm_ic_w = src.gm_ic_w;
            trg.gm_ic_h = src.gm_ic_h;
            trg.gm_close = src.gm_close;
            trg.gm_snd_wait = src.gm_snd_wait;
            trg.gm_gen_mode = src.gm_gen_mode;
            trg.gm_gen_elem = src.gm_gen_elem;
            trg.gm_font = src.gm_font;
            trg.gm_foreg_col = src.gm_foreg_col;
            trg.gm_foreg_dyn = src.gm_foreg_dyn;
            trg.gm_foreg_h = src.gm_foreg_h;
            trg.gm_foreg_col_h = src.gm_foreg_col_h;
            trg.gm_foreg_c = src.gm_foreg_c;
            trg.gm_foreg_col_c = src.gm_foreg_col_c;
            trg.gm_backg = src.gm_backg;
            trg.gm_backg_col = src.gm_backg_col;
            trg.gm_backg_dyn = src.gm_backg_dyn;
            trg.gm_backg_h = src.gm_backg_h;
            trg.gm_backg_col_h = src.gm_backg_col_h;
            trg.gm_backg_c = src.gm_backg_c;
            trg.gm_backg_col_c = src.gm_backg_col_c;
            trg.gm_border = src.gm_border;
            trg.gm_border_col = src.gm_border_col;
            trg.gm_border_dyn = src.gm_border_dyn;
            trg.gm_border_h = src.gm_border_h;
            trg.gm_border_col_h = src.gm_border_col_h;
            trg.gm_border_c = src.gm_border_c;
            trg.gm_border_col_c = src.gm_border_col_c;
            trg.gm_snd_hover = src.gm_snd_hover;
            trg.gm_snd_h = src.gm_snd_h;
            trg.gm_snd_click = src.gm_snd_click;
            trg.gm_snd_c = src.gm_snd_c;
        }
    }

    class Data_Games
    {
        public string name;
        public string target;
        public string launch_pars;
        public string icon;
        public string work_dir;
    }
}