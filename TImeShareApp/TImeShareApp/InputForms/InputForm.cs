using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
namespace TImeShareApp.InputForms
{
    public partial class InputForm : Office2007Form
    {
        private bool isok = false;
      public  List<TextBox> textboxes = new List<TextBox>();
        public InputForm( string[] items, string buttontext, string title, int labelwidth, int textboxwidth)
        {
        
            InitializeComponent();
            this.EnableGlass = false;
            
            for (int i = 0; i < items.Length; i++)
            {
                FlowLayoutPanel f = new FlowLayoutPanel();
                f.AutoSize = true;
                f.Controls.Add(new Label() { Width = labelwidth, Text = items[i] });
                TextBox t = new TextBox();
                t.Width = textboxwidth;
                textboxes.Add(t);
                f.Controls.Add(t);
                flowLayoutPanel1.Controls.Add(f);

            }
            button1.Text = buttontext;
            button2.Text = Utility.CurrentLanguage["cancel"];
            this.Text = title;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            isok = true;
            this.Close();
        }

        public string[] Open(IWin32Window owner)
        {
            base.ShowDialog(owner);
            if (isok)
            {
                string[] arr = new string[this.textboxes.Count];
                for (int i = 0; i < textboxes.Count; i++)
                {
                    arr[i] = textboxes[i].Text;
                }
                return arr;
            }
            return null;
        }

        private void InputForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InputForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
