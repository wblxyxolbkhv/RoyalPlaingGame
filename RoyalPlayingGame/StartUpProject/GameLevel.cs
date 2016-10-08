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
using System.Drawing;

namespace StartUpProject
{
    public class GameLevel
    {
        public GameLevel()
        {
            GenerateLevel();
        }
        ComplexObject Player { get; set; }
        List<ComplexEnemy> Enemies { get; set; }
        List<ComplexObject> Spells { get; set; }
        List<ComplexStructure> Structures { get; set; }

        List<RealObject> CollisionDomain { get; set; }
        Power Gravity { get; set; }

        int CameraBias { get; set; }
        public int WorkAreaWidth { get; set; }
        public int WorkAreaHeight { get; set; }

        public void OnPrintAllObjects(object sender, PaintEventArgs e)
        {
            Player.PrintObject(e, CameraBias);
            foreach (ComplexStructure o in Structures)
                o.PrintTexture(e, CameraBias);
            foreach (ComplexObject o in Spells)
                o.PrintObject(e, CameraBias);
            foreach (ComplexEnemy o in Enemies)
                o.PrintObject(e, CameraBias);
        }
        public void OnRefresh(object sender, EventArgs e)
        {
            Player.OnRefresh(sender, e);
            foreach (ComplexObject o in Spells)
                o.OnRefresh(sender, e);
            foreach (ComplexEnemy o in Enemies)
                o.OnRefresh(sender, e);
            foreach (ComplexStructure o in Structures)
                o.RealObject.OnRefreshPosition(sender, e);
            CameraBias = GetCameraBiasX();
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
            Enemies = new List<ComplexEnemy>();
            Gravity = new Power(0.01 * new Vector2(0, 1));

            InitPlayer();

            ComplexStructure ground = new ComplexStructure("Textures/ground.png");
            Structures.Add(ground);
            ground.RealObject = new RealObject(CollisionDomain);
            ground.RealObject.Position = new Vector2(0, 520);
            ground.BiasY = 19;
            ground.RealObject.Height = 104;
            ground.RealObject.Width = 4000;

            CameraBias = 0;


            ComplexEnemy enemy = new ComplexEnemy();

            enemy.Unit = new Unit();

            enemy.RealObject = new RealObject(CollisionDomain, Gravity);
            enemy.RealObject.Position = new Vector2(600, 400);
            enemy.RealObject.Height = 110;
            enemy.RealObject.Width = 110;
            enemy.RealObject.SpeedX = 2;
            enemy.RealObject.direction = Direction.Right;

            enemy.WalkAnimationLeft = new Animation("Minotaur/WalkLeft", 100);
            enemy.WalkAnimationLeft.Start();
            enemy.WalkAnimationRight = new Animation("Minotaur/WalkRight", 100);
            enemy.WalkAnimationRight.Start();

            enemy.DefaultAnimation = enemy.WalkAnimationLeft;
            enemy.Animation = enemy.WalkAnimationLeft;

            Enemies.Add(enemy);
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

        public void OnMouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ComplexStructure o = new ComplexStructure("Textures/stone.png");
                o.RealObject = new RealObject(CollisionDomain, Gravity);
                o.RealObject.Position = new Vector2(e.X + CameraBias, e.Y);
                o.RealObject.Height = 50;
                o.RealObject.Width = 50;
                o.RealObject.SpeedX = 8;
                Structures.Add(o);
            }
            else
            {
                Player.RealObject.Position = new Vector2(e.X + CameraBias, e.Y);
            }

        }
        private int GetCameraBiasX()
        {
            int limit = 400;
            if (WorkAreaWidth - (int)Player.RealObject.Position.X + CameraBias < limit)
            {
                int answer = (int)Player.RealObject.Position.X + limit - WorkAreaWidth;
                return answer;
            }
            if (WorkAreaWidth - (int)Player.RealObject.Position.X + CameraBias > WorkAreaWidth - limit)
            {
                int answer = (int)Player.RealObject.Position.X - limit;
                if (answer < 0)
                    return 0;
                return answer;
            }
            return CameraBias;
        }







    }
}
