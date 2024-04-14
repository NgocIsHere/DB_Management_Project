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
            this.container_pri = new System.Windows.Forms.GroupBox();
            this.lv_wgoption = new System.Windows.Forms.ListView();
            this.lv_revoke = new System.Windows.Forms.ListView();
            this.lv_grant = new System.Windows.Forms.ListView();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lv_privilege = new System.Windows.Forms.ListView();
            this.label6 = new System.Windows.Forms.Label();
            this.lv_column = new System.Windows.Forms.ListView();
            this.lv_g = new System.Windows.Forms.ListView();
            this.gb1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lv_wgo = new System.Windows.Forms.ListView();
            this.lv_r = new System.Windows.Forms.ListView();
            this.lv_role = new System.Windows.Forms.ListView();
            this.container_pri.SuspendLayout();
            this.gb1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(102, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(219, 23);
            this.label5.TabIndex = 30;
            this.label5.Text = "All table Privilege";
            // 
            // btn_exit
            // 
            this.btn_exit.BackColor = System.Drawing.Color.Aqua;
            this.btn_exit.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_exit.ForeColor = System.Drawing.Color.Black;
            this.btn_exit.Location = new System.Drawing.Point(493, 630);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(99, 31);
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
            this.btn_save.Location = new System.Drawing.Point(366, 630);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(99, 31);
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
            this.Username_Box.Location = new System.Drawing.Point(128, 30);
            this.Username_Box.Name = "Username_Box";
            this.Username_Box.Size = new System.Drawing.Size(243, 31);
            this.Username_Box.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Aqua;
            this.label2.Location = new System.Drawing.Point(24, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 23);
            this.label2.TabIndex = 20;
            this.label2.Text = "Username";
            // 
            // lv_pri_tab
            // 
            this.lv_pri_tab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lv_pri_tab.HideSelection = false;
            this.lv_pri_tab.Location = new System.Drawing.Point(17, 101);
            this.lv_pri_tab.Name = "lv_pri_tab";
            this.lv_pri_tab.Size = new System.Drawing.Size(508, 269);
            this.lv_pri_tab.TabIndex = 31;
            this.lv_pri_tab.UseCompatibleStateImageBehavior = false;
            // 
            // lv_tab
            // 
            this.lv_tab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lv_tab.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lv_tab.HideSelection = false;
            this.lv_tab.Location = new System.Drawing.Point(17, 415);
            this.lv_tab.Name = "lv_tab";
            this.lv_tab.Size = new System.Drawing.Size(260, 226);
            this.lv_tab.TabIndex = 33;
            this.lv_tab.UseCompatibleStateImageBehavior = false;
            this.lv_tab.SelectedIndexChanged += new System.EventHandler(this.lv_tab_SelectedIndexChanged);
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
            this.container_pri.Location = new System.Drawing.Point(545, 294);
            this.container_pri.Name = "container_pri";
            this.container_pri.Size = new System.Drawing.Size(410, 254);
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
            this.lv_wgoption.Location = new System.Drawing.Point(348, 82);
            this.lv_wgoption.Name = "lv_wgoption";
            this.lv_wgoption.Scrollable = false;
            this.lv_wgoption.Size = new System.Drawing.Size(34, 112);
            this.lv_wgoption.TabIndex = 47;
            this.lv_wgoption.UseCompatibleStateImageBehavior = false;
            this.lv_wgoption.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lv_wgoption_ItemChecked);
            // 
            // lv_revoke
            // 
            this.lv_revoke.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lv_revoke.CheckBoxes = true;
            this.lv_revoke.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lv_revoke.HideSelection = false;
            this.lv_revoke.Location = new System.Drawing.Point(273, 82);
            this.lv_revoke.Name = "lv_revoke";
            this.lv_revoke.Scrollable = false;
            this.lv_revoke.Size = new System.Drawing.Size(34, 112);
            this.lv_revoke.TabIndex = 46;
            this.lv_revoke.UseCompatibleStateImageBehavior = false;
            this.lv_revoke.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lv_revoke_ItemChecked);
            // 
            // lv_grant
            // 
            this.lv_grant.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lv_grant.CheckBoxes = true;
            this.lv_grant.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lv_grant.HideSelection = false;
            this.lv_grant.Location = new System.Drawing.Point(197, 82);
            this.lv_grant.Name = "lv_grant";
            this.lv_grant.Scrollable = false;
            this.lv_grant.Size = new System.Drawing.Size(34, 112);
            this.lv_grant.TabIndex = 45;
            this.lv_grant.UseCompatibleStateImageBehavior = false;
            this.lv_grant.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lv_grant_ItemChecked);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.ForeColor = System.Drawing.Color.Aqua;
            this.label4.Location = new System.Drawing.Point(313, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 38);
            this.label4.TabIndex = 42;
            this.label4.Text = "With grant option";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.Aqua;
            this.label1.Location = new System.Drawing.Point(258, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 38);
            this.label1.TabIndex = 41;
            this.label1.Text = "Revoke";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.ForeColor = System.Drawing.Color.Aqua;
            this.label3.Location = new System.Drawing.Point(171, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 38);
            this.label3.TabIndex = 40;
            this.label3.Text = "Grant";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lv_privilege
            // 
            this.lv_privilege.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lv_privilege.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lv_privilege.HideSelection = false;
            this.lv_privilege.Location = new System.Drawing.Point(14, 82);
            this.lv_privilege.Margin = new System.Windows.Forms.Padding(0);
            this.lv_privilege.Name = "lv_privilege";
            this.lv_privilege.Size = new System.Drawing.Size(126, 112);
            this.lv_privilege.TabIndex = 34;
            this.lv_privilege.UseCompatibleStateImageBehavior = false;
            this.lv_privilege.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged_1);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.ForeColor = System.Drawing.Color.Aqua;
            this.label6.Location = new System.Drawing.Point(87, 386);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 38);
            this.label6.TabIndex = 41;
            this.label6.Text = "Table";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lv_column
            // 
            this.lv_column.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lv_column.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lv_column.HideSelection = false;
            this.lv_column.Location = new System.Drawing.Point(545, 59);
            this.lv_column.Name = "lv_column";
            this.lv_column.Size = new System.Drawing.Size(177, 229);
            this.lv_column.TabIndex = 33;
            this.lv_column.UseCompatibleStateImageBehavior = false;
            this.lv_column.Visible = false;
            this.lv_column.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lv_column_ItemChecked);
            this.lv_column.SelectedIndexChanged += new System.EventHandler(this.lv_column_SelectedIndexChanged);
            // 
            // lv_g
            // 
            this.lv_g.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lv_g.CheckBoxes = true;
            this.lv_g.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lv_g.HideSelection = false;
            this.lv_g.Location = new System.Drawing.Point(23, 56);
            this.lv_g.Name = "lv_g";
            this.lv_g.Scrollable = false;
            this.lv_g.Size = new System.Drawing.Size(34, 232);
            this.lv_g.TabIndex = 46;
            this.lv_g.UseCompatibleStateImageBehavior = false;
            this.lv_g.View = System.Windows.Forms.View.Details;
            this.lv_g.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lv_g_ItemChecked);
            this.lv_g.SelectedIndexChanged += new System.EventHandler(this.lv_g_SelectedIndexChanged);
            // 
            // gb1
            // 
            this.gb1.Controls.Add(this.label9);
            this.gb1.Controls.Add(this.label8);
            this.gb1.Controls.Add(this.label7);
            this.gb1.Controls.Add(this.lv_wgo);
            this.gb1.Controls.Add(this.lv_r);
            this.gb1.Controls.Add(this.lv_g);
            this.gb1.Location = new System.Drawing.Point(719, 0);
            this.gb1.Name = "gb1";
            this.gb1.Size = new System.Drawing.Size(236, 301);
            this.gb1.TabIndex = 47;
            this.gb1.TabStop = false;
            this.gb1.Visible = false;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label9.ForeColor = System.Drawing.Color.Aqua;
            this.label9.Location = new System.Drawing.Point(139, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 38);
            this.label9.TabIndex = 51;
            this.label9.Text = "With grant option";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label8.ForeColor = System.Drawing.Color.Aqua;
            this.label8.Location = new System.Drawing.Point(84, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 38);
            this.label8.TabIndex = 50;
            this.label8.Text = "Revoke";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label7.ForeColor = System.Drawing.Color.Aqua;
            this.label7.Location = new System.Drawing.Point(6, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 38);
            this.label7.TabIndex = 49;
            this.label7.Text = "Grant";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lv_wgo
            // 
            this.lv_wgo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lv_wgo.CheckBoxes = true;
            this.lv_wgo.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lv_wgo.HideSelection = false;
            this.lv_wgo.Location = new System.Drawing.Point(174, 56);
            this.lv_wgo.Name = "lv_wgo";
            this.lv_wgo.Scrollable = false;
            this.lv_wgo.Size = new System.Drawing.Size(34, 232);
            this.lv_wgo.TabIndex = 48;
            this.lv_wgo.UseCompatibleStateImageBehavior = false;
            this.lv_wgo.View = System.Windows.Forms.View.Details;
            this.lv_wgo.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lv_wgo_ItemChecked);
            // 
            // lv_r
            // 
            this.lv_r.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lv_r.CheckBoxes = true;
            this.lv_r.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lv_r.HideSelection = false;
            this.lv_r.Location = new System.Drawing.Point(99, 56);
            this.lv_r.Name = "lv_r";
            this.lv_r.Scrollable = false;
            this.lv_r.Size = new System.Drawing.Size(34, 232);
            this.lv_r.TabIndex = 47;
            this.lv_r.UseCompatibleStateImageBehavior = false;
            this.lv_r.View = System.Windows.Forms.View.Details;
            this.lv_r.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lv_r_ItemChecked);
            // 
            // lv_role
            // 
            this.lv_role.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lv_role.CheckBoxes = true;
            this.lv_role.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lv_role.HideSelection = false;
            this.lv_role.Location = new System.Drawing.Point(283, 415);
            this.lv_role.Name = "lv_role";
            this.lv_role.Size = new System.Drawing.Size(242, 185);
            this.lv_role.TabIndex = 48;
            this.lv_role.UseCompatibleStateImageBehavior = false;
            this.lv_role.View = System.Windows.Forms.View.Details;
            // 
            // EditUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(982, 673);
            this.Controls.Add(this.lv_role);
            this.Controls.Add(this.gb1);
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
            this.Name = "EditUser";
            this.container_pri.ResumeLayout(false);
            this.gb1.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox container_pri;
        private System.Windows.Forms.ListView lv_privilege;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView lv_wgoption;
        private System.Windows.Forms.ListView lv_revoke;
        private System.Windows.Forms.ListView lv_grant;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListView lv_column;
        private System.Windows.Forms.ListView lv_g;
        private System.Windows.Forms.GroupBox gb1;
        private System.Windows.Forms.ListView lv_wgo;
        private System.Windows.Forms.ListView lv_r;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListView lv_role;
    }
}