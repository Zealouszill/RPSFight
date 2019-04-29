using System;
using System.Collections.Generic;
using System.Text;

namespace RPSBackendLogic.Entities
{
    public class Encryptor
    {
        private static string Key = "";
        public string Encrypt(string val)
        {
            var bin = StringToBinary(val);
            var temp = "";
            for(int i = 0; i < bin.Length; i++)
            {
                temp += Xor(bin[i], Key[i]);
            }
            return temp;
        }
        public string Decrypt(string val)
        {
            var temp = "";
            for (int i = 0; i < val.Length; i++)
            {
                temp += Xor(val[i], Key[i]);
            }
            var bin = BinaryToString(temp);
            return bin;
        }
        public string StringToBin(string data)
        {
            return StringToBinary(data);
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

        private static string Xor(char one, char two)
        {
            if (one == two)
                return "0";
            else
                return "1";
        }
    }
}
