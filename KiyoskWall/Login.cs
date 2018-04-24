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
        public static List<Schedule> tempSchedules;
        public static List<Tray> TempTrays;
        string y;
        string yy;
        PoonehEntities1 db;

        public Login()
        {
            InitializeComponent();
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
               
                y = DateTime.Now.ToPersianDateString();
                LoadCash();
            }
            else
                y = "1397/01/01";
           

        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;



        }

    

 

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                yy = DateTime.Now.ToPersianDateString();
                if (y.CompareTo(yy) == -1)
                {
                    LoadCash();
                    y = yy;
                }
                KeyPad frm = new KeyPad(false);
                frm.ShowDialog();

            }
            else
            {
                Alarm frm = new Alarm();
                frm.Show();
            }
               
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                yy = DateTime.Now.ToPersianDateString();
                if (y.CompareTo(yy) == -1)
                {
                    LoadCash();
                    y = yy;
                }
                KeyPad frm = new KeyPad(true);
                frm.Show();

            }

            else
            {
                Alarm frm = new Alarm();
                frm.Show();
            }
        }

        private void LoadCash()
        {
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                try
                {
                    y = DateTime.Now.ToPersianDateString();
                    db = new PoonehEntities1();

                    tempSchedules = db.Schedules.Where(p => p.SDate.CompareTo(y) == 1).Distinct().ToList();
                    var AllDays = tempSchedules.Select(p => new Date { date = p.SDate }).Distinct();


                    var ew = tempSchedules.Where(p => AllDays.Any(pe => pe.date == p.SDate)).Select(p => p.Tray_Id_Fk).Distinct().ToList();
                    TempTrays = db.Trays.Where(p => ew.Any(ll => ll == p.Id)).Select(s => s).ToList();
                }
                catch (Exception)
                {

                    MessageBox.Show("مشکل در لود");
                }
              
            }
                

        }
    }
}
