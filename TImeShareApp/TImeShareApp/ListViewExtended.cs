using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

class ListViewExtended : DevComponents.DotNetBar.Controls.ListViewEx
{
    public delegate void CellChangedHandler(object sender, CellChangedEventArgs e);
    public event CellChangedHandler OnCellChanged;
    private void ChangeCell(ListViewItem item)
    {
        if (OnCellChanged == null) return;

        CellChangedEventArgs args = new CellChangedEventArgs(item);
        OnCellChanged(this, args);
    }
    private readonly TextBox txt = new TextBox { BorderStyle = BorderStyle.FixedSingle, Visible = false };

    private ListViewHitTestInfo current_hit;
    private bool txtch = false;
    public ListViewExtended()
    {
        this.View = System.Windows.Forms.View.Details;
        
        this.Controls.Add(txt);
        this.FullRowSelect = true;
        this.MouseDoubleClick += this_MouseDoubleClick;
        txt.Leave += (o, e) =>
        {
            current_hit.SubItem.Text = txt.Text; 
            txt.Visible = false;
            if (txtch)
            {
                txtch = false;
                ChangeCell(current_hit.Item);
            }
        };
        txt.KeyDown += txt_KeyDown;
        txt.TextChanged += txt_textchanged;
    }
    private void txt_textchanged(object sender, EventArgs e)
    {
        txtch = true;
    }
    private void txt_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            current_hit.SubItem.Text = ((TextBox)sender).Text; 
            ((TextBox)sender).Visible = false;
          //  ChangeCell(current_hit.Item); 

        }
    }
    private void this_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Left)
        {
            ListViewHitTestInfo hit = this.HitTest(e.Location);
            current_hit = hit; 
            Rectangle rowBounds = hit.SubItem.Bounds;
            Rectangle labelBounds = hit.Item.GetBounds(ItemBoundsPortion.Label);
            int leftMargin = labelBounds.Left - 1;
            txt.Bounds = new Rectangle(rowBounds.Left + leftMargin, rowBounds.Top, rowBounds.Width - leftMargin - 1, rowBounds.Height);
            txt.Text = hit.SubItem.Text;
            txt.SelectAll();
            txt.Visible = true;
            txt.Focus();
            txtch = false;
        }
    }
}
public class CellChangedEventArgs : EventArgs
{
    public ListViewItem Item { get; private set; }

    public CellChangedEventArgs(ListViewItem changedItem)
    {
        Item = changedItem;
    }
}