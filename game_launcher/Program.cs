using System;
using System.Drawing;
using System.Windows.Forms;
using System.Media;
using System.Collections.Generic;

namespace game_launcher
{
    class MainForm : Form
    {
        MenuItem mi_games;
        MenuItem mi_style;
        MenuItem mi_exit;
        List<GameBtn> game_btns = new List<GameBtn>();

        public static MainForm inst;

        public MainForm()
        {
            MaximizeBox = false;
            SuspendLayout();
            mi_games = new MenuItem("Edit games", MenuClick);
            mi_style = new MenuItem("Edit style", MenuClick);
            mi_exit = new MenuItem("Exit", MenuClick);
            ContextMenu = new ContextMenu(new MenuItem[] { mi_games, mi_style, mi_exit });
            Data_Form.inst.Load();
            UpdateStyle();
            ResumeLayout(false);
        }

        private void MenuClick(object sender, EventArgs e)
        {
            if (sender == mi_games) new EditGamesForm().ShowDialog();
            else if (sender == mi_style) new EditStyleForm().ShowDialog();
            else Application.Exit();
        }

        public void UpdateStyle()
        {
            Data_Form.UpdateStyle(this, game_btns, Data_Form.inst);
        }
    }

    static class Program
    {
        public const string TITLE = "Game Launcher";

        [STAThread]
        static void Main()
        {
            //Compatibility
            System.Threading.Thread.CurrentThread.CurrentCulture =
                System.Globalization.CultureInfo.InvariantCulture;
            //
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm.inst = new MainForm();
            Application.Run(MainForm.inst);
        }

        public static void ShowInfo(string msg)
        {
            MessageBox.Show(msg, TITLE, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult ShowQuestion(string msg, MessageBoxButtons btn)
        {
            return MessageBox.Show(msg, TITLE, btn, MessageBoxIcon.Question);
        }

        public static DialogResult ShowWarning(string msg, MessageBoxButtons btn)
        {
            return MessageBox.Show(msg, TITLE, btn, MessageBoxIcon.Warning);
        }

        public static void ShowError(Exception ex)
        {
            MessageBox.Show(ex.Message, TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}