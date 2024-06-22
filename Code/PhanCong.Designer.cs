namespace DB_Management
{
    partial class PhanCong
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gb_edit = new System.Windows.Forms.GroupBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.tb_mahp = new System.Windows.Forms.TextBox();
            this.tb_mact = new System.Windows.Forms.TextBox();
            this.tb_nam = new System.Windows.Forms.TextBox();
            this.tb_hk = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_magv = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lv_pc = new System.Windows.Forms.ListView();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_choose = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.gb_edit.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_edit
            // 
            this.gb_edit.Controls.Add(this.btn_save);
            this.gb_edit.Controls.Add(this.tb_mahp);
            this.gb_edit.Controls.Add(this.tb_mact);
            this.gb_edit.Controls.Add(this.tb_nam);
            this.gb_edit.Controls.Add(this.tb_hk);
            this.gb_edit.Controls.Add(this.label4);
            this.gb_edit.Controls.Add(this.label3);
            this.gb_edit.Controls.Add(this.label2);
            this.gb_edit.Controls.Add(this.label1);
            this.gb_edit.Controls.Add(this.tb_magv);
            this.gb_edit.Controls.Add(this.label6);
            this.gb_edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.gb_edit.ForeColor = System.Drawing.Color.Cyan;
            this.gb_edit.Location = new System.Drawing.Point(20, 57);
            this.gb_edit.Name = "gb_edit";
            this.gb_edit.Size = new System.Drawing.Size(949, 149);
            this.gb_edit.TabIndex = 1;
            this.gb_edit.TabStop = false;
            this.gb_edit.Text = "Insert";
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.Aqua;
            this.btn_save.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.ForeColor = System.Drawing.Color.Black;
            this.btn_save.Location = new System.Drawing.Point(844, 13);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(99, 31);
            this.btn_save.TabIndex = 53;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // tb_mahp
            // 
            this.tb_mahp.Location = new System.Drawing.Point(210, 98);
            this.tb_mahp.Name = "tb_mahp";
            this.tb_mahp.Size = new System.Drawing.Size(155, 24);
            this.tb_mahp.TabIndex = 51;
            // 
            // tb_mact
            // 
            this.tb_mact.Location = new System.Drawing.Point(788, 98);
            this.tb_mact.Name = "tb_mact";
            this.tb_mact.Size = new System.Drawing.Size(155, 24);
            this.tb_mact.TabIndex = 50;
            // 
            // tb_nam
            // 
            this.tb_nam.Location = new System.Drawing.Point(595, 98);
            this.tb_nam.Name = "tb_nam";
            this.tb_nam.Size = new System.Drawing.Size(155, 24);
            this.tb_nam.TabIndex = 49;
            // 
            // tb_hk
            // 
            this.tb_hk.Location = new System.Drawing.Point(402, 98);
            this.tb_hk.Name = "tb_hk";
            this.tb_hk.Size = new System.Drawing.Size(155, 24);
            this.tb_hk.TabIndex = 48;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.ForeColor = System.Drawing.Color.Aqua;
            this.label4.Location = new System.Drawing.Point(207, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 38);
            this.label4.TabIndex = 47;
            this.label4.Text = "MAHP";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.ForeColor = System.Drawing.Color.Aqua;
            this.label3.Location = new System.Drawing.Point(408, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 38);
            this.label3.TabIndex = 46;
            this.label3.Text = "HOCKY";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.ForeColor = System.Drawing.Color.Aqua;
            this.label2.Location = new System.Drawing.Point(592, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 38);
            this.label2.TabIndex = 45;
            this.label2.Text = "NAM";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.Aqua;
            this.label1.Location = new System.Drawing.Point(785, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 38);
            this.label1.TabIndex = 44;
            this.label1.Text = "MACT";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_magv
            // 
            this.tb_magv.Location = new System.Drawing.Point(6, 98);
            this.tb_magv.Name = "tb_magv";
            this.tb_magv.Size = new System.Drawing.Size(155, 24);
            this.tb_magv.TabIndex = 43;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.ForeColor = System.Drawing.Color.Aqua;
            this.label6.Location = new System.Drawing.Point(3, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 38);
            this.label6.TabIndex = 42;
            this.label6.Text = "MAGV";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lv_pc
            // 
            this.lv_pc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lv_pc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lv_pc.FullRowSelect = true;
            this.lv_pc.HideSelection = false;
            this.lv_pc.Location = new System.Drawing.Point(20, 295);
            this.lv_pc.Name = "lv_pc";
            this.lv_pc.Size = new System.Drawing.Size(949, 398);
            this.lv_pc.TabIndex = 52;
            this.lv_pc.UseCompatibleStateImageBehavior = false;
            this.lv_pc.View = System.Windows.Forms.View.Details;
            this.lv_pc.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lv_pc_ItemCheck);
            this.lv_pc.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lv_pc_ItemChecked);
            this.lv_pc.SelectedIndexChanged += new System.EventHandler(this.lv_pc_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.ForeColor = System.Drawing.Color.Aqua;
            this.label5.Location = new System.Drawing.Point(402, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(190, 38);
            this.label5.TabIndex = 52;
            this.label5.Text = "PHAN CONG";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_delete
            // 
            this.btn_delete.BackColor = System.Drawing.Color.Aqua;
            this.btn_delete.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete.ForeColor = System.Drawing.Color.Black;
            this.btn_delete.Location = new System.Drawing.Point(759, 238);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(99, 42);
            this.btn_delete.TabIndex = 54;
            this.btn_delete.Text = "Back";
            this.btn_delete.UseVisualStyleBackColor = false;
            this.btn_delete.Visible = false;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_choose
            // 
            this.btn_choose.BackColor = System.Drawing.Color.Aqua;
            this.btn_choose.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_choose.ForeColor = System.Drawing.Color.Black;
            this.btn_choose.Location = new System.Drawing.Point(864, 238);
            this.btn_choose.Name = "btn_choose";
            this.btn_choose.Size = new System.Drawing.Size(105, 42);
            this.btn_choose.TabIndex = 55;
            this.btn_choose.Text = "Choose";
            this.btn_choose.UseVisualStyleBackColor = false;
            this.btn_choose.Click += new System.EventHandler(this.btn_choose_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Aqua;
            this.button1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(20, 247);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 42);
            this.button1.TabIndex = 56;
            this.button1.Text = "Load";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PhanCong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_choose);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lv_pc);
            this.Controls.Add(this.gb_edit);
            this.Name = "PhanCong";
            this.Size = new System.Drawing.Size(1000, 720);
            this.Load += new System.EventHandler(this.PhanCong_Load);
            this.gb_edit.ResumeLayout(false);
            this.gb_edit.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gb_edit;
        private System.Windows.Forms.TextBox tb_mahp;
        private System.Windows.Forms.TextBox tb_mact;
        private System.Windows.Forms.TextBox tb_nam;
        private System.Windows.Forms.TextBox tb_hk;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_magv;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListView lv_pc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_choose;
        private System.Windows.Forms.Button button1;
    }
}
