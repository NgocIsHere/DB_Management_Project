namespace DB_Management
{
    partial class SinhVien
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.insert_button = new System.Windows.Forms.Button();
            this.update_button = new System.Windows.Forms.Button();
            this.manganh_comboBox = new System.Windows.Forms.ComboBox();
            this.mact_comboBox = new System.Windows.Forms.ComboBox();
            this.mact_label = new System.Windows.Forms.Label();
            this.diachi_label = new System.Windows.Forms.Label();
            this.diachi_textBox = new System.Windows.Forms.TextBox();
            this.manganh_label = new System.Windows.Forms.Label();
            this.dtbtl_label = new System.Windows.Forms.Label();
            this.dtbtl_textBox = new System.Windows.Forms.TextBox();
            this.phucap_label = new System.Windows.Forms.Label();
            this.stctl_textBox = new System.Windows.Forms.TextBox();
            this.ngaysinh_dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.ngaysinh_label = new System.Windows.Forms.Label();
            this.nu_radioButton = new System.Windows.Forms.RadioButton();
            this.nam_radioButton = new System.Windows.Forms.RadioButton();
            this.phai_label = new System.Windows.Forms.Label();
            this.hoten_label = new System.Windows.Forms.Label();
            this.hoten_textBox = new System.Windows.Forms.TextBox();
            this.masv_label = new System.Windows.Forms.Label();
            this.masv_textBox = new System.Windows.Forms.TextBox();
            this.delete_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dt_textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 35);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(957, 317);
            this.dataGridView1.TabIndex = 105;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // insert_button
            // 
            this.insert_button.BackColor = System.Drawing.Color.Aqua;
            this.insert_button.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.insert_button.ForeColor = System.Drawing.Color.Black;
            this.insert_button.Location = new System.Drawing.Point(516, 594);
            this.insert_button.Name = "insert_button";
            this.insert_button.Size = new System.Drawing.Size(99, 31);
            this.insert_button.TabIndex = 104;
            this.insert_button.Text = "Insert";
            this.insert_button.UseVisualStyleBackColor = false;
            this.insert_button.Click += new System.EventHandler(this.InsertSV_Click);
            // 
            // update_button
            // 
            this.update_button.BackColor = System.Drawing.Color.Aqua;
            this.update_button.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.update_button.ForeColor = System.Drawing.Color.Black;
            this.update_button.Location = new System.Drawing.Point(687, 594);
            this.update_button.Name = "update_button";
            this.update_button.Size = new System.Drawing.Size(99, 31);
            this.update_button.TabIndex = 103;
            this.update_button.Text = "Update";
            this.update_button.UseVisualStyleBackColor = false;
            this.update_button.Click += new System.EventHandler(this.Update_Click);
            // 
            // manganh_comboBox
            // 
            this.manganh_comboBox.FormattingEnabled = true;
            this.manganh_comboBox.Location = new System.Drawing.Point(691, 423);
            this.manganh_comboBox.Name = "manganh_comboBox";
            this.manganh_comboBox.Size = new System.Drawing.Size(140, 24);
            this.manganh_comboBox.TabIndex = 102;
            // 
            // mact_comboBox
            // 
            this.mact_comboBox.FormattingEnabled = true;
            this.mact_comboBox.Location = new System.Drawing.Point(691, 373);
            this.mact_comboBox.Name = "mact_comboBox";
            this.mact_comboBox.Size = new System.Drawing.Size(140, 24);
            this.mact_comboBox.TabIndex = 101;
            // 
            // mact_label
            // 
            this.mact_label.AutoSize = true;
            this.mact_label.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mact_label.ForeColor = System.Drawing.SystemColors.Control;
            this.mact_label.Location = new System.Drawing.Point(500, 375);
            this.mact_label.Name = "mact_label";
            this.mact_label.Size = new System.Drawing.Size(128, 18);
            this.mact_label.TabIndex = 100;
            this.mact_label.Text = "MÃ CHƯƠNG TRÌNH";
            // 
            // diachi_label
            // 
            this.diachi_label.AutoSize = true;
            this.diachi_label.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diachi_label.ForeColor = System.Drawing.SystemColors.Control;
            this.diachi_label.Location = new System.Drawing.Point(40, 575);
            this.diachi_label.Name = "diachi_label";
            this.diachi_label.Size = new System.Drawing.Size(64, 18);
            this.diachi_label.TabIndex = 99;
            this.diachi_label.Text = "ĐỊA CHỈ";
            // 
            // diachi_textBox
            // 
            this.diachi_textBox.Location = new System.Drawing.Point(148, 573);
            this.diachi_textBox.Name = "diachi_textBox";
            this.diachi_textBox.Size = new System.Drawing.Size(200, 22);
            this.diachi_textBox.TabIndex = 98;
            // 
            // manganh_label
            // 
            this.manganh_label.AutoSize = true;
            this.manganh_label.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manganh_label.ForeColor = System.Drawing.SystemColors.Control;
            this.manganh_label.Location = new System.Drawing.Point(500, 425);
            this.manganh_label.Name = "manganh_label";
            this.manganh_label.Size = new System.Drawing.Size(72, 18);
            this.manganh_label.TabIndex = 97;
            this.manganh_label.Text = "MÃ NGÀNH";
            // 
            // dtbtl_label
            // 
            this.dtbtl_label.AutoSize = true;
            this.dtbtl_label.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtbtl_label.ForeColor = System.Drawing.SystemColors.Control;
            this.dtbtl_label.Location = new System.Drawing.Point(500, 525);
            this.dtbtl_label.Name = "dtbtl_label";
            this.dtbtl_label.Size = new System.Drawing.Size(128, 18);
            this.dtbtl_label.TabIndex = 96;
            this.dtbtl_label.Text = "ĐIỂM TRUNG BÌNH";
            // 
            // dtbtl_textBox
            // 
            this.dtbtl_textBox.Location = new System.Drawing.Point(691, 523);
            this.dtbtl_textBox.Name = "dtbtl_textBox";
            this.dtbtl_textBox.Size = new System.Drawing.Size(140, 22);
            this.dtbtl_textBox.TabIndex = 95;
            // 
            // phucap_label
            // 
            this.phucap_label.AutoSize = true;
            this.phucap_label.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phucap_label.ForeColor = System.Drawing.SystemColors.Control;
            this.phucap_label.Location = new System.Drawing.Point(500, 475);
            this.phucap_label.Name = "phucap_label";
            this.phucap_label.Size = new System.Drawing.Size(160, 18);
            this.phucap_label.TabIndex = 94;
            this.phucap_label.Text = "SỐ TÍN CHỈ TÍCH LŨY";
            // 
            // stctl_textBox
            // 
            this.stctl_textBox.Location = new System.Drawing.Point(691, 473);
            this.stctl_textBox.Name = "stctl_textBox";
            this.stctl_textBox.Size = new System.Drawing.Size(140, 22);
            this.stctl_textBox.TabIndex = 93;
            // 
            // ngaysinh_dateTimePicker
            // 
            this.ngaysinh_dateTimePicker.Location = new System.Drawing.Point(148, 521);
            this.ngaysinh_dateTimePicker.Name = "ngaysinh_dateTimePicker";
            this.ngaysinh_dateTimePicker.Size = new System.Drawing.Size(200, 22);
            this.ngaysinh_dateTimePicker.TabIndex = 92;
            // 
            // ngaysinh_label
            // 
            this.ngaysinh_label.AutoSize = true;
            this.ngaysinh_label.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaysinh_label.ForeColor = System.Drawing.SystemColors.Control;
            this.ngaysinh_label.Location = new System.Drawing.Point(40, 525);
            this.ngaysinh_label.Name = "ngaysinh_label";
            this.ngaysinh_label.Size = new System.Drawing.Size(80, 18);
            this.ngaysinh_label.TabIndex = 91;
            this.ngaysinh_label.Text = "NGÀY SINH";
            // 
            // nu_radioButton
            // 
            this.nu_radioButton.AutoSize = true;
            this.nu_radioButton.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nu_radioButton.ForeColor = System.Drawing.SystemColors.Control;
            this.nu_radioButton.Location = new System.Drawing.Point(211, 473);
            this.nu_radioButton.Name = "nu_radioButton";
            this.nu_radioButton.Size = new System.Drawing.Size(45, 22);
            this.nu_radioButton.TabIndex = 90;
            this.nu_radioButton.TabStop = true;
            this.nu_radioButton.Text = "Nữ";
            this.nu_radioButton.UseVisualStyleBackColor = true;
            // 
            // nam_radioButton
            // 
            this.nam_radioButton.AutoSize = true;
            this.nam_radioButton.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nam_radioButton.ForeColor = System.Drawing.SystemColors.Control;
            this.nam_radioButton.Location = new System.Drawing.Point(148, 473);
            this.nam_radioButton.Name = "nam_radioButton";
            this.nam_radioButton.Size = new System.Drawing.Size(53, 22);
            this.nam_radioButton.TabIndex = 89;
            this.nam_radioButton.TabStop = true;
            this.nam_radioButton.Text = "Nam";
            this.nam_radioButton.UseVisualStyleBackColor = true;
            // 
            // phai_label
            // 
            this.phai_label.AutoSize = true;
            this.phai_label.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phai_label.ForeColor = System.Drawing.SystemColors.Control;
            this.phai_label.Location = new System.Drawing.Point(40, 475);
            this.phai_label.Name = "phai_label";
            this.phai_label.Size = new System.Drawing.Size(40, 18);
            this.phai_label.TabIndex = 88;
            this.phai_label.Text = "PHÁI";
            // 
            // hoten_label
            // 
            this.hoten_label.AutoSize = true;
            this.hoten_label.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten_label.ForeColor = System.Drawing.SystemColors.Control;
            this.hoten_label.Location = new System.Drawing.Point(40, 425);
            this.hoten_label.Name = "hoten_label";
            this.hoten_label.Size = new System.Drawing.Size(56, 18);
            this.hoten_label.TabIndex = 87;
            this.hoten_label.Text = "HỌ TÊN";
            // 
            // hoten_textBox
            // 
            this.hoten_textBox.Location = new System.Drawing.Point(148, 423);
            this.hoten_textBox.Name = "hoten_textBox";
            this.hoten_textBox.Size = new System.Drawing.Size(200, 22);
            this.hoten_textBox.TabIndex = 86;
            // 
            // masv_label
            // 
            this.masv_label.AutoSize = true;
            this.masv_label.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.masv_label.ForeColor = System.Drawing.SystemColors.Control;
            this.masv_label.Location = new System.Drawing.Point(40, 375);
            this.masv_label.Name = "masv_label";
            this.masv_label.Size = new System.Drawing.Size(40, 18);
            this.masv_label.TabIndex = 85;
            this.masv_label.Text = "MASV";
            // 
            // masv_textBox
            // 
            this.masv_textBox.Location = new System.Drawing.Point(148, 373);
            this.masv_textBox.Name = "masv_textBox";
            this.masv_textBox.Size = new System.Drawing.Size(200, 22);
            this.masv_textBox.TabIndex = 84;
            // 
            // delete_button
            // 
            this.delete_button.BackColor = System.Drawing.Color.Aqua;
            this.delete_button.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delete_button.ForeColor = System.Drawing.Color.Black;
            this.delete_button.Location = new System.Drawing.Point(854, 594);
            this.delete_button.Name = "delete_button";
            this.delete_button.Size = new System.Drawing.Size(99, 31);
            this.delete_button.TabIndex = 83;
            this.delete_button.Text = "Delete";
            this.delete_button.UseVisualStyleBackColor = false;
            this.delete_button.Click += new System.EventHandler(this.Delete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(40, 625);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 18);
            this.label1.TabIndex = 107;
            this.label1.Text = "SĐT";
            // 
            // dt_textBox
            // 
            this.dt_textBox.Location = new System.Drawing.Point(148, 623);
            this.dt_textBox.Name = "dt_textBox";
            this.dt_textBox.Size = new System.Drawing.Size(200, 22);
            this.dt_textBox.TabIndex = 106;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Aqua;
            this.label2.Location = new System.Drawing.Point(437, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 23);
            this.label2.TabIndex = 108;
            this.label2.Text = "SINH VIÊN";
            // 
            // SinhVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(982, 673);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dt_textBox);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.insert_button);
            this.Controls.Add(this.update_button);
            this.Controls.Add(this.manganh_comboBox);
            this.Controls.Add(this.mact_comboBox);
            this.Controls.Add(this.mact_label);
            this.Controls.Add(this.diachi_label);
            this.Controls.Add(this.diachi_textBox);
            this.Controls.Add(this.manganh_label);
            this.Controls.Add(this.dtbtl_label);
            this.Controls.Add(this.dtbtl_textBox);
            this.Controls.Add(this.phucap_label);
            this.Controls.Add(this.stctl_textBox);
            this.Controls.Add(this.ngaysinh_dateTimePicker);
            this.Controls.Add(this.ngaysinh_label);
            this.Controls.Add(this.nu_radioButton);
            this.Controls.Add(this.nam_radioButton);
            this.Controls.Add(this.phai_label);
            this.Controls.Add(this.hoten_label);
            this.Controls.Add(this.hoten_textBox);
            this.Controls.Add(this.masv_label);
            this.Controls.Add(this.masv_textBox);
            this.Controls.Add(this.delete_button);
            this.Name = "SinhVien";
            this.Load += new System.EventHandler(this.SinhVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button insert_button;
        private System.Windows.Forms.Button update_button;
        private System.Windows.Forms.ComboBox manganh_comboBox;
        private System.Windows.Forms.ComboBox mact_comboBox;
        private System.Windows.Forms.Label mact_label;
        private System.Windows.Forms.Label diachi_label;
        private System.Windows.Forms.TextBox diachi_textBox;
        private System.Windows.Forms.Label manganh_label;
        private System.Windows.Forms.Label dtbtl_label;
        private System.Windows.Forms.TextBox dtbtl_textBox;
        private System.Windows.Forms.Label phucap_label;
        private System.Windows.Forms.TextBox stctl_textBox;
        private System.Windows.Forms.DateTimePicker ngaysinh_dateTimePicker;
        private System.Windows.Forms.Label ngaysinh_label;
        private System.Windows.Forms.RadioButton nu_radioButton;
        private System.Windows.Forms.RadioButton nam_radioButton;
        private System.Windows.Forms.Label phai_label;
        private System.Windows.Forms.Label hoten_label;
        private System.Windows.Forms.TextBox hoten_textBox;
        private System.Windows.Forms.Label masv_label;
        private System.Windows.Forms.TextBox masv_textBox;
        private System.Windows.Forms.Button delete_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox dt_textBox;
        private System.Windows.Forms.Label label2;
    }
}
