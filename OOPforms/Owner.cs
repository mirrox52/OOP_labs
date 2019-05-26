using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace OOPforms
{
    [Serializable]
    public class Owner : Company
    {
      
        
        public int budget { get; set; }

        public Owner(string name, int year, int budget, Manager manager) : base(name, year)
        {
            this.budget = budget;
            this.manager = manager;
        }

        public Manager manager { get; set; }

    }
}
