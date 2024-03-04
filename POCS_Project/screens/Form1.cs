using POCS_Project.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POCS_Project
{
    public partial class ChoosePlayMode : Form
    {
        public ChoosePlayMode()
        {
            InitializeComponent();
        }

        private void MultiplayerBtn_Click(object sender, EventArgs e)
        {
            this.ChangeScreen(new SelectAnExistentGame());
        }
    }
}
