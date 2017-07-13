using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimplePhysicalEngine.NonPhysicalComponents;
using System.Drawing;
using System.Windows.Forms;
/* Назначение: Класс для структур в реальном мире
 * Автор: Никитенко А.В.
 */
namespace StartUpProject
{
    public class ComplexStructure
    {
        public ComplexStructure()
        {
            Texture = Image.FromFile("GroundTextureTransparent.png");
            ((Bitmap)Texture).MakeTransparent(Color.White);
        }
        public ComplexStructure(string pathTexture)
        {
            Texture = Image.FromFile(pathTexture);
            ((Bitmap)Texture).MakeTransparent(Color.White);
        }
        public RealObject RealObject { get; set; }
        public int IndentX { get; set; } = 0;
        public int IndentY { get; set; } = 0;

        public Image Texture { get; set; }
        public void PrintTexture(PaintEventArgs e, int CameraBias)
        {
            if (Texture == null)
                e.Graphics.FillRectangle(System.Drawing.Brushes.Black,
                    (float)RealObject.Position.X - IndentX - CameraBias,
                    (float)RealObject.Position.Y - IndentY,
                    (float)RealObject.Width,
                    (float)RealObject.Height);
            else
            {
                if (Texture.Width < RealObject.Width)
                {
                    int count = (int)RealObject.Width / Texture.Width;
                    count++;
                    for (int i = 0; i<count;i++)
                        e.Graphics.DrawImage(Texture,
                        (float)RealObject.Position.X - IndentX + i*Texture.Width - CameraBias,
                        (float)RealObject.Position.Y - IndentY);
                }
                else
                    e.Graphics.DrawImage(Texture,
                    (float)RealObject.Position.X - IndentX - CameraBias,
                    (float)RealObject.Position.Y - IndentY);
            }
        }
    }
}
