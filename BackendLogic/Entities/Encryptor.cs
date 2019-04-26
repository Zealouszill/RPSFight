using System;
using System.Collections.Generic;
using System.Text;

namespace RPSBackendLogic.Entities
{
    public class Encryptor
    {
        public static string Encrypt(string val)
        {

            Random rand = new Random();
            var bin = StringToBinary(val);
            var binLength = bin.Length;


            return null;
        }
        public static string Decrypt(string val)
        {
            return null;
        }

        private static string StringToBinary(string data)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in data.ToCharArray())
            {
                sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            }
            return sb.ToString();
        }
        
        private static string BinaryToString(string data)
        {
            List<Byte> byteList = new List<Byte>();

            for (int i = 0; i < data.Length; i += 8)
            {
                byteList.Add(Convert.ToByte(data.Substring(i, 8), 2));
            }
            return Encoding.ASCII.GetString(byteList.ToArray());
        }
    }
}
