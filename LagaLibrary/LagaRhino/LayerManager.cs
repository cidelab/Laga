using Rhino;
using Rhino.Display;
using Rhino.DocObjects;
using Rhino.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LagaRhino
{
    /// <summary>
    /// Get control of layers.
    /// </summary>
    public class LayerManager
    {
        private readonly RhinoDoc doc;
        List<string> layerNames = new List<string>();

        /// <summary>
        /// Get all layer names
        /// </summary>
        public List<string> Layers { get { return layerNames; } }

        /// <summary>
        /// Create the class
        /// </summary>
        /// <param name="ActiveDoc">Rhino active document</param>
        public LayerManager(RhinoDoc ActiveDoc) 
        {
            doc = ActiveDoc;
            GetlayerNames();
        }

        private void GetlayerNames()
        {
            foreach (Layer layer in doc.Layers)
                if(layer != null && layer.IsDeleted == false)
                    layerNames.Add(layer.Name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="layerName"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public RhinoPageView CreateLayoutFromLayer(string layerName, string size = "A4")
        {
            LayoutSize(size, out double w, out double h);
            RhinoPageView pageView = doc.Views.AddPageView(layerName, w, h);

            if (pageView != null)
            {
                RhinoApp.WriteLine($"PageView '(layerName)' created successfully.");
                Rhino.Geometry.Point2d top_Left = new Rhino.Geometry.Point2d(10, 287);
                Rhino.Geometry.Point2d bottom_Right = new Rhino.Geometry.Point2d(200, 10);
                DetailViewObject detailView = pageView.AddDetailView("name", top_Left, bottom_Right, DefinedViewportProjection.Top);
                if (detailView != null)
                {
                    pageView.SetActiveDetail(detailView.Id);
                    detailView.Viewport.ZoomExtents();
                    detailView.DetailGeometry.IsProjectionLocked = true;
                    detailView.DetailGeometry.SetScale(1, doc.ModelUnitSystem, 1, doc.PageUnitSystem);
                    detailView.CommitChanges();
                }
            }
            else
                RhinoApp.WriteLine($"Something terrible wrong happened.");

            return pageView;
        }

        private bool CurrentLayer(string layerName)
        {
            //doc.Layers.ge

            return false;
        }

        private void LayoutSize(string pageName, out double width, out double height)
        {
            switch (pageName)
            {
                case "A4":
                    width = 210;
                    height = 297;
                    break;
                case "A3":
                    width = 297;
                    height = 420;
                    break;
                case "A2":
                    width = 420;
                    height = 590;
                    break;
                default:
                    width = 210;
                    height = 297;
                    break;
            }
        }
    }
}
