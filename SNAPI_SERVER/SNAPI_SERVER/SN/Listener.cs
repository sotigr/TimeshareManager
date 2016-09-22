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
        private RSAKeyLoader keyloader;
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
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
        }
        byte[] eos = new byte[6] { 5, 6, 1, 100, 1, 123 };
        public void Start()
        {
            keyloader = new RSAKeyLoader("keys1024.txt");
            TcpListener listener = new TcpListener(IPAddress.Parse(_ip), _port);
            listener.Start();
            Console.WriteLine("Listener initialized and listening to " + _ip + ":" + _port);
            // System.Windows.Forms.MessageBox.Show("Listener initialized and listening to " + _ip + ":" + _port);
            new Thread(() =>
            {
                RemoveExpiredSessions();
            }).Start();
            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();

                new Thread((cl) =>
                {
                    try
                    {
                        NetworkStream networkStream = ((TcpClient)cl).GetStream();
                        byte[] bytesFrom = new byte[(int)((TcpClient)cl).ReceiveBufferSize];
                        MemoryStream requestStrm = new MemoryStream();
                        int bytesread = 0;
                        byte[] last_bytes = new byte[6];
                        do
                        {

                            bytesread = networkStream.Read(bytesFrom, 0, (int)((TcpClient)cl).ReceiveBufferSize);
                            requestStrm.Write(bytesFrom, 0, bytesread);
                            bytesFrom = new byte[(int)((TcpClient)cl).ReceiveBufferSize];

                            requestStrm.Seek((int)requestStrm.Length - 6, SeekOrigin.Begin);
                            requestStrm.Read(last_bytes, 0, 6);
                            requestStrm.Seek(0, SeekOrigin.End);

                        } while (
                            last_bytes[0] != 5 ||
                            last_bytes[1] != 6 ||
                            last_bytes[2] != 1 ||
                            last_bytes[3] != 100 ||
                            last_bytes[4] != 1 ||
                            last_bytes[5] != 123
                        );

                        string request = Encoding.UTF8.GetString(requestStrm.ToArray(), 0, (int)requestStrm.Length - 6);

                        byte[] sendBytes = new byte[0];

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
                                                sendBytes = System.Text.Encoding.UTF8.GetBytes("ok.");
                                
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
                                                sendBytes = System.Text.Encoding.UTF8.GetBytes(AES.Encrypt(Newtonsoft.Json.JsonConvert.SerializeObject(SN.InvokeByAttribute.Invoke(info.attr, info)), Encoding.ASCII.GetBytes((string)SN.Sessions.Current[info.sid]["AES_KEY"]), Encoding.ASCII.GetBytes((string)SN.Sessions.Current[info.sid]["AES_IV"])));

                                              

                                                clientAuth = true;
                                            }
                                            catch (Exception ex) { Console.WriteLine(ex.Message); }
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

                                sendBytes = System.Text.Encoding.UTF8.GetBytes(Newtonsoft.Json.JsonConvert.SerializeObject(rinfo));
                             
                            }
                            else
                            {
                                if (!clientAuth)
                                {
                                    if (badtoken)
                                    {
                                        sendBytes = System.Text.Encoding.UTF8.GetBytes("Bad Token.");
                                         
                                    }
                                    else
                                    {
                                        sendBytes = System.Text.Encoding.UTF8.GetBytes("Authentication error.");
                                  
                                    }
                                }
                            }
                        }
                        catch
                        {
                            sendBytes = System.Text.Encoding.UTF8.GetBytes("Protocol error.");
                         
                        }
                        MemoryStream resstrm = new MemoryStream();
                        resstrm.Write(sendBytes, 0, sendBytes.Length);
                        resstrm.Write(eos, 0, 6);

                        networkStream.Write(resstrm.ToArray(), 0, (int)resstrm.Length);
                       
                        networkStream.Flush();

                        ((TcpClient)cl).Close();

                    }
                    catch (Exception ex) { Console.WriteLine(ex.Message); }
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
                    RSA rsa = new RSA(RsaLength, false, true);
                    RsaKey key = keyloader.GetKey();

                    rsa.SetPrivateKey(new rsa_component.PrivateKey() { d = key.d, n = key.n });
                    rsa.SetPublicKey(new rsa_component.PublicKey() { e = key.e, n = key.n });

                    SN.Sessions.Current[sid]["RSA"] = rsa;


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
