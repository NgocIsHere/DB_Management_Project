namespace DB_Management
{
    partial class ThongBao
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
            this.label5 = new System.Windows.Forms.Label();
            this.lv_tb = new System.Windows.Forms.ListView();
            this.detail = new System.Windows.Forms.GroupBox();
            this.btn_next = new System.Windows.Forms.Button();
            this.btn_pre = new System.Windows.Forms.Button();
            this.lb_detail = new System.Windows.Forms.Label();
            this.btn_back = new System.Windows.Forms.Button();
            this.detail.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.ForeColor = System.Drawing.Color.Aqua;
            this.label5.Location = new System.Drawing.Point(303, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(365, 38);
            this.label5.TabIndex = 53;
            this.label5.Text = "THÔNG BÁO";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lv_tb
            // 
            this.lv_tb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lv_tb.FullRowSelect = true;
            this.lv_tb.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lv_tb.HideSelection = false;
            this.lv_tb.Location = new System.Drawing.Point(57, 106);
            this.lv_tb.Name = "lv_tb";
            this.lv_tb.Size = new System.Drawing.Size(866, 502);
            this.lv_tb.TabIndex = 54;
            this.lv_tb.UseCompatibleStateImageBehavior = false;
            this.lv_tb.View = System.Windows.Forms.View.Details;
            this.lv_tb.SelectedIndexChanged += new System.EventHandler(this.lv_tb_SelectedIndexChanged);
            // 
            // detail
            // 
            this.detail.Controls.Add(this.btn_next);
            this.detail.Controls.Add(this.btn_pre);
            this.detail.Controls.Add(this.lb_detail);
            this.detail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.detail.ForeColor = System.Drawing.Color.Aqua;
            this.detail.Location = new System.Drawing.Point(57, 106);
            this.detail.Name = "detail";
            this.detail.Size = new System.Drawing.Size(866, 502);
            this.detail.TabIndex = 55;
            this.detail.TabStop = false;
            this.detail.Text = "chi tiết";
            this.detail.Visible = false;
            // 
            // btn_next
            // 
            this.btn_next.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btn_next.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_next.ForeColor = System.Drawing.Color.Aqua;
            this.btn_next.Location = new System.Drawing.Point(425, 440);
            this.btn_next.Name = "btn_next";
            this.btn_next.Size = new System.Drawing.Size(99, 42);
            this.btn_next.TabIndex = 56;
            this.btn_next.Text = "Tiếp";
            this.btn_next.UseVisualStyleBackColor = false;
            this.btn_next.Click += new System.EventHandler(this.btn_next_Click);
            // 
            // btn_pre
            // 
            this.btn_pre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btn_pre.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_pre.ForeColor = System.Drawing.Color.Aqua;
            this.btn_pre.Location = new System.Drawing.Point(320, 440);
            this.btn_pre.Name = "btn_pre";
            this.btn_pre.Size = new System.Drawing.Size(99, 42);
            this.btn_pre.TabIndex = 55;
            this.btn_pre.Text = "Lui";
            this.btn_pre.UseVisualStyleBackColor = false;
            this.btn_pre.Click += new System.EventHandler(this.btn_pre_Click);
            // 
            // lb_detail
            // 
            this.lb_detail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lb_detail.Location = new System.Drawing.Point(16, 42);
            this.lb_detail.Name = "lb_detail";
            this.lb_detail.Size = new System.Drawing.Size(824, 373);
            this.lb_detail.TabIndex = 0;
            this.lb_detail.Text = "thong bao 1: fdasfsafsaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
    "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            // 
            // btn_back
            // 
            this.btn_back.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btn_back.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_back.ForeColor = System.Drawing.Color.Aqua;
            this.btn_back.Location = new System.Drawing.Point(57, 19);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(99, 42);
            this.btn_back.TabIndex = 57;
            this.btn_back.Text = "Quay lại";
            this.btn_back.UseVisualStyleBackColor = false;
            this.btn_back.Visible = false;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(982, 673);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.detail);
            this.Controls.Add(this.lv_tb);
            this.Controls.Add(this.label5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.detail.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListView lv_tb;
        private System.Windows.Forms.GroupBox detail;
        private System.Windows.Forms.Button btn_next;
        private System.Windows.Forms.Button btn_pre;
        private System.Windows.Forms.Label lb_detail;
        private System.Windows.Forms.Button btn_back;
    }
}
