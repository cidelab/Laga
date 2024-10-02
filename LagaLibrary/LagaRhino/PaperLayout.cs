using Rhino.Display;
using Rhino.DocObjects;
using Rhino.UI;
using Rhino;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagaRhino
{
    /// <summary>
    /// Rhino Layouts for printing
    /// </summary>
    public class PaperLayout
    {
        private readonly RhinoDoc doc;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ActiveDoc"></param>
        public PaperLayout(RhinoDoc ActiveDoc)
        {
            doc = ActiveDoc;
        }

        /// <summary>
        /// Create a Layout with a Detail view on it.
        /// </summary>
        /// <param name="layoutName">Layout name</param>
        /// <param name="winDetailView">Windows detail view</param>
        /// <param name="size">string type, support: "A4", "A3", "A2"</param>
        /// <returns>RhinoPageView</returns>
        public RhinoPageView CreateLayoutFromLayer(string layoutName, string winDetailView, string size = "A4")
        {
            LayoutSize(size, out double w, out double h);
            RhinoPageView pageView = doc.Views.AddPageView(layoutName, w, h);

            if (pageView != null)
            {
                RhinoApp.WriteLine($"PageView '(name)' created successfully.");
                Rhino.Geometry.Point2d top_Left = new Rhino.Geometry.Point2d(10, 287);
                Rhino.Geometry.Point2d bottom_Right = new Rhino.Geometry.Point2d(200, 10);
                DetailViewObject detailView = pageView.AddDetailView(winDetailView, top_Left, bottom_Right, DefinedViewportProjection.Top);
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

        /// <summary>
        /// Layout paper size in mm.
        /// </summary>
        /// <param name="pageName"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
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
