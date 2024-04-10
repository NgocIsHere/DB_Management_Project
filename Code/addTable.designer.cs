namespace DB_Management
{
    partial class addTable
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
            this.lb_title = new System.Windows.Forms.Label();
            this.lv_table = new System.Windows.Forms.ListView();
            this.btn_back = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb_title
            // 
            this.lb_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lb_title.ForeColor = System.Drawing.Color.Aqua;
            this.lb_title.Location = new System.Drawing.Point(179, 9);
            this.lb_title.Name = "lb_title";
            this.lb_title.Size = new System.Drawing.Size(116, 38);
            this.lb_title.TabIndex = 1;
            this.lb_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lv_table
            // 
            this.lv_table.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lv_table.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lv_table.HideSelection = false;
            this.lv_table.Location = new System.Drawing.Point(81, 84);
            this.lv_table.Name = "lv_table";
            this.lv_table.Size = new System.Drawing.Size(321, 261);
            this.lv_table.TabIndex = 2;
            this.lv_table.UseCompatibleStateImageBehavior = false;
            this.lv_table.SelectedIndexChanged += new System.EventHandler(this.lv_table_SelectedIndexChanged);
            // 
            // btn_back
            // 
            this.btn_back.BackColor = System.Drawing.Color.Aqua;
            this.btn_back.Location = new System.Drawing.Point(184, 382);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(85, 35);
            this.btn_back.TabIndex = 11;
            this.btn_back.Text = "Aply";
            this.btn_back.UseVisualStyleBackColor = false;
            this.btn_back.Click += new System.EventHandler(this.btn_aply_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(498, 450);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.lv_table);
            this.Controls.Add(this.lb_title);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lb_title;
        private System.Windows.Forms.ListView lv_table;
        private System.Windows.Forms.Button btn_back;
    }
}