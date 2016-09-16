using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Threading;

namespace TImeShareApp
{
    public partial class MainMDI : Office2007Form
    {

        public MainMDI()
        {

            InitializeComponent();
            this.Size = new Size(1024, 768);

        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }



        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }


        private void MainMDI_Load(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;

            Utility.database = new Database(Utility.settings["MDBpath"]);
            MdiClient ctlMDI;
            int cn = 0;
            // Loop through all of the form's controls looking
            // for the control of type MdiClient.
            foreach (Control ctl in this.Controls)
            {
                try
                {
                    // Attempt to cast the control to type MdiClient.
                    ctlMDI = (MdiClient)ctl;

                    // Set the BackColor of the MdiClient control.
                    ctlMDI.BackColor = this.BackColor;
                    cn += 1;
                }
                catch
                {
                    // Catch and ignore the error if casting failed.
                }
            }

            Language l = new Language();
            l["application_title"] = "Time Share";
            l["file"] = "File";
            l["edit"] = "Edit";
            l["view"] = "View";
            l["tools"] = "Tools";
            l["windows"] = "Windows";
            l["help"] = "Help";
            l["new"] = "New";
            l["open"] = "Open";
            l["save"] = "Save";
            l["save_as"] = "Save as...";
            l["print"] = "Print";
            l["print_preview"] = "Print Preview";
            l["print_setup"] = "Print Setup";
            l["exit"] = "Exit";
            l["toolbar"] = "Toolbar";
            l["statusbar"] = "Status Bar";
            l["options"] = "Options";
            l["about"] = "About";
            l["tools"] = "Tools";
            l["clients_title"] = "Clients";
            l["client"] = "Client";
            l["ok"] = "OK";
            l["cancel"] = "Cancel";
            l["extract"] = "Extract";
            l["name"] = "Name";
            l["surname"] = "Surname";
            l["address"] = "Address";
            l["phone"] = "Phone";
            l["bank_number"] = "Bank number";
            l["rci_number"] = "RCI number";
            l["appartment"] = "Appartment";
            l["contract"] = "Contact";
            l["contracts"] = "Contacts";
            l["card"] = "Cards";
            l["date"] = "Date";
            l["ammount"] = "Ammount";
            l["proof_of_service"] = "POF";
            l["notes"] = "Notes";
            l["year"] = "Year";
            l["month"] = "Month";
            l["day"] = "Day";
            l["week"] = "Week";

            l["application_title"] = "Time Share";
            l["file"] = "Αρχείο";
            l["edit"] = "Επεξεργασία";
            l["view"] = "Προβολή";
            l["tools"] = "Εργαλεία";
            l["windows"] = "Παράθυρα";
            l["help"] = "Βοήθεια";
            l["new"] = "Νέο";
            l["open"] = "Άνοιγμα";
            l["save"] = "Αποθήκευση";
            l["save_as"] = "Αποθήκευση ώς...";
            l["print"] = "Εκτύπωση";
            l["print_preview"] = "Προβολή εκτύπωσης";
            l["print_setup"] = "Επεξεργασία εκτύπωσης";
            l["exit"] = "Έξοδος";
            l["toolbar"] = "Γραμμή εργαλείων";
            l["statusbar"] = "Γραμμή κατάστασης";
            l["options"] = "Επιλογές";
            l["about"] = "Περί";
            l["tools"] = "Εργαλεία";
            l["clients_title"] = "Πελάτες";
            l["client"] = "Πελάτης";
            l["ok"] = "Εντάξει";
            l["cancel"] = "Άκυρο";
            l["extract"] = "Εξαγωγή";
            l["number"] = "Κωδικός";
            l["name"] = "Όνομα";
            l["surname"] = "Επόνυμο";
            l["address"] = "Διεύθυνση";
            l["phone"] = "Τηλέφωνο";
            l["bank_number"] = "Αριθμός τραπέζης";
            l["rci_number"] = "Αριθμός RCI";
            l["appartment"] = "Διαμέρισμα";
            l["appartments"] = "Διαμερίσματα";
            l["contract"] = "Συμβόλαιο";
            l["contracts"] = "Συμβόλαια";
            l["card"] = "Καρτέλα";
            l["cards"] = "Καρτέλες";
            l["date"] = "Ημερομηνια";
            l["ammount"] = "Ποσό";
            l["proof_of_service"] = "ΑΠΥ";
            l["notes"] = "Σημειώσεις";
            l["year"] = "Χρόνος";
            l["month"] = "Μήνας";
            l["day"] = "Ημέρα";
            l["week"] = "Εβδομάδα";
            l["client_info"] = "Πληροφορίες πελάτη";
            l["clients"] = "Πελάτες";
            l["email"] = "Email";
            l["appartment_number"] = "Αριθμός Διαμερίσματος";
            l["add_card"] = "Προσθήκη καρτέλας";
            l["reset_form"] = "Επαναφορά φόρμας";
            l["add_card_q"] = "Προσθήκη καρτέλας;";
            l["reset_form_q"] = "Επαναφορά φόρμας;";
            l["addnew_f"] = "Προσθήκη νέας";
            l["company"] = "Εταιρία";
            l["remove"] = "Αφαίρεση";
            l["appartment-week"] = "Διαμέρισμα-Εβδομάδα";
            l["nothing_to_remove"] = "Δεν υπάρχει τίποτα για να αφαιρεθεί.";
            l["pls_select_name_from_list"] = "Παρακαλώ επιλέξτε πρώτα ένα όνομα από τη λίστα.";
            l["pls_select_address_from_list"] = "Παρακαλώ επιλέξτε πρώτα μια διεύθυνση από τη λίστα.";
            l["pls_select_phone_from_list"] = "Παρακαλώ επιλέξτε πρώτα ένα τηλέφωνο από τη λίστα.";
            l["pls_select_email_from_list"] = "Παρακαλώ επιλέξτε πρώτα ένα email από τη λίστα.";

            l["delete_selected_name_q"] = "Διαγραφή επιλεγμένου ονόματος;";
            l["delete_selected_address_q"] = "Διαγραφή επιλεγμένης διεύθυνσης;";
            l["delete_selected_phone_q"] = "Διαγραφή επιλεγμένου τηλεφώνου;";
            l["delete_selected_email_q"] = "Διαγραφή επιλεγμένου email;";
            l["enable_editing"] = "Ενεργοποίηση επεξεργασίας";
            l["find"] = "Εύρεση";
            l["enter_a_nore"] = "Εισάγετε σημείωση: ";
            l["note"] = "Σημείωση";
            l["pos"] = "ΑΠΥ";
            l["m_value"] = "Ποσό";
            l["m_value:"] = "Ποσό: ";
            l["pos:"] = "ΑΠΥ: ";
            l["enter_pos"] = "Εισαγωγή ΑΠΥ";
            l["pay_for"] = "Πληρωμή για - ";
            l["payment"] = "Εξώφληση";
            l["card_search"] = "Εύρεση καρτέλας";
            //options
            l["general"] = "Γενικά";
            l["database"] = "Βάση δεδωμένων";
            l["option_lang_des"] = "Αυτή η επιλογή αλλάζει την γλώσσα του προγράμματος";
            l["language"] = "Γλώσσα";
            l["options_database_location"] = "Τοποθεσία βάσης δεδωμένων: ";
            l["browse"] = "Επιλογή...";
            l["edit_in_access"] = "Επεξεργασία στο Access";
            l["payments"] = "Πληρομές";
            l["search_by"] = "Αναζήτηση βάση σε:";
            l["resaults"] = "Αποτελέσματα";
            l["connect"] = "Σύνδεση";
            l["login"] = "Σύνδεση";
            l["gooffline"] = "Τοπική χρήση"; 
            l["loginform"] = "Φόρμα σύνδεσης";

            l["server"] = "Διακομιστής";
            l["port"] = "Θύρα";
            l["username"] = "Όνομα χρήστη";
            l["password"] = "Κωδικός";
            Utility.CurrentLanguage = l;
            //System.IO.File.WriteAllText("gr", JsonConvert.SerializeObject(obj));


            this.Text = Utility.CurrentLanguage["application_title"];
            fileMenu.Text = Utility.CurrentLanguage["file"];

            exitToolStripMenuItem.Text = Utility.CurrentLanguage["exit"];


            viewMenu.Text = Utility.CurrentLanguage["view"];
            statusBarToolStripMenuItem.Text = Utility.CurrentLanguage["statusbar"];

            toolsMenu.Text = Utility.CurrentLanguage["tools"];
            optionsToolStripMenuItem.Text = Utility.CurrentLanguage["options"];

            windowsMenu.Text = Utility.CurrentLanguage["windows"];
            helpMenu.Text = Utility.CurrentLanguage["help"];

            aboutToolStripMenuItem.Text = Utility.CurrentLanguage["about"];

            allcardsToolStripMenuItem.Text = Utility.CurrentLanguage["cards"];
            findToolStripMenuItem1.Text = Utility.CurrentLanguage["find"];
            addNewToolStripMenuItem.Text = Utility.CurrentLanguage["addnew_f"];
            clientsToolStripMenuItem.Text = Utility.CurrentLanguage["clients"];

            new Thread(() => { Thread.Sleep(100); this.Invoke(new Action(() => { ShowLoginForm(); })); }).Start();
            //            ShowSearchCard();

        }
        private string serializeObject(object obj)
        {
            string sz = JsonConvert.SerializeObject(obj);
            // JsonConvert.DeserializeObject<SampleGroup>(sz, new SampleConverter());

            return sz;
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowOptions();
        }


        private void SendSrt(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            Application.DoEvents();
            this.Cursor = Cursors.AppStarting;
        }

        private void SendEnd(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            Application.DoEvents();
            this.Cursor = Cursors.Default;
        }
        private void ShowLoginForm()
        {

            AuthLoginForm F2 = new AuthLoginForm();

            F2.ShowDialog();
            if (F2.authed)
            {

                Utility.database.OnlineMode = true;
                statusLabel.Text = "Online Mode - Connected to " + Utility.Connection.IP + ":" + Utility.Connection.Port.ToString();
                statusLabel.ForeColor = Color.Green;
                conBtnToolStripMenuItem.Text = "Logout";
                Utility.Connection.SendStarted += SendSrt;
                Utility.Connection.SendEnded += SendEnd;
            }
            else
            {
                Utility.Connection = null;
                statusLabel.Text = "Offline Mode";
                statusLabel.ForeColor = Color.Red;
                conBtnToolStripMenuItem.Text = "Login";
            }

        }

        private void ShowSearchCard()
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm is CardSearch)
                {
                    if (frm.WindowState == FormWindowState.Minimized)
                        frm.WindowState = FormWindowState.Normal;
                    frm.Focus();
                    return;
                }
            }
            CardSearch F2 = new CardSearch();
            F2.MdiParent = this;
            F2.Show();
        }

        private void ShowRunQuery()
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm is RunQuery)
                {
                    if (frm.WindowState == FormWindowState.Minimized)
                        frm.WindowState = FormWindowState.Normal;
                    frm.Focus();
                    return;
                }
            }
            RunQuery F2 = new RunQuery();
            F2.MdiParent = this;
            F2.Show();


        }
        private void ShowOptions()
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm is options_form)
                {
                    if (frm.WindowState == FormWindowState.Minimized)
                        frm.WindowState = FormWindowState.Normal;
                    frm.Focus();
                    return;
                }
            }
            options_form F2 = new options_form();
            F2.MdiParent = this;
            F2.Show();

        }
        private void ShowAddCard()
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm is addCard)
                {
                    if (frm.WindowState == FormWindowState.Minimized)
                        frm.WindowState = FormWindowState.Normal;
                    frm.Focus();
                    return;
                }
            }
            addCard F2 = new addCard();
            F2.MdiParent = this;
            F2.Show();


        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAddCard();
        }

        private void chargeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {

            InputForms.InputForm iform = new InputForms.InputForm(new string[2] { "Year:", "Value:" }, "Charge", "Charge clients", 40, 150);
            string[] iformres = iform.Open(this);
            if (iformres != null)
                if (MessageBox.Show(this, "Charge all clients " + iformres[1] + "€ for " + iformres[0] + "?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Utility.database.OpenConnection();

                    SqlResault res = Utility.database.Query("select id from Clients");

                    for (int i = 0; i < res.Count; i++)
                    {
                        string cid = res[i]["id"];
                        SqlResault appartments = Utility.database.Query("select * from Appartments where client_id = " + cid + ";");
                        for (int j = 0; j < appartments.Count; j++)
                        {
                            Utility.database.Query(@"insert into Owes (client_id, appartment_id, aYear,mvalue,notes)
                                             values (" + cid + ", '" + appartments[j]["id"] + "' , '" + iformres[0] + "', " + iformres[1] + ", '');");
                        }
                    }
                    Utility.database.CloseConnection();
                    MessageBox.Show("All clients were charged for their appartments for the year " + iformres[0] + ".");
                }
        }

        private void helpMenu_Click(object sender, EventArgs e)
        {

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.Q))
            {
                ShowRunQuery();

                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void allcardsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void findToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowSearchCard();

        }

        private void conBtnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Utility.Connection != null)
            {
                if (Utility.Connection.Connected)
                {
                    Utility.Connection.Send<string>("logout");
                    Utility.Connection = null;
                    Utility.database.OnlineMode = false;
                    statusLabel.Text = "Offline Mode";
                    statusLabel.ForeColor = Color.Red;
                    conBtnToolStripMenuItem.Text = "Login";
                }
                else
                {
                    ShowLoginForm();
                }
            }
            else
            {
                ShowLoginForm();
            }
        }
    }
}
