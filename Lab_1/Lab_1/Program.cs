using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            MD5 md5 = MD5.Create();

            string input = "Hello";

            Hashtable hashtable = new Hashtable();

            byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            byte[] hash = md5.ComputeHash(inputBytes);

            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < hash.Length; i++)
            {
                sBuilder.Append(hash[i].ToString("x2"));
            }

            String str = Encoding.Default.GetString(hash);

            hashtable.Add(input, str);

            for(int i = 0; i < 31; i++)
            {
                hash = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
                for (int j = 0; j < hash.Length; j++)
                    sBuilder.Append(hash[j].ToString("x2"));
                hashtable.Add(str, sBuilder.ToString());
                str = sBuilder.ToString();
            }

            foreach(DictionaryEntry entry in hashtable)
            {
                Console.WriteLine("Key: " + entry.Key + "   Value: " + entry.Value );
            }

            //Console.WriteLine(str);
            Console.ReadKey();
        }
    }
}
