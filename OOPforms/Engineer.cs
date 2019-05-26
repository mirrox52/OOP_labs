using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPforms
{
    [Serializable]
    public class Engineer: Employee
    {
       
        public string equipment { get; set; }

        public Engineer(string equip, int salary, int DayOfHolidays, string name, int year ) : base(name, year, salary, DayOfHolidays)
        {
            this.equipment = equip;
        }


        public override string Info()
        {
         return $"{name}, {year}, {salary}, {DayOfHolidays}";
        }
    }
}
