using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

class Utility
{
    public static Language CurrentLanguage;
    public static Database database;
    public static Dictionary<string, dynamic> settings;
    public static SN.Connection Connection = null;


    public static bool IsDouble(string text)
    {
        try
        {
            double x = double.Parse(text);
            return true;
        }
        catch
        {
            return false;
        }
    }
    public static bool IsInt(string text)
    {
        try
        {
            int x = int.Parse(text);
            return true;
        }
        catch
        {
            return false;
        }
    }
    public static string ToMD5(string text)
    {
        string password = @"" + text;
        byte[] encodedPassword = new System.Text.UTF8Encoding().GetBytes(password);
        byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);
        string encoded = BitConverter.ToString(hash)
           .Replace("-", string.Empty)
           .ToLower();
        return encoded;
    }
    public static void SaveSettings()
    {
        System.IO.File.WriteAllText(Application.StartupPath + "\\usttngs.json", JsonConvert.SerializeObject(Utility.settings));
    }
    public static void LoadSettings()
    {
        Utility.settings = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(System.IO.File.ReadAllText(Application.StartupPath + "\\usttngs.json"));
    }
    public static void openInAccess(string file)
    {
        string[] office_versions = {"7.0"
                                       ,"8.0"
                                       ,"9.0"
                                       ,"10.0"
                                       ,"11.0"
                                       ,"12.0"
                                       ,"14.0"
                                       ,"15.0"
                                       ,"16.0" };
        string office_path = "";
        foreach (string v in office_versions)
        {
            object reg_val = Registry.GetValue("HKEY_LOCAL_MACHINE\\Software\\Microsoft\\Office\\" + v + "\\Word\\InstallRoot", "path", long.MinValue);
            if (reg_val != null)
                office_path = (string)reg_val;
            else
            {
                reg_val = Registry.GetValue("HKEY_LOCAL_MACHINE\\Software\\Microsoft\\Office\\" + v + "\\Word\\InstallRoot", "Path", long.MinValue);
                if (reg_val != null)
                    office_path = (string)reg_val;
            }
        }

        if (office_path == "")
        {
            MessageBox.Show("Could not obtain office installation path. Openning file with the default program.");
            System.Diagnostics.Process.Start(file);
            return;
        }
        System.Diagnostics.Process.Start(office_path + "\\MSACCESS.EXE", file);

    }
    public static void openInExcel(string file)
    {
        string[] office_versions = {"7.0"
                                       ,"8.0"
                                       ,"9.0"
                                       ,"10.0"
                                       ,"11.0"
                                       ,"12.0"
                                       ,"14.0"
                                       ,"15.0"
                                       ,"16.0" };
        string office_path = "";
        foreach (string v in office_versions)
        {
            object reg_val = Registry.GetValue("HKEY_LOCAL_MACHINE\\Software\\Microsoft\\Office\\" + v + "\\Word\\InstallRoot", "path", long.MinValue);
            if (reg_val != null)
                office_path = (string)reg_val;
            else
            {
                reg_val = Registry.GetValue("HKEY_LOCAL_MACHINE\\Software\\Microsoft\\Office\\" + v + "\\Word\\InstallRoot", "Path", long.MinValue);
                if (reg_val != null)
                    office_path = (string)reg_val;
            }
        }
        if (office_path == "")
        {
            MessageBox.Show("Could not obtain office installation path. Openning file with the default program.");
            System.Diagnostics.Process.Start(file);
            return;
        }
        System.Diagnostics.Process.Start(office_path + "\\EXCEL.EXE", file);

    }
    public static void ExtractToCSV(SqlResault resault, string path)
    {
        string txt = "";
        foreach (KeyValuePair<string, string> kv in resault[0])
        {
            txt += kv.Key + ";";
        }
        txt += "\n";
        for (int i = 0; i < resault.Count; i++)
        {

            foreach (KeyValuePair<string, string> kv in resault[i])
            {

                txt += "\"" + kv.Value + "\";";

            }
            txt += "\n";
        }

        byte[] csvBytes = Encoding.UTF8.GetBytes(txt);
        byte[] Utf8Csv = new byte[csvBytes.Length + 3];
        csvBytes.CopyTo(Utf8Csv, 3);
        Utf8Csv[0] = 0xEF;
        Utf8Csv[1] = 0xBB;
        Utf8Csv[2] = 0xBF;
        System.IO.File.WriteAllBytes(path, Utf8Csv);
    }
    public static void ExtractToMDB(SqlResault resault, string path)
    {

        System.IO.File.WriteAllBytes(path, TImeShareApp.Properties.Resources.dbtemplate);
        Database database = new Database(path);

        string tablequery = "CREATE TABLE ThisTable (";
        string dataQ = "(";
        foreach (KeyValuePair<string, string> kv in resault[0])
        {
            tablequery += "[" + kv.Key + "] Text, ";
            dataQ += kv.Key + ", ";
        }
        tablequery = tablequery.Remove(tablequery.Length - 2, 2);
        tablequery += ");";
        dataQ = dataQ.Remove(dataQ.Length - 2, 2);
        dataQ += ")";
        database.Query(tablequery);

        string fillq = "";
        for (int i = 0; i < resault.Count; i++)
        {
            string itemq = "INSERT INTO ThisTable " + dataQ + " VALUES (";
            foreach (KeyValuePair<string, string> kv in resault[i])
            {
                itemq += "'" + kv.Value + "', ";
            }
            itemq = itemq.Remove(itemq.Length - 2, 2);
            itemq += ");";
            fillq += itemq;
        }
        database.Query(fillq);

    }
}