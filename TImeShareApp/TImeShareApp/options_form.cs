using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using DevComponents.DotNetBar;
using System.Globalization;

namespace TImeShareApp
{
    public partial class options_form : Office2007Form
    {
        public options_form()
        {
            InitializeComponent();
        }

        private void options_form_Load(object sender, EventArgs e)
        {
 
            Text = Utility.CurrentLanguage["options"];
            tabPage1.Text = Utility.CurrentLanguage["general"];
            tabPage2.Text = Utility.CurrentLanguage["database"];
            tabPage3.Text = Utility.CurrentLanguage["payments"];
            button1.Text = Utility.CurrentLanguage["ok"];
            button2.Text = Utility.CurrentLanguage["cancel"];

            comboBox1.Items.Add("English");
            comboBox1.Items.Add("Ελληνικά");


            groupBox1.Text = Utility.CurrentLanguage["language"];
            option_lang_des.Text = Utility.CurrentLanguage["option_lang_des"];
            btn_db_brz.Text = Utility.CurrentLanguage["browse"];
            options_database_location.Text = Utility.CurrentLanguage["options_database_location"];
            btn_edit_in_access.Text = Utility.CurrentLanguage["edit_in_access"];

            if (Utility.settings["OpenFilesAfterExtraction"] == true)
                checkBox1.Checked = true;
            if (Utility.settings["KeepFileBackups"] == true)
                checkBox2.Checked = true;
            txt_db_brz.Text = Utility.settings["MDBpath"];
            if (Utility.settings["Languange"] == "gr")
                comboBox1.SelectedIndex = 1;
            else if (Utility.settings["Languange"] == "en")
                comboBox1.SelectedIndex = 0;
            else
                comboBox1.SelectedIndex = 0;
           
            txt_normal_week_cost.Text = Utility.settings["normal_week_cost"];
            txt_discount_week_cost.Text = Utility.settings["discount_week_cost"];
            try
            {
                date_dis_start.Value = DateTime.ParseExact(Utility.settings["discount_start_date"], "dd-MM", CultureInfo.InvariantCulture);
                date_dis_end.Value = DateTime.ParseExact(Utility.settings["discount_end_date"], "dd-MM", CultureInfo.InvariantCulture);
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_db_brz_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog d = new OpenFileDialog();
            d.Filter = "(*.mdb)|*.mdb";
            if (d.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txt_db_brz.Text = d.FileName;
            }
        }

        private void btn_edit_in_access_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(txt_db_brz.Text))
                Utility.openInAccess(txt_db_brz.Text);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Utility.settings["MDBpath"] = txt_db_brz.Text;
            if (comboBox1.SelectedIndex == 1)
                Utility.settings["Languange"] = "gr";
            else if (comboBox1.SelectedIndex == 0)
                Utility.settings["Languange"] = "en";
            Utility.settings["OpenFilesAfterExtraction"] = checkBox1.Checked;
            Utility.settings["KeepFileBackups"] = checkBox2.Checked;

            Utility.settings["normal_week_cost"] = txt_normal_week_cost.Text;
            Utility.settings["discount_week_cost"] = txt_discount_week_cost.Text;
            Utility.settings["discount_start_date"] = date_dis_start.Value.ToString("dd-MM");
            Utility.settings["discount_end_date"] = date_dis_end.Value.ToString("dd-MM");

            Utility.SaveSettings();
            this.Close();
        }


    }
}
