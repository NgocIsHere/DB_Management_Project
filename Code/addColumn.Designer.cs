namespace DB_Management
{
    partial class addColumn
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
            this.btn_back = new System.Windows.Forms.Button();
            this.lv_column = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // btn_back
            // 
            this.btn_back.BackColor = System.Drawing.Color.Aqua;
            this.btn_back.Location = new System.Drawing.Point(134, 330);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(85, 35);
            this.btn_back.TabIndex = 15;
            this.btn_back.Text = "Aply";
            this.btn_back.UseVisualStyleBackColor = false;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // lv_column
            // 
            this.lv_column.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lv_column.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lv_column.HideSelection = false;
            this.lv_column.Location = new System.Drawing.Point(55, 39);
            this.lv_column.Name = "lv_column";
            this.lv_column.Size = new System.Drawing.Size(262, 261);
            this.lv_column.TabIndex = 14;
            this.lv_column.UseCompatibleStateImageBehavior = false;
            this.lv_column.SelectedIndexChanged += new System.EventHandler(this.lv_table_SelectedIndexChanged);
            // 
            // addColumn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(385, 399);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.lv_column);
            this.Name = "addColumn";
            this.Text = "Column";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.ListView lv_column;
    }
}