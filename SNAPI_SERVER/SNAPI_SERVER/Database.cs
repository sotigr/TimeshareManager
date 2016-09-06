using System;
using System.Collections.Generic;
using System.Data.Odbc;

public class Database
{
    private string path;
    private OdbcConnection Con;
    private bool con_open = false;
    public Database(string databasepath)
    {
        path = databasepath;
        Con = new OdbcConnection("Driver={Microsoft Access Driver (*.mdb)}; DBQ=" + path + ";UID=;PWD=;");
    }
    public void OpenConnection()
    {
        if (con_open)
            Con.Close();
        Con.Open();
        con_open = true;
    }
    public void CloseConnection()
    {
        if (con_open)
        {
            Con.Close();
            con_open = false;
        }
    }
    public SqlResault Query(string qr)
    {
        string[] qrcommands = qr.Split(';');
        SqlResault res = new SqlResault();
        foreach (string command in qrcommands)
        {
            if (command.Trim() != "")
            {
                using (OdbcCommand DbCommand = Con.CreateCommand())
                {
                    DbCommand.CommandText = command + ";";
                    using (OdbcDataReader DbReader = DbCommand.ExecuteReader())
                    {
                        int cn = 0;
                        while (DbReader.Read())
                        {
                            int fCount = DbReader.FieldCount;
                            Dictionary<string, string> dict = new Dictionary<string, string>();

                            for (int i = 0; i < fCount; i++)
                            {
                                dict[DbReader.GetName(i)] = DbReader.GetString(i);
                            }
                            res[cn] = dict;
                            cn += 1;
                        }
                        DbReader.Close();
                        DbCommand.Cancel();
                        DbCommand.Dispose();
                    }
                }
            }
        }
         
        return res;
    }
}
public class SqlResault : Dictionary<int, IDictionary<string, string>> { }