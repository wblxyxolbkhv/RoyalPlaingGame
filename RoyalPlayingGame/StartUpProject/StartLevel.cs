using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimplePhysicalEngine;
using SimplePhysicalEngine.NonPhysicalComponents;
using VisualPart;
using RoyalPlayingGame.Spell;
using RoyalPlayingGame.Spell.NegativeSpells;
using RoyalPlayingGame.Units;
using RoyalPlayingGame.Items;
using System.Drawing;
using StartUpProject.Enemies;
using StartUpProject.Spells;
using StartUpProject.Dialogs;
using RoyalPlayingGame;
using StartUpProject.Scripts;
using StartUpProject.GlobalGameComponents;
using System.Threading;

namespace StartUpProject
{
    class StartLevel : GameLevel
    {
        public StartLevel():base() { }
        protected override void GenerateLevel()
        {
            CollisionDomain = new List<RealObject>();
            EnemiesCollisionDomain = new List<RealObject>();
            Structures = new List<ComplexStructure>();
            DroppedItems = new List<ComplexItem>();
            Spells = new List<ComplexSpell>();
            Enemies = new List<ComplexEnemy>();
            NPCs = new List<ComplexUnit>();
            Gravity = new Power(0.01 * new Vector2(0, 1));

            InitPlayer();

            ComplexStructure ground = new ComplexStructure("Textures/ground.png");
            Structures.Add(ground);
            ground.RealObject = new RealObject(CollisionDomain);
            ground.RealObject.Position = new Vector2(0, 523);
            ground.IndentY = 19;
            ground.RealObject.Height = 104;
            ground.RealObject.Width = 1000;
            ground.RealObject.CollisionDetected += OnCollisionDetected;

            CameraBias = 0;

            DarkLord enemy = new DarkLord(CollisionDomain, null);
            enemy.RealObject.Position = new Vector2(700, 300);
            NPCs.Add(enemy);



            ScriptManager.AddActionDelegate("fight_stage", () =>
            {
                Random rnd = new Random();
                CastEnemySpell(Player.Cast(new FireBall(0, 0), CollisionDomain));
                CastEnemySpell(new Lighting(new Vector2(rnd.Next(50, 1000), 300)));

                Thread.Sleep(500);
                CastEnemySpell(new Lighting(new Vector2(rnd.Next(50, 1000), 300)));
                Player.RealObject.direction = Direction.Right;
                CastEnemySpell(new Lighting(new Vector2(rnd.Next(50, 1000), 300)));

                Thread.Sleep(900);
                CastEnemySpell(new Lighting(new Vector2(rnd.Next(50, 1000), 300)));
                Player.RealObject.direction = Direction.NoneRight;
                CastEnemySpell(new Lighting(new Vector2(rnd.Next(50, 1000), 300)));
                CastEnemySpell(Player.Cast(new FrostDragonHead(0, 0), CollisionDomain));
                CastEnemySpell(new Lighting(new Vector2(rnd.Next(50, 1000), 300)));

                Thread.Sleep(1000);
                CastEnemySpell(new Lighting(new Vector2(rnd.Next(50, 1000), 300)));
                CastEnemySpell(Player.Cast(new RoyalPlayingGame.Spell.NegativeSpells.IceWave(0, 0), CollisionDomain));
                CastEnemySpell(new Lighting(new Vector2(rnd.Next(50, 1000), 300)));

                Thread.Sleep(1000);
                CastEnemySpell(new Orb(new Vector2(
                    Player.RealObject.Position.X - 120,
                    Player.RealObject.Position.Y - 45)));
            }
            );
        }
    }
}
