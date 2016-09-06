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
using System.Runtime.InteropServices;

namespace TImeShareApp
{
    public partial class payments : Form
    {
        string client_id;
        public payments(string client_id)
        {
            InitializeComponent();
            this.client_id = client_id;
            payed_list.View = View.Details;
            owes_list.View = View.Details;

        }

        private void payments_Load(object sender, EventArgs e)
        {
            panelEx1.Text = Utility.CurrentLanguage["client"] + " - " + client_id;
            LoadFields();
        }
        private void LoadFields()
        {
            payed_list.Clear();
            owes_list.Clear();

            payed_list.Columns.Add(new ColumnHeader() { Text = Utility.CurrentLanguage["date"], Width = 70 });
            payed_list.Columns.Add(new ColumnHeader() { Text = Utility.CurrentLanguage["appartment"], Width = 30 });
            payed_list.Columns.Add(new ColumnHeader() { Text = Utility.CurrentLanguage["week"], Width = 30 });
            payed_list.Columns.Add(Utility.CurrentLanguage["m_value"]);
            payed_list.Columns.Add(Utility.CurrentLanguage["pos"]);
            payed_list.Columns.Add(new ColumnHeader() { Text = Utility.CurrentLanguage["notes"], Width = 300 });

            owes_list.Columns.Add(new ColumnHeader() { Text = Utility.CurrentLanguage["year"], Width = 50 });
            owes_list.Columns.Add(new ColumnHeader() { Text = Utility.CurrentLanguage["appartment"], Width = 30 });
            owes_list.Columns.Add(new ColumnHeader() { Text = Utility.CurrentLanguage["week"], Width = 30 });
            owes_list.Columns.Add(Utility.CurrentLanguage["m_value"]);
            owes_list.Columns.Add(new ColumnHeader() { Text = Utility.CurrentLanguage["notes"], Width = 300 });
            Utility.database.OpenConnection();


            SqlResault res = Utility.database.Query("select *, Payed.id as payed_id from Payed, Appartments where Payed.client_id = " + client_id + " and Appartments.id = Payed.appartment_id;");
            for (int i = 0; i < res.Count; i++)
            {
                ListViewItem it = new ListViewItem();
                it.Text = DateTime.ParseExact(res[i]["aDate"], "yyyy-MM-dd H:mm:ss", System.Globalization.CultureInfo.InvariantCulture).ToString("dd/MM/yyyy").Replace("-", "/");
                it.SubItems.Add(res[i]["AppartmentNumber"]);
                it.SubItems.Add(res[i]["aWeek"]);

                it.SubItems.Add(res[i]["mvalue"] + "€");
                it.SubItems.Add(res[i]["pof"]);
                it.SubItems.Add(res[i]["notes"]);
                it.SubItems.Add(res[i]["appartment_id"]);
                it.SubItems.Add(res[i]["payed_id"]);
                payed_list.Items.Add(it);
            }

            res = Utility.database.Query("select *, Owes.id as owe_id from Owes, Appartments where Owes.client_id = " + client_id + " and Appartments.id = Owes.appartment_id;");
            for (int i = 0; i < res.Count; i++)
            {
                SqlResault monies = Utility.database.Query("select mvalue from Payed where client_id = " + client_id + " and year(aDate) = '" + DateTime.Now.Year + "' and appartment_id = " + res[i]["appartment_id"] + ";");


                ListViewItem it = new ListViewItem();
                it.Text = res[i]["aYear"];
                it.SubItems.Add(res[i]["AppartmentNumber"]);
                it.SubItems.Add(res[i]["aWeek"]);

                it.SubItems.Add(res[i]["mvalue"] + "€");
                 
                it.SubItems.Add(res[i]["notes"]);
                it.SubItems.Add(res[i]["appartment_id"]);
                it.SubItems.Add(res[i]["owe_id"]);
                owes_list.Items.Add(it);
            }


            Utility.database.CloseConnection();
        }
   

        private void payToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (owes_list.SelectedIndices.Count == 1)
            {

                InputForms.InputForm f = new InputForms.InputForm(new string[2] { Utility.CurrentLanguage["m_value:"], Utility.CurrentLanguage["pos:"] }, Utility.CurrentLanguage["ok"], Utility.CurrentLanguage["pay_for"] + owes_list.SelectedItems[0].SubItems[0].Text + " - " + owes_list.SelectedItems[0].SubItems[1].Text + " - " + owes_list.SelectedItems[0].SubItems[2].Text, 50, 200);
                string[] res = f.Open(this);
                if (res != null)
                {
                    if (!Utility.IsDouble(res[0]))
                    {
                        MessageBox.Show("Please complete the fields correctly.");
                        return;
                    }
                    if (MessageBox.Show(this, "Pay: " + res[0] + "€ ?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Utility.database.OpenConnection();

                        string owe_id = owes_list.SelectedItems[0].SubItems[6].Text;
                        double current_owe = double.Parse(Utility.database.Query("select mvalue from Owes where id = " + owe_id + ";")[0]["mvalue"]);
                        double value_to_pay = double.Parse(res[0]);
                        if (current_owe - value_to_pay <= 0)
                            Utility.database.Query("delete from Owes where id = " + owe_id + ";");
                        else
                            Utility.database.Query("update Owes set mvalue = " + (current_owe - value_to_pay) + " where id =" + owe_id + ";");

                        Utility.database.Query(@"insert into Payed (client_id, aDate, appartment_id, mvalue, pof, notes)
                                                values(" + client_id + ", '" + DateTime.Now.ToString("yyyy-MM-dd") + "', " + owes_list.SelectedItems[0].SubItems[5].Text + ", " + res[0] + ",'" + res[1] + "', '');");
                        Utility.database.CloseConnection();
                        LoadFields();
                    }
                }

            }

        }
        private void payOffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (owes_list.SelectedIndices.Count != 1)
                return;

            string owe_id = owes_list.SelectedItems[0].SubItems[6].Text;
            Utility.database.OpenConnection();
            double current_owe = double.Parse(Utility.database.Query("select mvalue from Owes where id = " + owe_id + ";")[0]["mvalue"]);

            if (MessageBox.Show(this, Utility.CurrentLanguage["payment"] + ": " + current_owe + "€ ?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                InputForms.InputForm F = new InputForms.InputForm(new string[1] { Utility.CurrentLanguage["pos:"] }, Utility.CurrentLanguage["ok"], Utility.CurrentLanguage["enter_pos"], 40, 150);
                string[] rs = F.Open(this);
                if (rs == null)
                    return;

                Utility.database.Query("delete from Owes where id = " + owe_id + ";");

                Utility.database.Query(@"insert into Payed (client_id, aDate, appartment_id, mvalue, pof, notes)
                                                values(" + client_id + ", '" + DateTime.Now.ToString("yyyy-MM-dd") + "', " + owes_list.SelectedItems[0].SubItems[5].Text + ", " + current_owe + ",'" + rs[0] + "', '');");
                Utility.database.CloseConnection();
                LoadFields();
            }
        }
         

        private void payed_list_DoubleClick(object sender, EventArgs e)
        {
            if (payed_list.SelectedIndices.Count != 1)
                return;
            InputForms.InputForm f = new InputForms.InputForm(new string[1] { Utility.CurrentLanguage["enter_a_nore"] }, Utility.CurrentLanguage["ok"], Utility.CurrentLanguage["note"], 130, 400);
            Utility.database.OpenConnection();
            string payed_id = payed_list.SelectedItems[0].SubItems[7].Text;
            f.textboxes[0].Text = Utility.database.Query("select notes from Payed where id = " + payed_id + ";")[0]["notes"];
            string[] f_res = f.Open(this);
            if (f_res != null)
            {
                string message = f_res[0];



                Utility.database.Query("update Payed set notes = '" + message + "' where id=" + payed_id + ";");
                Utility.database.CloseConnection();
                LoadFields();
            }
        }
    }
}
