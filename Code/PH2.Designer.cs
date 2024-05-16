using System.Drawing;
using System.Windows.Forms;

namespace DB_Management
{
    partial class PH2
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_hp = new System.Windows.Forms.Button();
            this.btn_phancong = new System.Windows.Forms.Button();
            this.btn_khm = new System.Windows.Forms.Button();
            this.btn_dangky = new System.Windows.Forms.Button();
            this.btn_sv = new System.Windows.Forms.Button();
            this.btn_donvi = new System.Windows.Forms.Button();
            this.btn_nhansu = new System.Windows.Forms.Button();
            this.content = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.btn_hp);
            this.panel1.Controls.Add(this.btn_phancong);
            this.panel1.Controls.Add(this.btn_khm);
            this.panel1.Controls.Add(this.btn_dangky);
            this.panel1.Controls.Add(this.btn_sv);
            this.panel1.Controls.Add(this.btn_donvi);
            this.panel1.Controls.Add(this.btn_nhansu);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(249, 720);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btn_hp
            // 
            this.btn_hp.BackColor = System.Drawing.Color.Aqua;
            this.btn_hp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_hp.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.btn_hp.ForeColor = System.Drawing.Color.Black;
            this.btn_hp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_hp.Location = new System.Drawing.Point(2, 223);
            this.btn_hp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_hp.Name = "btn_hp";
            this.btn_hp.Size = new System.Drawing.Size(241, 71);
            this.btn_hp.TabIndex = 7;
            this.btn_hp.Text = "Học phần";
            this.btn_hp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_hp.UseVisualStyleBackColor = false;
            this.btn_hp.Click += new System.EventHandler(this.btn_hp_Click);
            // 
            // btn_phancong
            // 
            this.btn_phancong.BackColor = System.Drawing.Color.Aqua;
            this.btn_phancong.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_phancong.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.btn_phancong.ForeColor = System.Drawing.Color.Black;
            this.btn_phancong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_phancong.Location = new System.Drawing.Point(-1, 373);
            this.btn_phancong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_phancong.Name = "btn_phancong";
            this.btn_phancong.Size = new System.Drawing.Size(241, 71);
            this.btn_phancong.TabIndex = 6;
            this.btn_phancong.Text = "Phân công";
            this.btn_phancong.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_phancong.UseVisualStyleBackColor = false;
            this.btn_phancong.Click += new System.EventHandler(this.btn_phancong_Click);
            // 
            // btn_khm
            // 
            this.btn_khm.BackColor = System.Drawing.Color.Aqua;
            this.btn_khm.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_khm.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.btn_khm.ForeColor = System.Drawing.Color.Black;
            this.btn_khm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_khm.Location = new System.Drawing.Point(-1, 448);
            this.btn_khm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_khm.Name = "btn_khm";
            this.btn_khm.Size = new System.Drawing.Size(241, 71);
            this.btn_khm.TabIndex = 5;
            this.btn_khm.Text = "Kế hoạch mở";
            this.btn_khm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_khm.UseVisualStyleBackColor = false;
            this.btn_khm.Click += new System.EventHandler(this.btn_khm_Click);
            // 
            // btn_dangky
            // 
            this.btn_dangky.BackColor = System.Drawing.Color.Aqua;
            this.btn_dangky.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_dangky.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.btn_dangky.ForeColor = System.Drawing.Color.Black;
            this.btn_dangky.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_dangky.Location = new System.Drawing.Point(2, 298);
            this.btn_dangky.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_dangky.Name = "btn_dangky";
            this.btn_dangky.Size = new System.Drawing.Size(241, 71);
            this.btn_dangky.TabIndex = 4;
            this.btn_dangky.Text = "Đăng ký";
            this.btn_dangky.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_dangky.UseVisualStyleBackColor = false;
            this.btn_dangky.Click += new System.EventHandler(this.btn_dangky_Click);
            // 
            // btn_sv
            // 
            this.btn_sv.BackColor = System.Drawing.Color.Aqua;
            this.btn_sv.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_sv.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.btn_sv.ForeColor = System.Drawing.Color.Black;
            this.btn_sv.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_sv.Location = new System.Drawing.Point(0, 72);
            this.btn_sv.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_sv.Name = "btn_sv";
            this.btn_sv.Size = new System.Drawing.Size(243, 71);
            this.btn_sv.TabIndex = 3;
            this.btn_sv.Text = "Sinh Viên";
            this.btn_sv.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_sv.UseVisualStyleBackColor = false;
            this.btn_sv.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_donvi
            // 
            this.btn_donvi.BackColor = System.Drawing.Color.Aqua;
            this.btn_donvi.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_donvi.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.btn_donvi.ForeColor = System.Drawing.Color.Black;
            this.btn_donvi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_donvi.Location = new System.Drawing.Point(-1, 148);
            this.btn_donvi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_donvi.Name = "btn_donvi";
            this.btn_donvi.Size = new System.Drawing.Size(241, 71);
            this.btn_donvi.TabIndex = 2;
            this.btn_donvi.Text = "Đơn vị";
            this.btn_donvi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_donvi.UseVisualStyleBackColor = false;
            this.btn_donvi.Click += new System.EventHandler(this.button3_Click);
            // 
            // btn_nhansu
            // 
            this.btn_nhansu.BackColor = System.Drawing.Color.Aqua;
            this.btn_nhansu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_nhansu.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.btn_nhansu.ForeColor = System.Drawing.Color.Black;
            this.btn_nhansu.Location = new System.Drawing.Point(3, 2);
            this.btn_nhansu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_nhansu.Name = "btn_nhansu";
            this.btn_nhansu.Size = new System.Drawing.Size(240, 66);
            this.btn_nhansu.TabIndex = 3;
            this.btn_nhansu.Text = "Nhân sự";
            this.btn_nhansu.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_nhansu.UseVisualStyleBackColor = false;
            this.btn_nhansu.Click += new System.EventHandler(this.button1_Click);
            // 
            // content
            // 
            this.content.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.content.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.content.ForeColor = System.Drawing.Color.White;
            this.content.Location = new System.Drawing.Point(249, 0);
            this.content.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.content.Name = "content";
            this.content.Size = new System.Drawing.Size(1013, 720);
            this.content.TabIndex = 1;
            this.content.Paint += new System.Windows.Forms.PaintEventHandler(this.content_Paint);
            // 
            // PH2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1262, 720);
            this.Controls.Add(this.content);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "PH2";
            this.Text = "QTV";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Panel content;
        private Button btn_donvi;
        private Button btn_nhansu;
        private Button btn_sv;
        private Button btn_hp;
        private Button btn_phancong;
        private Button btn_khm;
        private Button btn_dangky;
    }
}