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
    public partial class Scale : UserControl
    {
        public Scale()
        {
            InitializeComponent();
            brush = Brushes.Red;
            scaleColor = Color.Red;
            CurrentValue = 100;
            MaxValue = 100;
        }
        private Brush brush;
        private Color scaleColor;
        public int MaxValue { get; set; }
        public int CurrentValue { get; set; }
        public Color ScaleColor
        {
            get { return scaleColor; }
            set
            {
                scaleColor = value;
                brush = new SolidBrush(scaleColor);
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //e.Graphics.FillRectangle(Brushes.Black, 0, 0, this.Width, this.Height);
            double percent = (double)CurrentValue / (double)MaxValue;
            e.Graphics.FillRectangle(brush, 2, 2, (float)(this.Width * percent) - 4, this.Height - 4);
            labelValue.Text = CurrentValue + "/" + MaxValue;
        }
    }
}
