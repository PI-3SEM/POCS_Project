using POCS_Project.entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POCS_Project.screens.Component
{
    class RotatedCard: PictureBox
    {
        public Card CardData { get; set; }
        public RotatedCard(Card cardData): base()
        {
            CardData = cardData;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.TranslateTransform(this.Width / 2, this.Height / 2);
            e.Graphics.RotateTransform(45);
            e.Graphics.TranslateTransform(-this.Width / 2, -this.Height / 2);
        }
    }
}
