namespace TImeShareApp
{
    partial class Card
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
            this.components = new System.ComponentModel.Container();
            this.cl_label_client_information = new System.Windows.Forms.GroupBox();
            this.list_contracts = new System.Windows.Forms.ListBox();
            this.contracts_contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contracts_add = new System.Windows.Forms.ToolStripMenuItem();
            this.contracts_remove = new System.Windows.Forms.ToolStripMenuItem();
            this.txt_notes = new System.Windows.Forms.TextBox();
            this.cl_label_notes = new System.Windows.Forms.Label();
            this.list_email = new System.Windows.Forms.ListBox();
            this.emals_contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.emails_add = new System.Windows.Forms.ToolStripMenuItem();
            this.emails_remove = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_paynebts = new DevComponents.DotNetBar.ButtonX();
            this.list_phones = new System.Windows.Forms.ListBox();
            this.phones_contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.phones_add = new System.Windows.Forms.ToolStripMenuItem();
            this.phones_remove = new System.Windows.Forms.ToolStripMenuItem();
            this.cl_label_email = new System.Windows.Forms.Label();
            this.cl_label_phone = new System.Windows.Forms.Label();
            this.list_addresses = new System.Windows.Forms.ListBox();
            this.addresses_contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addresses_add = new System.Windows.Forms.ToolStripMenuItem();
            this.addresses_remove = new System.Windows.Forms.ToolStripMenuItem();
            this.list_names = new System.Windows.Forms.ListBox();
            this.names_contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.names_add = new System.Windows.Forms.ToolStripMenuItem();
            this.names_remove = new System.Windows.Forms.ToolStripMenuItem();
            this.cl_label_contracts = new System.Windows.Forms.Label();
            this.list_appartments = new System.Windows.Forms.ListView();
            this.appartments_contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.appartments_add = new System.Windows.Forms.ToolStripMenuItem();
            this.appartments_remove = new System.Windows.Forms.ToolStripMenuItem();
            this.cl_label_appartments = new System.Windows.Forms.Label();
            this.txt_rci_number = new System.Windows.Forms.TextBox();
            this.cl_label_rci_number = new System.Windows.Forms.Label();
            this.txt_bank_number = new System.Windows.Forms.TextBox();
            this.cl_label_bank_number = new System.Windows.Forms.Label();
            this.txt_number = new System.Windows.Forms.TextBox();
            this.cl_label_address = new System.Windows.Forms.Label();
            this.cl_label_name = new System.Windows.Forms.Label();
            this.cl_label_number = new System.Windows.Forms.Label();
            this.cl_label_client_information.SuspendLayout();
            this.contracts_contextMenuStrip.SuspendLayout();
            this.emals_contextMenuStrip.SuspendLayout();
            this.phones_contextMenuStrip.SuspendLayout();
            this.addresses_contextMenuStrip.SuspendLayout();
            this.names_contextMenuStrip.SuspendLayout();
            this.appartments_contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // cl_label_client_information
            // 
            this.cl_label_client_information.Controls.Add(this.list_contracts);
            this.cl_label_client_information.Controls.Add(this.txt_notes);
            this.cl_label_client_information.Controls.Add(this.cl_label_notes);
            this.cl_label_client_information.Controls.Add(this.list_email);
            this.cl_label_client_information.Controls.Add(this.btn_paynebts);
            this.cl_label_client_information.Controls.Add(this.list_phones);
            this.cl_label_client_information.Controls.Add(this.cl_label_email);
            this.cl_label_client_information.Controls.Add(this.cl_label_phone);
            this.cl_label_client_information.Controls.Add(this.list_addresses);
            this.cl_label_client_information.Controls.Add(this.list_names);
            this.cl_label_client_information.Controls.Add(this.cl_label_contracts);
            this.cl_label_client_information.Controls.Add(this.list_appartments);
            this.cl_label_client_information.Controls.Add(this.cl_label_appartments);
            this.cl_label_client_information.Controls.Add(this.txt_rci_number);
            this.cl_label_client_information.Controls.Add(this.cl_label_rci_number);
            this.cl_label_client_information.Controls.Add(this.txt_bank_number);
            this.cl_label_client_information.Controls.Add(this.cl_label_bank_number);
            this.cl_label_client_information.Controls.Add(this.txt_number);
            this.cl_label_client_information.Controls.Add(this.cl_label_address);
            this.cl_label_client_information.Controls.Add(this.cl_label_name);
            this.cl_label_client_information.Controls.Add(this.cl_label_number);
            this.cl_label_client_information.Location = new System.Drawing.Point(14, 14);
            this.cl_label_client_information.Name = "cl_label_client_information";
            this.cl_label_client_information.Size = new System.Drawing.Size(534, 584);
            this.cl_label_client_information.TabIndex = 0;
            this.cl_label_client_information.TabStop = false;
            this.cl_label_client_information.Text = "Client Information";
            // 
            // list_contracts
            // 
            this.list_contracts.ContextMenuStrip = this.contracts_contextMenuStrip;
            this.list_contracts.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.list_contracts.FormattingEnabled = true;
            this.list_contracts.ItemHeight = 17;
            this.list_contracts.Location = new System.Drawing.Point(355, 267);
            this.list_contracts.Name = "list_contracts";
            this.list_contracts.Size = new System.Drawing.Size(161, 123);
            this.list_contracts.TabIndex = 8;
            this.list_contracts.Leave += new System.EventHandler(this.list_contracts_Leave);
            // 
            // contracts_contextMenuStrip
            // 
            this.contracts_contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contracts_add,
            this.contracts_remove});
            this.contracts_contextMenuStrip.Name = "names_contextMenuStrip";
            this.contracts_contextMenuStrip.Size = new System.Drawing.Size(153, 70);
            // 
            // contracts_add
            // 
            this.contracts_add.Name = "contracts_add";
            this.contracts_add.Size = new System.Drawing.Size(117, 22);
            this.contracts_add.Text = "Add";
            this.contracts_add.Click += new System.EventHandler(this.contracts_add_Click);
            // 
            // contracts_remove
            // 
            this.contracts_remove.Name = "contracts_remove";
            this.contracts_remove.Size = new System.Drawing.Size(152, 22);
            this.contracts_remove.Text = "Remove";
            this.contracts_remove.Click += new System.EventHandler(this.contracts_remove_Click);
            // 
            // txt_notes
            // 
            this.txt_notes.AcceptsReturn = true;
            this.txt_notes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_notes.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txt_notes.Location = new System.Drawing.Point(15, 413);
            this.txt_notes.Margin = new System.Windows.Forms.Padding(5);
            this.txt_notes.Multiline = true;
            this.txt_notes.Name = "txt_notes";
            this.txt_notes.ReadOnly = true;
            this.txt_notes.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_notes.Size = new System.Drawing.Size(501, 153);
            this.txt_notes.TabIndex = 9;
            this.txt_notes.WordWrap = false;
            this.txt_notes.DoubleClick += new System.EventHandler(this.txt_notes_DoubleClick);
            // 
            // cl_label_notes
            // 
            this.cl_label_notes.AutoSize = true;
            this.cl_label_notes.Location = new System.Drawing.Point(12, 393);
            this.cl_label_notes.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.cl_label_notes.Name = "cl_label_notes";
            this.cl_label_notes.Size = new System.Drawing.Size(39, 15);
            this.cl_label_notes.TabIndex = 26;
            this.cl_label_notes.Text = "Notes";
            // 
            // list_email
            // 
            this.list_email.ContextMenuStrip = this.emals_contextMenuStrip;
            this.list_email.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.list_email.FormattingEnabled = true;
            this.list_email.ItemHeight = 17;
            this.list_email.Location = new System.Drawing.Point(268, 178);
            this.list_email.Name = "list_email";
            this.list_email.Size = new System.Drawing.Size(250, 55);
            this.list_email.TabIndex = 4;
            this.list_email.DoubleClick += new System.EventHandler(this.list_email_DoubleClick);
            this.list_email.Leave += new System.EventHandler(this.list_email_Leave);
            // 
            // emals_contextMenuStrip
            // 
            this.emals_contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.emails_add,
            this.emails_remove});
            this.emals_contextMenuStrip.Name = "names_contextMenuStrip";
            this.emals_contextMenuStrip.Size = new System.Drawing.Size(118, 48);
            // 
            // emails_add
            // 
            this.emails_add.Name = "emails_add";
            this.emails_add.Size = new System.Drawing.Size(117, 22);
            this.emails_add.Text = "Add";
            this.emails_add.Click += new System.EventHandler(this.emails_add_Click);
            // 
            // emails_remove
            // 
            this.emails_remove.Name = "emails_remove";
            this.emails_remove.Size = new System.Drawing.Size(152, 22);
            this.emails_remove.Text = "Remove";
            this.emails_remove.Click += new System.EventHandler(this.emails_remove_Click);
            // 
            // btn_paynebts
            // 
            this.btn_paynebts.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_paynebts.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_paynebts.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_paynebts.Location = new System.Drawing.Point(404, 23);
            this.btn_paynebts.Name = "btn_paynebts";
            this.btn_paynebts.Size = new System.Drawing.Size(114, 27);
            this.btn_paynebts.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_paynebts.TabIndex = 10;
            this.btn_paynebts.Text = "payments";
            this.btn_paynebts.Click += new System.EventHandler(this.btn_paynebts_Click);
            // 
            // list_phones
            // 
            this.list_phones.ContextMenuStrip = this.phones_contextMenuStrip;
            this.list_phones.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.list_phones.FormattingEnabled = true;
            this.list_phones.ItemHeight = 17;
            this.list_phones.Location = new System.Drawing.Point(12, 178);
            this.list_phones.Name = "list_phones";
            this.list_phones.Size = new System.Drawing.Size(250, 55);
            this.list_phones.TabIndex = 3;
            this.list_phones.DoubleClick += new System.EventHandler(this.list_phones_DoubleClick);
            this.list_phones.Leave += new System.EventHandler(this.list_phones_Leave);
            // 
            // phones_contextMenuStrip
            // 
            this.phones_contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.phones_add,
            this.phones_remove});
            this.phones_contextMenuStrip.Name = "names_contextMenuStrip";
            this.phones_contextMenuStrip.Size = new System.Drawing.Size(118, 48);
            // 
            // phones_add
            // 
            this.phones_add.Name = "phones_add";
            this.phones_add.Size = new System.Drawing.Size(117, 22);
            this.phones_add.Text = "Add";
            this.phones_add.Click += new System.EventHandler(this.phones_add_Click);
            // 
            // phones_remove
            // 
            this.phones_remove.Name = "phones_remove";
            this.phones_remove.Size = new System.Drawing.Size(152, 22);
            this.phones_remove.Text = "Remove";
            this.phones_remove.Click += new System.EventHandler(this.phones_remove_Click);
            // 
            // cl_label_email
            // 
            this.cl_label_email.AutoSize = true;
            this.cl_label_email.Location = new System.Drawing.Point(268, 159);
            this.cl_label_email.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.cl_label_email.Name = "cl_label_email";
            this.cl_label_email.Size = new System.Drawing.Size(39, 15);
            this.cl_label_email.TabIndex = 22;
            this.cl_label_email.Text = "Email";
            // 
            // cl_label_phone
            // 
            this.cl_label_phone.AutoSize = true;
            this.cl_label_phone.Location = new System.Drawing.Point(8, 159);
            this.cl_label_phone.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.cl_label_phone.Name = "cl_label_phone";
            this.cl_label_phone.Size = new System.Drawing.Size(43, 15);
            this.cl_label_phone.TabIndex = 21;
            this.cl_label_phone.Text = "Phone";
            // 
            // list_addresses
            // 
            this.list_addresses.ContextMenuStrip = this.addresses_contextMenuStrip;
            this.list_addresses.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.list_addresses.FormattingEnabled = true;
            this.list_addresses.ItemHeight = 17;
            this.list_addresses.Location = new System.Drawing.Point(268, 89);
            this.list_addresses.Name = "list_addresses";
            this.list_addresses.Size = new System.Drawing.Size(250, 55);
            this.list_addresses.TabIndex = 2;
            this.list_addresses.DoubleClick += new System.EventHandler(this.list_addresses_DoubleClick);
            this.list_addresses.Leave += new System.EventHandler(this.list_addresses_Leave);
            // 
            // addresses_contextMenuStrip
            // 
            this.addresses_contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addresses_add,
            this.addresses_remove});
            this.addresses_contextMenuStrip.Name = "names_contextMenuStrip";
            this.addresses_contextMenuStrip.Size = new System.Drawing.Size(118, 48);
            // 
            // addresses_add
            // 
            this.addresses_add.Name = "addresses_add";
            this.addresses_add.Size = new System.Drawing.Size(117, 22);
            this.addresses_add.Text = "Add";
            this.addresses_add.Click += new System.EventHandler(this.addresses_add_Click);
            // 
            // addresses_remove
            // 
            this.addresses_remove.Name = "addresses_remove";
            this.addresses_remove.Size = new System.Drawing.Size(152, 22);
            this.addresses_remove.Text = "Remove";
            this.addresses_remove.Click += new System.EventHandler(this.addresses_remove_Click);
            // 
            // list_names
            // 
            this.list_names.ContextMenuStrip = this.names_contextMenuStrip;
            this.list_names.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.list_names.FormattingEnabled = true;
            this.list_names.ItemHeight = 17;
            this.list_names.Location = new System.Drawing.Point(12, 89);
            this.list_names.Name = "list_names";
            this.list_names.Size = new System.Drawing.Size(250, 55);
            this.list_names.TabIndex = 1;
            this.list_names.DoubleClick += new System.EventHandler(this.list_names_DoubleClick);
            // 
            // names_contextMenuStrip
            // 
            this.names_contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.names_add,
            this.names_remove});
            this.names_contextMenuStrip.Name = "names_contextMenuStrip";
            this.names_contextMenuStrip.Size = new System.Drawing.Size(118, 48);
            // 
            // names_add
            // 
            this.names_add.Name = "names_add";
            this.names_add.Size = new System.Drawing.Size(152, 22);
            this.names_add.Text = "Add";
            this.names_add.Click += new System.EventHandler(this.names_add_Click);
            // 
            // names_remove
            // 
            this.names_remove.Name = "names_remove";
            this.names_remove.Size = new System.Drawing.Size(152, 22);
            this.names_remove.Text = "Remove";
            this.names_remove.Click += new System.EventHandler(this.names_remove_Click);
            // 
            // cl_label_contracts
            // 
            this.cl_label_contracts.AutoSize = true;
            this.cl_label_contracts.Location = new System.Drawing.Point(352, 249);
            this.cl_label_contracts.Name = "cl_label_contracts";
            this.cl_label_contracts.Size = new System.Drawing.Size(58, 15);
            this.cl_label_contracts.TabIndex = 18;
            this.cl_label_contracts.Text = "Contracts";
            // 
            // list_appartments
            // 
            this.list_appartments.ContextMenuStrip = this.appartments_contextMenuStrip;
            this.list_appartments.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.list_appartments.FullRowSelect = true;
            this.list_appartments.Location = new System.Drawing.Point(15, 267);
            this.list_appartments.Name = "list_appartments";
            this.list_appartments.Size = new System.Drawing.Size(135, 123);
            this.list_appartments.TabIndex = 5;
            this.list_appartments.UseCompatibleStateImageBehavior = false;
            this.list_appartments.DoubleClick += new System.EventHandler(this.list_appartments_DoubleClick);
            // 
            // appartments_contextMenuStrip
            // 
            this.appartments_contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.appartments_add,
            this.appartments_remove});
            this.appartments_contextMenuStrip.Name = "names_contextMenuStrip";
            this.appartments_contextMenuStrip.Size = new System.Drawing.Size(118, 48);
            // 
            // appartments_add
            // 
            this.appartments_add.Name = "appartments_add";
            this.appartments_add.Size = new System.Drawing.Size(117, 22);
            this.appartments_add.Text = "Add";
            this.appartments_add.Click += new System.EventHandler(this.appartments_add_Click);
            // 
            // appartments_remove
            // 
            this.appartments_remove.Name = "appartments_remove";
            this.appartments_remove.Size = new System.Drawing.Size(152, 22);
            this.appartments_remove.Text = "Remove";
            this.appartments_remove.Click += new System.EventHandler(this.appartments_remove_Click);
            // 
            // cl_label_appartments
            // 
            this.cl_label_appartments.AutoSize = true;
            this.cl_label_appartments.Location = new System.Drawing.Point(15, 248);
            this.cl_label_appartments.Name = "cl_label_appartments";
            this.cl_label_appartments.Size = new System.Drawing.Size(76, 15);
            this.cl_label_appartments.TabIndex = 14;
            this.cl_label_appartments.Text = "Appartments";
            // 
            // txt_rci_number
            // 
            this.txt_rci_number.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_rci_number.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txt_rci_number.Location = new System.Drawing.Point(156, 291);
            this.txt_rci_number.Name = "txt_rci_number";
            this.txt_rci_number.ReadOnly = true;
            this.txt_rci_number.Size = new System.Drawing.Size(193, 25);
            this.txt_rci_number.TabIndex = 6;
            this.txt_rci_number.DoubleClick += new System.EventHandler(this.txt_rci_number_DoubleClick);
            // 
            // cl_label_rci_number
            // 
            this.cl_label_rci_number.AutoSize = true;
            this.cl_label_rci_number.Location = new System.Drawing.Point(156, 273);
            this.cl_label_rci_number.Name = "cl_label_rci_number";
            this.cl_label_rci_number.Size = new System.Drawing.Size(75, 15);
            this.cl_label_rci_number.TabIndex = 12;
            this.cl_label_rci_number.Text = "RCI Number";
            // 
            // txt_bank_number
            // 
            this.txt_bank_number.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_bank_number.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txt_bank_number.Location = new System.Drawing.Point(156, 340);
            this.txt_bank_number.Name = "txt_bank_number";
            this.txt_bank_number.ReadOnly = true;
            this.txt_bank_number.Size = new System.Drawing.Size(193, 25);
            this.txt_bank_number.TabIndex = 7;
            this.txt_bank_number.DoubleClick += new System.EventHandler(this.txt_bank_number_DoubleClick);
            // 
            // cl_label_bank_number
            // 
            this.cl_label_bank_number.AutoSize = true;
            this.cl_label_bank_number.Location = new System.Drawing.Point(155, 322);
            this.cl_label_bank_number.Name = "cl_label_bank_number";
            this.cl_label_bank_number.Size = new System.Drawing.Size(83, 15);
            this.cl_label_bank_number.TabIndex = 10;
            this.cl_label_bank_number.Text = "Bank Number";
            // 
            // txt_number
            // 
            this.txt_number.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_number.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txt_number.Location = new System.Drawing.Point(12, 42);
            this.txt_number.Name = "txt_number";
            this.txt_number.ReadOnly = true;
            this.txt_number.ShortcutsEnabled = false;
            this.txt_number.Size = new System.Drawing.Size(161, 25);
            this.txt_number.TabIndex = 0;
            this.txt_number.DoubleClick += new System.EventHandler(this.txt_number_DoubleClick);
            // 
            // cl_label_address
            // 
            this.cl_label_address.AutoSize = true;
            this.cl_label_address.Location = new System.Drawing.Point(268, 71);
            this.cl_label_address.Name = "cl_label_address";
            this.cl_label_address.Size = new System.Drawing.Size(51, 15);
            this.cl_label_address.TabIndex = 2;
            this.cl_label_address.Text = "Address";
            // 
            // cl_label_name
            // 
            this.cl_label_name.AutoSize = true;
            this.cl_label_name.Location = new System.Drawing.Point(10, 71);
            this.cl_label_name.Name = "cl_label_name";
            this.cl_label_name.Size = new System.Drawing.Size(41, 15);
            this.cl_label_name.TabIndex = 1;
            this.cl_label_name.Text = "Name";
            // 
            // cl_label_number
            // 
            this.cl_label_number.AutoSize = true;
            this.cl_label_number.Location = new System.Drawing.Point(10, 23);
            this.cl_label_number.Name = "cl_label_number";
            this.cl_label_number.Size = new System.Drawing.Size(52, 15);
            this.cl_label_number.TabIndex = 0;
            this.cl_label_number.Text = "Number";
            // 
            // Card
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(563, 613);
            this.Controls.Add(this.cl_label_client_information);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Card";
            this.Text = "Card";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Card_FormClosing);
            this.Load += new System.EventHandler(this.Card_Load);
            this.Move += new System.EventHandler(this.Card_Move);
            this.cl_label_client_information.ResumeLayout(false);
            this.cl_label_client_information.PerformLayout();
            this.contracts_contextMenuStrip.ResumeLayout(false);
            this.emals_contextMenuStrip.ResumeLayout(false);
            this.phones_contextMenuStrip.ResumeLayout(false);
            this.addresses_contextMenuStrip.ResumeLayout(false);
            this.names_contextMenuStrip.ResumeLayout(false);
            this.appartments_contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox cl_label_client_information;
        private System.Windows.Forms.TextBox txt_number;
        private System.Windows.Forms.Label cl_label_address;
        private System.Windows.Forms.Label cl_label_name;
        private System.Windows.Forms.Label cl_label_number;
        private System.Windows.Forms.TextBox txt_bank_number;
        private System.Windows.Forms.Label cl_label_bank_number;
        private System.Windows.Forms.TextBox txt_rci_number;
        private System.Windows.Forms.Label cl_label_rci_number;
        private System.Windows.Forms.ListView list_appartments;
        private System.Windows.Forms.Label cl_label_appartments;
        private System.Windows.Forms.Label cl_label_contracts;
        private DevComponents.DotNetBar.ButtonX btn_paynebts;
        private System.Windows.Forms.ListBox list_addresses;
        private System.Windows.Forms.ListBox list_names;
        private System.Windows.Forms.Label cl_label_phone;
        private System.Windows.Forms.ListBox list_email;
        private System.Windows.Forms.ListBox list_phones;
        private System.Windows.Forms.Label cl_label_email;
        private System.Windows.Forms.TextBox txt_notes;
        private System.Windows.Forms.Label cl_label_notes;
        private System.Windows.Forms.ListBox list_contracts;
        private System.Windows.Forms.ContextMenuStrip names_contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem names_remove;
        private System.Windows.Forms.ToolStripMenuItem names_add;
        private System.Windows.Forms.ContextMenuStrip addresses_contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addresses_add;
        private System.Windows.Forms.ToolStripMenuItem addresses_remove;
        private System.Windows.Forms.ContextMenuStrip phones_contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem phones_add;
        private System.Windows.Forms.ToolStripMenuItem phones_remove;
        private System.Windows.Forms.ContextMenuStrip emals_contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem emails_add;
        private System.Windows.Forms.ToolStripMenuItem emails_remove;
        private System.Windows.Forms.ContextMenuStrip appartments_contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem appartments_add;
        private System.Windows.Forms.ToolStripMenuItem appartments_remove;
        private System.Windows.Forms.ContextMenuStrip contracts_contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem contracts_add;
        private System.Windows.Forms.ToolStripMenuItem contracts_remove;
    }
}