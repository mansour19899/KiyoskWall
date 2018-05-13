using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KiyoskWall
{
   public class NeedToReserve
    {
        
        public List<Schedule> Schedules { get; set; }
        public List<Tray> Trays { get; set; }
        public string date { get; set; }
        public int restaurent { get; set; }
        public Person Person { get; set; }
        public int meal { get; set; }
        public List<Date> AllDays { get; set; }
        public List<Schedule> tempSchedules;
        public List<Tray> TempTrays;

        public NeedToReserve(Person person)
        {
        PoonehEntities1 db=new PoonehEntities1();  // Change DataBase 

            Person = person;
            date = "";
            ListDate ty = new ListDate(person);
            AllDays = ty.GetList();

            // string y = AllDays.ElementAt(0).date.AddDaysToShamsiDate(-1);
            tempSchedules = Login.tempSchedules;

           // var ew = tempSchedules.Where(p => AllDays.Any(pe => pe.date == p.SDate)).Select(p => p.Tray_Id_Fk).Distinct().ToList();
            TempTrays = Login.TempTrays;

        }
     
        public void GiveTraysSchedle()
        {
            Schedules = (from p in tempSchedules
                         where p.SDate.Equals(date) & p.Restaurant_Id_Fk == restaurent
                                                          & p.Meal_Id_Fk == meal
                         select p).ToList();

            int t = (int)Schedules.ElementAt(0).Tray_Id_Fk;
            int tt = (int)Schedules.ElementAt(1).Tray_Id_Fk;
            int ttt = (int)Schedules.ElementAt(2).Tray_Id_Fk;
            Trays = (from qqq in TempTrays
                     where qqq.Id == t || qqq.Id == tt || qqq.Id == ttt
                     select qqq).ToList();

        }

        public void GiveAllTraysSchedle()
        {
            Schedules = tempSchedules.Where(p=>p.Restaurant_Id_Fk==restaurent).ToList();
            Trays = TempTrays;
            
        }
    }
}
