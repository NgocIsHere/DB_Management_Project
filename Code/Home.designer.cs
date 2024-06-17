using System.Drawing;
using System.Windows.Forms;

namespace DB_Management
{
    partial class Home
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
            this.FGA_btn = new System.Windows.Forms.Button();
            this.standard_btn = new System.Windows.Forms.Button();
            this.btn_dx = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.content = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.FGA_btn);
            this.panel1.Controls.Add(this.standard_btn);
            this.panel1.Controls.Add(this.btn_dx);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(249, 720);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // FGA_btn
            // 
            this.FGA_btn.BackColor = System.Drawing.Color.Aqua;
            this.FGA_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.FGA_btn.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.FGA_btn.ForeColor = System.Drawing.Color.Black;
            this.FGA_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FGA_btn.Location = new System.Drawing.Point(2, 298);
            this.FGA_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FGA_btn.Name = "FGA_btn";
            this.FGA_btn.Size = new System.Drawing.Size(241, 71);
            this.FGA_btn.TabIndex = 12;
            this.FGA_btn.Text = "FGA Audit";
            this.FGA_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.FGA_btn.UseVisualStyleBackColor = false;
            this.FGA_btn.Click += new System.EventHandler(this.FGA_btn_Click);
            // 
            // standard_btn
            // 
            this.standard_btn.BackColor = System.Drawing.Color.Aqua;
            this.standard_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.standard_btn.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.standard_btn.ForeColor = System.Drawing.Color.Black;
            this.standard_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.standard_btn.Location = new System.Drawing.Point(2, 223);
            this.standard_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.standard_btn.Name = "standard_btn";
            this.standard_btn.Size = new System.Drawing.Size(241, 71);
            this.standard_btn.TabIndex = 11;
            this.standard_btn.Text = "Standard Audit";
            this.standard_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.standard_btn.UseVisualStyleBackColor = false;
            this.standard_btn.Click += new System.EventHandler(this.standard_btn_Click);
            // 
            // btn_dx
            // 
            this.btn_dx.BackColor = System.Drawing.Color.Aqua;
            this.btn_dx.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_dx.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.btn_dx.ForeColor = System.Drawing.Color.Black;
            this.btn_dx.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_dx.Location = new System.Drawing.Point(2, 638);
            this.btn_dx.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_dx.Name = "btn_dx";
            this.btn_dx.Size = new System.Drawing.Size(241, 71);
            this.btn_dx.TabIndex = 10;
            this.btn_dx.Text = "Đăng xuất";
            this.btn_dx.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_dx.UseVisualStyleBackColor = false;
            this.btn_dx.Click += new System.EventHandler(this.btn_dx_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Aqua;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(3, 72);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(240, 71);
            this.button2.TabIndex = 3;
            this.button2.Text = "ADD USER";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Aqua;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(2, 148);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(241, 71);
            this.button3.TabIndex = 2;
            this.button3.Text = "ROLE";
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Aqua;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(3, 2);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(240, 66);
            this.button1.TabIndex = 3;
            this.button1.Text = "HOME";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1262, 720);
            this.Controls.Add(this.content);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Home";
            this.Text = "QTV";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Panel content;
        private Button button3;
        private Button button1;
        private Button button2;
        private Button btn_dx;
        private Button FGA_btn;
        private Button standard_btn;
    }
}