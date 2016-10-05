using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimplePhysicalEngine.NonPhysicalComponents;
using System.Windows.Forms;
using SimplePhysicalEngine;
using VisualPart;

namespace StartUpProject
{
    public class GameLevel
    {
        public GameLevel()
        {
            GenerateLevel();
        }
        ComplexObject Player { get; set; }
        List<ComplexObject> Enemies { get; set; }
        List<ComplexStructure> Structures { get; set; }

        List<RealObject> CollisionDomain { get; set; }
        Power Gravity { get; set; }

        public void OnPrintAllObjects(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(Player.CurrentFrame, (float)Player.RealObject.Position.X, (float)Player.RealObject.Position.Y);

            foreach (ComplexStructure o in Structures)
            {
                if (o.Texture == null)
                    e.Graphics.FillRectangle(System.Drawing.Brushes.Black,
                        (float)o.RealObject.Position.X,
                        (float)o.RealObject.Position.Y,
                        (float)o.RealObject.Width,
                        (float)o.RealObject.Height);
                else
                    e.Graphics.DrawImage(o.Texture,
                        (float)o.RealObject.Position.X,
                        (float)o.RealObject.Position.Y);
            }
        }
        public void OnRefresh(object sender, EventArgs e)
        {
            Player.OnRefresh(sender, e);
        }
        public void OnKeyDownExternal(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D:
                    Player.RealObject.direction = Direction.Right;
                    break;
                case Keys.A:
                    Player.RealObject.direction = Direction.Left;
                    break;
                case Keys.W:
                    Player.RealObject.Jump(-1);
                    break;
            }
        }
        public void OnKeyUpExternal(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D:
                    Player.RealObject.direction = Direction.None;
                    break;
                case Keys.A:
                    Player.RealObject.direction = Direction.None;
                    break;
            }
        }

        private void GenerateLevel()
        {
            CollisionDomain = new List<RealObject>();
            Structures = new List<ComplexStructure>();
            Gravity = new Power(0.01 * new Vector2(0, 1));

            Player = new ComplexObject();
            Player.RealObject = new RealObject(CollisionDomain, Gravity);
            Player.RealObject.Position = new Vector2(400, 400);
            Player.RealObject.Height = 72;
            Player.RealObject.Width = 72;
            Player.RealObject.SpeedX = 8;
            Player.NonActivityAnimation = new Animation("NonActivitySprites", 100);
            Player.NonActivityAnimation.Start();
            Player.WalkAnimationLeft = new Animation("WalkAnimationLeft", 100);
            Player.WalkAnimationLeft.Start();
            Player.WalkAnimationRight = new Animation("WalkAnimationRight", 100);
            Player.WalkAnimationRight.Start();
            Player.Animation = Player.NonActivityAnimation;

            ComplexStructure ground = new ComplexStructure();
            Structures.Add(ground);
            ground.RealObject = new RealObject(CollisionDomain);
            ground.RealObject.Position = new Vector2(20, 600);
            ground.RealObject.Height = 10;
            ground.RealObject.Width = 800;
        }

    }
}
