﻿using System;
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
        private int _meal;
        private KiyoskWall.PoonehEntities db;
        List<Schedule> Schedules;
        private PoonehReservation t;

        public ReserveFood(string date,int restaurantId,Person person,string meal)
        {
            InitializeComponent();
            _person = person;
            _date = date;
            _restaurant_id = restaurantId;
            _meal = int.Parse(meal);
            db = new PoonehEntities();
            
        }

        private void ReserveFood_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;

            if (_meal == 1)
                lbMeal.Text = "ناهار";
            else
            {
                lbMeal.Text = "شام";
                
            }
                
                
            lbDate.Text = _date;
            Schedules = (from p in db.Schedules
                where p.SDate.Equals(_date) & p.Restaurant_Id_Fk == _restaurant_id
                                           & p.Meal_Id_Fk ==_meal
                select p).ToList();
            int t = (int)Schedules.ElementAt(0).Tray_Id_Fk;
            int tt = (int)Schedules.ElementAt(1).Tray_Id_Fk;
            int ttt = (int)Schedules.ElementAt(2).Tray_Id_Fk;
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SetReserve(0);

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SetReserve(1);
           
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            SetReserve(2);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void SetReserve(int food)
        {
            var x1 = Schedules.ElementAt(0).Id;
            var x2 = Schedules.ElementAt(1).Id;
            var x3 = Schedules.ElementAt(2).Id;
            t = null;
            t =( from r in db.PoonehReservations
                where r.Person_Id_Fk == _person.Id
                      where r.Schedule_Id_Fk ==x1 || r.Schedule_Id_Fk == x2 || r.Schedule_Id_Fk == x3 
                select  r).SingleOrDefault();



            if (t != null)
            {
                t.Tray_Id_Fk = Schedules.ElementAt(food).Tray_Id_Fk;
                t.Schedule_Id_Fk = Schedules.ElementAt(food).Id;
                int tt = db.SaveChanges();
                MessageBox.Show("رزرو تغیر کرد");
                this.Close();

            }
            else
            {
                PoonehReservation reserv = new PoonehReservation()
                {
                    Tray_Id_Fk = Schedules.ElementAt(food).Tray_Id_Fk,
                    Person_Id_Fk = _person.Id,
                    Schedule_Id_Fk = Schedules.ElementAt(food).Id,
                    Company_Id_Fk = _person.Company_Id_Fk,
                    Unit_Id_Fk = _person.Unit_Id_Fk,
                    Restaurant_Id_Fk = Schedules.ElementAt(food).Restaurant_Id_Fk,
                    Meal_Id_Fk = Schedules.ElementAt(food).Meal_Id_Fk

                };
                db.PoonehReservations.Add(reserv);
                int x = db.SaveChanges();
             
                if (x != 0)
                {
                    MessageBox.Show("رزرو انجام شد");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("خطا در رزرو");
                }
            }
        }


    }
}
