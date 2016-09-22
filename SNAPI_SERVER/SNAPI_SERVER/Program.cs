using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace FileSyncServer
{
    class Program
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        static void Main(string[] args)
        {
            AllocConsole();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
         utility.ini = new System.Text.IniParser("snsets.ini");
            if (!System.IO.File.Exists("snsets.ini"))
            {
                utility.ini.Write("basic", "dbpath", "");
                utility.ini.Write("basic", "rsa_key_length", "512");
                utility.ini.Save();
            }
            string databasepath = utility.ini.Read("basic", "dbpath");
            if (!System.IO.File.Exists(databasepath))
            {
                System.Windows.Forms.MessageBox.Show("The database file was not found the program will exit.\n" + "Current registered path: " + databasepath);
                return;
            }
            utility.database = new Database(databasepath);
            utility.database.OpenConnection();
            Application.Run(new MyApplicationContext());
        }
    }
}

