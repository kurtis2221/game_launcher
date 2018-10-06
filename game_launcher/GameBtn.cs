using System;
using System.Drawing;
using System.Windows.Forms;
using System.Media;
using System.Diagnostics;

namespace game_launcher
{
    class GameBtn : Label
    {
        //Enable features
        public static bool enable_fg;
        public static bool enable_fg_h;
        public static bool enable_fg_c;
        public static bool enable_bg;
        public static bool enable_bg_h;
        public static bool enable_bg_c;
        public static bool enable_snd_h;
        public static bool enable_snd_c;
        public static bool enable_border;
        public static bool enable_border_h;
        public static bool enable_border_c;
        public static bool enable_dynborder;

        //Dynamic text
        public static Color fg_sel;
        public static Color fg_unsel;
        public static Color fg_click;

        //Dynamic background
        public static Color bg_sel;
        public static Color bg_unsel;
        public static Color bg_click;

        //Dynamic border
        public static Brush border_sel;
        public static Brush border_unsel;
        public static Brush border_click;
        public Brush border_curr;

        //Enter and click events
        public static SoundPlayer snd_sel;
        public static SoundPlayer snd_click;

        public static bool test_mode;

        //Game ref
        public Data_Games game;

        protected override void OnMouseEnter(EventArgs e)
        {
            OnHover(true);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            if (enable_fg && enable_fg_h) ForeColor = fg_unsel;
            if (enable_bg && enable_bg_h) BackColor = bg_unsel;
            if (enable_dynborder && enable_border_h)
            {
                border_curr = border_unsel;
                Invalidate();
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (enable_fg && enable_fg_c) ForeColor = fg_click;
                if (enable_bg && enable_bg_c) BackColor = bg_click;
                if (enable_dynborder && enable_border_c)
                {
                    border_curr = border_click;
                    Invalidate();
                }
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (enable_dynborder)
                {
                    if (enable_border_h) OnHover(false);
                    else if (enable_border_c)
                    {
                        border_curr = border_unsel;
                        Invalidate();
                    }
                }
                if (enable_snd_c) snd_click.Play();
                //Launch process
                if (test_mode) return;
                try
                {
                    Process proc = new Process();
                    ProcessStartInfo proc_info = new ProcessStartInfo();
                    proc_info.FileName = game.target;
                    if (game.launch_pars.Length > 0) proc_info.Arguments = game.launch_pars;
                    proc_info.WorkingDirectory = game.work_dir.Length > 0 ? game.work_dir :
                        System.IO.Path.GetDirectoryName(game.target);
                    proc.StartInfo = proc_info;
                    proc.Start();
                    if (Data_Form.inst.gm_close)
                    {
                        System.Threading.Thread.Sleep(Data_Form.inst.gm_snd_wait);
                        Application.Exit();
                    }
                }
                catch (Exception ex)
                {
                    Program.ShowError(ex);
                }
            }
        }

        private void OnHover(bool playsnd)
        {
            if (enable_fg && enable_fg_h) ForeColor = fg_sel;
            if (enable_bg && enable_bg_h) BackColor = bg_sel;
            if (enable_snd_h && playsnd) snd_sel.Play();
            if (enable_dynborder && enable_border_h)
            {
                border_curr = border_sel;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (enable_border && border_curr != null)
            {
                Graphics g = e.Graphics;
                g.FillRectangle(border_curr, 0, 0, Width, 2);
                g.FillRectangle(border_curr, 0, 2, 2, Height);
                g.FillRectangle(border_curr, 0, Height - 2, Width, 2);
                g.FillRectangle(border_curr, Width - 2, 0, 2, Height);
            }
            base.OnPaint(e);
        }
    }
}