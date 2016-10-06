﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimplePhysicalEngine.NonPhysicalComponents;
using System.Windows.Forms;
using SimplePhysicalEngine;
using VisualPart;
using RoyalPlayingGame;

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
        List<ComplexObject> Spells { get; set; }
        List<ComplexStructure> Structures { get; set; }

        List<RealObject> CollisionDomain { get; set; }
        Power Gravity { get; set; }

        public void OnPrintAllObjects(object sender, PaintEventArgs e)
        {
            if (Player.CurrentFrame != null)
                e.Graphics.DrawImage(Player.CurrentFrame, (float)Player.RealObject.Position.X, (float)Player.RealObject.Position.Y);
            else e.Graphics.FillRectangle(System.Drawing.Brushes.Black,
                        (float)Player.RealObject.Position.X,
                        (float)Player.RealObject.Position.Y,
                        (float)Player.RealObject.Width,
                        (float)Player.RealObject.Height);
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
            foreach (ComplexObject o in Spells)
            {
                if (o.CurrentFrame == null)
                    e.Graphics.FillRectangle(System.Drawing.Brushes.Black,
                        (float)o.RealObject.Position.X,
                        (float)o.RealObject.Position.Y,
                        (float)o.RealObject.Width,
                        (float)o.RealObject.Height);
                else
                    e.Graphics.DrawImage(o.CurrentFrame,
                        (float)o.RealObject.Position.X,
                        (float)o.RealObject.Position.Y);
            }
        }
        public void OnRefresh(object sender, EventArgs e)
        {
            Player.OnRefresh(sender, e);
            foreach (ComplexObject o in Spells)
                o.OnRefresh(sender, e);
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
                    Player.RealObject.Jump(-0.7);
                    break;
                case Keys.Space:
                    Spells.Add(Player.Cast(Player.Unit.CastSpell() as NegativeSpell, Player.RealObject, CollisionDomain));
                    break;
            }
        }
        public void OnKeyUpExternal(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D:
                    Player.RealObject.direction = Direction.NoneRight;
                    break;
                case Keys.A:
                    Player.RealObject.direction = Direction.NoneLeft;
                    break;
            }
        }

        private void GenerateLevel()
        {
            CollisionDomain = new List<RealObject>();
            Structures = new List<ComplexStructure>();
            Spells = new List<ComplexObject>();
            Gravity = new Power(0.01 * new Vector2(0, 1));

            InitPlayer();

            ComplexStructure ground = new ComplexStructure();
            Structures.Add(ground);
            ground.RealObject = new RealObject(CollisionDomain);
            ground.RealObject.Position = new Vector2(0, 645);
            ground.RealObject.Height = 30;
            ground.RealObject.Width = 1008;
        }

        private void InitPlayer()
        {
            Player = new ComplexObject();

            Player.Unit = new Unit();
            
            Player.RealObject = new RealObject(CollisionDomain, Gravity);
            Player.RealObject.Position = new Vector2(400, 400);
            Player.RealObject.Height = 72;
            Player.RealObject.Width = 72;
            Player.RealObject.SpeedX = 4;
            Player.NonActivityAnimationLeft = new Animation("NonActivityAnimationLeft", 100);
            Player.NonActivityAnimationLeft.Start();
            Player.NonActivityAnimationRight = new Animation("NonActivityAnimationRight", 100);
            Player.NonActivityAnimationRight.Start();

            Player.WalkAnimationLeft = new Animation("WalkAnimationLeft", 100);
            Player.WalkAnimationLeft.Start();
            Player.WalkAnimationRight = new Animation("WalkAnimationRight", 100);
            Player.WalkAnimationRight.Start();

            Player.JumpAnimationLeft = new Animation("JumpAnimationLeft", 300);
            Player.JumpAnimationLeft.Start();
            Player.JumpAnimationRight = new Animation("JumpAnimationRight", 300);
            Player.JumpAnimationRight.Start();

            Player.Cast1AnimationLeft = new Animation("Cast1/Cast1Left", 100);
            Player.Cast1AnimationLeft.Mode = AnimationMode.Once;
            Player.Cast1AnimationRight = new Animation("Cast1/Cast1Right", 100);
            Player.Cast1AnimationRight.Mode = AnimationMode.Once;
            Player.DefaultAnimation = Player.NonActivityAnimationRight;
            Player.Animation = Player.NonActivityAnimationRight;
        }






        
    }
}
