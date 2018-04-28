using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiyoskWall
{
    class ListDate
    {
        private int _worksheet;
        private int _resturentid;
        private Person _person;
        PoonehEntities1 db;
        string dtnow;
        public ListDate(Person person)
        {
            _person = person;
            _worksheet = _person.WorkSheet_Id_FK.Value;
           

        }

        public List<Date> GetList()
        {
             db = new PoonehEntities1();
            List<Date> q;
            dtnow = DateTime.Now.ToPersianDateString().AddDaysToShamsiDate(1);
            //string dtnow = DateTime.Now.ToPersianDateString();
            _resturentid = db.Person_Restaurant.FirstOrDefault(p => p.Person_Id_Fk ==_person.Id ).Restaurant_Id_Fk.Value;

            q = (from p in db.Schedules
                where p.Restaurant_Id_Fk==_resturentid
                where p.SDate.CompareTo(dtnow) == 1
                select new Date { date = p.SDate } 
                ).Distinct().OrderBy(o => o.date).ToList();


            var w = q;

            if (_worksheet == (int)Shift.Rozkar)
            {
               List<Date> qq = (from pp in db.HoliDays
                    where pp.HolidayDate.CompareTo(dtnow) == 1
                    select new Date { date = pp.HolidayDate,meal = 1}).Distinct().ToList();

                for (int i = 0; i < qq.Count; i++)
                {
                    var ee = q.Where(p => p.date == qq.ElementAt(i).date).FirstOrDefault();
                    q.Remove(ee);
                }

                foreach (var item in q)
                {
                    item.day = item.date.ToPersianday();
                    item.meal = 1;
                }

                return ExtraMealAdded(w, q);
            }

            else if (_worksheet == (int)Shift.A8)
            {
                return ExtraMealAdded(w, ShiftFilter8(q, 0));
            }

            else if (_worksheet == (int)Shift.B8)
            {
                return ShiftFilter8(q, 4);
            }

            else if (_worksheet == (int)Shift.C8)
            {
                return ShiftFilter8(q, 8);
            }

            else if (_worksheet == (int)Shift.D8)
            {
                return ShiftFilter8(q, 12);
            }

            else if (_worksheet == (int)Shift.A12)
            {
                return ShiftFilter12(q, 8);
            }

            else if (_worksheet == (int)Shift.B12)
            {
                return ShiftFilter12(q, 4);
            }

            else if (_worksheet == (int)Shift.C12)
            {
                return ShiftFilter12(q, 0);
            }
            else
            {
                List<Date> qq = (from pp in db.HoliDays
                                 where pp.HolidayDate.CompareTo(dtnow) == 1
                                 select new Date { date = pp.HolidayDate, meal = 1 }).Distinct().ToList();

                for (int i = 0; i < qq.Count; i++)
                {
                    var ee = q.Where(p => p.date == qq.ElementAt(i).date).FirstOrDefault();
                    q.Remove(ee);
                }

                foreach (var item in q)
                {
                    item.day = item.date.ToPersianday();
                    item.meal = 1;
                }
                return q;
            }


        }

        private List<Date> ShiftFilter8(List<Date> d, int skip)
        {
            int x = 0;

            string datee = "1397/01/11".AddDaysToShamsiDate(skip);
            List<Date> qqq=new List<Date>();
            for (int i = 0; i < d.Count; i++)
               
            {
                x = d.ElementAt(i).date.DiffDaysShamsi(datee);
                x = x %16;
                if (x >=0 & x < 4)
                {
                    d.ElementAt(i).meal = 1;
                    qqq.Add(d.ElementAt(i));
                }

                if (x >=4 & x < 8)
                {
                    d.ElementAt(i).meal = 2;
                    qqq.Add(d.ElementAt(i));
                }

            }

            foreach (var item in qqq)
            {
                item.day = item.date.ToPersianday();
            }
            return qqq;
        }

        private List<Date> ShiftFilter12(List<Date> d, int skip)
        {
            int x = 0;

            string datee = "1397/01/31".AddDaysToShamsiDate(skip);
            List<Date> qqq = new List<Date>();
            for (int i = 0; i < d.Count; i++)

            {
                x = d.ElementAt(i).date.DiffDaysShamsi(datee);
                x = x % 12;
                if (x >= 0 & x < 4)
                {
                    d.ElementAt(i).meal = 1;
                    qqq.Add(d.ElementAt(i));
                }

                if (x >= 4 & x < 8)
                {
                    d.ElementAt(i).meal = 2;
                    qqq.Add(d.ElementAt(i));
                }

            }

            foreach (var item in qqq)
            {
                item.day = item.date.ToPersianday();
            }
            return qqq;
        }

        private List<Date> ExtraMealAdded(List<Date> Mainlist,List<Date> FilterList)
        {
            List<Date> extralist = new List<Date>();
            var r = from p in db.ExtraTimes
                    where p.EndDate.CompareTo(dtnow)==1&p.Person_Id_Fk==_person.Id
                    select p;

            foreach (var item in Mainlist)
            {
                foreach (var items in r)
                {
                  
                    if(item.date.CompareTo(items.StartDate.AddDaysToShamsiDate(-1)) ==1& item.date.CompareTo(items.EndDate.AddDaysToShamsiDate(1)) == -1)
                    {
                        if (items.Lunch.Value)
                            extralist.Add(new Date { date = item.date, meal = 1 });
                        if (items.Dinner.Value)
                            extralist.Add(new Date { date = item.date, meal = 2 });

                    }

                }
            }

            foreach (var item in extralist)
            {
                item.day = item.date.ToPersianday();
            }
            return extralist;
        }
    }
}
