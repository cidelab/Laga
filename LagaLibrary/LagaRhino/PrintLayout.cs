using Rhino;
using System.IO;
using Rhino.FileIO;
using System;
using Rhino.Commands;
using Rhino.Display;

namespace LagaRhino
{
    /// <summary>
    /// 
    /// </summary>
    public class PrintLayout
    {
        private readonly RhinoDoc doc;
        private readonly Rhino.DocObjects.Tables.ViewTable rhinoViews;
        private readonly string folder;
        private readonly int dpi;
        //private readonly double width;
        //private readonly double height;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ActiveDoc"></param>
        /// <param name="Directory"></param>
        /// <param name="Dpi"></param>
        public PrintLayout(RhinoDoc ActiveDoc, string Directory, int Dpi) 
        {
            doc = ActiveDoc;
            folder = Directory;
            dpi = Dpi;
            rhinoViews = doc.Views; //doc.Views;
            
        }


        /// <summary>
        /// Print a PDF.
        /// </summary>
        /// <param name="pageLayout">The Layout to print</param>
        /// <param name="fileName">the file name to save the pdf</param>
        /// <returns>Result type</returns>
        public Result PrintPDF(RhinoPageView pageLayout, string fileName)
        {
            FilePdf filePdf = FilePdf.Create();

            pageLayout.SetPageAsActive();
            doc.Views.ActiveView = pageLayout;
            pageLayout.MainViewport.ZoomExtents();
            doc.Views.Redraw();

            double pageWidth = pageLayout.PageWidth;
            double pageHeight = pageLayout.PageHeight;
            System.Drawing.Size size = new System.Drawing.Size(Convert.ToInt32(pageWidth * dpi / 25.4), Convert.ToInt32(pageHeight * dpi / 25.4));

            ViewCaptureSettings settings = new ViewCaptureSettings(pageLayout, size, dpi);
            settings.RasterMode = false;
            
            filePdf.AddPage(settings);

            string filePath = Path.Combine(folder, fileName + ".pdf");
            try
            {
                filePdf.Write(filePath);
            }
            catch (Exception ex)
            {
                RhinoApp.WriteLine($"Error writing PDF: {ex.Message}");
                return Result.Failure;
            }

            return Result.Success;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public Result PrintPDF(string filename)
        {
            FilePdf filePdf = FilePdf.Create();
            
                RhinoView view = rhinoViews.ActiveView;
                RhinoPageView actuaView = view as RhinoPageView;
                int w = Convert.ToInt32(actuaView.PageHeight);
                int h = Convert.ToInt32(actuaView.PageWidth);
                System.Drawing.Size size = new System.Drawing.Size(Convert.ToInt32(h * dpi / 25.4), Convert.ToInt32(w * dpi / 25.4));
                ViewCaptureSettings settings = new ViewCaptureSettings(view, size, dpi);
                settings.RasterMode = false;
                double res = settings.Resolution;
                filePdf.AddPage(settings);

                string filePath = Path.Combine(folder, filename + ".pdf");
                filePdf.Write(filePath);

            return Result.Success;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Result PrintLayouts()
        {
            string rpvName;
            foreach (RhinoView view in rhinoViews)
            {
                if (view is RhinoPageView rpv)
                { 
                    rpvName = rpv.PageName;
                    PrintPDF(rpvName);
                }
            }
            return Result.Success;
        }

    }
}
