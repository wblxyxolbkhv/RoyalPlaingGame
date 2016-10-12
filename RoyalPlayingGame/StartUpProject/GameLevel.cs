using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimplePhysicalEngine.NonPhysicalComponents;
using System.Windows.Forms;
using SimplePhysicalEngine;
using VisualPart;
using RoyalPlayingGame.Spell;
using RoyalPlayingGame.Units;
using System.Drawing;
using StartUpProject.Enemies;

namespace StartUpProject
{
    public class GameLevel
    {
        public GameLevel()
        {
            GenerateLevel();

            PlayerMenuManager = new PlayerMenuManager();
            PlayerMenuManager.player = (Player)Player.Unit;
        }
        ComplexUnit Player { get; set; }
        List<ComplexEnemy> Enemies { get; set; }
        List<ComplexSpell> Spells { get; set; }
        List<ComplexStructure> Structures { get; set; }

        List<RealObject> CollisionDomain { get; set; }
        List<RealObject> EnemiesCollisionDomain { get; set; }
        Power Gravity { get; set; }

        int CameraBias { get; set; }
        public int WorkAreaWidth { get; set; }
        public int WorkAreaHeight { get; set; }


        public PlayerMenuManager PlayerMenuManager { get; private set; }

        public void OnPrintAllObjects(object sender, PaintEventArgs e)
        {
            Player.PrintObject(e, CameraBias);
            foreach (ComplexStructure o in Structures)
                o.PrintTexture(e, CameraBias);
            foreach (ComplexEnemy o in Enemies)
                o.PrintObject(e, CameraBias);
            foreach (ComplexObject o in Spells)
                o.PrintObject(e, CameraBias);
            foreach (TemporaryTitle o in TemporaryObjects)
                o.PrintObject(e, CameraBias);
            //PlayerMenuManager.OnPrint(sender, e);
        }
        public void OnRefresh(object sender, EventArgs e)
        {
            CheckTemporaryObjects();
            RemoveRealObjects();
            PlayerMenuManager.OnMenuRefresh(sender, e);
            Player.OnRefresh(sender, e);
            foreach (ComplexEnemy o in Enemies)
            {
                o.OnRefresh(sender, e);
                CleanObject(o);
            }
            foreach (ComplexStructure o in Structures)
                o.RealObject.OnRefreshPosition(sender, e);
            foreach (ComplexSpell o in Spells)
            {
                o.OnRefresh(sender, e);
                CleanObject(o);
            }
            foreach (TemporaryTitle o in TemporaryObjects)
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
                case Keys.D1:
                    NegativeSpell spell;
                    try
                    {
                        spell = (Player.Unit as Player).CastSpell(Keys.D1) as NegativeSpell;
                    }
                    catch (RoyalPlayingGame.Exceptions.NoManaException)
                    {
                        CreateTemporaryTitle("Недостаточно маны", Player.RealObject.Position, false);
                        return;
                    }    
                    catch (RoyalPlayingGame.Exceptions.SpellCoolDownException)
                    {
                        CreateTemporaryTitle("Заклинание еще не готово", Player.RealObject.Position, false);
                        return;
                    }
                    ComplexSpell s = Player.Cast(spell, Player.RealObject, CollisionDomain);
                    s.Spell = spell;
                    s.RealObject.CollisionDetected += OnCollisionDetected;
                    Spells.Add(s);
                    break;
                case Keys.D2:
                    NegativeSpell spell2;
                    try
                    {
                        spell2 = (Player.Unit as Player).CastSpell(Keys.D2) as NegativeSpell;
                    }
                    catch (RoyalPlayingGame.Exceptions.NoManaException)
                    {
                        CreateTemporaryTitle("Недостаточно маны", Player.RealObject.Position, false);
                        return;
                    }
                    catch (RoyalPlayingGame.Exceptions.SpellCoolDownException)
                    {
                        CreateTemporaryTitle("Заклинание еще не готово", Player.RealObject.Position, false);
                        return;
                    }
                    ComplexSpell s2 = Player.Cast(spell2, Player.RealObject, CollisionDomain);
                    s2.Spell = spell2;
                    s2.RealObject.CollisionDetected += OnCollisionDetected;
                    Spells.Add(s2);
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
            EnemiesCollisionDomain = new List<RealObject>();
            Structures = new List<ComplexStructure>();
            Spells = new List<ComplexSpell>();
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
            ground.RealObject.CollisionDetected += OnCollisionDetected;

            CameraBias = 0;


            Minotaur enemy = new Minotaur(CollisionDomain, Gravity);
            
            enemy.RealObject.Position = new Vector2(600, 400);
            enemy.RealObject.CollisionDetected += OnCollisionDetected;
            
            Enemies.Add(enemy);
        }

        private void InitPlayer()
        {
            Player = new ComplexUnit();

            Player.Unit = new Player();
            Player.Unit.Health = 200;
            Player.Unit.Mana = 200;
            Player.Unit.RealHealth = 200;
            Player.Unit.RealMana = 200;

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
                o.RealObject.Height = o.Texture.Height ;
                o.RealObject.Width = o.Texture.Width;
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



        private void OnCollisionDetected(RealObject o1, RealObject o2)
        {
            ComplexSpell spell = FindSpell(o1);
            if (spell == null)
                spell = FindSpell(o2);
            else
            {
                ComplexObject enemy = FindObject(o2);
                DestroySpell(spell, enemy);
                return;
            }
            if (spell == null)
                return;
            else
            {
                ComplexObject enemy = FindObject(o1);
                DestroySpell(spell, enemy);
                return;
            }

        }
        private void DestroySpell(ComplexSpell spell, ComplexObject enemy)
        {
            if (spell.RealObject.SpeedX != 0)
                spell.ManualyDeath();
            if (enemy != null && !spell.DamagedUnits.Contains((ComplexUnit)enemy))
            {
                bool critical;
                int d = spell.Spell.DealtDamage(out critical);
                int dealedDamage = enemy.Unit.GotDamaged(d, DamageType.Magic);
                spell.DamagedUnits.Add((ComplexUnit)enemy);
                CreateTemporaryTitle("-" + dealedDamage.ToString(), enemy.RealObject.Position, critical);
            }
        }



        private ComplexSpell FindSpell(RealObject o)
        {
            foreach (ComplexSpell s in Spells)
                if (s.RealObject.Equals(o))
                    return s;
            return null;
        }
        private ComplexObject FindObject(RealObject o)
        {
            foreach (ComplexObject s in Enemies)
                if (s.RealObject.Equals(o))
                    return s;
            return null;
        }

        private List<ComplexObject> RemoveQueue = new List<ComplexObject>();
        private void RemoveRealObjects()
        {
            foreach(ComplexObject o in RemoveQueue)
            {
                if (o is ComplexSpell)
                {
                    if (Spells.Contains(o))
                    {
                        Spells.Remove(o as ComplexSpell);
                        if (CollisionDomain.Contains(o.RealObject))
                            CollisionDomain.Remove(o.RealObject);
                    }
                }
                else if (o is TemporaryTitle)
                {
                    if (TemporaryObjects.Contains(o as TemporaryTitle))
                        TemporaryObjects.Remove(o as TemporaryTitle);
                }
                else if (o is ComplexEnemy)
                {
                    if (Enemies.Contains(o as ComplexEnemy))
                        Enemies.Remove(o as ComplexEnemy);
                }
            }
            RemoveQueue.Clear();
        }

        private List<ComplexObject> TemporaryObjects = new List<ComplexObject>();
        private void CheckTemporaryObjects()
        {
            try
            {
                foreach (TemporaryTitle t in TemporaryObjects)
                {
                    if (!t.IsActive)
                        RemoveQueue.Add(t);
                }
            }
            catch { }
        }
        private void CreateTemporaryTitle(string title, Vector2 pos, bool critical)
        {
            RealObject r = new RealObject(new List<RealObject>());
            r.Position = new Vector2(pos.X, pos.Y);

            TemporaryTitle newTitle = new TemporaryTitle(title, 2, r, critical);
            TemporaryObjects.Add(newTitle);
        }
        private void CleanObject(ComplexObject s)
        {
            if (!s.IsActive)
            {
                if (CollisionDomain.Contains(s.RealObject))
                    CollisionDomain.Remove(s.RealObject);
                if (s.DeathAnimation != null && !s.DeathAnimation.IsActive || s.DeathAnimation == null)
                    RemoveQueue.Add(s);
                
            }
        }
    }
}
