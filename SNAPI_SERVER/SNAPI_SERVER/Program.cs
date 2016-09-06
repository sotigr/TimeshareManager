using System.Windows.Forms; 
namespace FileSyncServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string databasepath = "C:\\Users\\sotig\\Documents\\Database1.mdb";
            if (!System.IO.File.Exists(databasepath))
            {
                System.Windows.Forms.MessageBox.Show("The database file was not found the program will exit.");
                return;
            }
            utility.database = new Database(databasepath);
            utility.database.OpenConnection();
            Application.Run(new MyApplicationContext());
        }
    }
}

