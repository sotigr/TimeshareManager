
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace SN
{
    class Connection
    {
        private string ip;
        private byte[] aes_key, aes_iv;
        private int port;
        private ResponseInfo resp_inf;
        private bool con = false;
        public bool Connected { get { return con; } }
        public string IP { get { return ip; } }
        public int Port { get { return port; } }

        public event EventHandler SendStarted;
        public event EventHandler SendEnded;

        protected virtual void OnSendStarted(EventArgs e)
        {
            EventHandler handler = SendStarted;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        protected virtual void OnSendEnded(EventArgs e)
        {
            EventHandler handler = SendEnded;
            if (handler != null)
            {
                handler(this, e);
            }
        }



        public Connection(string ip, int port)
        {
            Match ipcheck = Regex.Match(ip, @"^(?:[0-9]{1,3}\.){3}[0-9]{1,3}$");
            if (ipcheck.Success)
                this.ip = ip;
            else
                this.ip = Dns.GetHostAddresses(ip)[0].ToString();
            this.port = port;

        }

        public void Open()
        {

            SN.RequestInfo rei = new SN.RequestInfo();

            byte[] data = System.Text.Encoding.UTF8.GetBytes(Newtonsoft.Json.JsonConvert.SerializeObject(rei));


            this.resp_inf = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseInfo>(System.Text.Encoding.UTF8.GetString(this.AuthSend(data)));

            while (true)
            {
                string key, iv;

                key = CreateRandomString(16);
                iv = CreateRandomString(16);

                aes_key = Encoding.ASCII.GetBytes(key);
                aes_iv = Encoding.ASCII.GetBytes(iv);

                RSA rsa = new RSA(0, false, true);
                rsa.SetPublicKey(resp_inf.rsa_p_key);
                string[] cipher = rsa.Encrypt(Encoding.UTF8.GetBytes(key + " " + iv), sha256(CreateRandomString(32)));
                string rsa_text = "";
                for (int i = 0; i < cipher.Length; i++)
                {
                    rsa_text += cipher[i] + " ";
                }
                rsa_text = Convert.ToBase64String(Encoding.ASCII.GetBytes(rsa_text));
                rei = new RequestInfo();
                rei.sid = this.resp_inf.sid;
                rei.tkn = rsa_text;
                data = System.Text.Encoding.UTF8.GetBytes(Newtonsoft.Json.JsonConvert.SerializeObject(rei));


                if (System.Text.Encoding.UTF8.GetString(AuthSend(data)) == "ok.")
                {
                    //       System.Windows.Forms.MessageBox.Show("Connected");
                    break;
                }
            }
            con = true;
        }
        static string sha256(string password)
        {
            SHA256Managed crypt = new SHA256Managed();
            string hash = String.Empty;
            byte[] crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(password), 0, Encoding.ASCII.GetByteCount(password));
            foreach (byte theByte in crypto)
            {
                hash += theByte.ToString("x2");
            }
            return hash;
        }

        byte[] eos = new byte[6] { 5, 6, 1, 100, 1, 123 };
        Stopwatch s = new Stopwatch();
        private byte[] AuthSend(byte[] msg)
        {
            s.Start();
            IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

            TcpClient clientSocket = new TcpClient();
            clientSocket.Connect(ipEndPoint);

            NetworkStream serverStream = clientSocket.GetStream();
            MemoryStream outstrm = new MemoryStream();
            outstrm.Write(msg, 0, msg.Length);
            outstrm.Write(eos, 0, 6);

            serverStream.Write(outstrm.ToArray(), 0, (int)outstrm.Length);
            serverStream.Flush();

            MemoryStream responseStrm = new MemoryStream();
            int bytesread = 0;
            byte[] last_bytes = new byte[6];
            byte[] bytesFrom = new byte[(int)clientSocket.ReceiveBufferSize];
            do
            {

                bytesread = serverStream.Read(bytesFrom, 0, (int)clientSocket.ReceiveBufferSize);
                responseStrm.Write(bytesFrom, 0, bytesread);
                bytesFrom = new byte[(int)clientSocket.ReceiveBufferSize];

                responseStrm.Seek((int)responseStrm.Length - 6, SeekOrigin.Begin);
                responseStrm.Read(last_bytes, 0, 6);
                responseStrm.Seek(0, SeekOrigin.End);

            } while (
                    last_bytes[0] != 5 ||
                    last_bytes[1] != 6 ||
                    last_bytes[2] != 1 ||
                    last_bytes[3] != 100 ||
                    last_bytes[4] != 1 ||
                    last_bytes[5] != 123
            );
            int fmsg_ln = (int)responseStrm.Length - 6;
            byte[] final = new byte[fmsg_ln];
            Array.Copy(responseStrm.ToArray(), final, fmsg_ln);
            s.Stop();
            System.Diagnostics.Debug.WriteLine("Ping: " + s.ElapsedMilliseconds + "ms");
            s.Reset();
            return final;
             
        }
        public T Send<T>(string apipath, object obj = null)
        {
            OnSendStarted(new EventArgs());
            SN.RequestInfo rei = new SN.RequestInfo();
            rei.attr = apipath;
            rei.sid = this.resp_inf.sid;
            rei.msg = AES.Encrypt(Newtonsoft.Json.JsonConvert.SerializeObject(obj), aes_key, aes_iv);
            byte[] data = System.Text.Encoding.UTF8.GetBytes(Newtonsoft.Json.JsonConvert.SerializeObject(rei));
            string response = AES.Decrypt(Encoding.UTF8.GetString(AuthSend(data)), aes_key, aes_iv);
            OnSendEnded(new EventArgs());
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(response);

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
