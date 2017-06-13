using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace Polls.DAL
{
    public class EncryptDecrypt
    {
        public EncryptDecrypt()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        const string DesKey = "AQWSEDRF";
        const string Desiv = "HGFEDCBA";
        public static string DESDecrypt(string stringToDecrypt)//Decrypt the content
        {
            stringToDecrypt = stringToDecrypt.Replace(" ", "+");
            string sEncryptionKey = "01234567890123456789";
            byte[] key = { };
            byte[] iV = { 10, 20, 30, 40, 50, 60, 70, 80 };
            byte[] inputByteArray = new byte[stringToDecrypt.Length];
            try
            {
                key = Encoding.UTF8.GetBytes(sEncryptionKey.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                inputByteArray = Convert.FromBase64String(stringToDecrypt);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(key, iV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                Encoding encoding = Encoding.UTF8;
                return encoding.GetString(ms.ToArray());
            }
            catch (System.Exception /*ex*/)
            {
                return (string.Empty);
            }
        }

        public static string DESEncrypt(string stringToEncrypt)// Encrypt the content
        {
            string sEncryptionKey = "01234567890123456789";
            byte[] key = { };
            byte[] iV = { 10, 20, 30, 40, 50, 60, 70, 80 };
            byte[] inputByteArray; //Convert.ToByte(stringToEncrypt.Length) 

            try
            {
                key = Encoding.UTF8.GetBytes(sEncryptionKey.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                inputByteArray = Encoding.UTF8.GetBytes(stringToEncrypt);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(key, iV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                return Convert.ToBase64String(ms.ToArray());
            }
            catch
            {
                return (string.Empty);
            }
        }
    }
}