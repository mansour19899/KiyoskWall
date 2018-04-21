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
    public partial class Login : Form
    {
        
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;



        }

    

 

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            KeyPad frm = new KeyPad(false);
            frm.ShowDialog();
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            KeyPad frm = new KeyPad(true);
            frm.Show();
        }
    }
}
