using System;
using System.Collections.Generic; 
using System.Text.RegularExpressions; 

namespace SN
{
    public struct RsaKey
    {
        public string e;
        public string d;
        public string n;
    }
    public class RSAKeyLoader
    {
        public List<RsaKey> RsaKeys = new List<RsaKey>();
        Random r = new Random();

        public RsaKey GetKey()
        {
            return RsaKeys[r.Next(0, RsaKeys.Count)];
        }
        public RSAKeyLoader(string path)
        {
            using (System.IO.StreamReader reader = new System.IO.StreamReader(path))
            {
                RsaKey curkey = new RsaKey();
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    Match linereg = Regex.Match(line, @"(.*)[\s]?[:][\s]?(.*)");
                    if (linereg.Success)
                    {
                        if (linereg.Groups[1].Value == "n")
                        {
                            curkey.n = linereg.Groups[2].Value;
                        }
                        else if (linereg.Groups[1].Value == "d")
                        {
                            curkey.d = linereg.Groups[2].Value;
                        }
                        else if (linereg.Groups[1].Value == "e")
                        {
                            curkey.e = linereg.Groups[2].Value;
                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        RsaKeys.Add(curkey);
                        curkey = new RsaKey();
                    }
                }
            }
        }
    }
    
}
