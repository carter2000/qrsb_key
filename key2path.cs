using System;
using System.Text;
using System.Security.Cryptography;

namespace trans
{
    class Program
    {
        static string GetBkKey(string key)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(key));
        }

        static byte[] GetSha1Key(string key)
        {
            SHA1 sha = new SHA1CryptoServiceProvider();
            return sha.ComputeHash(Encoding.UTF8.GetBytes(GetBkKey(key)));
        }

        static string GetHexKey(string key)
        {
            return BitConverter.ToString(GetSha1Key(key)).Replace("-", "").ToLower();
        }

        static string GetDir1st(string key)
        {
            return GetHexKey(key).Substring(0, 2);
        }

        static string GetDir2nd(string key)
        {
            return GetHexKey(key).Substring(2, 2);
        }

        static string GetPath(string qrsbDir, string key)
        {
            string bkKey = GetBkKey(key);
            string hexKey = GetHexKey(key);
            string dir1st = hexKey.Substring(0, 2);
            string dir2nd = hexKey.Substring(2, 2);
            return qrsbDir + "/data/" + dir1st + "/" + dir2nd + "/" + bkKey;
        }

        static void Main(string[] args)
        {
            while (true)
            {
                System.Console.Write("input raw key: ");

                string key = System.Console.ReadLine();

                System.Console.WriteLine("\tbkKey: {0}", GetBkKey(key));

                byte[] sha1Key = GetSha1Key(key);
                System.Console.Write("\tsha1Key: [");
                for (int i = 0; i < sha1Key.Length; i++)
                {
                    System.Console.Write(" {0}", sha1Key[i]);
                }
                System.Console.WriteLine("]");

                System.Console.WriteLine("\thexKey: {0}", GetHexKey(key));

                System.Console.WriteLine("\tdir1st: {0}", GetDir1st(key));

                System.Console.WriteLine("\tdir2nd: {0}", GetDir2nd(key));

                System.Console.WriteLine("path: {0}", GetPath("qrsb_dir", key));

                System.Console.WriteLine();
            }
        }
    }
}