using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Aurigma.GraphicsMill.Transforms;
using Aurigma.GraphicsMill.Codecs;
using Aurigma.GraphicsMill;
using System.Threading;
using USPDHUBBLL;
using Aurigma.GraphicsMill.AdvancedDrawing;

namespace USPDHUB
{
    public partial class Drawing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int imgWidth = 0;
                int imgHeight = 0;
                int genereatedimgWidth = 0;
                int generatedimgheight = 0;
                int originX = 0;
                int originY = 0;
                string filepath = Server.MapPath("~/Upload/TempBGImages");
                string uploadedfilepath = Server.MapPath("~/Upload/TempBGImages/girl.jpg");
                using (System.Drawing.Image myImage = System.Drawing.Image.FromFile(uploadedfilepath))
                {
                    imgWidth = myImage.Width;
                    imgHeight = myImage.Height;
                }
                int definedWidth = Convert.ToInt32(Resources.ValidationValues.BackGroundImageMinWidth);
                int definedHeight = Convert.ToInt32(Resources.ValidationValues.BackGroundImageMinHeight);

                if (imgWidth < definedWidth && imgHeight < definedHeight)
                {
                    genereatedimgWidth = definedWidth;
                    generatedimgheight = definedHeight;
                    originX = (int)((genereatedimgWidth - imgWidth) / 2 + 0.5m);
                    originY = (int)((generatedimgheight - imgHeight) / 2 + 0.5m);
                }
                else if (imgWidth < definedWidth && imgHeight >= definedHeight)
                {
                    genereatedimgWidth = (int)((imgHeight / Convert.ToDecimal(Resources.ValidationValues.CropHeightPercentage)) + 0.5m);
                    originX = (int)((genereatedimgWidth - imgWidth) / 2 + 0.5m);
                }
                else if (imgWidth >= definedWidth && imgHeight < definedHeight)
                {
                    generatedimgheight = (int)(imgWidth * Convert.ToDecimal(Resources.ValidationValues.CropHeightPercentage) + 0.5m);
                    originY = (int)((generatedimgheight - imgHeight) / 2 + 0.5m);
                }
                string generatedImgpath = filepath + "/10001.jpg";
                using (var generator = new ImageGenerator(genereatedimgWidth, generatedimgheight, PixelFormat.Format24bppRgb, RgbColor.White))
                using (var drawer = new Aurigma.GraphicsMill.Drawing.GdiPlusGraphicsDrawer())
                using (var writer = ImageWriter.Create(generatedImgpath))
                {
                    Pipeline.Run(generator + drawer + writer);
                }
                using (var reader = new Aurigma.GraphicsMill.Codecs.JpegReader(generatedImgpath))
                using (var watermark = new Aurigma.GraphicsMill.Codecs.JpegReader(uploadedfilepath))
                using (var combiner = new Aurigma.GraphicsMill.Transforms.Combiner())
                using (var writer = new Aurigma.GraphicsMill.Codecs.JpegWriter(filepath + "/Final.jpg"))
                {
                    var overlay = new Aurigma.GraphicsMill.Pipeline();
                    overlay.Add(watermark);
                    overlay.Add(new Aurigma.GraphicsMill.Transforms.ScaleAlpha(0.8f));
                    combiner.Mode = Aurigma.GraphicsMill.Transforms.CombineMode.Alpha;
                    combiner.TopImage = overlay;
                    combiner.X = originX;
                    combiner.Y = originY;
                    combiner.AutoDisposeTopImage = true;
                    Pipeline.Run(reader + combiner + writer);
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "Drawing.aspx.cs", "Page_Load", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
    }
}