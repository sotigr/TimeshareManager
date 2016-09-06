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
namespace TImeShareApp
{
    public partial class RunQuery : Office2007Form
    {
        public RunQuery()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {    Utility.database.OpenConnection();
            try {
                string[] qrcommands = textBox1.Text.Split(';');
            
                foreach (string command in qrcommands)
                {
                    if (command.Trim() != "")
                        Utility.database.Query(command + ";");
                }
            
            } catch (Exception ex) {
                MessageBox.Show(textBox1.Text + "\n\r" + ex.Message);
            }
            Utility.database.CloseConnection();
        }
 

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Reset database", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                System.IO.File.WriteAllBytes(Utility.settings["MDBpath"], TImeShareApp.Properties.Resources.dbtemplate);
                byte[] new_arr = new byte[TImeShareApp.Properties.Resources.db.Length - 3];
                Buffer.BlockCopy(TImeShareApp.Properties.Resources.db, 3, new_arr, 0, new_arr.Length);
                string qr = Encoding.UTF8.GetString(new_arr);

                string[] qrcommands = qr.Split(';');
                Utility.database.OpenConnection();
                foreach (string command in qrcommands)
                {
                    if (command.Trim() != "")
                        Utility.database.Query(command + ";");
                }
                Utility.database.CloseConnection();
            }
        }
    }
}
