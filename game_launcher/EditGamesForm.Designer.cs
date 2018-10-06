namespace game_launcher
{
    partial class EditGamesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbx_games = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bt_add = new System.Windows.Forms.Button();
            this.tb_target = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_icon = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_work = new System.Windows.Forms.TextBox();
            this.dl_file = new System.Windows.Forms.OpenFileDialog();
            this.bt_target = new System.Windows.Forms.Button();
            this.bt_icon = new System.Windows.Forms.Button();
            this.bt_work = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.bt_del = new System.Windows.Forms.Button();
            this.bt_up = new System.Windows.Forms.Button();
            this.bt_down = new System.Windows.Forms.Button();
            this.bt_upd = new System.Windows.Forms.Button();
            this.bt_save = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.tb_params = new System.Windows.Forms.TextBox();
            this.dl_ico = new System.Windows.Forms.OpenFileDialog();
            this.dl_fld = new System.Windows.Forms.FolderBrowserDialog();
            this.bt_new = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ts_info = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbx_games
            // 
            this.lbx_games.AllowDrop = true;
            this.lbx_games.FormattingEnabled = true;
            this.lbx_games.Location = new System.Drawing.Point(12, 29);
            this.lbx_games.Name = "lbx_games";
            this.lbx_games.Size = new System.Drawing.Size(520, 108);
            this.lbx_games.TabIndex = 0;
            this.lbx_games.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbx_games_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Games";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 195);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Properties";
            // 
            // bt_add
            // 
            this.bt_add.Location = new System.Drawing.Point(82, 143);
            this.bt_add.Name = "bt_add";
            this.bt_add.Size = new System.Drawing.Size(64, 24);
            this.bt_add.TabIndex = 2;
            this.bt_add.Text = "Add";
            this.bt_add.UseVisualStyleBackColor = true;
            this.bt_add.Click += new System.EventHandler(this.bt_games_Click);
            // 
            // tb_target
            // 
            this.tb_target.Location = new System.Drawing.Point(12, 277);
            this.tb_target.Name = "tb_target";
            this.tb_target.Size = new System.Drawing.Size(490, 20);
            this.tb_target.TabIndex = 8;
            this.tb_target.TextChanged += new System.EventHandler(this.tb_name_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 261);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Target";
            // 
            // tb_icon
            // 
            this.tb_icon.Location = new System.Drawing.Point(12, 355);
            this.tb_icon.Name = "tb_icon";
            this.tb_icon.Size = new System.Drawing.Size(490, 20);
            this.tb_icon.TabIndex = 11;
            this.tb_icon.TextChanged += new System.EventHandler(this.tb_name_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 339);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Icon (optional)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 378);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Working directory (optional)";
            // 
            // tb_work
            // 
            this.tb_work.Location = new System.Drawing.Point(12, 394);
            this.tb_work.Name = "tb_work";
            this.tb_work.Size = new System.Drawing.Size(490, 20);
            this.tb_work.TabIndex = 13;
            this.tb_work.TextChanged += new System.EventHandler(this.tb_name_TextChanged);
            // 
            // bt_target
            // 
            this.bt_target.Location = new System.Drawing.Point(508, 277);
            this.bt_target.Name = "bt_target";
            this.bt_target.Size = new System.Drawing.Size(24, 20);
            this.bt_target.TabIndex = 9;
            this.bt_target.Text = "...";
            this.bt_target.UseVisualStyleBackColor = true;
            this.bt_target.Click += new System.EventHandler(this.bt_filedial_Click);
            // 
            // bt_icon
            // 
            this.bt_icon.Location = new System.Drawing.Point(508, 355);
            this.bt_icon.Name = "bt_icon";
            this.bt_icon.Size = new System.Drawing.Size(24, 20);
            this.bt_icon.TabIndex = 12;
            this.bt_icon.Text = "...";
            this.bt_icon.UseVisualStyleBackColor = true;
            this.bt_icon.Click += new System.EventHandler(this.bt_filedial_Click);
            // 
            // bt_work
            // 
            this.bt_work.Location = new System.Drawing.Point(508, 394);
            this.bt_work.Name = "bt_work";
            this.bt_work.Size = new System.Drawing.Size(24, 20);
            this.bt_work.TabIndex = 14;
            this.bt_work.Text = "...";
            this.bt_work.UseVisualStyleBackColor = true;
            this.bt_work.Click += new System.EventHandler(this.bt_filedial_Click);
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Location = new System.Drawing.Point(0, 182);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(544, 2);
            this.label6.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 221);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Name";
            // 
            // tb_name
            // 
            this.tb_name.Location = new System.Drawing.Point(12, 237);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(490, 20);
            this.tb_name.TabIndex = 7;
            this.tb_name.TextChanged += new System.EventHandler(this.tb_name_TextChanged);
            // 
            // bt_del
            // 
            this.bt_del.Location = new System.Drawing.Point(152, 143);
            this.bt_del.Name = "bt_del";
            this.bt_del.Size = new System.Drawing.Size(64, 24);
            this.bt_del.TabIndex = 3;
            this.bt_del.Text = "Delete";
            this.bt_del.UseVisualStyleBackColor = true;
            this.bt_del.Click += new System.EventHandler(this.bt_games_Click);
            // 
            // bt_up
            // 
            this.bt_up.Location = new System.Drawing.Point(430, 143);
            this.bt_up.Name = "bt_up";
            this.bt_up.Size = new System.Drawing.Size(48, 24);
            this.bt_up.TabIndex = 5;
            this.bt_up.Text = "Up";
            this.bt_up.UseVisualStyleBackColor = true;
            this.bt_up.Click += new System.EventHandler(this.bt_games_Click);
            // 
            // bt_down
            // 
            this.bt_down.Location = new System.Drawing.Point(484, 143);
            this.bt_down.Name = "bt_down";
            this.bt_down.Size = new System.Drawing.Size(48, 24);
            this.bt_down.TabIndex = 6;
            this.bt_down.Text = "Down";
            this.bt_down.UseVisualStyleBackColor = true;
            this.bt_down.Click += new System.EventHandler(this.bt_games_Click);
            // 
            // bt_upd
            // 
            this.bt_upd.Location = new System.Drawing.Point(222, 143);
            this.bt_upd.Name = "bt_upd";
            this.bt_upd.Size = new System.Drawing.Size(64, 24);
            this.bt_upd.TabIndex = 4;
            this.bt_upd.Text = "Update";
            this.bt_upd.UseVisualStyleBackColor = true;
            this.bt_upd.Click += new System.EventHandler(this.bt_games_Click);
            // 
            // bt_save
            // 
            this.bt_save.Location = new System.Drawing.Point(468, 420);
            this.bt_save.Name = "bt_save";
            this.bt_save.Size = new System.Drawing.Size(64, 24);
            this.bt_save.TabIndex = 15;
            this.bt_save.Text = "Save";
            this.bt_save.UseVisualStyleBackColor = true;
            this.bt_save.Click += new System.EventHandler(this.bt_save_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 300);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(144, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Launch parameters (optional)";
            // 
            // tb_params
            // 
            this.tb_params.Location = new System.Drawing.Point(12, 316);
            this.tb_params.Name = "tb_params";
            this.tb_params.Size = new System.Drawing.Size(490, 20);
            this.tb_params.TabIndex = 10;
            this.tb_params.TextChanged += new System.EventHandler(this.tb_name_TextChanged);
            // 
            // dl_ico
            // 
            this.dl_ico.Filter = "Icons|*.bmp;*.png;*.gif;*.jpg;*.jpeg;*.ico;*.exe;*.dll|All files|*.*";
            // 
            // bt_new
            // 
            this.bt_new.Location = new System.Drawing.Point(12, 143);
            this.bt_new.Name = "bt_new";
            this.bt_new.Size = new System.Drawing.Size(64, 24);
            this.bt_new.TabIndex = 1;
            this.bt_new.Text = "New";
            this.bt_new.UseVisualStyleBackColor = true;
            this.bt_new.Click += new System.EventHandler(this.bt_games_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_info});
            this.statusStrip1.Location = new System.Drawing.Point(0, 450);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(544, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ts_info
            // 
            this.ts_info.Name = "ts_info";
            this.ts_info.Size = new System.Drawing.Size(0, 17);
            // 
            // EditGamesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 472);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tb_work);
            this.Controls.Add(this.tb_icon);
            this.Controls.Add(this.tb_name);
            this.Controls.Add(this.tb_params);
            this.Controls.Add(this.tb_target);
            this.Controls.Add(this.bt_work);
            this.Controls.Add(this.bt_icon);
            this.Controls.Add(this.bt_target);
            this.Controls.Add(this.bt_down);
            this.Controls.Add(this.bt_up);
            this.Controls.Add(this.bt_new);
            this.Controls.Add(this.bt_save);
            this.Controls.Add(this.bt_upd);
            this.Controls.Add(this.bt_del);
            this.Controls.Add(this.bt_add);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbx_games);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditGamesForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Games";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditGamesForm_FormClosing);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbx_games;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bt_add;
        private System.Windows.Forms.TextBox tb_target;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_icon;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_work;
        private System.Windows.Forms.OpenFileDialog dl_file;
        private System.Windows.Forms.Button bt_target;
        private System.Windows.Forms.Button bt_icon;
        private System.Windows.Forms.Button bt_work;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_name;
        private System.Windows.Forms.Button bt_del;
        private System.Windows.Forms.Button bt_up;
        private System.Windows.Forms.Button bt_down;
        private System.Windows.Forms.Button bt_upd;
        private System.Windows.Forms.Button bt_save;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tb_params;
        private System.Windows.Forms.OpenFileDialog dl_ico;
        private System.Windows.Forms.FolderBrowserDialog dl_fld;
        private System.Windows.Forms.Button bt_new;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel ts_info;

    }
}