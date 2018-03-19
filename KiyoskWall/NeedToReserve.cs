using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public NeedToReserve()
        {
            
        }
    }
}
