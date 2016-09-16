using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Collections.Generic;
namespace SN
{
    public class Listener
    {
        private string _ip;
        private int _port;
        public int RsaLength = 256;
        public Listener(string ip, int port)
        {
            _ip = ip;
            _port = port;
        }
        private void RemoveExpiredSessions()
        {
            while (true)
            {
                Thread.Sleep(600000); // 10 minutes
             
                try
                {
                    foreach (KeyValuePair<string, Dictionary<string, dynamic>> dict in SN.Sessions.Current)
                    {
                        if (Expired(dict.Value["session.activationdate"], 3600000))
                        {
                            System.Diagnostics.Debug.WriteLine("Session expired: " + dict.Key);
                            SN.Sessions.Current.Remove(dict.Key);

                        }
                    }
                } 
                catch (Exception ex) { System.IO.File.WriteAllText("err.txt", ex.Message); }
            }
        }
        public void Start()
        {
            TcpListener listener = new TcpListener(IPAddress.Parse(_ip), _port);
            listener.Start();
            System.Diagnostics.Debug.WriteLine("Listener initialized and listening to " + _ip + ":" + _port);
           // System.Windows.Forms.MessageBox.Show("Listener initialized and listening to " + _ip + ":" + _port);
            new Thread(() =>
            {
                RemoveExpiredSessions();
            }).Start();
            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                client.ReceiveTimeout = 5000;
                client.SendTimeout = 5000;
                new Thread((cl) =>
                {
                    try
                    {
                        using (NetworkStream stream = ((TcpClient)cl).GetStream())
                        {
                            NetworkStream strm = client.GetStream();
                            byte[] data = new byte[client.ReceiveBufferSize];
                            int bytesRead = strm.Read(data, 0, Convert.ToInt32(client.ReceiveBufferSize)); // Get the name's length
                            string request = Encoding.UTF8.GetString(data, 0, bytesRead); //Encode the name
                            try
                            {
                                SN.RequestInfo info = Newtonsoft.Json.JsonConvert.DeserializeObject<SN.RequestInfo>(request);
                                bool isNewClient = true;
                                bool clientAuth = false;
                                bool badtoken = false;
                                if (info.sid != null)
                                {
                                    if (SN.Sessions.Current.ContainsKey(info.sid))
                                    {
                                        if (SN.Sessions.Current[info.sid]["session.clientip"] == ((IPEndPoint)((TcpClient)cl).Client.RemoteEndPoint).Address.ToString())
                                        {
                                            if (SN.Sessions.Current[info.sid]["session.authflag"] == true)
                                            {
                                                string base64message = info.tkn;

                                                string[] rsa_numbers = Encoding.ASCII.GetString(Convert.FromBase64String(base64message)).Split(' ');
                                                rsa_numbers = rsa_numbers.Take(rsa_numbers.Count() - 1).ToArray();
                                                string[] aes_token = Encoding.ASCII.GetString(((RSA)SN.Sessions.Current[info.sid]["RSA"]).Decrypt((rsa_numbers))).Split(' ');

                                                if (aes_token[0].Length != 16 || aes_token[1].Length != 16)
                                                {
                                                    isNewClient = false;
                                                    badtoken = true;
                                                }
                                                else
                                                {
                                                    SN.Sessions.Current[info.sid]["AES_KEY"] = aes_token[0];
                                                    SN.Sessions.Current[info.sid]["AES_IV"] = aes_token[1];
                                                    SN.Sessions.Current[info.sid]["session.authflag"] = false;
                                                    byte[] response = System.Text.Encoding.UTF8.GetBytes("ok.");
                                                    strm.Write(response, 0, response.Length);
                                                    isNewClient = false;
                                                    clientAuth = true;
                                                }
                                            }
                                            else
                                            {
                                                isNewClient = false;
                                                try
                                                {
                                                    SN.Sessions.Current[info.sid]["session.activationdate"] = DateTime.Now;

                                                    info.msg = Newtonsoft.Json.JsonConvert.DeserializeObject(AES.Decrypt(info.msg, Encoding.ASCII.GetBytes((string)SN.Sessions.Current[info.sid]["AES_KEY"]), Encoding.ASCII.GetBytes((string)SN.Sessions.Current[info.sid]["AES_IV"])));
                                                    byte[] response = System.Text.Encoding.UTF8.GetBytes(AES.Encrypt(Newtonsoft.Json.JsonConvert.SerializeObject(SN.InvokeByAttribute.Invoke(info.attr, info)), Encoding.ASCII.GetBytes((string)SN.Sessions.Current[info.sid]["AES_KEY"]), Encoding.ASCII.GetBytes((string)SN.Sessions.Current[info.sid]["AES_IV"])));

                                                    strm.Write(response, 0, response.Length);

                                                    clientAuth = true;
                                                }
                                                catch (Exception ex) { System.IO.File.WriteAllText("err.txt", ex.Message); }
                                            }

                                        }
                                    }
                                }

                                if (isNewClient)
                                {
                                    string session_id = CreateSession(((IPEndPoint)((TcpClient)cl).Client.RemoteEndPoint).Address.ToString());
                                    ResponseInfo rinfo = new ResponseInfo();
                                    rinfo.rsa_p_key = ((RSA)SN.Sessions.Current[session_id]["RSA"]).GetPublicKey();
                                    rinfo.sid = session_id;

                                    byte[] response = System.Text.Encoding.UTF8.GetBytes(Newtonsoft.Json.JsonConvert.SerializeObject(rinfo));
                                    strm.Write(response, 0, response.Length);
                                }
                                else
                                {
                                    if (!clientAuth)
                                    {
                                        if (badtoken)
                                        {
                                            byte[] response = System.Text.Encoding.UTF8.GetBytes("Bad Token.");
                                            strm.Write(response, 0, response.Length);
                                        }
                                        else
                                        {
                                            byte[] response = System.Text.Encoding.UTF8.GetBytes("Authentication error.");
                                            strm.Write(response, 0, response.Length);
                                        }
                                    }
                                }
                            }
                            catch
                            {
                                byte[] response = System.Text.Encoding.UTF8.GetBytes("Protocol error.");
                                strm.Write(response, 0, response.Length);
                            }
                            client.Close();
                        }

                    }
                    catch (Exception ex) {  System.IO.File.WriteAllText("err.txt",ex.Message);  }
                    GC.Collect();
                }).Start(client);
            }
        }
        private bool Expired(DateTime date, double Expiretime)
        {
            if (date.AddMilliseconds(Expiretime) < DateTime.Now)
                return true;
            return false;
        }
        private string CreateSession(string client_ip)
        {
            string sid = "";
            while (true)
            {
                sid = CreateRandomString(16);
                if (!SN.Sessions.Current.ContainsKey(sid))
                {
                    SN.Sessions.Current[sid] = new System.Collections.Generic.Dictionary<string, dynamic>();
                    SN.Sessions.Current[sid]["session.activationdate"] = DateTime.Now;
                    SN.Sessions.Current[sid]["session.clientip"] = client_ip;
                    SN.Sessions.Current[sid]["session.authflag"] = true;
                    SN.Sessions.Current[sid]["RSA"] = new RSA(RsaLength, true);
          
                    break;
                }
            }
            return sid;
        }
        private string CreateRandomString(int length)
        {
            Random r = new Random();
            byte[] bytes = new byte[length];
            for (int i = 0; i < length; i++)
            {
                bytes[i] = (byte)r.Next(48, 122);
            }
            return Encoding.ASCII.GetString(bytes);
        }
    }
}
