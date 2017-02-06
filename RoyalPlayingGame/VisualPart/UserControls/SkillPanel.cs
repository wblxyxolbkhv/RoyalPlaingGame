using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RoyalPlayingGame.Spell;

namespace VisualPart.UserControls
{
    public partial class SkillPanel : UserControl
    {
        private class SpellImageIcon
        {
            public Image Image;
            public string SpellName;
        }
        List<SpellImageIcon> Icons = new List<SpellImageIcon>();
        public SkillPanel()
        {
            InitializeComponent();


        }
        public Spell SpellHotKey1 { get; set; }
        public Spell SpellHotKey2 { get; set; }
        public Spell SpellHotKey3 { get; set; }
        public Spell SpellHotKey4 { get; set; }
        public Spell SpellHotKey5 { get; set; }
        public Spell SpellHotKey6 { get; set; }
        public Spell SpellHotKey7 { get; set; }
        public Spell SpellHotKey8 { get; set; }
        public Spell SpellHotKey9 { get; set; }
        public Spell SpellHotKey10 { get; set; }
    }
}
