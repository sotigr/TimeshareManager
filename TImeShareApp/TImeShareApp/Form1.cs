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
    public partial class Form1 : Office2007Form
    {

        public Form1()
        {
            InitializeComponent();
            listView1.OnCellChanged += ListChangedCell;
        }
        private void ListChangedCell(object sender, CellChangedEventArgs e)
        {
            string final = "";
            foreach (ListViewItem.ListViewSubItem it in e.Item.SubItems)
            {
                final += it.Text + "\n";
            }
            MessageBox.Show(final);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
 
            listView1.Clear();
            listView1.Columns.Clear();
            //   Database.Query(@"insert into Clients (ClientNumber, Name, Surname, Birthdate, Phone, Phone2, Address)
            //                  values ('22Wsotiris','Sotiris','Papaioannou','2014-2-3','2141521521','1252151252215','kleisouras');");


            res = Utility.database.Query("select * from Clients;");


            foreach (KeyValuePair<string, string> kv in res[0])
            {
                listView1.Columns.Add(kv.Key);
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

                listView1.Items.Add(it);
            }
        }
        SqlResault res;
        private void button1_Click(object sender, EventArgs e)
        {

        }



        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog d = new SaveFileDialog();
            d.Filter = "(*.csv)|*.csv";
            if (d.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Utility.ExtractToCSV(res, d.FileName);
                if (Utility.settings["OpenFilesAfterExtraction"])
                Utility.openInExcel(d.FileName);
            }

        }
         

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            d.Filter = "(*.mdb)|*.mdb";
            if (d.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Utility.ExtractToMDB(res, d.FileName);
                if (Utility.settings["OpenFilesAfterExtraction"])
                Utility.openInAccess(d.FileName);
            }
        }
       





    } 