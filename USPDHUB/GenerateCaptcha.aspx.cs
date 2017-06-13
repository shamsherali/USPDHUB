using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using USPDHUBBLL;

public partial class GenerateCaptcha : System.Web.UI.Page
{

     private int height1 = 60;
     public int Height
     { get { return height1; } 
       set { height1 = value; } 
     } 
     private string text1 = "generateimage";
     public string Text
     { get { return text1; }
       set { text1 = value; }
     }
    private int width1 = 200;
    public int Width 
    { get { return width1; }
      set { width1 = value; }
    }  
    /// <summary>  
    /// 22:    /// Get Character from Random Number
    /// 23:    /// </summary>  
    /// 24:    /// <param name="genNo"></param>  25:   
    /// /// <returns></returns> 
    public string GetChar(int genNo)
    { 
        switch (genNo)
        {  
            case 0: 
                return "1"; 
            case 1:  
                return "2"; 
            case 2:  
                return "3";
            case 3:
                return "4"; 
            case 4: 
                return "5"; 
            case 5: 
                return "6"; 
            case 6:  
                return "7";
            case 7:  
                return "8";
            case 8: 
                return "9"; 
            case 9:
                return "0"; 
        }
        return string.Empty;
    }
    //generating random numbers.
    private Random objRandom = new Random();
    protected void Page_Load(object sender, EventArgs e)
    {
        try{
        //generate random text
        Random r = new Random();
        string str =r.Next().ToString().Substring(0,6);
        char[] ch = str.ToCharArray();
        Text = string.Empty;
        foreach (char var in ch)
        { 
            //get appropriate char  67:
            Text += GetChar(Convert.ToInt32(var.ToString()));
        } 
        //generate random image
        GenerateImage();
        }
        catch (Exception ex)
        {
            InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
            /*** Error Log ***/
            objInBuiltData.ErrorHandling("ERROR", "GenerateCaptcha.aspx.cs", "Page_Load", ex.Message, Convert.ToString(ex.StackTrace),
                Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
     private void GenerateImage()
     { 
         //using System.Drawing; and using System.Drawing.Imaging; 
         //Create a new 32-bit bitmap image.
         //specify height width
         //if you want to change pass that value in to query string
         Bitmap objBitmap = new Bitmap(this.Width, this.Height, PixelFormat.Format32bppArgb);
         //Create a graphics object
         Graphics objGraphic = Graphics.FromImage(objBitmap);
         objGraphic.SmoothingMode = SmoothingMode.HighQuality;
         Rectangle objRect = new Rectangle(0, 0, this.Width, this.Height);
         // Fill in the background color 
         //using System.Drawing.Drawing2D;
         //you specify different fillup style
         HatchBrush objHatchBrush = new HatchBrush(HatchStyle.DashedVertical, Color.White, Color.White);
         objGraphic.FillRectangle(objHatchBrush, objRect);
         // Text Font Size
         SizeF objectFontSize;
         float fontSize = objRect.Height + 3;
         Font objFont; 
         // Adjust the font size until the text fits within the image.
         do
         {
             fontSize--;
             objFont = new Font(FontFamily.GenericSerif, fontSize, FontStyle.Italic);
             objectFontSize = objGraphic.MeasureString(this.Text, objFont); 
         } while (objectFontSize.Width > objRect.Width); 
         // Set up the text format.
         StringFormat objectStringFormat = new StringFormat(); 
         objectStringFormat.Alignment = StringAlignment.Center;
         objectStringFormat.LineAlignment = StringAlignment.Center;
         // Create a path using the text and warp it randomly. 111:
         GraphicsPath objGraphicPath = new GraphicsPath();
         objGraphicPath.AddString(this.Text, objFont.FontFamily, (int)objFont.Style, objFont.Size, objRect, objectStringFormat); 
         float size = 6F;
         PointF[] points =
            { 
                new PointF(this.objRandom.Next(objRect.Width) / size, this.objRandom.Next(objRect.Height) / size), 
                new PointF(objRect.Width - this.objRandom.Next(objRect.Width) / size, this.objRandom.Next(objRect.Height) / size), 
                new PointF(this.objRandom.Next(objRect.Width) / size, objRect.Height - this.objRandom.Next(objRect.Height) / size), 
                new PointF(objRect.Width - this.objRandom.Next(objRect.Width) / size, objRect.Height - this.objRandom.Next(objRect.Height) / size)
            };
         Matrix objMatrix = new Matrix();
         objMatrix.Translate(0F, 0F);
         objGraphicPath.Warp(points, objRect, objMatrix, WarpMode.Perspective, 0F);
         //Draw Text 
         objHatchBrush = new HatchBrush(HatchStyle.Wave, Color.Black, Color.Black);
         objGraphic.FillPath(objHatchBrush, objGraphicPath);
         //Add more noise in the image 
         int m = Math.Max(objRect.Width, objRect.Height); 
         for (int i = 0; i < (int)(objRect.Width * objRect.Height / 30F); i++)
         {
             int x = this.objRandom.Next(objRect.Width);
             int y = this.objRandom.Next(objRect.Height);
             int w = this.objRandom.Next(m / 52);
             int h = this.objRandom.Next(m / 52);
             objGraphic.FillEllipse(objHatchBrush, x, y, w, h);
         } 
         objFont.Dispose();
         objHatchBrush.Dispose();
         objGraphic.Dispose();
         this.Response.ContentType = "image/jpeg";
         Session.Add("ImageString",this.Text);
         objBitmap.Save(this.Response.OutputStream, ImageFormat.Jpeg); 
     }
}
