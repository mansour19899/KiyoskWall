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
        public ListDate(int WorkSheet)
        {
            
            _worksheet = WorkSheet;
            
        }

        public List<Date> GetList()
        {
            var db = new PoonehEntities();
            string dtnow = "1396/11/05";
           List<Date> q = (from p in db.Schedules
                where p.SDate.CompareTo(dtnow) == 1
                select new Date {date = p.SDate}).Distinct().ToList();

            List<Date> qq = (from pp in db.HoliDays
                where pp.HolidayDate.CompareTo(dtnow) == 1
                select new Date {date = pp.HolidayDate}).Distinct().ToList();

            for (int i = 0; i < qq.Count; i++)
            {
                var ee = q.Where(p => p.date == qq.ElementAt(i).date).Single();
                 q.Remove(ee);
            }

            foreach (var item in q)
            {
                item.day = item.date.ToPersianday();
            }
            



            return q;

        }
    }
}
