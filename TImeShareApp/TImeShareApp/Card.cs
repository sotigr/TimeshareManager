using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Runtime.InteropServices;
using TImeShareApp.InputForms;
namespace TImeShareApp
{
    public partial class Card : Office2007Form
    {
        struct appartment_week
        {
            public string week;
            public string appartment;
        };
        public string id;
        private string number, bank_num, rci_num, company, notes;
        private List<string> names, addresses, phones, emails, contracts;

        private void list_phones_Leave(object sender, EventArgs e)
        {
            ((ListBox)sender).SelectedIndex = -1;
        }

        private void list_email_Leave(object sender, EventArgs e)
        {
            ((ListBox)sender).SelectedIndex = -1;
        }

        private void list_contracts_Leave(object sender, EventArgs e)
        {
            ((ListBox)sender).SelectedIndex = -1;
        }

        private void names_removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (list_names.SelectedIndices.Count > 0)
                list_names.Items.Remove(list_names.SelectedItem);
            else
                MessageBox.Show("Please select a name");
        }

        private void list_addresses_Leave(object sender, EventArgs e)
        {
            ((ListBox)sender).SelectedIndex = -1;
        }

        private void Card_Move(object sender, EventArgs e)
        {
            if (payments_frm != null)
            {
                //payments_frm.Focus();
                payments_frm.Location = new System.Drawing.Point(this.Location.X + this.Width, this.Location.Y);
            }

        }

        private void txt_number_DoubleClick(object sender, EventArgs e)
        {
            InputForm f = new InputForm(new string[1] { Utility.CurrentLanguage["number"] + ":" }, Utility.CurrentLanguage["ok"], "", 60, 150);
            f.textboxes[0].Text = txt_number.Text;
            string[] fres = f.Open(this);
            if (fres == null)
                return;
            Utility.database.OpenConnection();

            Utility.database.Query("update Clients set UserNumber = '" + fres[0] + "' where id = " + id + ";");

            Utility.database.CloseConnection();
            LoadFields();
        }



        private void txt_rci_number_DoubleClick(object sender, EventArgs e)
        {
            InputForm f = new InputForm(new string[1] { Utility.CurrentLanguage["rci_number"] + ":" }, Utility.CurrentLanguage["ok"], "", 85, 150);
            f.textboxes[0].Text = txt_rci_number.Text;
            string[] fres = f.Open(this);
            if (fres == null)
                return;
            Utility.database.OpenConnection();

            Utility.database.Query("update Clients set RCINumber = '" + fres[0] + "' where id = " + id + ";");

            Utility.database.CloseConnection();
            LoadFields();
        }

        private void txt_bank_number_DoubleClick(object sender, EventArgs e)
        {
            InputForm f = new InputForm(new string[1] { Utility.CurrentLanguage["bank_number"] + ":" }, Utility.CurrentLanguage["ok"], "", 120, 150);
            f.textboxes[0].Text = txt_bank_number.Text;
            string[] fres = f.Open(this);
            if (fres == null)
                return;
            Utility.database.OpenConnection();

            Utility.database.Query("update Clients set BankNumber = '" + fres[0] + "' where id = " + id + ";");

            Utility.database.CloseConnection();
            LoadFields();
        }

        private void txt_notes_DoubleClick(object sender, EventArgs e)
        {
            MultiLineInputForm f = new MultiLineInputForm(txt_notes.Text, Utility.CurrentLanguage["notes"], Utility.CurrentLanguage["ok"]);

            string fres = f.Open(this);
            if (fres == null)
                return;
            Utility.database.OpenConnection();

            Utility.database.Query("update Clients set cNotes = '" + fres + "' where id = " + id + ";");

            Utility.database.CloseConnection();
            LoadFields();
        }


        private void list_names_DoubleClick(object sender, EventArgs e)
        {
            if (list_names.SelectedItems.Count != 1)
                return;
            InputForm f = new InputForm(new string[1] { Utility.CurrentLanguage["name"] + ":" }, Utility.CurrentLanguage["ok"], "", 80, 150);
            f.textboxes[0].Text = (string)list_names.SelectedItem;
            string[] fres = f.Open(this);
            if (fres == null)
                return;
            Utility.database.OpenConnection();

            Utility.database.Query("update Names set name = '" + fres[0] + "' where client_id = " + id + " and name = '" + (string)list_names.SelectedItem + "';");

            Utility.database.CloseConnection();
            LoadFields();
        }

        private void list_addresses_DoubleClick(object sender, EventArgs e)
        {
            if (list_addresses.SelectedItems.Count != 1)
                return;
            InputForm f = new InputForm(new string[1] { Utility.CurrentLanguage["address"] + ":" }, Utility.CurrentLanguage["ok"], "", 80, 150);
            f.textboxes[0].Text = (string)list_addresses.SelectedItem;
            string[] fres = f.Open(this);
            if (fres == null)
                return;
            Utility.database.OpenConnection();

            Utility.database.Query("update Addresses set uAddress = '" + fres[0] + "' where client_id = " + id + " and uAddress = '" + (string)list_addresses.SelectedItem + "';");

            Utility.database.CloseConnection();
            LoadFields();
        }

        private void list_phones_DoubleClick(object sender, EventArgs e)
        {
            if (list_phones.SelectedItems.Count != 1)
                return;
            InputForm f = new InputForm(new string[1] { Utility.CurrentLanguage["phone"] + ":" }, Utility.CurrentLanguage["ok"], "", 80, 150);
            f.textboxes[0].Text = (string)list_phones.SelectedItem;
            string[] fres = f.Open(this);
            if (fres == null)
                return;
            Utility.database.OpenConnection();

            Utility.database.Query("update Phones set pNumber = '" + fres[0] + "' where client_id = " + id + " and pNumber = '" + (string)list_phones.SelectedItem + "';");

            Utility.database.CloseConnection();
            LoadFields();
        }

        private void list_email_DoubleClick(object sender, EventArgs e)
        {
            if (list_email.SelectedItems.Count != 1)
                return;
            InputForm f = new InputForm(new string[1] { Utility.CurrentLanguage["email"] + ":" }, Utility.CurrentLanguage["ok"], "", 80, 150);
            f.textboxes[0].Text = (string)list_email.SelectedItem;
            string[] fres = f.Open(this);
            if (fres == null)
                return;
            Utility.database.OpenConnection();

            Utility.database.Query("update Emails set email = '" + fres[0] + "' where client_id = " + id + " and email = '" + (string)list_email.SelectedItem + "';");

            Utility.database.CloseConnection();
            LoadFields();
        }

        private void list_appartments_DoubleClick(object sender, EventArgs e)
        {
            if (list_appartments.SelectedItems.Count != 1)
                return;
            InputForm f = new InputForm(new string[2] { Utility.CurrentLanguage["appartment"] + ":", Utility.CurrentLanguage["week"] + ":" }, Utility.CurrentLanguage["ok"], "", 80, 150);
            f.textboxes[0].Text = list_appartments.SelectedItems[0].SubItems[0].Text;
            f.textboxes[1].Text = list_appartments.SelectedItems[0].SubItems[1].Text;
            string[] fres = f.Open(this);
            if (fres == null)
                return;
            Utility.database.OpenConnection();

            Utility.database.Query("update Appartments set AppartmentNumber = '" + fres[0] + "', aWeek = '" + fres[1] + "' where client_id = " + id + " and AppartmentNumber = '" + list_appartments.SelectedItems[0].SubItems[0].Text + "' and aWeek = '" + list_appartments.SelectedItems[0].SubItems[1].Text + "';");

            Utility.database.CloseConnection();
            LoadFields();
        }

        private void names_add_Click(object sender, EventArgs e)
        {
            InputForm f = new InputForm(new string[1] { Utility.CurrentLanguage["name"] + ":" }, Utility.CurrentLanguage["ok"], Utility.CurrentLanguage["name"], 60, 150);
            string[] res = f.Open(this);
            if (res != null)
            {
                if (res[0].Trim() == "")
                    return;
                string name = res[0];

                Utility.database.OpenConnection();

                Utility.database.Query("insert into Names (client_id, name) values ('" + id + "' ,'" + name + "');");

                Utility.database.CloseConnection();
                this.LoadFields();
            }
        }

        private void addresses_add_Click(object sender, EventArgs e)
        {
            InputForm f = new InputForm(new string[1] { Utility.CurrentLanguage["address"] + ":" }, Utility.CurrentLanguage["ok"], Utility.CurrentLanguage["address"], 80, 150);
            string[] res = f.Open(this);
            if (res != null)
            {
                if (res[0].Trim() == "")
                    return;
                string addr = res[0];

                Utility.database.OpenConnection();

                Utility.database.Query("insert into Addresses (client_id, uAddress) values ('" + id + "' ,'" + addr + "');");

                Utility.database.CloseConnection();
                this.LoadFields();
            }
        }

        private void phones_add_Click(object sender, EventArgs e)
        {
            InputForm f = new InputForm(new string[1] { Utility.CurrentLanguage["phone"] + ":" }, Utility.CurrentLanguage["ok"], Utility.CurrentLanguage["phone"], 80, 150);
            string[] res = f.Open(this);
            if (res != null)
            {
                if (res[0].Trim() == "")
                    return;
                string phone = res[0];

                Utility.database.OpenConnection();

                Utility.database.Query("insert into Phones (client_id, pNumber) values ('" + id + "' ,'" + phone + "');");

                Utility.database.CloseConnection();
                this.LoadFields();
            }
        }

        private void emails_add_Click(object sender, EventArgs e)
        {
            InputForm f = new InputForm(new string[1] { Utility.CurrentLanguage["email"] + ":" }, Utility.CurrentLanguage["ok"], Utility.CurrentLanguage["email"], 60, 150);
            string[] res = f.Open(this);
            if (res != null)
            {
                if (res[0].Trim() == "")
                    return;
                string email = res[0];

                Utility.database.OpenConnection();

                Utility.database.Query("insert into Emails (client_id, email) values ('" + id + "' ,'" + email + "');");

                Utility.database.CloseConnection();
                this.LoadFields();
            }
        }

        private void appartments_add_Click(object sender, EventArgs e)
        {
            InputForm f = new InputForm(new string[2] { Utility.CurrentLanguage["appartment"] + ":", Utility.CurrentLanguage["week"] + ":" }, Utility.CurrentLanguage["ok"], Utility.CurrentLanguage["appartment"], 80, 150);
            string[] res = f.Open(this);

            if (res != null)
            {
                if (res[0].Trim() == "" || res[1].Trim() == "")
                    return;
                string appartment = res[0];
                string week = res[1];
                Utility.database.OpenConnection();

                Utility.database.Query("insert into Appartments (client_id, AppartmentNumber, aWeek) values ('" + id + "' ,'" + appartment + "', '" + week + "');");

                Utility.database.CloseConnection();
                this.LoadFields();
            }
        }

        private void contracts_add_Click(object sender, EventArgs e)
        {
            InputForm f = new InputForm(new string[1] { Utility.CurrentLanguage["contract"] + ":" }, Utility.CurrentLanguage["ok"], Utility.CurrentLanguage["contract"], 60, 150);
            string[] res = f.Open(this);
            if (res != null)
            {

                string cn;
                if (res[0].Trim() == "")
                    cn = "Unknown Contract";
                else
                    cn = res[0];

                Utility.database.OpenConnection();

                Utility.database.Query("insert into Contracts (client_id, ContractName) values ('" + id + "' ,'" + cn + "');");

                Utility.database.CloseConnection();
                this.LoadFields();
            }
        }

        private void names_remove_Click(object sender, EventArgs e)
        {
            if (list_names.SelectedIndices.Count <= 0)
                return;
            if (MessageBox.Show(this, "Are you sure you want to remove this name?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                Utility.database.OpenConnection();

                Utility.database.Query("delete from Names where client_id = " + id + " and name = '" + (string)list_names.SelectedItem + "';");

                Utility.database.CloseConnection();
                this.LoadFields();
            }
        }

        private void addresses_remove_Click(object sender, EventArgs e)
        {
            if (list_addresses.SelectedIndices.Count <= 0)
                return;
            if (MessageBox.Show(this, "Are you sure you want to remove this address?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                Utility.database.OpenConnection();

                Utility.database.Query("delete from Addresses where client_id = " + id + " and uAddress = '" + (string)list_addresses.SelectedItem + "';");

                Utility.database.CloseConnection();
                this.LoadFields();
            }
        }

        private void phones_remove_Click(object sender, EventArgs e)
        {
            if (list_phones.SelectedIndices.Count <= 0)
                return;
            if (MessageBox.Show(this, "Are you sure you want to remove this phone?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                Utility.database.OpenConnection();

                Utility.database.Query("delete from Phones where client_id = " + id + " and pNumber = '" + (string)list_phones.SelectedItem + "';");

                Utility.database.CloseConnection();
                this.LoadFields();
            }
        }

        private void emails_remove_Click(object sender, EventArgs e)
        {
            if (list_email.SelectedIndices.Count <= 0)
                return;
            if (MessageBox.Show(this, "Are you sure you want to remove this email?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                Utility.database.OpenConnection();

                Utility.database.Query("delete from Emails where client_id = " + id + " and email = '" + (string)list_email.SelectedItem + "';");

                Utility.database.CloseConnection();
                this.LoadFields();
            }
        }

        private void appartments_remove_Click(object sender, EventArgs e)
        {
            if (list_appartments.SelectedIndices.Count <= 0)
                return;
            if (MessageBox.Show(this, "Are you sure you want to remove this apaprtment?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                Utility.database.OpenConnection();

                Utility.database.Query("delete from Appartments where client_id = " + id + " and AppartmentNumber = '" + list_appartments.SelectedItems[0].SubItems[0].Text + "' and aWeek = '" + list_appartments.SelectedItems[0].SubItems[1].Text + "';");

                Utility.database.CloseConnection();
                this.LoadFields();
            }
        }

        private void contracts_remove_Click(object sender, EventArgs e)
        {
            if (list_contracts.SelectedIndices.Count <= 0)
                return;
            if (MessageBox.Show(this, "Are you sure you want to remove this contract?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int same_count = 0;
                string selected_it = (string)list_contracts.SelectedItem;
               for  (int i = 0; i < list_contracts.Items.Count; i++)
                {
                    if ((string)list_contracts.Items[i] == selected_it)
                        same_count++;
                }

                Utility.database.OpenConnection();

                string qr = "";
                qr += "delete from Contracts where client_id = " + id + " and ContractName = '" + selected_it + "';"; 
                for (int i = 0; i < same_count  - 1; i++)
                {
                    qr+= "insert into Contracts (client_id, ContractName) values ('" + id + "' ,'" + selected_it + "');";
                }
                Utility.database.Query(qr);

                Utility.database.CloseConnection();
                this.LoadFields();
            }
        }

        private List<appartment_week> appartments;
        public Card(string id)
        {
            InitializeComponent();
            this.id = id;

        }

        private void Card_Load(object sender, EventArgs e)
        {

            this.Text = Utility.CurrentLanguage["card"] + " - " + number;

            cl_label_address.Text = Utility.CurrentLanguage["address"];
            cl_label_appartments.Text = Utility.CurrentLanguage["appartments"];
            cl_label_bank_number.Text = Utility.CurrentLanguage["bank_number"];
            cl_label_client_information.Text = Utility.CurrentLanguage["client_info"];
            cl_label_contracts.Text = Utility.CurrentLanguage["contracts"];
            cl_label_email.Text = Utility.CurrentLanguage["email"];
            cl_label_name.Text = Utility.CurrentLanguage["name"];
            cl_label_number.Text = Utility.CurrentLanguage["number"];
            cl_label_phone.Text = Utility.CurrentLanguage["phone"];
            cl_label_rci_number.Text = Utility.CurrentLanguage["rci_number"];
            cl_label_notes.Text = Utility.CurrentLanguage["notes"];
            btn_paynebts.Text = Utility.CurrentLanguage["payments"];

            LoadFields();
        }
        private void LoadFields()
        {
            list_names.Items.Clear();
            list_addresses.Items.Clear();
            list_phones.Items.Clear();
            list_email.Items.Clear();
            list_appartments.Clear();
            list_contracts.Items.Clear();
            txt_number.Text = "";
            txt_rci_number.Text = "";
            txt_bank_number.Text = "";
            txt_notes.Text = "";

            Utility.database.OpenConnection();
            SqlResault res = Utility.database.Query("select * from Clients where id = " + id + ";");
            number = res[0]["UserNumber"];
            bank_num = res[0]["BankNumber"];
            rci_num = res[0]["RCINumber"];
            company = res[0]["cCompany"];
            notes = res[0]["cNotes"];

            res = Utility.database.Query("select * from Names where client_id = " + id + ";");
            names = new List<string>();
            for (int i = 0; i < res.Count; i++)
            {
                names.Add(res[i]["name"]);
            }

            res = Utility.database.Query("select * from Addresses where client_id = " + id + ";");
            addresses = new List<string>();
            for (int i = 0; i < res.Count; i++)
            {
                addresses.Add(res[i]["uAddress"]);
            }

            res = Utility.database.Query("select * from Phones where client_id = " + id + ";");
            phones = new List<string>();
            for (int i = 0; i < res.Count; i++)
            {
                phones.Add(res[i]["pNumber"]);
            }

            res = Utility.database.Query("select * from Emails where client_id = " + id + ";");
            emails = new List<string>();
            for (int i = 0; i < res.Count; i++)
            {
                emails.Add(res[i]["email"]);
            }

            res = Utility.database.Query("select * from Contracts where client_id = " + id + ";");
            contracts = new List<string>();
            for (int i = 0; i < res.Count; i++)
            {
                contracts.Add(res[i]["ContractName"]);
            }

            res = Utility.database.Query("select * from Appartments where client_id = " + id + ";");
            appartments = new List<appartment_week>();
            for (int i = 0; i < res.Count; i++)
            {
                appartments.Add(new appartment_week { appartment = res[i]["AppartmentNumber"], week = res[i]["aWeek"] });
            }
            Utility.database.CloseConnection();


            list_appartments.View = View.Details;
            list_appartments.Columns.Add(Utility.CurrentLanguage["appartment_number"]);
            list_appartments.Columns.Add(Utility.CurrentLanguage["week"]);
            list_appartments.Columns[0].Width = 50;

            txt_number.Text = number;
            txt_bank_number.Text = bank_num;
            txt_rci_number.Text = rci_num;
            txt_notes.Text = notes;

            list_names.Items.AddRange(names.ToArray());
            list_addresses.Items.AddRange(addresses.ToArray());
            list_phones.Items.AddRange(phones.ToArray());
            list_email.Items.AddRange(emails.ToArray());
            list_contracts.Items.AddRange(contracts.ToArray());

            foreach (appartment_week aw in appartments)
            {
                ListViewItem it = new ListViewItem();
                it.Text = aw.appartment;
                it.SubItems.Add(aw.week);
                list_appartments.Items.Add(it);
            }
        }
  

        private void Card_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            try
            {
                payments_frm.Close();
            }
            catch { }
            e.Cancel = false;
        }

        public payments payments_frm;
        private void btn_paynebts_Click(object sender, EventArgs e)
        {
            try
            {
                payments_frm.Close();
                payments_frm = null;
            }
            catch
            {
                payments_frm = new payments(this.id);

                payments_frm.MdiParent = Program.MainMdiWindow;

                payments_frm.Show();
                payments_frm.Location = new System.Drawing.Point(this.Location.X + this.Width, this.Location.Y);
                payments_frm.Height = this.Height;

            }
            
        }
    }
}
