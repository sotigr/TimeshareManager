using DevComponents.DotNetBar;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TImeShareApp
{
    static class Program
    {
        public static MainMDI MainMdiWindow;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!System.IO.File.Exists(Application.StartupPath + "\\usttngs.json"))
                CreateSettings();
            else
                Utility.LoadSettings();

            MessageBoxEx.EnableGlass = false;
            MessageBoxEx.UseSystemLocalizedString = false;
            MessageBoxEx.AntiAlias = true;
           

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainMdiWindow = new MainMDI();
            Application.Run(MainMdiWindow);
        }
        static void CreateSettings()
        {
            Utility.settings = new Dictionary<string, dynamic>();

            if (System.IO.File.Exists(Application.StartupPath + "\\base.mdb"))
                Utility.settings["MDBpath"] = Application.StartupPath + "\\base.mdb";
            else
                Utility.settings["MDBpath"] = "";
            Utility.settings["Languange"] = "gr";
            Utility.settings["KeepFileBackups"] = false;
            Utility.settings["OpenFilesAfterExtraction"] = true;
            Utility.settings["normal_week_cost"] = "";
            Utility.settings["discount_week_cost"] = "";
            Utility.settings["discount_start_date"] = "";
            Utility.settings["discount_end_date"] = "";
            Utility.SaveSettings();
        }
    }
}