using Rhino;
using Rhino.Display;
using Rhino.DocObjects;
using System.Collections.Generic;
using System.Linq;

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
        /// From all the layers in the document, will only display the ones in the list.
        /// </summary>
        /// <param name="layerNamesToShow">the List or array of layernames to display</param>
        /// <returns>bool, true if successful</returns>
        public bool ShowLayers(IEnumerable<string> layerNamesToShow)
        {
            int indexLayer;
            Layer L;
            foreach (string Lname in layerNames)
            {
                indexLayer = -1;
                for (int i = 0; i < layerNamesToShow.Count(); i++)
                {
                    string name = layerNamesToShow.ElementAt(i);
                    if (Lname == name)
                        indexLayer = GetLayerIndex(name);
                }

                if (indexLayer != -1)
                {
                    L = doc.Layers[indexLayer];
                    L.IsVisible = true;
                }
                else
                {
                    indexLayer = GetLayerIndex(Lname);
                    L = doc.Layers[indexLayer];
                    L.IsVisible = false;
                }
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int GetLayerIndex(string name)
        {
            Layer myLayer = doc.Layers.FindName(name);
            return myLayer.Index;
        }

        /// <summary>
        /// Set the current layer using their name
        /// </summary>
        /// <param name="name">the name of the layer</param>
        /// <returns>bool</returns>
        public bool SetCurrentLayer(string name)
        {
            int indexLayer = GetLayerIndex(name);
            return doc.Layers.SetCurrentLayerIndex(indexLayer, true);
        }
    }
}
