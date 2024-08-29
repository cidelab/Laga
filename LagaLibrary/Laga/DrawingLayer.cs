using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino;
using System.Drawing;
using Rhino.Input;

namespace LagaRhino
{
    public class DrawingLayer
    {
        private RhinoDoc activeDoc;
        public DrawingLayer(RhinoDoc doc, string layername, Color color)
        {
            activeDoc = doc;
        }

        //check if layername exist.
        private string[] LayerList()
        {
            string[] arrString;

          Rhino.  = activeDoc.Layers;

            return arrString;
        }
    }
}
