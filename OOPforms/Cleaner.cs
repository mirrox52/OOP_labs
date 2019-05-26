using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPforms
{
    [Serializable]
    public class Cleaner : Employee
    {
      //  public bool NightShift { get; set; }


        public Cleaner( int salary, int DayOfHolidays, string name, int year) : base(name, year, salary, DayOfHolidays)
        {
          //  NightShift = IsNightShift;
        }



        //public override string Info()
        //{
        //    //return $"{(NightShift ? "Cleaner is working in nightshift" : "Cleaner is at dayshift")}";
        //}
    }
}
