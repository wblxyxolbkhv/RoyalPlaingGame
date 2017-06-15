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
using RoyalPlayingGame.Quests;
using RoyalPlayingGame;

/* Назначение: Медведь для отладки диалогов
 * Автор: Никитенко А.В.
 */
namespace StartUpProject.Enemies
{
    class DebugBear: ComplexUnit
    {
        public DebugBear(List<RealObject> CollisionDomain, Power Gravity)
        {
            
            Unit = new Unit(1000);
            Unit.Health = 100;
            Unit.RealHealth = 100;

            RealObject = new RealObject(CollisionDomain, Gravity);
            RealObject.Position = new Vector2(600, 400);
            RealObject.Height = 110;
            RealObject.Width = 110;
            RealObject.SpeedX = 0;
            RealObject.direction = Direction.Right;

            WalkAnimationLeft = new Animation("DebugBear", 120);
            WalkAnimationLeft.Mode = AnimationMode.Loop;
            WalkAnimationLeft.Start();
            

            DefaultAnimation = WalkAnimationLeft;
            Animation = WalkAnimationLeft;

            CurrentDialog = new RoyalPlayingGame.Dialogs.Dialog();
            CurrentDialog.LoadDialog("TestDialog.xml");

            Quest quest = new Quest();
            quest.LoadQuest("PigeonQuest.xml");

            
        }
    }
}
