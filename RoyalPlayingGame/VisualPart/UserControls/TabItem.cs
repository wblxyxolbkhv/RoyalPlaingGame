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
    public partial class TabItem : UserControl
    {
        public TabItem()
        {
            InitializeComponent();

            activeUp = (Bitmap)pbUp.BackgroundImage;
            activeUpLeft = (Bitmap)pbLeftUp.BackgroundImage;
            activeUpRight = (Bitmap)pbRightUp.BackgroundImage;
            activeRight = (Bitmap)pbRight.BackgroundImage;
            activeLeft = (Bitmap)pbLeft.BackgroundImage;
            activeRightDown = (Bitmap)pbRightDown.BackgroundImage;
            activeLeftDown = (Bitmap)pbLeftDown.BackgroundImage;
            activeDown = (Bitmap)pbDown.BackgroundImage;

            //not_activeUp = VisualPart.Properties.Resources.up;
            //not_activeUpLeft = VisualPart.Properties.Resources.left_up;
            //not_activeUpRight = VisualPart.Properties.Resources.right_up;
            //not_activeRight = VisualPart.Properties.Resources.right;
            //not_activeLeft = VisualPart.Properties.Resources.left;
            //not_activeRightDown = VisualPart.Properties.Resources.right_down;
            //not_activeLeftDown = VisualPart.Properties.Resources.left_down;
            //not_activeDown = VisualPart.Properties.Resources.down;

            IsActive = false;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);


        }
        Bitmap activeUp;
        Bitmap activeUpLeft;
        Bitmap activeUpRight;
        Bitmap activeRight;
        Bitmap activeLeft;
        Bitmap activeRightDown;
        Bitmap activeLeftDown;
        Bitmap activeDown;

        Bitmap not_activeUp;
        Bitmap not_activeUpLeft;
        Bitmap not_activeUpRight;
        Bitmap not_activeRight;
        Bitmap not_activeLeft;
        Bitmap not_activeRightDown;
        Bitmap not_activeLeftDown;
        Bitmap not_activeDown;

        public bool IsActive
        {
            get
            {
                return isActive;
            }
            set
            {
                isActive = value;
                if (value)
                {
                    pbUp.BackgroundImage = activeUp;
                    pbLeftUp.BackgroundImage = activeUpLeft;
                    pbRightUp.BackgroundImage = activeUpRight;
                    pbRight.BackgroundImage = activeRight;
                    pbLeft.BackgroundImage = activeLeft;
                    pbRightDown.BackgroundImage = activeRightDown;
                    pbLeftDown.BackgroundImage = activeLeftDown;
                    pbDown.BackgroundImage = activeDown;
                }
                else
                {
                    pbUp.BackgroundImage = not_activeUp;
                    pbLeftUp.BackgroundImage = not_activeUpLeft;
                    pbRightUp.BackgroundImage = not_activeUpRight;
                    pbRight.BackgroundImage = not_activeRight;
                    pbLeft.BackgroundImage = not_activeLeft;
                    pbRightDown.BackgroundImage = not_activeRightDown;
                    pbLeftDown.BackgroundImage = not_activeLeftDown;
                    pbDown.BackgroundImage = not_activeDown;
                }
            }
        }
        bool isActive = true;
        public string Title
        {
            get { return text; }
            set
            {
                label1.Text = value;
                text = value;
            }
        }
        string text = "Все предметы";
    }
}
