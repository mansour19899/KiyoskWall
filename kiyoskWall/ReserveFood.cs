using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KiyoskWall
{
    public partial class ReserveFood : Form
    {
        private string dtnow;
        private Person _person;
        private int _restaurant_id;
        private string _date;
        private KiyoskWall.PoonehEntities db;
        public ReserveFood(string date,int restaurantId,Person person)
        {
            InitializeComponent();
            _person = person;
            _date = date;
            _restaurant_id = restaurantId;
            db = new PoonehEntities();
        }

        private void ReserveFood_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            lbDate.Text = _date;
            var trayIds = (from p in db.Schedules
                where p.SDate.Equals(_date) & p.Restaurant_Id_Fk == _restaurant_id
                                           & p.Meal_Id_Fk == 1
                select new { p.Tray_Id_Fk }).ToList();
            int t = (int)trayIds.ElementAt(0).Tray_Id_Fk;
            int tt = (int)trayIds.ElementAt(1).Tray_Id_Fk;
            int ttt = (int)trayIds.ElementAt(2).Tray_Id_Fk;
            List<Tray> qq = (from qqq in db.Trays
                where qqq.Id == t || qqq.Id == tt || qqq.Id == ttt
                select qqq).ToList();

      

            MemoryStream mStream = new MemoryStream(qq.ElementAt(0).Image);
            pictureBox1.Image= Image.FromStream(mStream);
            label1.Text = qq.ElementAt(0).Name;

            MemoryStream mStreamm = new MemoryStream(qq.ElementAt(1).Image);
            pictureBox2.Image = Image.FromStream(mStreamm);
            label2.Text = qq.ElementAt(1).Name;

            MemoryStream mStreammm = new MemoryStream(qq.ElementAt(2).Image);
            pictureBox3.Image = Image.FromStream(mStreammm);
            label3.Text = qq.ElementAt(2).Name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
