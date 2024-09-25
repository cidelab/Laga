using Rhino;
using System.IO;
using Rhino.FileIO;
using System;
using Rhino.Commands;
using Rhino.DocObjects;

namespace LagaRhino
{
    public class PrintLayout
    {
        private readonly RhinoDoc doc;
        private Rhino.DocObjects.Tables.ViewTable rhinoViews;
        private readonly string folder;
        private readonly int dpi;
        private readonly double width;
        private readonly double height;
        public PrintLayout(RhinoDoc ActiveDoc, string Directory, int Dpi) 
        {
            doc = ActiveDoc;
            folder = Directory;
            dpi = Dpi;
            rhinoViews = doc.Views;
            
        }

        public Result PrintPDF(string filename)
        {
            FilePdf filePdf = FilePdf.Create();

                Rhino.Display.RhinoView view = rhinoViews.ActiveView;
                Rhino.Display.RhinoPageView actuaView = view as Rhino.Display.RhinoPageView;
                int w = Convert.ToInt32(actuaView.PageHeight);
                int h = Convert.ToInt32(actuaView.PageWidth);
                System.Drawing.Size size = new System.Drawing.Size(Convert.ToInt32(h * dpi / 25.4), Convert.ToInt32(w * dpi / 25.4));
                Rhino.Display.ViewCaptureSettings settings = new Rhino.Display.ViewCaptureSettings(view, size, dpi);
                settings.RasterMode = false;
                double res = settings.Resolution;
                filePdf.AddPage(settings);

                string filePath = Path.Combine(folder, filename + ".pdf");
                filePdf.Write(filePath);


            return Result.Success;
        }

    }
}
