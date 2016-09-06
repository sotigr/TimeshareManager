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
    public partial class MultiLineInputForm : Office2007Form
    {
        bool appl = false;
        public MultiLineInputForm(string input_text, string title, string button_text)
        {
            InitializeComponent();
            EnableGlass = false;
            button2.Text = Utility.CurrentLanguage["cancel"];
            button1.Text = button_text;
            this.Text = title;
            textBox1.Text = input_text;
        }
        public string Open(IWin32Window owner)
        {
      
            this.ShowDialog(owner);
            if (appl)
                return textBox1.Text;
            else
                return null;
        }
        private void MultiLineInputForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            appl = true;
            this.Close();
        }
    }
}
