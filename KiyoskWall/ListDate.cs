using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
        PoonehEntities db;
        string dtnow;
        public List<Schedule> Schedules { get; set; }
        public List<Tray> Trays { get; set; }

        public List<Schedule> tempSchedules;
        public List<Tray> TempTrays;

        public List<PerMeal> PerMEAL { get; set; }
        public ListDate(Person person)
        {
            _person = person;
            if (_person.WorkSheet_Id_FK == null)
                _worksheet = 22;
            else
                _worksheet = _person.WorkSheet_Id_FK.Value;

            tempSchedules = Login.tempSchedules;

            TempTrays = Login.TempTrays;
            PerMEAL = new List<PerMeal>();
            PerMEAL.Clear();

        }

        public List<Date> GetList()
        {
            db = new PoonehEntities();
            db.Configuration.LazyLoadingEnabled = true;
            List<Date> q;
            dtnow = DateTime.Now.ToPersianDateString();

            _resturentid = db.Person_Restaurant.FirstOrDefault(p => p.Person_Id_Fk == _person.Id).Restaurant_Id_Fk.Value;

            q = (from p in db.Schedules
                 where p.Restaurant_Id_Fk == _resturentid
                 where p.SDate.CompareTo(dtnow) == 1
                 select new Date { date = p.SDate }
                ).Distinct().OrderBy(o => o.date).ToList();


            List<Date> w = q.ToList();

            if (_worksheet == (int)Shift.Rozkar)
            {

                List<Date> qq = (from pp in db.HoliDays
                                 where pp.HolidayDate.CompareTo(dtnow) == 1
                                 select new Date { date = pp.HolidayDate, meal = 1 }).Distinct().ToList();
                if (!Login.RamezanDay)
                {
                    for (int i = 0; i < qq.Count; i++)
                    {
                        var ee = q.Where(p => p.date == qq.ElementAt(i).date).FirstOrDefault();
                        q.Remove(ee);

                    }
                }
                else
                {
                    for (int i = 0; i < qq.Count; i++)
                    {
                        var ee = q.Where(p => p.date == qq.ElementAt(i).date).FirstOrDefault();
                        q.Remove(ee);
                    }
                    string comper;
                    for (int ij = q.Count - 1; ij > -1; ij--)
                    {
                        comper = q.ElementAt(ij).date;
                        if (Login.tempSchedules.Where(p => p.SDate == comper).Any(pp => pp.Meal_Id_Fk == 4&pp.Restaurant_Id_Fk==_resturentid))
                            q.RemoveAt(ij);

                    }
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
                return ExtraMealAdded(w, ShiftFilter8(q, 4));
            }

            else if (_worksheet == (int)Shift.C8)
            {
                return ExtraMealAdded(w, ShiftFilter8(q, 8));
            }

            else if (_worksheet == (int)Shift.D8)
            {
                return ExtraMealAdded(w, ShiftFilter8(q, 12));
            }

            else if (_worksheet == (int)Shift.A12)
            {
                return ExtraMealAdded(w, ShiftFilter12(q, 8));
            }

            else if (_worksheet == (int)Shift.B12)
            {
                return ExtraMealAdded(w, ShiftFilter12(q, 4));
            }

            else if (_worksheet == (int)Shift.C12)
            {
                return ExtraMealAdded(w, ShiftFilter12(q, 0));
            }
            else
            {
                List<Date> qq = (from pp in db.HoliDays
                                 where pp.HolidayDate.CompareTo(dtnow) == 1
                                 select new Date { date = pp.HolidayDate, meal = 1 }).Distinct().ToList();

                if (!Login.RamezanDay)
                {
                    for (int i = 0; i < qq.Count; i++)
                    {
                        var ee = q.Where(p => p.date == qq.ElementAt(i).date).FirstOrDefault();
                        q.Remove(ee);

                    }
                }
                else
                {
                    for (int i = 0; i < qq.Count; i++)
                    {
                        var ee = q.Where(p => p.date == qq.ElementAt(i).date).FirstOrDefault();
                        q.Remove(ee);
                    }
                    string comper;
                    for (int ij = q.Count - 1; ij > -1; ij--)
                    {
                        comper = q.ElementAt(ij).date;
                        if (Login.tempSchedules.Where(p => p.SDate == comper).Any(pp => pp.Meal_Id_Fk == 4 & pp.Restaurant_Id_Fk == _resturentid))
                            q.RemoveAt(ij);

                    }
                }


                foreach (var item in q)
                {
                    item.day = item.date.ToPersianday();
                    item.meal = 1;
                }
                return ExtraMealAdded(w, q);
            }


        }

        private List<Date> ShiftFilter8(List<Date> d, int skip)
        {
            int x = 0;

            string datee = "1397/01/11".AddDaysToShamsiDate(skip);
            List<Date> qqq = new List<Date>();
            for (int i = 0; i < d.Count; i++)

            {
                x = d.ElementAt(i).date.DiffDaysShamsi(datee);
                x = x % 16;
                if (!Login.RamezanDay)
                {
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
                else
                {
            
                        if (Login.tempSchedules.Where(p => p.SDate == d.ElementAt(i).date).Any(pp=>pp.Meal_Id_Fk==4 & pp.Restaurant_Id_Fk == _resturentid))
                        {
                        if (x >= 4 & x < 8)
                        {
                            d.ElementAt(i).meal = 5;
                            qqq.Add(d.ElementAt(i));
                        }

                        if (x >= 8 & x < 12)
                        {
                            d.ElementAt(i).meal = 4;
                            qqq.Add(d.ElementAt(i));
                        }
                    }
                    else
                    {
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
                if (!Login.RamezanDay)
                {
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
                else
                {
                    if (Login.tempSchedules.Where(p => p.SDate == d.ElementAt(i).date).Any(pp => pp.Meal_Id_Fk == 4 & pp.Restaurant_Id_Fk == _resturentid))
                    {
                        if (x >= 4 & x < 8)
                        {
                            d.ElementAt(i).meal = 5;
                            qqq.Add(d.ElementAt(i));
                            qqq.Add(new Date { date = d.ElementAt(i).date.AddDaysToShamsiDate(1), meal = 4, day = d.ElementAt(i).date.AddDaysToShamsiDate(1).ToPersianday() });


                        }


                    }
                    else
                    {
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

                }


            }

            foreach (var item in qqq)
            {
                item.day = item.date.ToPersianday();
            }
            return qqq;
        }

        private List<Date> ExtraMealAdded(List<Date> Mainlist, List<Date> FilterList)
        {
            List<Date> extralist = new List<Date>();

            var r = from p in db.ExtraTimes
                    where p.EndDate.CompareTo(dtnow) == 1 & p.Person_Id_Fk == _person.Id
                    select p;

            foreach (var item in Mainlist)
            {
                foreach (var items in r)
                {

                    if (item.date.CompareTo(items.StartDate.AddDaysToShamsiDate(-1)) == 1 & item.date.CompareTo(items.EndDate.AddDaysToShamsiDate(1)) == -1)
                    {
                        if (items.Lunch.Value)
                            extralist.Add(new Date { date = item.date, meal = 1 });
                        if (items.Dinner.Value)
                            extralist.Add(new Date { date = item.date, meal = 2 });
                        if (items.Eftar.Value)
                            extralist.Add(new Date { date = item.date, meal = 5 });
                        if (items.ExtraMeal.Value)
                            extralist.Add(new Date { date = item.date, meal = 4 });

                    }

                }
            }

            foreach (var item in extralist)
            {
                item.day = item.date.ToPersianday();
            }
            string x = "";
            int xxt = 0;
            foreach (var item in extralist)
            {
                x = item.date;
                xxt = item.meal;
                var t = FilterList.Any(p => p.date == x & p.meal == xxt);
                if (t)
                {

                }
                else
                {
                    if(!Login.RamezanDay)
                    FilterList.Add(item);
                    else
                    {
                        if (Login.tempSchedules.Where(p => p.SDate ==item.date).Any(pp => (pp.Meal_Id_Fk == 4 || pp.Meal_Id_Fk == 5) & pp.Restaurant_Id_Fk == _resturentid))
                            if(item.meal==1||item.meal==2)
                            {

                            }
                        else
                            FilterList.Add(item);
                    }
                }
            }

            return FilterList.OrderBy(p => p.date).Take(25).ToList();

        }

        public List<PerMeal> GetPerMeal(int lenght)
        {
            Schedules = new List<Schedule>();
            List<Date> DatesAll = GetList();
          var  Dates=DatesAll.Take(lenght);
            foreach (var item in Dates)
            {
                PerMeal per = new PerMeal(item);
                Schedules.Clear();
                Schedules = (from p in tempSchedules
                             where p.SDate.Equals(item.date) & p.Restaurant_Id_Fk == _resturentid
                                                              & p.Meal_Id_Fk == item.meal
                             select p).ToList();


                per.Schedules.Add(Schedules.ElementAt(0));
                per.Schedules.Add(Schedules.ElementAt(1));
                per.Schedules.Add(Schedules.ElementAt(2));

                per.schedule1 = Schedules.ElementAt(0);
                per.schedule2 = Schedules.ElementAt(1);
                per.schedule3 = Schedules.ElementAt(2);

                Trays = (from qqq in TempTrays
                         where qqq.Id == per.schedule1.Tray_Id_Fk || qqq.Id == per.schedule2.Tray_Id_Fk || qqq.Id == per.schedule3.Tray_Id_Fk
                         select qqq).ToList();
                per.Trays.Add(Trays.ElementAt(0));
                per.Trays.Add(Trays.ElementAt(1));
                per.Trays.Add(Trays.ElementAt(2));

                per.Tray1 = Trays.ElementAt(0);
                per.Tray2 = Trays.ElementAt(1);
                per.Tray3 = Trays.ElementAt(2);

                MemoryStream mStream = new MemoryStream(Trays.ElementAt(0).Image);
                per.pictuer1 = Image.FromStream(mStream);

                MemoryStream mStreamm = new MemoryStream(Trays.ElementAt(1).Image);
                per.pictuer2 = Image.FromStream(mStreamm);

                MemoryStream mStreammm = new MemoryStream(Trays.ElementAt(2).Image);
                per.pictuer3 = Image.FromStream(mStreammm);

                per.Images.Add(Image.FromStream(mStream));
                per.Images.Add(Image.FromStream(mStreamm));
                per.Images.Add(Image.FromStream(mStreammm));

                PerMEAL.Add(per);


            }

            return PerMEAL;
        }
    }
}
