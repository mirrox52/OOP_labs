using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace OOPforms
{
    [DataContract]
    class JSONserialized { 

        [DataMember]
        public BindingList<Company> JCompany { get; set; }
        [DataMember]
        public BindingList<Owner> Jowner { get; set; }
        [DataMember]
        public BindingList<Manager> JManager { get; set; }
        [DataMember]
        public BindingList<Cleaner> JCleaner { get; set; }
        [DataMember]
        public BindingList<Engineer> JEngineer { get; set; }
        public static JSONserialized jsonFormatter { get; set; }
        public static void CreateJson()
        {
           jsonFormatter = new JSONserialized();
        }

        public static void Savejson(string fileName)
        {
            using (var f = File.OpenWrite(fileName))
                new DataContractJsonSerializer(typeof(JSONserialized)).WriteObject(f, jsonFormatter);
        }

        public static void Loadjson(string fileName)
        {
            using (var st = File.OpenRead(fileName))
                jsonFormatter = (JSONserialized)new DataContractJsonSerializer(typeof(JSONserialized)).ReadObject(st);
        }


    }
}
