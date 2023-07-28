using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace OnlineShop_v2.Common
{
    public static class Enscryptor
    {
        public static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text  
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            //get hash result after compute it  
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits  
                //for each byte  
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }

        // Mã hóa dữ liệu bằng khóa công khai
        public static string EncryptData(string data, string publicKey)
        {
            byte[] byteData = Encoding.UTF8.GetBytes(data);

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(publicKey);

                byte[] encryptedData = rsa.Encrypt(byteData, false);

                return Convert.ToBase64String(encryptedData);
            }
        }

        // Giải mã dữ liệu bằng khóa bí mật
        public static string DecryptData(string encryptedData, string privateKey)
        {
            byte[] byteData = Convert.FromBase64String(encryptedData);

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(privateKey);

                byte[] decryptedData = rsa.Decrypt(byteData, false);

                return Encoding.UTF8.GetString(decryptedData);
            }
        }
    }
}