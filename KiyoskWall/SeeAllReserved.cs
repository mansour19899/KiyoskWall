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
    public partial class SeeAllReserved : Form
    {
        Person p;
        PoonehEntities db;
     public    List<Label> Labels;
        public SeeAllReserved(Person per)
        {
            InitializeComponent();
            p = per;
           
        }
        public SeeAllReserved()
        {
            InitializeComponent();
        }

        private void SeeAllReserved_Load(object sender, EventArgs e)
        {
            int id = 34647;
            db = new PoonehEntities();
            db.Configuration.LazyLoadingEnabled = true;

            string dtnow= DateTime.Now.ToPersianDateString();
            var t = db.PoonehReservations.Where(p => p.Person_Id_Fk == id&p.Schedule.SDate.CompareTo(dtnow)==1)
                .Select(pp=>new {date=pp.Schedule.SDate,NameFood=pp.Tray.Name,meal=pp.Meal_Id_Fk }).ToList();
            int i=0;

            Labels = new List<Label>();
            //  SetLabel();

            Labels.Add(lbl1);
            Labels.Add(lbl2);
            Labels.Add(lbl3);
            Labels.Add(lbl4);
            Labels.Add(lbl5);
            Labels.Add(lbl6);
            Labels.Add(lbl7);
            Labels.Add(lbl8);
            Labels.Add(lbl9);
            Labels.Add(lbl10);
            Labels.Add(lbl11);
            Labels.Add(lbl12);

            foreach (var item in t)
            {
                Labels.ElementAt(i).Text = item.NameFood;
                i++;
            }
            int x = 0;

        }

        public void SetLabel()
        {
            Labels.Add(lbl1);
            Labels.Add(lbl2);
            Labels.Add(lbl3);
            Labels.Add(lbl4);
            Labels.Add(lbl5);
            Labels.Add(lbl6);
            Labels.Add(lbl7);
            Labels.Add(lbl8);
            Labels.Add(lbl9);
            Labels.Add(lbl10);
            Labels.Add(lbl11);
            Labels.Add(lbl12);

        }
    }
}
