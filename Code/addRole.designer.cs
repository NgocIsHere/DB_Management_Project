namespace DB_Management
{
    partial class addRole
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
            this.container_role = new System.Windows.Forms.GroupBox();
            this.container_edit = new System.Windows.Forms.GroupBox();
            this.container_privilege = new System.Windows.Forms.GroupBox();
            this.lv_deny = new System.Windows.Forms.ListView();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lv_grant = new System.Windows.Forms.ListView();
            this.lv_privilege = new System.Windows.Forms.ListView();
            this.btn_submit = new System.Windows.Forms.Button();
            this.tb_rolename = new System.Windows.Forms.TextBox();
            this.lb_rolename = new System.Windows.Forms.Label();
            this.lv_table = new System.Windows.Forms.ListView();
            this.btn_col = new System.Windows.Forms.Button();
            this.lb_privilege = new System.Windows.Forms.Label();
            this.cb_insert = new System.Windows.Forms.CheckBox();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_choose = new System.Windows.Forms.Button();
            this.btn_back = new System.Windows.Forms.Button();
            this.lb_total = new System.Windows.Forms.Label();
            this.lv_roles = new System.Windows.Forms.ListView();
            this.lb_addrole = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_addtable = new System.Windows.Forms.Button();
            this.container_role.SuspendLayout();
            this.container_edit.SuspendLayout();
            this.container_privilege.SuspendLayout();
            this.SuspendLayout();
            // 
            // container_role
            // 
            this.container_role.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.container_role.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.container_role.Controls.Add(this.container_edit);
            this.container_role.Controls.Add(this.cb_insert);
            this.container_role.Controls.Add(this.btn_add);
            this.container_role.Controls.Add(this.btn_choose);
            this.container_role.Controls.Add(this.btn_back);
            this.container_role.Controls.Add(this.lb_total);
            this.container_role.Controls.Add(this.lv_roles);
            this.container_role.Controls.Add(this.lb_addrole);
            this.container_role.Controls.Add(this.label1);
            this.container_role.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.container_role.Location = new System.Drawing.Point(0, 0);
            this.container_role.Margin = new System.Windows.Forms.Padding(0);
            this.container_role.Name = "container_role";
            this.container_role.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.container_role.Size = new System.Drawing.Size(1000, 720);
            this.container_role.TabIndex = 1;
            this.container_role.TabStop = false;
            // 
            // container_edit
            // 
            this.container_edit.Controls.Add(this.btn_addtable);
            this.container_edit.Controls.Add(this.container_privilege);
            this.container_edit.Controls.Add(this.btn_submit);
            this.container_edit.Controls.Add(this.tb_rolename);
            this.container_edit.Controls.Add(this.lb_rolename);
            this.container_edit.Controls.Add(this.lv_table);
            this.container_edit.Controls.Add(this.btn_col);
            this.container_edit.Controls.Add(this.lb_privilege);
            this.container_edit.Location = new System.Drawing.Point(439, 90);
            this.container_edit.Name = "container_edit";
            this.container_edit.Size = new System.Drawing.Size(561, 630);
            this.container_edit.TabIndex = 13;
            this.container_edit.TabStop = false;
            this.container_edit.Visible = false;
            // 
            // container_privilege
            // 
            this.container_privilege.Controls.Add(this.lv_deny);
            this.container_privilege.Controls.Add(this.label4);
            this.container_privilege.Controls.Add(this.label3);
            this.container_privilege.Controls.Add(this.lv_grant);
            this.container_privilege.Controls.Add(this.lv_privilege);
            this.container_privilege.Location = new System.Drawing.Point(34, 297);
            this.container_privilege.Name = "container_privilege";
            this.container_privilege.Size = new System.Drawing.Size(494, 233);
            this.container_privilege.TabIndex = 30;
            this.container_privilege.TabStop = false;
            this.container_privilege.Visible = false;
            // 
            // lv_deny
            // 
            this.lv_deny.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lv_deny.CheckBoxes = true;
            this.lv_deny.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lv_deny.HideSelection = false;
            this.lv_deny.Location = new System.Drawing.Point(412, 63);
            this.lv_deny.Name = "lv_deny";
            this.lv_deny.Scrollable = false;
            this.lv_deny.Size = new System.Drawing.Size(34, 145);
            this.lv_deny.TabIndex = 42;
            this.lv_deny.UseCompatibleStateImageBehavior = false;
            this.lv_deny.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lv_deny_ItemChecked);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.ForeColor = System.Drawing.Color.Aqua;
            this.label4.Location = new System.Drawing.Point(398, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 38);
            this.label4.TabIndex = 40;
            this.label4.Text = "Deny";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.ForeColor = System.Drawing.Color.Aqua;
            this.label3.Location = new System.Drawing.Point(270, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 38);
            this.label3.TabIndex = 39;
            this.label3.Text = "Grant";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lv_grant
            // 
            this.lv_grant.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lv_grant.CheckBoxes = true;
            this.lv_grant.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lv_grant.HideSelection = false;
            this.lv_grant.Location = new System.Drawing.Point(293, 63);
            this.lv_grant.Name = "lv_grant";
            this.lv_grant.Scrollable = false;
            this.lv_grant.Size = new System.Drawing.Size(34, 145);
            this.lv_grant.TabIndex = 36;
            this.lv_grant.UseCompatibleStateImageBehavior = false;
            this.lv_grant.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lv_grant_ItemChecked);
            // 
            // lv_privilege
            // 
            this.lv_privilege.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lv_privilege.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lv_privilege.HideSelection = false;
            this.lv_privilege.Location = new System.Drawing.Point(74, 63);
            this.lv_privilege.Name = "lv_privilege";
            this.lv_privilege.Scrollable = false;
            this.lv_privilege.Size = new System.Drawing.Size(120, 145);
            this.lv_privilege.TabIndex = 32;
            this.lv_privilege.UseCompatibleStateImageBehavior = false;
            // 
            // btn_submit
            // 
            this.btn_submit.BackColor = System.Drawing.Color.Aqua;
            this.btn_submit.Location = new System.Drawing.Point(231, 554);
            this.btn_submit.Name = "btn_submit";
            this.btn_submit.Size = new System.Drawing.Size(116, 35);
            this.btn_submit.TabIndex = 29;
            this.btn_submit.Text = "Submit";
            this.btn_submit.UseVisualStyleBackColor = false;
            this.btn_submit.Click += new System.EventHandler(this.btn_submit_Click);
            // 
            // tb_rolename
            // 
            this.tb_rolename.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tb_rolename.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tb_rolename.ForeColor = System.Drawing.Color.Black;
            this.tb_rolename.Location = new System.Drawing.Point(126, 33);
            this.tb_rolename.Margin = new System.Windows.Forms.Padding(0);
            this.tb_rolename.Name = "tb_rolename";
            this.tb_rolename.Size = new System.Drawing.Size(314, 24);
            this.tb_rolename.TabIndex = 19;
            // 
            // lb_rolename
            // 
            this.lb_rolename.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lb_rolename.ForeColor = System.Drawing.Color.Aqua;
            this.lb_rolename.Location = new System.Drawing.Point(8, 29);
            this.lb_rolename.Name = "lb_rolename";
            this.lb_rolename.Size = new System.Drawing.Size(115, 38);
            this.lb_rolename.TabIndex = 17;
            this.lb_rolename.Text = "Role name";
            this.lb_rolename.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lv_table
            // 
            this.lv_table.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lv_table.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lv_table.HideSelection = false;
            this.lv_table.Location = new System.Drawing.Point(34, 80);
            this.lv_table.Name = "lv_table";
            this.lv_table.Size = new System.Drawing.Size(406, 186);
            this.lv_table.TabIndex = 16;
            this.lv_table.UseCompatibleStateImageBehavior = false;
            this.lv_table.SelectedIndexChanged += new System.EventHandler(this.lv_table_SelectedIndexChanged);
            // 
            // btn_col
            // 
            this.btn_col.BackColor = System.Drawing.Color.Aqua;
            this.btn_col.Location = new System.Drawing.Point(461, 249);
            this.btn_col.Name = "btn_col";
            this.btn_col.Size = new System.Drawing.Size(79, 42);
            this.btn_col.TabIndex = 15;
            this.btn_col.Text = "Column";
            this.btn_col.UseVisualStyleBackColor = false;
            this.btn_col.Visible = false;
            // 
            // lb_privilege
            // 
            this.lb_privilege.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lb_privilege.ForeColor = System.Drawing.Color.Aqua;
            this.lb_privilege.Location = new System.Drawing.Point(71, -9);
            this.lb_privilege.Name = "lb_privilege";
            this.lb_privilege.Size = new System.Drawing.Size(102, 38);
            this.lb_privilege.TabIndex = 14;
            this.lb_privilege.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cb_insert
            // 
            this.cb_insert.AutoSize = true;
            this.cb_insert.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cb_insert.ForeColor = System.Drawing.Color.Cyan;
            this.cb_insert.Location = new System.Drawing.Point(692, 12);
            this.cb_insert.Name = "cb_insert";
            this.cb_insert.Size = new System.Drawing.Size(155, 22);
            this.cb_insert.TabIndex = 31;
            this.cb_insert.Text = "with grant option";
            this.cb_insert.UseVisualStyleBackColor = true;
            this.cb_insert.Visible = false;
            // 
            // btn_add
            // 
            this.btn_add.BackColor = System.Drawing.Color.Aqua;
            this.btn_add.Location = new System.Drawing.Point(900, 53);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(94, 35);
            this.btn_add.TabIndex = 12;
            this.btn_add.Text = "Add";
            this.btn_add.UseVisualStyleBackColor = false;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_choose
            // 
            this.btn_choose.BackColor = System.Drawing.Color.Aqua;
            this.btn_choose.Location = new System.Drawing.Point(352, 56);
            this.btn_choose.Name = "btn_choose";
            this.btn_choose.Size = new System.Drawing.Size(89, 35);
            this.btn_choose.TabIndex = 11;
            this.btn_choose.Text = "Choose";
            this.btn_choose.UseVisualStyleBackColor = false;
            this.btn_choose.Click += new System.EventHandler(this.btn_choose_Click);
            // 
            // btn_back
            // 
            this.btn_back.BackColor = System.Drawing.Color.Aqua;
            this.btn_back.Location = new System.Drawing.Point(261, 56);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(85, 35);
            this.btn_back.TabIndex = 10;
            this.btn_back.Text = "Back";
            this.btn_back.UseVisualStyleBackColor = false;
            this.btn_back.Visible = false;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // lb_total
            // 
            this.lb_total.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lb_total.ForeColor = System.Drawing.Color.Aqua;
            this.lb_total.Location = new System.Drawing.Point(6, 56);
            this.lb_total.Name = "lb_total";
            this.lb_total.Size = new System.Drawing.Size(138, 38);
            this.lb_total.TabIndex = 9;
            this.lb_total.Text = "Total: ";
            this.lb_total.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lv_roles
            // 
            this.lv_roles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lv_roles.FullRowSelect = true;
            this.lv_roles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lv_roles.HideSelection = false;
            this.lv_roles.Location = new System.Drawing.Point(0, 97);
            this.lv_roles.Name = "lv_roles";
            this.lv_roles.Size = new System.Drawing.Size(441, 623);
            this.lv_roles.TabIndex = 8;
            this.lv_roles.UseCompatibleStateImageBehavior = false;
            this.lv_roles.View = System.Windows.Forms.View.Details;
            this.lv_roles.SelectedIndexChanged += new System.EventHandler(this.lv_roles_SelectedIndexChanged);
            // 
            // lb_addrole
            // 
            this.lb_addrole.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lb_addrole.ForeColor = System.Drawing.Color.Aqua;
            this.lb_addrole.Location = new System.Drawing.Point(644, 53);
            this.lb_addrole.Name = "lb_addrole";
            this.lb_addrole.Size = new System.Drawing.Size(156, 38);
            this.lb_addrole.TabIndex = 2;
            this.lb_addrole.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.Aqua;
            this.label1.Location = new System.Drawing.Point(408, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Role";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_addtable
            // 
            this.btn_addtable.BackColor = System.Drawing.Color.Aqua;
            this.btn_addtable.Location = new System.Drawing.Point(446, 80);
            this.btn_addtable.Name = "btn_addtable";
            this.btn_addtable.Size = new System.Drawing.Size(94, 35);
            this.btn_addtable.TabIndex = 31;
            this.btn_addtable.Text = "Add";
            this.btn_addtable.UseVisualStyleBackColor = false;
            this.btn_addtable.Click += new System.EventHandler(this.btn_addtable_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 720);
            this.Controls.Add(this.container_role);
            this.Name = "Form1";
            this.Text = "Form1";
            this.container_role.ResumeLayout(false);
            this.container_role.PerformLayout();
            this.container_edit.ResumeLayout(false);
            this.container_edit.PerformLayout();
            this.container_privilege.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox container_role;
        private System.Windows.Forms.GroupBox container_edit;
        private System.Windows.Forms.GroupBox container_privilege;
        private System.Windows.Forms.ListView lv_deny;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView lv_grant;
        private System.Windows.Forms.ListView lv_privilege;
        private System.Windows.Forms.Button btn_submit;
        private System.Windows.Forms.TextBox tb_rolename;
        private System.Windows.Forms.Label lb_rolename;
        private System.Windows.Forms.ListView lv_table;
        private System.Windows.Forms.Button btn_col;
        private System.Windows.Forms.Label lb_privilege;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_choose;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.Label lb_total;
        private System.Windows.Forms.ListView lv_roles;
        private System.Windows.Forms.Label lb_addrole;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cb_insert;
        private System.Windows.Forms.Button btn_addtable;
    }
}

