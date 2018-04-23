using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KiyoskWall
{
    public partial class Alarm : Form
    {
        int x;
        public Alarm()
        {
            InitializeComponent();
            x = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            x = x + 1;
            
            if (x == 4)
                this.Close();
        }
    }
}
