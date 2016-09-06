using System;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SN
{
    public class RSA
    {
        private BigInteger p, q, n, phi, e, d;

        private int prime_length = 128;
        private bool keys_generated = false;
        public RSA(int key_bit_lenth, bool generate_keys_now = true, bool openkeymode = false)
        {
            prime_length = key_bit_lenth / 2;
            if (openkeymode)
                keys_generated = true;
            if (generate_keys_now)
                GenerateKeys();
        }
        public void GenerateKeys()
        {
            p = GenerateRandomPrime(prime_length);
            q = GenerateRandomPrime(prime_length);

            n = p * q;

            //This detects propable errors in big prime selection.
            if (n.ToByteArray().Length * 8 != prime_length * 2)
                GenerateKeys();

            phi = (p - 1) * (q - 1);

            do
            {
                e = GenerateRandomCoprime(phi);
                d = ExtendedEuclidean(e % phi, phi).u1;
            } while (d < 0);
            keys_generated = true;
        }

        public string[] Encrypt(byte[] message, string pad_hash)
        {
            if (keys_generated)
            {

                message = Pad(message, 64, pad_hash);

                int pt_ln = message.Length;
                List<string> res = new List<string>();

                List<string> res_ts_0 = new List<string>();
                List<string> res_ts_1 = new List<string>();
                List<string> res_ts_2 = new List<string>();
                List<string> res_ts_3 = new List<string>();

                int task_share = pt_ln / 4;

                int task0_cycles = task_share;
                int task1_cycles = task_share * 2;
                int task2_cycles = task_share * 3;
                int task3_cycles = pt_ln;

                Task t0 = Task.Factory.StartNew(() =>
                {
                    for (int i = 0; i < task0_cycles; i++)
                    {
                        res_ts_0.Add(BigInteger.ModPow(message[i], e, n).ToString());
                    }
                });
                Task t1 = Task.Factory.StartNew(() =>
                {
                    for (int i = task0_cycles; i < task1_cycles; i++)
                    {
                        res_ts_1.Add(BigInteger.ModPow(message[i], e, n).ToString());
                    }
                });
                Task t2 = Task.Factory.StartNew(() =>
                {
                    for (int i = task1_cycles; i < task2_cycles; i++)
                    {
                        res_ts_2.Add(BigInteger.ModPow(message[i], e, n).ToString());
                    }
                });
                Task t3 = Task.Factory.StartNew(() =>
                {
                    for (int i = task2_cycles; i < task3_cycles; i++)
                    {
                        res_ts_3.Add(BigInteger.ModPow(message[i], e, n).ToString());
                    }
                });

                t0.Wait();
                t1.Wait();
                t2.Wait();
                t3.Wait();

                res.AddRange(res_ts_0);
                res.AddRange(res_ts_1);
                res.AddRange(res_ts_2);
                res.AddRange(res_ts_3);

                return res.ToArray();
            }
            else
                throw new System.InvalidOperationException("RSA - The public and private keys have not been generated yet.");
        }
        public byte[] Decrypt(string[] message)
        {
            if (keys_generated)
            {
                int pt_ln = message.Length;
                List<byte> res = new List<byte>();

                List<byte> res_ts_0 = new List<byte>();
                List<byte> res_ts_1 = new List<byte>();
                List<byte> res_ts_2 = new List<byte>();
                List<byte> res_ts_3 = new List<byte>();

                int task_share = pt_ln / 4;

                int task0_cycles = task_share;
                int task1_cycles = task_share * 2;
                int task2_cycles = task_share * 3;
                int task3_cycles = pt_ln;

                Task t0 = Task.Factory.StartNew(() =>
                {
                    for (int i = 0; i < task0_cycles; i++)
                    {
                        res_ts_0.Add((byte)BigInteger.ModPow(BigInteger.Parse(message[i].Trim()), d, n));
                    }
                });
                Task t1 = Task.Factory.StartNew(() =>
                {
                    for (int i = task0_cycles; i < task1_cycles; i++)
                    {
                        res_ts_1.Add((byte)BigInteger.ModPow(BigInteger.Parse(message[i].Trim()), d, n));
                    }
                });
                Task t2 = Task.Factory.StartNew(() =>
                {
                    for (int i = task1_cycles; i < task2_cycles; i++)
                    {
                        res_ts_2.Add((byte)BigInteger.ModPow(BigInteger.Parse(message[i].Trim()), d, n));
                    }
                });
                Task t3 = Task.Factory.StartNew(() =>
                {
                    for (int i = task2_cycles; i < task3_cycles; i++)
                    {
                        res_ts_3.Add((byte)BigInteger.ModPow(BigInteger.Parse(message[i].Trim()), d, n));
                    }
                });

                t0.Wait();
                t1.Wait();
                t2.Wait();
                t3.Wait();

                res.AddRange(res_ts_0);
                res.AddRange(res_ts_1);
                res.AddRange(res_ts_2);
                res.AddRange(res_ts_3);

                return UnPad(res.ToArray());
            }
            else
                throw new System.InvalidOperationException("RSA - The public and private keys have not been generated yet.");
        }
        public void SetPublicKey(rsa_component.PublicKey key)
        {
            this.e = BigInteger.Parse(key.e);
            this.n = BigInteger.Parse(key.n);

        }
        public rsa_component.PublicKey GetPublicKey()
        {
            if (keys_generated)
                return new rsa_component.PublicKey { e = e.ToString(), n = n.ToString() };
            throw new System.InvalidOperationException("RSA - The public key has not been generated yet.");
        }
        public rsa_component.PrivateKey GetPrivateKey()
        {
            if (keys_generated)
                return new rsa_component.PrivateKey { d = d.ToString(), n = n.ToString() };
            throw new System.InvalidOperationException("RSA - The private key has not been generated yet.");
        }
        public rsa_component.PrimeSet GetPrimeSet()
        {
            if (keys_generated)
                return new rsa_component.PrimeSet { p = p.ToString(), q = q.ToString() };
            throw new System.InvalidOperationException("RSA - The prime set has not been generated yet.");
        }
        private BigInteger GetGCDByModulus(BigInteger value1, BigInteger value2)
        {
            while (value1 != 0 && value2 != 0)
            {
                if (value1 > value2)
                    value1 %= value2;
                else
                    value2 %= value1;
            }
            return BigInteger.Max(value1, value2);
        }
        private bool Coprime(BigInteger value1, BigInteger value2)
        {
            return GetGCDByModulus(value1, value2).IsOne;
        }
        private BigInteger GenerateRandomCoprime(BigInteger number)
        {
            bool found = false;
            BigInteger resault = BigInteger.Zero;
            while (!found)
            {
                resault = GenerateRandomPrime(prime_length - 1, 10);
                if (Coprime(number, resault))
                    found = true;
            }
            return resault;
        }

        private BigInteger GenerateRandomPrime(int length, int witnesses = 10, int tasks = 6)
        {
            bool flag = false;
            BigInteger num = BigInteger.Zero;
            while (!flag)
            {
                List<Task> tl = new List<Task>();
                for (int i = 0; i < tasks; i++)
                {
                    tl.Add(Task.Factory.StartNew(() =>
                    {
                        RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
                        byte[] bytes = new byte[length / 8];
                        rng.GetBytes(bytes);

                        BigInteger p = new BigInteger(bytes);

                        bool isprime = p.IsProbablyPrime(witnesses);
                        if (isprime)
                        {
                            num = p;
                            flag = true;
                        }

                    }));
                }
                for (int i = 0; i < tasks - 1; i++)
                {
                    tl[i].Wait();
                }

                tl.Clear();
            }
            return num;
        }
        static ExtendedEuclideanResult ExtendedEuclidean(BigInteger a, BigInteger b)
        {
            BigInteger x0 = 1, xn = 1;
            BigInteger y0 = 0, yn = 0;
            BigInteger x1 = 0;
            BigInteger y1 = 1;
            BigInteger q;
            BigInteger r = a % b;

            while (r > 0)
            {
                q = a / b;
                xn = x0 - q * x1;
                yn = y0 - q * y1;

                x0 = x1;
                y0 = y1;
                x1 = xn;
                y1 = yn;
                a = b;
                b = r;
                r = a % b;
            }

            return new ExtendedEuclideanResult()
            {
                u1 = xn,
                u2 = yn,
                gcd = b
            };
        }

        struct ExtendedEuclideanResult
        {
            public BigInteger u1;
            public BigInteger u2;
            public BigInteger gcd;
        }

        private byte[] Pad(byte[] message, int length, string hash128)
        {
            int mLen = message.Length;
            if (mLen > length || length > 64)
            {
                return null;
            }

            byte[] hash = Encoding.ASCII.GetBytes(hash128);

            int[] mask = CreateMask(mLen, length);

            byte[] padded = new byte[length + 64];
            int msgcn = 0;
            for (int i = 64; i < length + 64; i++)
            {
                if (mask[i - 64] == 0)
                {
                    padded[i] = message[msgcn];
                    msgcn++;
                }
                else
                    padded[i] = hash[i - 64];
            }
            for (int i = 0; i < 64; i++)
            {
                padded[i] = hash[i];
            }
            return padded;
        }
        private byte[] UnPad(byte[] message)
        {
            int mLen = message.Length;
            byte[] hash = new byte[64];
            byte[] actual_message = new byte[mLen - 64];
            Array.Copy(message, hash, 64);
            Array.Copy(message, 64, actual_message, 0, mLen - 64);

            List<byte> unpdaded = new List<byte>();
            for (int i = 0; i < mLen - 64; i++)
            {
                if (actual_message[i] != hash[i])
                    unpdaded.Add(actual_message[i]);
            }
            return unpdaded.ToArray();
        }
        private int[] CreateMask(int text_length, int masklength)
        {
            Random random = new Random();
            List<int> existing = new List<int>();
            int[] arr = new int[masklength];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = -1;
            }
            int cn = 0;
            while (cn < text_length)
            {
                int rand = random.Next(0, masklength);
                if (!existing.Contains(rand))
                {
                    existing.Add(rand);
                    arr[rand] = 0;
                    cn += 1;
                }
            }
            return arr;
        }

        private byte[] RandomBytes(int length)
        {
            Random random = new Random();
            byte[] array = new byte[length];
            for (int i = 0; i < length; i++)
            {
                array[i] = (byte)random.Next(1, 255);
            }
            return array;
        }

        private string sha256(string password)
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
        private string sha256(byte[] password)
        {
            SHA256Managed crypt = new SHA256Managed();
            string hash = String.Empty;
            byte[] crypto = crypt.ComputeHash(password, 0, password.Length);
            foreach (byte theByte in crypto)
            {
                hash += theByte.ToString("x2");
            }
            return hash;
        }


    }
    public static class PrimeExtensions
    {
        private static ThreadLocal<Random> s_Gen = new ThreadLocal<Random>(
          () =>
          {
              return new Random();
          }
        );

        private static Random Gen
        {
            get
            {
                return s_Gen.Value;
            }
        }

        public static Boolean IsProbablyPrime(this BigInteger value, int witnesses = 10)
        {
            if (value <= 1)
                return false;

            if (witnesses <= 0)
                witnesses = 10;

            BigInteger d = value - 1;
            int s = 0;

            while (d % 2 == 0)
            {
                d /= 2;
                s += 1;
            }

            Byte[] bytes = new Byte[value.ToByteArray().LongLength];
            BigInteger a;

            for (int i = 0; i < witnesses; i++)
            {
                do
                {
                    Gen.NextBytes(bytes);

                    a = new BigInteger(bytes);
                }
                while (a < 2 || a >= value - 2);

                BigInteger x = BigInteger.ModPow(a, d, value);
                if (x == 1 || x == value - 1)
                    continue;

                for (int r = 1; r < s; r++)
                {
                    x = BigInteger.ModPow(x, 2, value);

                    if (x == 1)
                        return false;
                    if (x == value - 1)
                        break;
                }

                if (x != value - 1)
                    return false;
            }

            return true;
        }

    }
}