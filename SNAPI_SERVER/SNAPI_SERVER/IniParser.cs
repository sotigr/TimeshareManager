using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.IO;

namespace System.Text
{
   public class IniParser
    {
        private string _fp;
        private Dictionary<string, Dictionary<string, string>> _fmem;
        private bool _sload;

        public bool Loaded { get { return _sload; } }
        public IniParser(string filepath)
        {
            _fp = filepath;
            _fmem = new Dictionary<string, Dictionary<string, string>>();
            _sload = false;
            if (File.Exists(filepath))
                Load();
        }

        public void Load()
        {
            try
            {
                using (StreamReader r = new StreamReader(new FileStream(_fp, FileMode.Open), Encoding.UTF8))
                {
                    string current_section = string.Empty;

                    do
                    {
                        string l = r.ReadLine();

                        Match secm = Regex.Match(l, @"([\[])(.*)([\]])");
                        Match linem = Regex.Match(l, @"(.*)[\s]?[=][\s]?(.*)");
                        Match comm = Regex.Match(l, @"(^\s*?[;]\s*?)(.*)");
                        if (secm.Success)
                        {
                            string sname = secm.Groups[2].Value;
                            _fmem.Add(sname, new Dictionary<string, string>());
                            current_section = sname;
                        }
                        else if (linem.Success)
                        {
                            string valname = linem.Groups[1].Value;
                            string valval = linem.Groups[2].Value;
                            _fmem[current_section][valname] = valval;
                        }
                        else if (comm.Success) {
                            //ignore comment line
                        }
                        else
                        {
                            //bad formated line
                        }
                    } while (!r.EndOfStream);
                    _sload = true;
                }
            }
            catch { _sload = false; }
        }
        public void Save()
        {
            try
            {
                using (StreamWriter w = new StreamWriter(new FileStream(_fp, FileMode.CreateNew), Encoding.UTF8))
                {
                    foreach (KeyValuePair<string, Dictionary<string, string>> i in _fmem)
                    {
                        w.WriteLine("[" + i.Key + "]");
                        foreach (KeyValuePair<string, string> j in i.Value)
                        {
                            w.WriteLine(j.Key + "=" + j.Value);
                        }
                    }
                }

            }
            catch { }
        }
        public string Read(string section, string key)
        {
            return _fmem[section][key];
        }
        public void Write(string section, string key, string value, bool save = false)
        {
            if (!_fmem.ContainsKey(section))
                _fmem[section] = new Dictionary<string, string>();
            _fmem[section][key] = value;
            if (save)
                Save();
        }


    }
}
