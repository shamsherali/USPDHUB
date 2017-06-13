/*========================================================================================//
    Name : SuneelKumar Biyyapu
    Date : 18th November 20014
    Use  : To Convert Word Documents to PDF Files (Max Limit is 20 Paragraphs in a File.)
//========================================================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GemBox.Document;
using GemBox.Document.Tables;
using System.IO;
using System.Text.RegularExpressions;

namespace DocToPDFConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get All Files From Directory into String Array
            string[] filePaths = Directory.GetFiles(@"E:\ProjectRawData\Help2.0\2.0 Help Content\2.0 Help ContentTest");

            // RegEx Pattern for keeping only Alphabets and . in FileName
            string pattern = @"[^a-zA-Z.]";

            // If using Professional version, put your serial key below.
            ComponentInfo.SetLicense("FREE-LIMITED-KEY");
            
            // Declaration Part
            string pathFileName = string.Empty;
            string a = string.Empty;
            string b = string.Empty;

            // To Get Paragraph Count Use "document.GetChildElements(true, ElementType.Paragraph).Count();"

            // Loop Through All Files in String Array
            for (int i = 0; i < filePaths.Count(); i++)
            {
                pathFileName = Path.GetFileNameWithoutExtension(filePaths[i]);
                a = Regex.Replace(pathFileName, pattern, string.Empty);
                b = a.Replace("..", string.Empty).Replace(".", string.Empty).Remove(0,1);
                DocumentModel document = DocumentModel.Load(filePaths[i]);
                document.Save(@"E:\ProjectRawData\Help2.0\2.0 Help Content\PDFs\" + b + ".pdf");
            }
        }
    }
}
