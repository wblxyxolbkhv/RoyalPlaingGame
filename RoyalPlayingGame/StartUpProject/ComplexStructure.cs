using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimplePhysicalEngine.NonPhysicalComponents;
using System.Drawing;

namespace StartUpProject
{
    public class ComplexStructure
    {
        public ComplexStructure()
        {
            Texture = Image.FromFile("GroundTextureTransparent.png");
            ((Bitmap)Texture).MakeTransparent(Color.White);
        }
        public RealObject RealObject { get; set; }
        public Image Texture { get; set; }
    }
}
