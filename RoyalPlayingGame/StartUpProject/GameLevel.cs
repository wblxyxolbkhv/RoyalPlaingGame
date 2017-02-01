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
using RoyalPlayingGame;


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
            
            ActiveQuestManager = new ActiveQuestManager();
            ActiveQuestManager.Player = Player.Unit as Player;

            QuestJournalManager = new QuestJournalManager();
            QuestJournalManager.Player = Player.Unit as Player;

            InventoryManager = new InventoryManager();
            InventoryManager.Player = Player.Unit as Player;
            HintQueue = new HintQueue();
            HintQueue.Brush = Brushes.White;

            JournalNotesPublisher.Journal = (Player.Unit as Player).QuestJournal;

        }


        ComplexUnit Player { get; set; }
        List<ComplexEnemy> Enemies { get; set; }
        List<ComplexUnit> NPCs { get; set; }
        List<ComplexSpell> Spells { get; set; }
        List<ComplexStructure> Structures { get; set; }
        List<ComplexItem> DroppedItems { get; set; }

        List<RealObject> CollisionDomain { get; set; }
        List<RealObject> EnemiesCollisionDomain { get; set; }
        Power Gravity { get; set; }

        int CameraBias { get; set; }
        public int WorkAreaWidth { get; set; }
        public int WorkAreaHeight { get; set; }

        
        public PlayerMenuManager PlayerMenuManager { get; private set; }
        public DialogManager DialogManager { get; private set; }
        public ActiveQuestManager ActiveQuestManager { get; private set; }
        public QuestJournalManager QuestJournalManager { get; set; }
        public InventoryManager InventoryManager { get; set; }
        private HintQueue HintQueue { get; set; }

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
            foreach (ComplexItem o in DroppedItems)
                o.PrintObject(e, CameraBias);
            foreach (TemporaryTitle o in TemporaryObjects)
                o.PrintObject(e, CameraBias);

            HintQueue.PrintHints(e);
            DialogManager.PrintDialog(e, CameraBias);
            
            //PlayerMenuManager.OnPrint(sender, e);
        }
        public void OnRefresh(object sender, EventArgs e)
        {
            CheckTemporaryObjects();
            ChangeRealObjects();
            // TODO: заменить магическое число 10
            DialogManager.Refresh(10);
            HintQueue.OnRefresh(10);
            PlayerMenuManager.OnMenuRefresh(sender, e);
            ActiveQuestManager.OnRefresh();
            QuestJournalManager.OnRefresh();
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
            foreach (ComplexItem o in DroppedItems)
                o.OnRefresh(sender, e);
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
                    Interact(AvailableForTalkingNPC);
                    break;
                case Keys.Escape:
                    {
                        break;
                    }
                case Keys.J:
                    QuestJournalManager.ChangeVisibility();
                    break;
                case Keys.I:
                    InventoryManager.ChangeVisibility();
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
                HintQueue.AddHint("Недостаточно маны", 1000);
                return;
            }
            catch (RoyalPlayingGame.Exceptions.SpellCoolDownException)
            {
                HintQueue.AddHint("Заклинание еще не готово", 1000);
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
            ground.RealObject.Width = 4000;
            ground.RealObject.CollisionDetected += OnCollisionDetected;

            CameraBias = 0;

            CreateTriggers();

            CreateEnemies();


            DebugBear bear = new DebugBear(new List<RealObject>(), null);
            bear.RealObject.Position = new Vector2(600, 440);

            

            NPCs.Add(bear);
        }
        private void CreateEnemies()
        {
            Minotaur enemy = new Minotaur(CollisionDomain, Gravity);

            enemy.RealObject.Position = new Vector2(2000, 300);
            enemy.RealObject.CollisionDetected += OnCollisionDetected;
            enemy.PatrolPoint = new Vector2(2000, 400);
            Enemies.Add(enemy);

            Minotaur enemy1 = new Minotaur(CollisionDomain, Gravity);

            enemy1.RealObject.Position = new Vector2(2500, 400);
            enemy1.RealObject.CollisionDetected += OnCollisionDetected;
            enemy1.PatrolPoint = new Vector2(2500, 400);
            Enemies.Add(enemy1);

            Minotaur enemy2 = new Minotaur(CollisionDomain, Gravity);

            enemy2.RealObject.Position = new Vector2(3000, 400);
            enemy2.RealObject.CollisionDetected += OnCollisionDetected;
            enemy2.PatrolPoint = new Vector2(3000, 400);
            Enemies.Add(enemy2);
        }
        private void InitPlayer()
        {
            Player = new ComplexUnit();

            Player.Unit = new Player();
            Player.Unit.Health = 200;
            Player.Unit.Mana = 100000;
            Player.Unit.RealMana = 100000;
            Player.Unit.RealHealth = 200;

            Player.RealObject = new RealObject(CollisionDomain, 0, Gravity);
            Player.RealObject.Position = new Vector2(400, 400);
            Player.RealObject.Height = 69;
            Player.RealObject.Width = 42;
            Player.IndentY = 3;
            Player.IndentX = 21;
            Player.RealObject.SpeedX = 4;
            Player.NonActivityAnimationLeft = new Animation("Player/NonActivityAnimationLeft", 100);
            Player.NonActivityAnimationLeft.Start();
            Player.NonActivityAnimationRight = new Animation("Player/NonActivityAnimationRight", 100);
            Player.NonActivityAnimationRight.Start();

            Player.WalkAnimationLeft = new Animation("Player/WalkAnimationLeft", 100);
            Player.WalkAnimationLeft.Start();
            Player.WalkAnimationRight = new Animation("Player/WalkAnimationRight", 100);
            Player.WalkAnimationRight.Start();

            Player.JumpAnimationLeft = new Animation("Player/JumpAnimationLeft", 300);
            Player.JumpAnimationLeft.Start();
            Player.JumpAnimationRight = new Animation("Player/JumpAnimationRight", 300);
            Player.JumpAnimationRight.Start();

            Player.Cast1AnimationLeft = new Animation("Player/Cast1/Cast1Left", 100);
            Player.Cast1AnimationLeft.Mode = AnimationMode.Once;
            Player.Cast1AnimationRight = new Animation("Player/Cast1/Cast1Right", 100);
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
        private void ChangeRealObjects()
        {
            foreach(ComplexObject o in RemoveQueue)
            {
                if (o is ComplexItem)
                {
                    DroppedItems.Remove(o as ComplexItem);
                    CollisionDomain.Remove(o.RealObject);
                }
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
                ComplexEnemy enemy = s as ComplexEnemy;

                if (CollisionDomain.Contains(s.RealObject))
                    CollisionDomain.Remove(s.RealObject);
                if (enemy != null)
                    if (enemy.Unit.Loot != null && enemy.Unit.Loot.Count > 0)
                        return;
                if (s.DeathAnimation != null && !s.DeathAnimation.IsActive || s.DeathAnimation == null)
                    RemoveQueue.Add(s);
                
            }
        }

        private void OnTalkAvailable()
        {
            if (DialogManager.Dialog != null && DialogManager.Dialog.IsActive)
                return;
            int range = 100;
            AvailableForTalkingNPC = null;
            foreach (ComplexUnit unit in NPCs)
            {
                switch (Player.RealObject.direction)
                {
                    case Direction.Right:
                    case Direction.NoneRight:
                        if (unit.RealObject.Position.X - Player.RealObject.Position.X - Player.RealObject.Width <= range &&
                            unit.RealObject.Position.X - Player.RealObject.Position.X - Player.RealObject.Width > 0)
                        {
                            if (!HintQueue.Contains("Нажмите E чтобы заговорить с ЭТИМ"))
                                HintQueue.AddHint("Нажмите E чтобы заговорить с ЭТИМ");
                            AvailableForTalkingNPC = unit;
                        }
                        break;
                    case Direction.Left:
                    case Direction.NoneLeft:
                        if (Player.RealObject.Position.X > unit.RealObject.Position.X + unit.RealObject.Width &&
                            Player.RealObject.Position.X < unit.RealObject.Position.X + unit.RealObject.Width + range)
                        {
                            if (!HintQueue.Contains("Нажмите E чтобы заговорить с ЭТИМ"))
                                HintQueue.AddHint("Нажмите E чтобы заговорить с ЭТИМ");
                            AvailableForTalkingNPC = unit;
                        }
                        break;
                }
            }
            foreach (ComplexEnemy enemy in Enemies)
            {
                if (enemy.Unit.IsAlive)
                    continue;
                switch (Player.RealObject.direction)
                {
                    case Direction.Right:
                    case Direction.NoneRight:
                        if (enemy.RealObject.Position.X - Player.RealObject.Position.X - Player.RealObject.Width <= range &&
                            enemy.RealObject.Position.X - Player.RealObject.Position.X - Player.RealObject.Width > 0)
                        {
                            if (enemy.Unit.Loot != null && enemy.Unit.Loot.Count > 0)
                            {
                                if (!HintQueue.Contains("Нажмите E чтобы подобрать предмет"))
                                    HintQueue.AddHint("Нажмите E чтобы подобрать предмет");
                                AvailableForTalkingNPC = enemy;
                            }
                            else RemoveQueue.Add(enemy);
                        }
                        break;
                    case Direction.Left:
                    case Direction.NoneLeft:
                        if (Player.RealObject.Position.X > enemy.RealObject.Position.X + enemy.RealObject.Width &&
                            Player.RealObject.Position.X < enemy.RealObject.Position.X + enemy.RealObject.Width + range)
                        {
                            if (enemy.Unit.Loot != null && enemy.Unit.Loot.Count > 0)
                            {
                                if (!HintQueue.Contains("Нажмите E чтобы подобрать предмет"))
                                    HintQueue.AddHint("Нажмите E чтобы подобрать предмет");
                                AvailableForTalkingNPC = enemy;
                            }
                            else RemoveQueue.Add(enemy);
                        }
                        break;
                }

            }
        }
        private ComplexObject AvailableForTalkingNPC;
        private void Interact(ComplexObject obj)
        {
            if (obj == null)
                return;
            ComplexUnit unit = null;
            if ((unit = obj as ComplexUnit) != null && unit.CurrentDialog!=null)
            {
                DialogManager.Dialog = unit.CurrentDialog;
                DialogManager.Dialog.IsActive = true;
                DialogManager.Dialog.GoToDialogBeginning();
                DialogManager.TalkingObject = unit;
            }
            else
            {
                // здесь твое поле для творчества
                obj.Interact();
            }
            
        }
        private void CreateTriggers()
        {

            RealObject Trigger1 = new RealObject(CollisionDomain, 1);
            Trigger1.Position = new Vector2(2000, 400);
            Trigger1.Height = 100;
            Trigger1.Width = 100;
            CollisionDomain.Add(Trigger1);
            Trigger1.IsTrigger = true;
        }


    }
}
