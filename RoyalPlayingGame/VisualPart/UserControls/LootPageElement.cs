using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RoyalPlayingGame.Items;

namespace VisualPart.UserControls
{
    public partial class LootPageElement : UserControl
    {
        public LootPageElement()
        {
            InitializeComponent();
            pictureBox1.MouseMove += OnMouseMove;
            pictureBox1.MouseLeave += OnMouseLeave;
            label1.MouseMove += OnMouseMove;
            label1.MouseLeave += OnMouseLeave;
            
        }

        public Item CurItem { get; set; }

        /// <summary>
        /// Обновление данных контрола
        /// </summary>
        /// <param name="item"></param>
        public void Update(Item item)
        {
            CurItem = item;
            label1.Text = item.Name;
            //if (CurItem.Amount > 1)
            {
                Label amountLabel = new Label();
                pictureBox1.Controls.Add(amountLabel);
                amountLabel.Location = new Point(pictureBox1.Location.X + 34, pictureBox1.Location.Y + 34);
                amountLabel.Text = CurItem.Amount.ToString();
                amountLabel.BackColor = Color.Black;
                amountLabel.ForeColor = Color.White;
                amountLabel.BorderStyle = BorderStyle.Fixed3D;
                amountLabel.AutoSize = true;
                amountLabel.Anchor = AnchorStyles.Right;
            }
        }

        private void OnDoubleClick(object sender, EventArgs e)
        {
            if(Parent!=null)
                if(Parent.Parent!=null)
                    if(Parent.Parent.Parent as LootPageControl != null)
            (Parent.Parent.Parent as LootPageControl).OnDoubleClick(this, e);
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (Parent != null)
                if (Parent.Parent != null)
                    if (Parent.Parent.Parent as LootPageControl != null)
                (Parent.Parent.Parent as LootPageControl).OnMouseMove(this, e);
        }

        private void OnMouseLeave(object sender, EventArgs e)
        {
            if (Parent != null)
                if (Parent.Parent != null)
                    if (Parent.Parent.Parent as LootPageControl != null)
                (Parent.Parent.Parent as LootPageControl).OnMouseLeave(this, e);
        }

        /// <summary>
        /// Добавление иконки предмета на PB
        /// </summary>
        /// <param name="bm"></param>
        public void SetBitmapImage(Bitmap bm)
        {
            pictureBox1.Image = bm;
        }
    }
}
