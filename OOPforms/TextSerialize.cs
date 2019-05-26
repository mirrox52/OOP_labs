using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace OOPforms
{
   public class TextSerialize : IEnumerable
    {
        public static TextSerialize text;
        public BindingList<Company> TCompany { get; set; }
        public BindingList<Engineer> TEngineer { get; set; }
    
        public BindingList<Manager> TManager { get; set; }
        public BindingList<Cleaner> TCleaner { get; set; }

        public List<Object> list;
   
        public static void CreateText()
        {
            text = new TextSerialize();
    

        }

        public static void SaveText()
        {
           List<Object> list = new List<Object>();
            List<String> arrayInfo = new List<string>();
            foreach(Object member in text.TCompany)
            {
                list.Add(member);
            }
            foreach (Object member in text.TEngineer)
            {
                list.Add(member);
            }
            foreach (Object member in text.TManager)
            {
                list.Add(member);
            }
             foreach (Object member in text.TCleaner)
            {
                list.Add(member);
            }
         

                String str = "["; 
                foreach (Object member in list)
                {
                PropertyInfo[] myPropertyInfo = member.GetType().GetProperties();
                str += "\r\n" + member.GetType().ToString();
                str += "{";
                foreach (var prop in myPropertyInfo)
                {
                    str +=" "+ prop.Name + "=" + prop.GetValue(member);
                }

                   
                    str += " }";
                }
                str += "]";
                arrayInfo.Add(str);
                

            using (FileStream stream = new FileStream("textser.txt", FileMode.Create))
            {
                int size;

                foreach (string s in arrayInfo)
                {
                    size = s.Length;
                    byte[] infoArray = new byte[size];
                    infoArray = System.Text.Encoding.UTF8.GetBytes(s);
                    stream.Write(infoArray, 0, infoArray.Length);
                }
            }
        }


        public static void LoadText()
        {
            using (StreamReader sr = new StreamReader("textser.txt", System.Text.Encoding.UTF8))
            {
                List<Object> list = new List<Object>();
               
                Type[] argTypes = new Type[] { };
               
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line == "[")
                        continue;
                    
                    List<Object> args = new List<Object>();
                    List<Type> tType = new List<Type>();
                    string[] words = line.Split(new char[] { '{' });
                    string[] words1 = words[1].Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries);
                    foreach(var temp in words1)
                    {
                        if (temp.Contains("}"))
                            continue;
                        string myType = temp.Substring(temp.IndexOf("=") + 1);
                        
                        if (int.TryParse(myType, out int n)){
                            args.Add(n);
                        }
                        else
                        {
                            args.Add(myType);
                        }

                    }
                    Type myType1 = Type.GetType(words[0]);
                    PropertyInfo[] myPropertyInfo = myType1.GetProperties();
                   
                    for (int i = 0; i < myPropertyInfo.Length; i++){
                        tType.Add(Type.GetType(myPropertyInfo[i].PropertyType.FullName));
                    }
                    argTypes = tType.ToArray();
                  
                    ConstructorInfo ctor = myType1.GetConstructor(argTypes);
                    object obj = ctor.Invoke(args.ToArray());
                    list.Add(obj);

                }
                text.TCompany = new BindingList<Company>();
                text.TCleaner = new BindingList<Cleaner>();
                text.TEngineer = new BindingList<Engineer>();
                text.TManager = new BindingList<Manager>();
                foreach (var obj in list)
                {
                    
                   string type = obj.GetType().ToString();
                    switch (type){
                        case "OOPforms.Company":
                            {
                                text.TCompany.Add((Company)obj);
                                break;
                            }
                        case "OOPforms.Engineer":
                            {
                                text.TEngineer.Add((Engineer)obj);
                                break;
                            }
                        case "OOPforms.Cleaner":
                            {
                                text.TCleaner.Add((Cleaner)obj);
                                break;
                            }
                        case "OOPforms.Manager":
                            {
                                text.TManager.Add((Manager)obj);
                                break;
                            }
                    }
                }

            }
           
        }

        public IEnumerator GetEnumerator()
        {
            return list.GetEnumerator();

        }

    }
    
}

