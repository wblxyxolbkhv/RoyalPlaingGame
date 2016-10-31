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
using StartUpProject.Dialogs;

namespace StartUpProject
{
    public class GameLevel
    {
        public GameLevel()
        {
            GenerateLevel();

            PlayerMenuManager = new PlayerMenuManager();
            PlayerMenuManager.player = (Player)Player.Unit;

            DialogManager = new DialogManager();
            DialogManager.Player = Player;

        }
        ComplexUnit Player { get; set; }
        List<ComplexEnemy> Enemies { get; set; }
        List<ComplexUnit> NPCs { get; set; }
        List<ComplexSpell> Spells { get; set; }
        List<ComplexStructure> Structures { get; set; }

        List<RealObject> CollisionDomain { get; set; }
        List<RealObject> EnemiesCollisionDomain { get; set; }
        Power Gravity { get; set; }

        int CameraBias { get; set; }
        public int WorkAreaWidth { get; set; }
        public int WorkAreaHeight { get; set; }


        public PlayerMenuManager PlayerMenuManager { get; private set; }
        public DialogManager DialogManager { get; private set; }

        private List<string> HintQueue = new List<string>();

        public void OnPrintAllObjects(object sender, PaintEventArgs e)
        {
            Player.PrintObject(e, CameraBias);
            foreach (ComplexStructure o in Structures)
                o.PrintTexture(e, CameraBias);
            foreach (ComplexEnemy o in Enemies)
                o.PrintObject(e, CameraBias);
            foreach (ComplexUnit o in NPCs)
                o.PrintObject(e, CameraBias);
            foreach (ComplexObject o in Spells)
                o.PrintObject(e, CameraBias);
            foreach (TemporaryTitle o in TemporaryObjects)
                o.PrintObject(e, CameraBias);
            DialogManager.PrintDialog(e, CameraBias);
            foreach (string s in HintQueue)
                e.Graphics.DrawString(s, new Font("Arial", 12), Brushes.Black, 400, 400);
            //PlayerMenuManager.OnPrint(sender, e);
        }
        public void OnRefresh(object sender, EventArgs e)
        {
            CheckTemporaryObjects();
            RemoveRealObjects();
            // TODO: заменить магическое число 10
            DialogManager.Refresh(10);
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
            OnTalkAvailable();
            CameraBias = GetCameraBiasX();
        }
        public void OnKeyDownExternal(object sender, KeyEventArgs e)
        {
            if (DialogManager.Dialog!=null && DialogManager.Dialog.IsActive)
                return;
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
                case Keys.D1:
                case Keys.D2:
                case Keys.D3:
                case Keys.D4:
                    CastSpell(e.KeyCode);
                    break;
                //case Keys.Space:
                //    Enemies[0].Cast(CollisionDomain);
                //    break;
                case Keys.E:
                    Talk(AvailableForTalkingNPC);
                    break;
                case Keys.Escape:
                    HintQueue.Clear();
                    break;
            }
        }
        private void CastSpell(Keys k)
        {
            NegativeSpell spell;
            try
            {
                spell = (Player.Unit as Player).CastSpell(k) as NegativeSpell;
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
            ComplexSpell s = Player.Cast(spell, CollisionDomain);
            s.Spell = spell;
            s.RealObject.CollisionDetected += OnCollisionDetected;
            Spells.Add(s);
        }
        public void OnKeyUpExternal(object sender, KeyEventArgs e)
        {
            if (DialogManager.Dialog != null && DialogManager.Dialog.IsActive)
                return;
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
            NPCs = new List<ComplexUnit>();
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

            

            DebugBear bear = new DebugBear(new List<RealObject>(), null);
            bear.RealObject.Position = new Vector2(600, 440);

            //Minotaur enemy = new Minotaur(CollisionDomain, Gravity);

            //enemy.RealObject.Position = new Vector2(600, 400);
            //enemy.RealObject.CollisionDetected += OnCollisionDetected;

            NPCs.Add(bear);
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

        private void OnTalkAvailable()
        {
            if (DialogManager.Dialog != null && DialogManager.Dialog.IsActive)
                return;
            int range = 50;
            AvailableForTalkingNPC = null;
            foreach (ComplexUnit unit in NPCs)
            {
                switch (Player.RealObject.direction)
                {
                    case Direction.Right:
                    case Direction.NoneRight:
                        if (unit.RealObject.Position.X - Player.RealObject.Position.X < range + 20 &&
                            unit.RealObject.Position.X - Player.RealObject.Position.X > range - 20)
                        {
                            if (!HintQueue.Contains("Нажмите E чтобы заговорить с ЭТИМ"))
                                HintQueue.Add("Нажмите E чтобы заговорить с ЭТИМ");
                            AvailableForTalkingNPC = unit;
                        }
                        break;
                    case Direction.Left:
                    case Direction.NoneLeft:
                        if (-unit.RealObject.Position.X + Player.RealObject.Position.X < range + 20 &&
                            -unit.RealObject.Position.X + Player.RealObject.Position.X > range - 20)
                        {
                            if (!HintQueue.Contains("Нажмите E чтобы заговорить с ЭТИМ"))
                                HintQueue.Add("Нажмите E чтобы заговорить с ЭТИМ");
                            AvailableForTalkingNPC = unit;
                        }
                        break;
                }
            }
        }
        private ComplexUnit AvailableForTalkingNPC;
        private void Talk(ComplexUnit unit)
        {
            if (unit != null)
            {
                DialogManager.Dialog = unit.CurrentDialog;
                DialogManager.Dialog.IsActive = true;
                DialogManager.Dialog.GoToDialogBeginning();
                DialogManager.TalkingObject = unit;
                HintQueue.Clear();
            }
        }
    }
}
