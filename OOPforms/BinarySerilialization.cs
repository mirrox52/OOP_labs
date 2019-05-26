using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace OOPforms
{
    [Serializable]
    public class BinarySerializer
    {
        
            public BindingList<Company> Wcompany { get; set; }
            public BindingList<Owner> Wowner { get; set; }
            public BindingList<Cleaner> Wcleaner { get; set; }
            public BindingList<Manager> Wmanager{ get; set; }
            public BindingList<Engineer> Wengineer { get; set; }
        


        //
        public static BinarySerializer Instance { get; private set; }
           
            public static void CreateInstance()
            {
                Instance = new BinarySerializer();
            }

            public static void LoadInstance(string fileName)
            {
                using (var st = File.OpenRead(fileName))
                    Instance = (BinarySerializer)new BinaryFormatter().Deserialize(st);
            }

            public static void SaveInstance(string fileName)
            {
                using (var f = File.OpenWrite(fileName))
                    new BinaryFormatter().Serialize(f, Instance);
            }
        
    }
    
            
}

