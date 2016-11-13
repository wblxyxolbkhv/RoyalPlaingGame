using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoyalPlayingGame.Items;
using System.Drawing;
using System.Windows.Forms;

namespace StartUpProject
{
    public class ComplexItem : ComplexObject
    {
        private Item item;
        public Item Item
        {
            get { return item; }
            set
            {
                item = value;
                if (item != null)
                {
                    string path = @"ItemsTextures/{0}.png";
                    path = string.Format(path, item.Name);
                    Texture = (Bitmap)Image.FromFile(path);
                    Texture.MakeTransparent(Color.White);
                }
            }
        }
        public Bitmap Texture { get; set; }
        public override void OnRefresh(object sender, EventArgs e)
        {
            RealObject.OnRefreshPosition(sender, e);
        }
        public override void PrintObject(PaintEventArgs e, int CameraBias)
        {
            e.Graphics.DrawImage(Texture,
                (float)RealObject.Position.X - CameraBias,
                (float)RealObject.Position.Y);
        }
    }
}
