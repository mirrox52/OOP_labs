using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPforms
{
    [Serializable]
    public class Employee:Company
    {
        public int salary { get; set; }
        

        public Employee(string name, int year, int salary, int DayOfHolidays) : base(name, year)
        {
            this.salary = salary;
            this.DayOfHolidays = DayOfHolidays;
        }

        public int DayOfHolidays { get; set; }

        public virtual string Info()
        {
           return $"Name : {name}, year: {year}, salary:  {salary}";
        }
    }
}
