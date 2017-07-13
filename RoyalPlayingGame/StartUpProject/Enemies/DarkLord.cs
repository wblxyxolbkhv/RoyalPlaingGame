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
using RoyalPlayingGame;
using RoyalPlayingGame.Items;
/* Назначение: Темный лорд на стартовой заставке
 * Автор: Никитенко А.В.
 */
namespace StartUpProject.Enemies
{
    public class DarkLord : ComplexUnit
    {
        public DarkLord(List<RealObject> CollisionDomain, Power Gravity)
        {

            Unit = new Unit(1003);
            Unit.Health = 100;
            Unit.RealHealth = 100;
            RealObject = new RealObject(CollisionDomain, Gravity);
            RealObject.Height = 161;
            RealObject.Width = 216;
            IndentX = 0;
            IndentY = 0;
            RealObject.SpeedX = 0;
            RealObject.SpeedY = 0;
            RealObject.direction = Direction.NoneLeft;


            WalkAnimationLeft = new Animation("DarkLord", 30);
            WalkAnimationLeft.Mode = AnimationMode.Loop;
            WalkAnimationLeft.Start();

            DefaultAnimation = WalkAnimationLeft;
            Animation = WalkAnimationLeft;



        }
    }
}
