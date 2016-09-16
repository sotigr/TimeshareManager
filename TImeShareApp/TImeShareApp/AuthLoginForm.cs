
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Threading;
using System;

namespace TImeShareApp
{
    public partial class AuthLoginForm : Office2007Form
    {
        public bool authed = false;
        public bool loaddone = false;
        public AuthLoginForm()
        {
            InitializeComponent();
        }

        private void AuthLoginForm_Load(object sender, System.EventArgs e)
        {
            this.Text = Utility.CurrentLanguage["loginform"];
            buttonX1.Text = Utility.CurrentLanguage["login"];

            buttonX3.Text = Utility.CurrentLanguage["connect"];

            buttonX2.Text = Utility.CurrentLanguage["gooffline"];

            labelX1.Text = Utility.CurrentLanguage["username"];

            labelX2.Text = Utility.CurrentLanguage["password"];

            labelX3.Text = Utility.CurrentLanguage["server"];

            labelX4.Text = Utility.CurrentLanguage["port"];

            textBoxX3.Text = "xenotelsn.ddns.net";
            textBoxX4.Text = "581";
 
            textBoxX1.Focus(); 

        }
        private void LoadEnded()
        {
            panel3.Visible = false;
            panel1.Enabled = true;
            loaddone = true;
            this.Height = 210;
        }

        private void buttonX1_Click(object sender, EventArgs e)
        { 
            Login();
        }
        private void Login()
        {
            try
            {
                string res = Utility.Connection.Send<string>("login", new string[2] { textBoxX1.Text, Utility.ToMD5(textBoxX2.Text) });
                if (res == "ok")
                {
                    authed = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(res);
                }
            }
            catch { MessageBox.Show("Session expired: Can't establish a secure connection with the server please reconnect."); }
        }
        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxX2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Login();

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            buttonX3.Enabled = false;
            buttonX2.Enabled = false;
            this.Height = 255;
            Authlabel.Visible = true;
            progressBarX1.Visible = true;
            new Thread(() =>
            {
                try
 {
                    Utility.Connection = new SN.Connection(textBoxX3.Text, int.Parse(textBoxX4.Text));
                    Utility.Connection.Open();
                    this.Invoke(new Action(() => { LoadEnded(); }));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    try
                    {
                        this.Invoke(new Action(() => {
                            buttonX3.Enabled = true;
                            buttonX2.Enabled = true;
                            this.Height = 157;
                            Authlabel.Visible = false;
                            progressBarX1.Visible = false;

                            MessageBox.Show("A connection with the server could not be established. Entering offline mode."); }));
                    }
                    catch { }
                } 
            }).Start();

        }

        private void labelX3_Click(object sender, EventArgs e)
        {

        }
    }
}
