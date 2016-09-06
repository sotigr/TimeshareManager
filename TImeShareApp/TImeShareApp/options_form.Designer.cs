namespace TImeShareApp
{
    partial class options_form
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.option_lang_des = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btn_edit_in_access = new DevComponents.DotNetBar.ButtonX();
            this.btn_db_brz = new DevComponents.DotNetBar.ButtonX();
            this.options_database_location = new System.Windows.Forms.Label();
            this.txt_db_brz = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.date_dis_end = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.date_dis_start = new System.Windows.Forms.DateTimePicker();
            this.txt_discount_week_cost = new System.Windows.Forms.TextBox();
            this.txt_normal_week_cost = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new DevComponents.DotNetBar.ButtonX();
            this.button1 = new DevComponents.DotNetBar.ButtonX();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(374, 422);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(366, 394);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "gen";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox2);
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Location = new System.Drawing.Point(9, 114);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(224, 85);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Extraction";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(7, 48);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(202, 19);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "Create backups of extracted files";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(7, 22);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(165, 19);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Open files afrer extraction";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.option_lang_des);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Location = new System.Drawing.Point(9, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(210, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Language";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // option_lang_des
            // 
            this.option_lang_des.Location = new System.Drawing.Point(7, 18);
            this.option_lang_des.Name = "option_lang_des";
            this.option_lang_des.Size = new System.Drawing.Size(196, 42);
            this.option_lang_des.TabIndex = 1;
            this.option_lang_des.Text = "l";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(7, 63);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(195, 23);
            this.comboBox1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btn_edit_in_access);
            this.tabPage2.Controls.Add(this.btn_db_brz);
            this.tabPage2.Controls.Add(this.options_database_location);
            this.tabPage2.Controls.Add(this.txt_db_brz);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(366, 394);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "db";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btn_edit_in_access
            // 
            this.btn_edit_in_access.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_edit_in_access.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_edit_in_access.Location = new System.Drawing.Point(9, 66);
            this.btn_edit_in_access.Name = "btn_edit_in_access";
            this.btn_edit_in_access.Size = new System.Drawing.Size(243, 27);
            this.btn_edit_in_access.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_edit_in_access.TabIndex = 3;
            this.btn_edit_in_access.Text = "Edit in Access";
            this.btn_edit_in_access.Click += new System.EventHandler(this.btn_edit_in_access_Click);
            // 
            // btn_db_brz
            // 
            this.btn_db_brz.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_db_brz.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_db_brz.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_db_brz.Location = new System.Drawing.Point(268, 36);
            this.btn_db_brz.Name = "btn_db_brz";
            this.btn_db_brz.Size = new System.Drawing.Size(87, 23);
            this.btn_db_brz.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_db_brz.TabIndex = 2;
            this.btn_db_brz.Text = "browse";
            this.btn_db_brz.Click += new System.EventHandler(this.btn_db_brz_Click);
            // 
            // options_database_location
            // 
            this.options_database_location.AutoSize = true;
            this.options_database_location.Location = new System.Drawing.Point(9, 17);
            this.options_database_location.Name = "options_database_location";
            this.options_database_location.Size = new System.Drawing.Size(41, 15);
            this.options_database_location.TabIndex = 1;
            this.options_database_location.Text = "label1";
            this.options_database_location.Click += new System.EventHandler(this.label1_Click);
            // 
            // txt_db_brz
            // 
            this.txt_db_brz.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_db_brz.Location = new System.Drawing.Point(9, 36);
            this.txt_db_brz.Name = "txt_db_brz";
            this.txt_db_brz.Size = new System.Drawing.Size(251, 21);
            this.txt_db_brz.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.date_dis_end);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.date_dis_start);
            this.tabPage3.Controls.Add(this.txt_discount_week_cost);
            this.tabPage3.Controls.Add(this.txt_normal_week_cost);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(366, 394);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "payments";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(168, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(180, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Discount - Ends";
            // 
            // date_dis_end
            // 
            this.date_dis_end.CustomFormat = "dd / MM";
            this.date_dis_end.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date_dis_end.Location = new System.Drawing.Point(187, 157);
            this.date_dis_end.Name = "date_dis_end";
            this.date_dis_end.Size = new System.Drawing.Size(163, 21);
            this.date_dis_end.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Discount - Begins";
            // 
            // date_dis_start
            // 
            this.date_dis_start.CustomFormat = "dd / MM";
            this.date_dis_start.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date_dis_start.Location = new System.Drawing.Point(13, 157);
            this.date_dis_start.Name = "date_dis_start";
            this.date_dis_start.Size = new System.Drawing.Size(152, 21);
            this.date_dis_start.TabIndex = 4;
            // 
            // txt_discount_week_cost
            // 
            this.txt_discount_week_cost.Location = new System.Drawing.Point(13, 107);
            this.txt_discount_week_cost.Name = "txt_discount_week_cost";
            this.txt_discount_week_cost.Size = new System.Drawing.Size(114, 21);
            this.txt_discount_week_cost.TabIndex = 3;
            // 
            // txt_normal_week_cost
            // 
            this.txt_normal_week_cost.Location = new System.Drawing.Point(13, 38);
            this.txt_normal_week_cost.Name = "txt_normal_week_cost";
            this.txt_normal_week_cost.Size = new System.Drawing.Size(114, 21);
            this.txt_normal_week_cost.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Week cost - Discount";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Week cost - Normal";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 384);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(374, 38);
            this.panel1.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button2.Location = new System.Drawing.Point(188, 7);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 27);
            this.button2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button1.Location = new System.Drawing.Point(282, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 27);
            this.button1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // options_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(374, 422);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "options_form";
            this.ShowIcon = false;
            this.Text = "Options";
            this.Load += new System.EventHandler(this.options_form_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.ButtonX button2;
        private DevComponents.DotNetBar.ButtonX button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label option_lang_des;
        private System.Windows.Forms.Label options_database_location;
        private System.Windows.Forms.TextBox txt_db_brz;
        private DevComponents.DotNetBar.ButtonX btn_db_brz;
        private DevComponents.DotNetBar.ButtonX btn_edit_in_access;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox txt_normal_week_cost;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker date_dis_end;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker date_dis_start;
        private System.Windows.Forms.TextBox txt_discount_week_cost;
        private System.Windows.Forms.Label label5;
    }
}