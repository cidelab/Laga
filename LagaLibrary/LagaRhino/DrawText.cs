using Rhino.Geometry;
using System.Drawing;
using Rhino;

namespace Laga.Rhino
{
    /// <summary>
    /// Draw RichText in Rhino.
    /// </summary>
     public class DrawText
    {
        private TextEntity txtEntity;
        readonly private int txtHeight;
        readonly private string mess;
        readonly private Plane pl;
        /// <summary>
        /// basic constructor for draw text.
        /// </summary>
        /// <param name="plane"></param>
        /// <param name="message"></param>
        /// <param name="TextHeight">The text height</param>
        public DrawText(Plane plane, string message, int TextHeight = 20)
        {
            pl = plane;
            mess = message;
            txtHeight = TextHeight;
            
            BuildTextEntity();

            RhinoDoc doc = RhinoDoc.ActiveDoc;
            doc.Objects.AddText(txtEntity);
        }

        private void BuildTextEntity()
        {
            txtEntity = new TextEntity
            {
                MaskColor = Color.White,
                MaskEnabled = true,
                MaskOffset = txtHeight * 0.1,
                MaskUsesViewportColor = false,
                Justification = TextJustification.Left,
                TextHeight = txtHeight,
                RichText = mess,
                Plane = pl
            };
        }

     }

}

