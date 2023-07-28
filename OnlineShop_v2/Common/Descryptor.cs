using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace OnlineShop_v2.Common
{
    public static class Descryptor
    {
        public static string DecryptMD5(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                // Chuyển đổi chuỗi input thành mảng byte
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);

                // Tính toán giá trị băm MD5 cho mảng byte đầu vào
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Chuyển đổi giá trị băm thành chuỗi hexa
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }

                return sb.ToString();
            }
        }
    }
}