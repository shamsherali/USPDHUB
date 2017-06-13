using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Aurigma.GraphicsMill.Transforms;
using System.IO;
using Microsoft.Office.Interop.Word;

namespace CopyPaste_POC
{
    public partial class Test : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
             
                string FileName = "D:\\Balaji-05.08.2015.docx";
                object NewFileName = "D:\\NewTestFile.txt";
                string NewFilePath = "D:\\NewTestFile.txt";
                object missing = System.Reflection.Missing.Value; 
                Object READONLY = false;
                File.Copy(FileName, NewFileName.ToString());
                Application App = new Application();
                Document doc = App.Documents.Open(ref NewFileName, ref missing, ref missing, ref missing,
                               ref missing, ref missing, ref missing, ref missing,
                               ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                               ref missing, ref missing);
                
                //App.Visible = true;
                string text = doc.Content.Text;
                doc.Close();
                if (File.Exists(NewFilePath))
                {
                    File.Delete(NewFilePath);
                }
              
            }
            catch
            {
            }


        }


    }
}