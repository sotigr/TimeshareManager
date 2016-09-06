
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;

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
        public Connection(string ip, int port)
        {
            this.ip = ip;
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

                RSA rsa = new RSA(512, false, true);
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
        private byte[] AuthSend(byte[] msg)
        {
            
            IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            client.Connect(ipEndPoint);

            client.Send(msg, msg.Length, SocketFlags.None);


            byte[] buffer = new byte[1024];
            int bytesRead = 1024;

            MemoryStream stream = new MemoryStream();
            while ((bytesRead = client.Receive(buffer, 0, buffer.Length, SocketFlags.None)) > 0)
            {
                stream.Write(buffer, 0, bytesRead);
            }

            client.Shutdown(SocketShutdown.Both);
            client.Close(); 
             
            return stream.ToArray();

        }
        public T Send<T>(string apipath, object obj = null)
        {
            SN.RequestInfo rei = new SN.RequestInfo();
            rei.attr = apipath;
            rei.sid = this.resp_inf.sid;
            rei.msg = AES.Encrypt(Newtonsoft.Json.JsonConvert.SerializeObject(obj), aes_key, aes_iv);
            byte[] data = System.Text.Encoding.UTF8.GetBytes(Newtonsoft.Json.JsonConvert.SerializeObject(rei));
            string response = AES.Decrypt(Encoding.UTF8.GetString(AuthSend(data)), aes_key, aes_iv);
   
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
