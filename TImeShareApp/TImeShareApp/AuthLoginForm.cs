
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
            panel2.TabStop = false;
            panel1.Focus();
            textBoxX3.Text = "192.168.1.4";
            textBoxX4.Text = "581";
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
                        this.Invoke(new Action(() => { MessageBox.Show("A connection with the server could not be established. Entering offline mode."); this.Close(); }));
                    }
                    catch { }
                }
            }).Start();

            textBoxX1.Focus();
        }
        private void LoadEnded()
        {
            panel2.Visible = false;
            panel1.Enabled = true;
            loaddone = true;
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
    }
}
