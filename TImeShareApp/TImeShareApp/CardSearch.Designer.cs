namespace TImeShareApp
{
    partial class CardSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CardSearch));
            this.combo_search = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label1 = new System.Windows.Forms.Label();
            this.listViewEx1 = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.label2 = new System.Windows.Forms.Label();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // combo_search
            // 
            this.combo_search.DisplayMember = "Text";
            this.combo_search.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.combo_search.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_search.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.combo_search.FormattingEnabled = true;
            this.combo_search.ItemHeight = 19;
            this.combo_search.Location = new System.Drawing.Point(12, 28);
            this.combo_search.Name = "combo_search";
            this.combo_search.Size = new System.Drawing.Size(139, 25);
            this.combo_search.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.combo_search.TabIndex = 0;
            this.combo_search.TabStop = false;
            this.combo_search.SelectedIndexChanged += new System.EventHandler(this.combo_search_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Search by:";
            // 
            // listViewEx1
            // 
            this.listViewEx1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.listViewEx1.Border.Class = "ListViewBorder";
            this.listViewEx1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.listViewEx1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.listViewEx1.FullRowSelect = true;
            this.listViewEx1.Location = new System.Drawing.Point(12, 72);
            this.listViewEx1.Name = "listViewEx1";
            this.listViewEx1.Size = new System.Drawing.Size(498, 201);
            this.listViewEx1.TabIndex = 3;
            this.listViewEx1.UseCompatibleStateImageBehavior = false;
            this.listViewEx1.View = System.Windows.Forms.View.Details;
            this.listViewEx1.DoubleClick += new System.EventHandler(this.listViewEx1_DoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Resault";
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.maskedTextBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.maskedTextBox1.Location = new System.Drawing.Point(157, 28);
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(353, 25);
            this.maskedTextBox1.TabIndex = 5;
            this.maskedTextBox1.TextChanged += new System.EventHandler(this.maskedTextBox1_TextChanged);
            this.maskedTextBox1.Enter += new System.EventHandler(this.maskedTextBox1_Enter);
            this.maskedTextBox1.Leave += new System.EventHandler(this.maskedTextBox1_Leave);
            // 
            // CardSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(522, 285);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listViewEx1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.combo_search);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CardSearch";
            this.Text = "CardSearch";
            this.Activated += new System.EventHandler(this.CardSearch_Activated);
            this.Load += new System.EventHandler(this.CardSearch_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.ComboBoxEx combo_search;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.ListViewEx listViewEx1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
    }
}