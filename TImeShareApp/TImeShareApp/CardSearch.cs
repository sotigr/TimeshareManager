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
    public partial class CardSearch : Office2007Form
    {
        public CardSearch()
        {
            InitializeComponent();
        }

        private void CardSearch_Load(object sender, EventArgs e)
        {
            this.Text = Utility.CurrentLanguage["card_search"];
            combo_search.Items.Add(Utility.CurrentLanguage["name"]);
            combo_search.Items.Add(Utility.CurrentLanguage["number"]);
            combo_search.Items.Add(Utility.CurrentLanguage["address"]);
            combo_search.Items.Add(Utility.CurrentLanguage["phone"]);
            combo_search.Items.Add(Utility.CurrentLanguage["email"]);
            combo_search.Items.Add(Utility.CurrentLanguage["rci_number"]);
            combo_search.Items.Add(Utility.CurrentLanguage["bank_number"]);
            combo_search.Items.Add(Utility.CurrentLanguage["appartment-week"]);
            combo_search.SelectedIndex = 0;
            label1.Text = Utility.CurrentLanguage["search_by"];
            label2.Text = Utility.CurrentLanguage["resaults"];

        }


        private void listViewEx1_DoubleClick(object sender, EventArgs e)
        {
            Utility.database.OpenConnection();
            string id = Utility.database.Query("select id from Clients where UserNumber = '" + listViewEx1.SelectedItems[0].SubItems[0].Text + "';")[0]["id"];
            Utility.database.CloseConnection();


            bool card_open = false;
            foreach (Form childForm in Program.MainMdiWindow.MdiChildren)
            {
                try
                {
                    if (((Card)childForm).id == id)
                    {
                        card_open = true;
                        childForm.Focus();
                    }
                }
                catch { }
            }
            if (!card_open)
            {
                Card c = new Card(id);
             c.MdiParent = Program.MainMdiWindow;
                c.WindowState = FormWindowState.Normal;
                c.Show();
            }

        }


        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        { 
            Search();
        }
        private void Search()
        {
            try
            {
                listViewEx1.Clear();
                if (maskedTextBox1.Text.Trim() == "") 
                    return; 

                SqlResault res = null;
                string static_query_part = "select distinct Clients.UserNumber as " + Utility.CurrentLanguage["number"] + ", Names.name as " + Utility.CurrentLanguage["name"] + ", Phones.pNumber as " + Utility.CurrentLanguage["phone"] + ", Addresses.uAddress as " + Utility.CurrentLanguage["address"] + " , Appartments.AppartmentNumber as " + Utility.CurrentLanguage["appartment"] + ", Appartments.aWeek as " + Utility.CurrentLanguage["week"] + "  from Names, Clients, Phones, Appartments, Addresses, Emails ";
              if (combo_search.SelectedIndex == 0)
                {
                    res = Utility.database.Query(static_query_part + @"where Clients.id = Appartments.client_id and Clients.id = Addresses.client_id and Clients.id = Phones.client_id and Clients.id = Names.client_id and
                                                                     Names.name LIKE '" + maskedTextBox1.Text + "%';");
                }
                else if (combo_search.SelectedIndex == 1)
                {
                    res = Utility.database.Query(static_query_part  + @"where Clients.id = Appartments.client_id and Clients.id = Addresses.client_id and Clients.id = Phones.client_id and Clients.id = Names.client_id and 
                                                                       Clients.UserNumber LIKE '" + maskedTextBox1.Text + "%';" );
                }
                else if (combo_search.SelectedIndex == 2)
                {
                    res = Utility.database.Query(static_query_part  + @"where Clients.id = Appartments.client_id and Clients.id = Addresses.client_id and Clients.id = Phones.client_id and Clients.id = Names.client_id and 
                                                                        Addresses.uAddress LIKE '" + maskedTextBox1.Text + "%';" );
                }
                else if (combo_search.SelectedIndex == 3)
                {
                    res = Utility.database.Query(static_query_part  + @"where Clients.id = Appartments.client_id and Clients.id = Addresses.client_id and Clients.id = Phones.client_id and Clients.id = Names.client_id and 
                                                                        Clients.id = Phones.client_id and Phones.pNumber LIKE '" + maskedTextBox1.Text + "%';"    );
                }
                else if (combo_search.SelectedIndex == 4)
                {
                    res = Utility.database.Query(static_query_part  + @"where Clients.id = Appartments.client_id and Clients.id = Addresses.client_id and Clients.id = Phones.client_id and Clients.id = Names.client_id and 
                                                                        Clients.id = Emails.client_id and Emails.email LIKE '" + maskedTextBox1.Text + "%';"    );
                }
                else if (combo_search.SelectedIndex == 5)
                {
                    res = Utility.database.Query(static_query_part  + @"where Clients.id = Appartments.client_id and Clients.id = Addresses.client_id and Clients.id = Phones.client_id and Clients.id = Names.client_id and 
                                                                            Clients.RCINumber LIKE '" + maskedTextBox1.Text + "%';"    );
                }
                else if (combo_search.SelectedIndex == 6)
                {
                    res = Utility.database.Query(static_query_part  + @"where Clients.id = Appartments.client_id and Clients.id = Addresses.client_id and Clients.id = Phones.client_id and Clients.id = Names.client_id and 
                                                                        Clients.BankNumber LIKE '" + maskedTextBox1.Text + "%';"    );
                }
                else if (combo_search.SelectedIndex == 7)
                {
                    string appartment = maskedTextBox1.Text.Substring(0, 3);
                    string week = maskedTextBox1.Text.Substring(4, 2);
                    res = Utility.database.Query(static_query_part  + @"where Clients.id = Appartments.client_id and Clients.id = Addresses.client_id and Clients.id = Phones.client_id and Clients.id = Names.client_id and 
                                                                        Clients.id = Appartments.client_id and Appartments.AppartmentNumber = '" + appartment + "' and Appartments.aWeek = '" + week + "';");
                }
                else
                    return;

                List<string> codes = new List<string>();
                 
                foreach (KeyValuePair<string, string> kv in res[0])
                {
                    listViewEx1.Columns.Add(kv.Key);
                }
                for (int i = 0; i < res.Count; i++)
                {
                    ListViewItem it = new ListViewItem();
                    bool floop = true;
                    foreach (KeyValuePair<string, string> kv in res[i])
                    {
                        if (floop)
                        {
                            it.Text = kv.Value;
                            floop = false;
                        }
                        else
                            it.SubItems.Add(kv.Value);

                    }
                    if (!codes.Contains(it.SubItems[0].Text))
                    {
                        listViewEx1.Items.Add(it);
                        codes.Add(it.SubItems[0].Text);
                    }
                }
            }
            catch {
              //  MessageBox.Show(ex.Message);
            }

        }
        private void maskedTextBox1_Enter(object sender, EventArgs e)
        {
            Utility.database.OpenConnection();
        }

        private void maskedTextBox1_Leave(object sender, EventArgs e)
        {
            Utility.database.CloseConnection();
        }

        private void combo_search_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_search.SelectedIndex == 7)
                maskedTextBox1.Mask = "000-00";
            else
                maskedTextBox1.Mask = "";
            maskedTextBox1.Focus();
            Search();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (combo_search.SelectedIndex == 7)
                maskedTextBox1.Mask = "000-00";
            else
                maskedTextBox1.Mask = "";
            maskedTextBox1.Focus();
            Search();
        }

        private void CardSearch_Activated(object sender, EventArgs e)
        {
            Utility.database.OpenConnection();
            Search();
        }
    }
}
