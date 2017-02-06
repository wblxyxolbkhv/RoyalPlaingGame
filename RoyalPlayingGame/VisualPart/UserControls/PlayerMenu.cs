using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualPart.UserControls
{
    public partial class PlayerMenu : UserControl
    {
        public PlayerMenu()
        {
            InitializeComponent();
        }
        public int MaxHP
        {
            get {  return maxHP; }
            set
            {
                if (value > 0)
                    maxHP = value;
                else maxHP = 1;
                scaleHP.MaxValue = maxHP;
            }
        }
        public int MaxMP
        {
            get { return maxMP; }
            set
            {
                if (value > 0)
                    maxMP = value;
                else maxMP = 1;
                scaleMP.MaxValue = maxMP;
            }
        }
        public int RealHP
        {
            get { return realHP; }
            set
            {
                if (value >= 0)
                    realHP = value;
                else realHP = 0;
                scaleHP.CurrentValue = realHP;
            }
        }
        public int RealMP
        {
            get { return realMP; }
            set
            {
                if (value >= 0)
                    realMP = value;
                else realMP = 0;
                scaleMP.CurrentValue = realMP;
            }
        }

        private int maxHP;
        private int maxMP;
        private int realHP;
        private int realMP;

        public int Strengh
        {
            get;set;
        }
        public int Agility
        {
            get;set;
        }
        public int Intelegence
        {
            get;set;
        }
        
        public int RealStrengh
        {
            get { return realStrengh; }
            set
            {
                if (value >= 0)
                    realStrengh = value;
                else realStrengh = 0;
                labelStrengh.Text = realStrengh.ToString();
                if (realStrengh < Strengh)
                    labelStrengh.ForeColor = Color.Red;
                else if (realStrengh > Strengh)
                    labelStrengh.ForeColor = Color.Green;
                else if (realStrengh == Strengh)
                    labelStrengh.ForeColor = Color.Black;
            }
        }
        public int RealAgility
        {
            get { return realAgility; }
            set
            {
                if (value >= 0)
                    realAgility = value;
                else realAgility = 0;
                labelAgility.Text = realAgility.ToString();
                if (realAgility < Agility)
                    labelAgility.ForeColor = Color.Red;
                else if (realAgility > Agility)
                    labelAgility.ForeColor = Color.Green;
                else if (realAgility == Agility)
                    labelAgility.ForeColor = Color.Black;
            }
        }
        public int RealIntelegence
        {
            get { return realIntelegence; }
            set
            {
                if (value >= 0)
                    realIntelegence = value;
                else realIntelegence = 0;
                labelIntelegence.Text = realIntelegence.ToString();
                if (realIntelegence < Intelegence)
                    labelIntelegence.ForeColor = Color.Red;
                else if (realIntelegence > Intelegence)
                    labelIntelegence.ForeColor = Color.Green;
                else if (realIntelegence == Intelegence)
                    labelIntelegence.ForeColor = Color.Black;
            }
        }

        private int realStrengh;
        private int realAgility;
        private int realIntelegence;
    }
}
