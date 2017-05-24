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
    public partial class AdvancedLabel : UserControl
    {
        public AdvancedLabel()
        {
            InitializeComponent();
        }
        public string LabelText
        {
            get
            {
                return label1.Text;
            }
            set
            {
                label1.Text = value;
            }
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            this.BorderStyle = BorderStyle.Fixed3D;
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            this.BorderStyle = BorderStyle.FixedSingle ;
        }
    }
}
