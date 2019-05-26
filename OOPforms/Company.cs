
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace OOPforms
{
    [Serializable]
    public class Company
    {
       
        public string name { get; set; }
    
        public int year { get; set; }

        public Company(string name,int year)
        {
            this.year = year;
            this.name = name;
        }

    }
}
