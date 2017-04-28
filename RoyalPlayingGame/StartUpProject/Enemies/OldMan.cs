using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimplePhysicalEngine.NonPhysicalComponents;
using SimplePhysicalEngine;
using VisualPart;
using RoyalPlayingGame.Quests;
using RoyalPlayingGame.Units;

namespace StartUpProject.Enemies
{
    class OldMan : ComplexUnit
    {
        public OldMan(List<RealObject> CollisionDomain, Power Gravity)
        {

            Unit = new Unit(1000);
            Unit.Health = 100;
            Unit.RealHealth = 100;

            RealObject = new RealObject(CollisionDomain, Gravity);
            RealObject.Position = new Vector2(600, 400);
            RealObject.Height = 110;
            RealObject.Width = 110;
            RealObject.SpeedX = 0;
            RealObject.direction = Direction.NoneLeft;

            NonActivityAnimationLeft = new Animation("OldManIdleLeft", 500);
            NonActivityAnimationLeft.Mode = AnimationMode.Loop;
            NonActivityAnimationLeft.Start();

            NonActivityAnimationRight = new Animation("OldManIdleRight", 500);
            NonActivityAnimationRight.Mode = AnimationMode.Loop;
            NonActivityAnimationRight.Start();

            DefaultAnimation = NonActivityAnimationLeft;
            Animation = NonActivityAnimationLeft;

            CurrentDialog = new RoyalPlayingGame.Dialogs.Dialog();
            CurrentDialog.LoadDialog("TestDialog.xml");

            Quest quest = new Quest();
            quest.LoadQuest("PigeonQuest.xml");


        }
    }
}
