using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomationSolution.Utilities
{
    public static class PasswordGenerator
    {
        /* public static string EncodePasswordToBase64(string password)
         {
             try
             {
                 byte[] encData_byte = new byte[password.Length];
                 encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                 string encodedData = Convert.ToBase64String(encData_byte);
                 return encodedData;
             }
             catch (Exception ex)
             {
                 throw new Exception("Error in base64Encode" + ex.Message);
             }
         }

         //this function Convert to Decord your Password
         public static string DecodeFrom64(string encodedData)
         {
             System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
             System.Text.Decoder utf8Decode = encoder.GetDecoder();
             byte[] todecode_byte = Convert.FromBase64String(encodedData);
             int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
             char[] decoded_char = new char[charCount];
             utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
             string result = new string(decoded_char);
             return result;
         }*/

        public static string EncryptString(string plainText)
        {
            
            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(Properties.Settings.Default.URL);
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }

                        array = memoryStream.ToArray();
                    }
                }
                return Convert.ToBase64String(array);
            }


        }

    }
}
