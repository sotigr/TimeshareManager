namespace TImeShareApp
{
    partial class payments
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
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.payed_list = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.owes_list = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.owesContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.payToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.payOffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.owesContextMenuStrip.SuspendLayout();
            this.panelEx2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Margin = new System.Windows.Forms.Padding(4);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(707, 43);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 1;
            this.panelEx1.Text = "panelEx1";
            // 
            // payed_list
            // 
            this.payed_list.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.payed_list.Border.Class = "ListViewBorder";
            this.payed_list.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.payed_list.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.payed_list.FullRowSelect = true;
            this.payed_list.Location = new System.Drawing.Point(12, 33);
            this.payed_list.Margin = new System.Windows.Forms.Padding(4);
            this.payed_list.Name = "payed_list";
            this.payed_list.Size = new System.Drawing.Size(675, 215);
            this.payed_list.TabIndex = 2;
            this.payed_list.UseCompatibleStateImageBehavior = false;
            this.payed_list.DoubleClick += new System.EventHandler(this.payed_list_DoubleClick);
            // 
            // owes_list
            // 
            this.owes_list.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.owes_list.Border.Class = "ListViewBorder";
            this.owes_list.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.owes_list.ContextMenuStrip = this.owesContextMenuStrip;
            this.owes_list.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.owes_list.FullRowSelect = true;
            this.owes_list.Location = new System.Drawing.Point(16, 289);
            this.owes_list.Margin = new System.Windows.Forms.Padding(4);
            this.owes_list.Name = "owes_list";
            this.owes_list.Size = new System.Drawing.Size(671, 159);
            this.owes_list.TabIndex = 3;
            this.owes_list.UseCompatibleStateImageBehavior = false;
            // 
            // owesContextMenuStrip
            // 
            this.owesContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.payToolStripMenuItem,
            this.payOffToolStripMenuItem});
            this.owesContextMenuStrip.Name = "owesContextMenuStrip";
            this.owesContextMenuStrip.Size = new System.Drawing.Size(114, 48);
            // 
            // payToolStripMenuItem
            // 
            this.payToolStripMenuItem.Name = "payToolStripMenuItem";
            this.payToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.payToolStripMenuItem.Text = "Pay";
            this.payToolStripMenuItem.Click += new System.EventHandler(this.payToolStripMenuItem_Click);
            // 
            // payOffToolStripMenuItem
            // 
            this.payOffToolStripMenuItem.Name = "payOffToolStripMenuItem";
            this.payOffToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.payOffToolStripMenuItem.Text = "Pay Off";
            this.payOffToolStripMenuItem.Click += new System.EventHandler(this.payOffToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Payed";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 270);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Owes";
            // 
            // panelEx2
            // 
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.owes_list);
            this.panelEx2.Controls.Add(this.label2);
            this.panelEx2.Controls.Add(this.payed_list);
            this.panelEx2.Controls.Add(this.label1);
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx2.Location = new System.Drawing.Point(0, 43);
            this.panelEx2.Margin = new System.Windows.Forms.Padding(4);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(707, 782);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 6;
            // 
            // payments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(707, 825);
            this.ControlBox = false;
            this.Controls.Add(this.panelEx2);
            this.Controls.Add(this.panelEx1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "payments";
            this.Load += new System.EventHandler(this.payments_Load);
            this.owesContextMenuStrip.ResumeLayout(false);
            this.panelEx2.ResumeLayout(false);
            this.panelEx2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.Controls.ListViewEx payed_list;
        private DevComponents.DotNetBar.Controls.ListViewEx owes_list;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private System.Windows.Forms.ContextMenuStrip owesContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem payToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem payOffToolStripMenuItem;
    }
}