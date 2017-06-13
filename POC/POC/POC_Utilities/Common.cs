using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace POC.POC_Utilities
{
    public static class Constants //Roles & Permissions...
    {
        public const int BULLETINS = 1;
        public const int UPDATES = 2;
        public const int EVENTS = 4;
        public const int NOTIFICATIONS = 8;
        public const int MBUTTONS = 16;
        public const int APPSETTINGS = 32;
        public const int CONTACTS = 64;
        public const int SURVEYS = 128;
        public const int BLOCKEDSENDERS = 256;
        public const int DOWNLOADS = 512;
    }

    public static class PageNames //Roles & Permissions...
    {
        public const string BULLETINS = "bulletins";
        public const string UPDATES = "updates";



        public const string BULLETIN = "Bulletin";
        public const string UPDATE = "Update";


    }
    public class Common
    {

    }

    public class ModuleTypes
    {
        public int ModuleTypeID { get; set; }
        public string ModuleTypName { get; set; }
    }

    public class EncryptDecrypt
    {

        public EncryptDecrypt()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        const string DESKey = "AQWSEDRF";
        const string DESIV = "HGFEDCBA";
        public static string DESDecrypt(string stringToDecrypt)//Decrypt the content
        {
            stringToDecrypt = stringToDecrypt.Replace(" ", "+");
            string sEncryptionKey = "01234567890123456789";
            byte[] key = { };
            byte[] IV = { 10, 20, 30, 40, 50, 60, 70, 80 };
            byte[] inputByteArray = new byte[stringToDecrypt.Length];
            try
            {
                key = Encoding.UTF8.GetBytes(sEncryptionKey.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                inputByteArray = Convert.FromBase64String(stringToDecrypt);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(key, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                Encoding encoding = Encoding.UTF8;
                return encoding.GetString(ms.ToArray());
            }
            catch (System.Exception ex)
            {
                return (string.Empty);
            }
        }

        public static string DESEncrypt(string stringToEncrypt)// Encrypt the content
        {
            string sEncryptionKey = "01234567890123456789";
            byte[] key = { };
            byte[] IV = { 10, 20, 30, 40, 50, 60, 70, 80 };
            byte[] inputByteArray; //Convert.ToByte(stringToEncrypt.Length) 

            try
            {
                key = Encoding.UTF8.GetBytes(sEncryptionKey.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                inputByteArray = Encoding.UTF8.GetBytes(stringToEncrypt);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(key, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                return Convert.ToBase64String(ms.ToArray());
            }
            catch
            {
                return (string.Empty);
            }
        }
        static byte[] Convert2ByteArray(string strInput)
        {

            int intCounter; char[] arrChar;
            arrChar = strInput.ToCharArray();
            byte[] arrByte = new byte[arrChar.Length];
            for (intCounter = 0; intCounter <= arrByte.Length - 1; intCounter++)
                arrByte[intCounter] = Convert.ToByte(arrChar[intCounter]);

            return arrByte;
        }

    }
    public enum RoleTypes
    {
        Consumer = 1, Business, Admin, AdminStaff, Advertiser
    }
}
