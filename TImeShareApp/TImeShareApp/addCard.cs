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
    public partial class addCard : Office2007Form
    {
        public addCard()
        {
            InitializeComponent();
        }

        private void addCard_Load(object sender, EventArgs e)
        {
            Text = Utility.CurrentLanguage["add_card"];
            appartment_list.View = View.Details;
            appartment_list.Columns.Add(Utility.CurrentLanguage["appartment"]);
            appartment_list.Columns.Add(Utility.CurrentLanguage["week"]);
            appartment_list.Columns[0].Width = 50;

            cl_label_address.Text = Utility.CurrentLanguage["address"] + " - 0";
            cl_label_email.Text = Utility.CurrentLanguage["email"] + " - 0";
            cl_label_name.Text = Utility.CurrentLanguage["name"] + " - 0";
            cl_label_phone.Text = Utility.CurrentLanguage["phone"] + " - 0";
            cl_label_appartments.Text = Utility.CurrentLanguage["appartments"];
            cl_label_bank_number.Text = Utility.CurrentLanguage["bank_number"];
            cl_label_client_information.Text = Utility.CurrentLanguage["client_info"];
            cl_label_contracts.Text = Utility.CurrentLanguage["contracts"];

            cl_label_number.Text = Utility.CurrentLanguage["number"];
            cl_label_rci_number.Text = Utility.CurrentLanguage["rci_number"];
            cl_label_notes.Text = Utility.CurrentLanguage["notes"];
            cl_label_company.Text = Utility.CurrentLanguage["company"];
            btn_add_card.Text = Utility.CurrentLanguage["add_card"];
            btn_reset_form.Text = Utility.CurrentLanguage["reset_form"];
            remove_appartmentsToolStripMenuItem.Text = Utility.CurrentLanguage["remove"];
            remove_contractsToolStripMenuItem.Text = Utility.CurrentLanguage["remove"];
        }


        //==========================================================================================================================
        //==========================================================================================================================
        //==========================================================================================================================

        private void combo_name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((ComboBox)sender).Items.Add(((ComboBox)sender).Text);
                ((ComboBox)sender).Text = "";
                cl_label_name.Text = Utility.CurrentLanguage["name"] + " - " + ((ComboBox)sender).Items.Count;
            }
        }
        private void combo_address_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((ComboBox)sender).Items.Add(((ComboBox)sender).Text);
                ((ComboBox)sender).Text = "";
                cl_label_address.Text = Utility.CurrentLanguage["address"] + " - " + ((ComboBox)sender).Items.Count;
            }
        }
        private void combo_phone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((ComboBox)sender).Items.Add(((ComboBox)sender).Text);
                ((ComboBox)sender).Text = "";
                cl_label_phone.Text = Utility.CurrentLanguage["phone"] + " - " + ((ComboBox)sender).Items.Count;
            }
        }
        private void combo_email_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((ComboBox)sender).Items.Add(((ComboBox)sender).Text);
                ((ComboBox)sender).Text = "";
                cl_label_email.Text = Utility.CurrentLanguage["email"] + " - " + ((ComboBox)sender).Items.Count;
            }
        }

        //==========================================================================================================================
        //==========================================================================================================================
        //==========================================================================================================================
        private void name_combo_btn_Click(object sender, EventArgs e)
        {
            if (combo_name.Items.Count > 0)
            {
                if (MessageBox.Show(this, Utility.CurrentLanguage["delete_selected_name_q"], "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (combo_name.SelectedItem == null)
                    {
                        MessageBox.Show(Utility.CurrentLanguage["pls_select_name_from_list"]);
                        return;
                    }
                    combo_name.Items.Remove(combo_name.SelectedItem);

                    combo_name.Text = "";
                    cl_label_name.Text = Utility.CurrentLanguage["name"] + " - " + combo_name.Items.Count;
                }
            }
            else
                MessageBox.Show(Utility.CurrentLanguage["nothing_to_remove"]);
        }
        private void address_combo_btn_Click(object sender, EventArgs e)
        {
            if (combo_address.Items.Count > 0)
            {
                if (MessageBox.Show(this, Utility.CurrentLanguage["delete_selected_address_q"], "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (combo_address.SelectedItem == null)
                    {
                        MessageBox.Show(Utility.CurrentLanguage["pls_select_address_from_list"]);
                        return;
                    }
                    combo_address.Items.Remove(combo_address.SelectedItem);

                    combo_address.Text = "";
                    cl_label_address.Text = Utility.CurrentLanguage["address"] + " - " + combo_address.Items.Count;
                }
            }
            else
                MessageBox.Show(Utility.CurrentLanguage["nothing_to_remove"]);
        }
        private void phone_combo_btn_Click(object sender, EventArgs e)
        {
            if (combo_phone.Items.Count > 0)
            {
                if (MessageBox.Show(this, Utility.CurrentLanguage["delete_selected_phone_q"], "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (combo_phone.SelectedItem == null)
                    {
                        MessageBox.Show(Utility.CurrentLanguage["pls_select_phone_from_list"]);
                        return;
                    }
                    combo_phone.Items.Remove(combo_phone.SelectedItem);

                    combo_phone.Text = "";
                    cl_label_phone.Text = Utility.CurrentLanguage["phone"] + " - " + combo_phone.Items.Count;
                }
            }
            else
                MessageBox.Show(Utility.CurrentLanguage["nothing_to_remove"]);
        }
        private void email_combo_btn_Click(object sender, EventArgs e)
        {
            if (combo_email.Items.Count > 0)
            {
                if (MessageBox.Show(this, Utility.CurrentLanguage["delete_selected_email_q"], "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (combo_email.SelectedItem == null)
                    {
                        MessageBox.Show(Utility.CurrentLanguage["pls_select_email_from_list"]);
                        return;
                    }
                    combo_email.Items.Remove(combo_email.SelectedItem);

                    combo_email.Text = "";
                    cl_label_email.Text = Utility.CurrentLanguage["email"] + " - " + combo_email.Items.Count;
                }
            }
            else
                MessageBox.Show(Utility.CurrentLanguage["nothing_to_remove"]);
        }

        private void appartment_input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    string appartment = ((MaskedTextBox)sender).Text.Substring(0, 3);
                    string week = ((MaskedTextBox)sender).Text.Substring(4, 2);

                    bool exists = false;

                    foreach (ListViewItem item in appartment_list.Items)
                    {

                        if (item.SubItems[0].Text == appartment && item.SubItems[1].Text == week)
                            exists = true;
                    }
                    if (!exists)
                    {
                        ListViewItem it = new ListViewItem();
                        it.Text = appartment;
                        it.SubItems.Add(week);
                        appartment_list.Items.Add(it);
                        ((MaskedTextBox)sender).Text = "";
                    }
                    else
                        MessageBox.Show("You have already registered this appartment to this client");
                }
                catch
                {
                    MessageBox.Show("The appartment or week you entered is not valid.");
                }

            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (((TextBox)sender).Text.Trim() == "")
                {
                    contractList.Items.Add("Unknown Contract");
                }
                else
                {
                    contractList.Items.Add(((TextBox)sender).Text);
                }
                ((TextBox)sender).Text = "";
            }
        }


        private void ResetForm()
        {
            txt_bank_number.Text = "";
            txt_rci_number.Text = "";
            appartment_input.Text = "";
            txt_contracts.Text = "";
            txt_number.Text = "";
            txt_notes.Text = "";

            combo_name.Items.Clear();
            combo_name.Text = "";

            combo_address.Items.Clear();
            combo_address.Text = "";

            combo_phone.Items.Clear();
            combo_phone.Text = "";

            combo_email.Items.Clear();
            combo_email.Text = "";

            contractList.Items.Clear();
            appartment_list.Items.Clear();

            cl_label_address.Text = Utility.CurrentLanguage["address"] + " - 0";
            cl_label_email.Text = Utility.CurrentLanguage["email"] + " - 0";
            cl_label_name.Text = Utility.CurrentLanguage["name"] + " - 0";
            cl_label_phone.Text = Utility.CurrentLanguage["phone"] + " - 0";

            txt_number.Focus();
        }
        private void btn_add_card_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, Utility.CurrentLanguage["add_card_q"], "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string[] names, addresses, phones, emails;
                string number, bank_number, rci_number, company, notes;
                names = new string[combo_name.Items.Count];
                for (int i = 0; i < combo_name.Items.Count; i++)
                {
                    names[i] = (string)combo_name.Items[i];
                }

                addresses = new string[combo_address.Items.Count];
                for (int i = 0; i < combo_address.Items.Count; i++)
                {
                    addresses[i] = (string)combo_address.Items[i];
                }

                phones = new string[combo_phone.Items.Count];
                for (int i = 0; i < combo_phone.Items.Count; i++)
                {
                    phones[i] = (string)combo_phone.Items[i];
                }

                emails = new string[combo_email.Items.Count];
                for (int i = 0; i < combo_email.Items.Count; i++)
                {
                    emails[i] = (string)combo_email.Items[i];
                }

                number = txt_number.Text;
                bank_number = txt_bank_number.Text;
                rci_number = txt_rci_number.Text;
                company = txt_company.Text;
                notes = txt_notes.Text;
                Utility.database.OpenConnection();
                //FILL CLIENT TABLE
                Utility.database.Query(@"insert into Clients (UserNumber, BankNumber, RCINumber, cCompany, cNotes)
                                         values ('" + number + "', '" + bank_number + "', '" + rci_number + "', '" + company + "','" + notes + "');");
                //GET GENERATED INDEX
                string index = Utility.database.Query(@"select id from Clients where
                                                       UserNumber = '" + number + "' and BankNumber = '" + bank_number + "' and RCINumber = '" + rci_number + "' and cCompany = '" + company + "';")[0]["id"];
                //INSERT NAMES
                foreach (string nm in names)
                {
                    Utility.database.Query("insert into Names (client_id, name) values ('" + index + "', '" + nm + "');");
                }

                //INSERT ADDRESSES
                foreach (string addr in addresses)
                {
                    Utility.database.Query("insert into Addresses (client_id, uAddress) values ('" + index + "', '" + addr + "');");
                }

                //INSERT PHONES
                foreach (string ph in phones)
                {
                    Utility.database.Query("insert into Phones (client_id, pNumber) values ('" + index + "', '" + ph + "');");
                }

                //INSERT EMAILS
                foreach (string email in emails)
                {
                    Utility.database.Query("insert into Emails (client_id, email) values ('" + index + "', '" + email + "');");
                }

                //INSERT APPARTMENTS
                foreach (ListViewItem it in appartment_list.Items)
                {
                    Utility.database.Query(@"insert into Appartments (client_id, AppartmentNumber, aWeek) 
                                            values ('" + index + "', '" + it.SubItems[0].Text + "', '" + it.SubItems[1].Text + "');");
                }

                //INSERT CONTRACTS
                foreach (ListViewItem it in contractList.Items)
                {
                    Utility.database.Query(@"insert into Contracts (client_id, ContractName) 
                                            values ('" + index + "', '" + it.SubItems[0].Text + "');");
                }
                Utility.database.CloseConnection();
                ResetForm();
            }
        }

        private void btn_reset_form_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, Utility.CurrentLanguage["reset_form_q"], "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ResetForm();
            }
        }

        private void remove_appartmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (appartment_list.Items.Count > 0)
                if (appartment_list.SelectedIndices.Count > 0)
                    appartment_list.Items.Remove(appartment_list.SelectedItems[0]);
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (contractList.Items.Count > 0)
                if (contractList.SelectedIndices.Count > 0)
                    contractList.Items.Remove(contractList.SelectedItems[0]);
        }
    }
}
