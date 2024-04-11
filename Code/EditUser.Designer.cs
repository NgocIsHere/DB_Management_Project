namespace DB_Management
{
    partial class EditUser
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
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.Username_Box = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lv_pri_tab = new System.Windows.Forms.ListView();
            this.lv_tab = new System.Windows.Forms.ListView();
            this.lv_column = new System.Windows.Forms.ListView();
            this.container_pri = new System.Windows.Forms.GroupBox();
            this.lv_wgoption = new System.Windows.Forms.ListView();
            this.lv_revoke = new System.Windows.Forms.ListView();
            this.lv_grant = new System.Windows.Forms.ListView();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lv_privilege = new System.Windows.Forms.ListView();
            this.label6 = new System.Windows.Forms.Label();
            this.container_pri.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(118, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(259, 28);
            this.label5.TabIndex = 30;
            this.label5.Text = "All table Privilege";
            // 
            // btn_exit
            // 
            this.btn_exit.BackColor = System.Drawing.Color.Aqua;
            this.btn_exit.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_exit.ForeColor = System.Drawing.Color.Black;
            this.btn_exit.Location = new System.Drawing.Point(560, 762);
            this.btn_exit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(111, 39);
            this.btn_exit.TabIndex = 25;
            this.btn_exit.Text = "Exit";
            this.btn_exit.UseVisualStyleBackColor = false;
            this.btn_exit.Click += new System.EventHandler(this.button3_Click);
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.Aqua;
            this.btn_save.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.ForeColor = System.Drawing.Color.Black;
            this.btn_save.Location = new System.Drawing.Point(412, 762);
            this.btn_save.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(111, 39);
            this.btn_save.TabIndex = 24;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.button1_Click);
            // 
            // Username_Box
            // 
            this.Username_Box.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.Username_Box.Enabled = false;
            this.Username_Box.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Username_Box.ForeColor = System.Drawing.Color.Aqua;
            this.Username_Box.Location = new System.Drawing.Point(144, 38);
            this.Username_Box.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Username_Box.Name = "Username_Box";
            this.Username_Box.Size = new System.Drawing.Size(273, 36);
            this.Username_Box.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Aqua;
            this.label2.Location = new System.Drawing.Point(27, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 28);
            this.label2.TabIndex = 20;
            this.label2.Text = "Username";
            // 
            // lv_pri_tab
            // 
            this.lv_pri_tab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lv_pri_tab.HideSelection = false;
            this.lv_pri_tab.Location = new System.Drawing.Point(20, 148);
            this.lv_pri_tab.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lv_pri_tab.Name = "lv_pri_tab";
            this.lv_pri_tab.Size = new System.Drawing.Size(517, 379);
            this.lv_pri_tab.TabIndex = 31;
            this.lv_pri_tab.UseCompatibleStateImageBehavior = false;
            // 
            // lv_tab
            // 
            this.lv_tab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lv_tab.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lv_tab.HideSelection = false;
            this.lv_tab.Location = new System.Drawing.Point(560, 60);
            this.lv_tab.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lv_tab.Name = "lv_tab";
            this.lv_tab.Size = new System.Drawing.Size(309, 282);
            this.lv_tab.TabIndex = 33;
            this.lv_tab.UseCompatibleStateImageBehavior = false;
            this.lv_tab.SelectedIndexChanged += new System.EventHandler(this.lv_tab_SelectedIndexChanged);
            // 
            // lv_column
            // 
            this.lv_column.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lv_column.CheckBoxes = true;
            this.lv_column.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lv_column.HideSelection = false;
            this.lv_column.Location = new System.Drawing.Point(882, 60);
            this.lv_column.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lv_column.Name = "lv_column";
            this.lv_column.Size = new System.Drawing.Size(184, 285);
            this.lv_column.TabIndex = 33;
            this.lv_column.UseCompatibleStateImageBehavior = false;
            this.lv_column.Visible = false;
            this.lv_column.SelectedIndexChanged += new System.EventHandler(this.lv_column_SelectedIndexChanged);
            // 
            // container_pri
            // 
            this.container_pri.Controls.Add(this.lv_wgoption);
            this.container_pri.Controls.Add(this.lv_revoke);
            this.container_pri.Controls.Add(this.lv_grant);
            this.container_pri.Controls.Add(this.label4);
            this.container_pri.Controls.Add(this.label1);
            this.container_pri.Controls.Add(this.label3);
            this.container_pri.Controls.Add(this.lv_privilege);
            this.container_pri.Location = new System.Drawing.Point(560, 368);
            this.container_pri.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.container_pri.Name = "container_pri";
            this.container_pri.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.container_pri.Size = new System.Drawing.Size(470, 318);
            this.container_pri.TabIndex = 34;
            this.container_pri.TabStop = false;
            this.container_pri.Visible = false;
            // 
            // lv_wgoption
            // 
            this.lv_wgoption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lv_wgoption.CheckBoxes = true;
            this.lv_wgoption.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lv_wgoption.HideSelection = false;
            this.lv_wgoption.Location = new System.Drawing.Point(392, 102);
            this.lv_wgoption.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lv_wgoption.Name = "lv_wgoption";
            this.lv_wgoption.Scrollable = false;
            this.lv_wgoption.Size = new System.Drawing.Size(38, 139);
            this.lv_wgoption.TabIndex = 47;
            this.lv_wgoption.UseCompatibleStateImageBehavior = false;
            // 
            // lv_revoke
            // 
            this.lv_revoke.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lv_revoke.CheckBoxes = true;
            this.lv_revoke.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lv_revoke.HideSelection = false;
            this.lv_revoke.Location = new System.Drawing.Point(307, 102);
            this.lv_revoke.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lv_revoke.Name = "lv_revoke";
            this.lv_revoke.Scrollable = false;
            this.lv_revoke.Size = new System.Drawing.Size(38, 139);
            this.lv_revoke.TabIndex = 46;
            this.lv_revoke.UseCompatibleStateImageBehavior = false;
            // 
            // lv_grant
            // 
            this.lv_grant.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lv_grant.CheckBoxes = true;
            this.lv_grant.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lv_grant.HideSelection = false;
            this.lv_grant.Location = new System.Drawing.Point(222, 102);
            this.lv_grant.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lv_grant.Name = "lv_grant";
            this.lv_grant.Scrollable = false;
            this.lv_grant.Size = new System.Drawing.Size(38, 139);
            this.lv_grant.TabIndex = 45;
            this.lv_grant.UseCompatibleStateImageBehavior = false;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.ForeColor = System.Drawing.Color.Aqua;
            this.label4.Location = new System.Drawing.Point(352, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 48);
            this.label4.TabIndex = 42;
            this.label4.Text = "With grant option";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.Aqua;
            this.label1.Location = new System.Drawing.Point(290, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 48);
            this.label1.TabIndex = 41;
            this.label1.Text = "Revoke";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.ForeColor = System.Drawing.Color.Aqua;
            this.label3.Location = new System.Drawing.Point(192, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 48);
            this.label3.TabIndex = 40;
            this.label3.Text = "Grant";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lv_privilege
            // 
            this.lv_privilege.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lv_privilege.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lv_privilege.HideSelection = false;
            this.lv_privilege.Location = new System.Drawing.Point(16, 102);
            this.lv_privilege.Margin = new System.Windows.Forms.Padding(0);
            this.lv_privilege.Name = "lv_privilege";
            this.lv_privilege.Size = new System.Drawing.Size(141, 139);
            this.lv_privilege.TabIndex = 34;
            this.lv_privilege.UseCompatibleStateImageBehavior = false;
            this.lv_privilege.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged_1);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.ForeColor = System.Drawing.Color.Aqua;
            this.label6.Location = new System.Drawing.Point(678, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 48);
            this.label6.TabIndex = 41;
            this.label6.Text = "Table";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EditUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.label6);
            this.Controls.Add(this.container_pri);
            this.Controls.Add(this.lv_column);
            this.Controls.Add(this.lv_tab);
            this.Controls.Add(this.lv_pri_tab);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.Username_Box);
            this.Controls.Add(this.label2);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "EditUser";
            this.Size = new System.Drawing.Size(1105, 841);
            this.container_pri.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.TextBox Username_Box;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lv_pri_tab;
        private System.Windows.Forms.ListView lv_tab;
        private System.Windows.Forms.ListView lv_column;
        private System.Windows.Forms.GroupBox container_pri;
        private System.Windows.Forms.ListView lv_privilege;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView lv_wgoption;
        private System.Windows.Forms.ListView lv_revoke;
        private System.Windows.Forms.ListView lv_grant;
        private System.Windows.Forms.Label label6;
    }
}