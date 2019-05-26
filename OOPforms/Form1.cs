
using OOPforms.plugin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
namespace OOPforms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           

        }

        public BindingList<Company> CompanyList = new BindingList<Company>();
        public BindingList<Owner> OwnerList = new BindingList<Owner>();
        public BindingList<Manager> ManagerList = new BindingList<Manager>();
        public BindingList<Engineer> EngineerList = new BindingList<Engineer>();

       private BindingList<Cleaner> CleanerList = new BindingList<Cleaner>();
        private void button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(CompanyYear.Text, out int n))
            {
                return;
            }
            Company company = new Company(CompanyName.Text, int.Parse(CompanyYear.Text));
            CompanyName.Clear();
            CompanyYear.Clear();
            CompanyList.Add(company);
            Companydata.DataSource = null;
            Companydata.DataSource = CompanyList;
        }
    
        private void Form1_Load(object sender, EventArgs e)
        {
           
              BinarySerializer.CreateInstance();
              JSONserialized.CreateJson();
            Companydata.DataSource = CompanyList;
            Ownerdata.DataSource = OwnerList;
            Managerdata.DataSource = ManagerList;
            Engineerdata.DataSource = EngineerList;
            Cleanerdata.DataSource = CleanerList;

            LoadPlugins();

        }

       public DataGridViewComboBoxColumn comboBoxColumn;
        private void button3_Click(object sender, EventArgs e)
        {
            if ((ManagerName.Text != "") && (ManagerYear.Text != "") && (ManagerSalary.Text != "") && (ManagerDayOfHolidays.Text != "") &&
                (ManagerDepartment.Text != "") && (ManagerExperience.Text != ""))
            {
                Manager obj = new Manager(ManagerName.Text, int.Parse(ManagerYear.Text), int.Parse(ManagerSalary.Text), int.Parse(ManagerDayOfHolidays.Text),
            ManagerDepartment.Text, int.Parse(ManagerExperience.Text));


                Owner owner = new Owner(OwnerName.Text, int.Parse(OwnerYear.Text), int.Parse(OwnerBudget.Text), obj);
                OwnerName.Clear();
                OwnerYear.Clear();
                OwnerBudget.Clear();
                ManagerName.Clear();
                ManagerYear.Clear();
                ManagerSalary.Clear();
                ManagerDayOfHolidays.Clear();
                ManagerExperience.Clear();
                ManagerDepartment.Clear();
                OwnerList.Add(owner);
                Ownerdata.DataSource = null;
                Ownerdata.DataSource = OwnerList;
            }
            else
                MessageBox.Show("Заполните поля manager ");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(ManagerExperience.Text, out int n))
            {
                return;
            }
            if (!int.TryParse(ManagerSalary.Text, out int t))
            {
                return;
            }
            if (!int.TryParse(ManagerDayOfHolidays.Text, out int l))
            {
                return;
            }
            Manager manager = new Manager(ManagerDepartment.Text, int.Parse(ManagerExperience.Text), int.Parse(ManagerSalary.Text), int.Parse(ManagerDayOfHolidays.Text),
             ManagerName.Text, int.Parse(ManagerYear.Text));

            ManagerName.Clear();
            ManagerYear.Clear();
            ManagerSalary.Clear();
            ManagerDayOfHolidays.Clear();
            ManagerExperience.Clear();
            ManagerDepartment.Clear();
            ManagerList.Add(manager);
            Managerdata.DataSource = null;
            Managerdata.DataSource = ManagerList;
        }
       
       
        private void button5_Click(object sender, EventArgs e)
        {

            Engineer engineer = new Engineer(EngineerEquipment.Text, int.Parse(EngineerSalary.Text), int.Parse(EngineerDayOfHolidays.Text), EngineerName.Text, int.Parse(EngineerYear.Text)
                );
 
          
            EngineerName.Clear();
            EngineerYear.Clear();
            EngineerSalary.Clear();
            EngineerDayOfHolidays.Clear();
          
            EngineerList.Add(engineer);

            Engineerdata.DataSource = null;
            Engineerdata.DataSource = EngineerList;

        }

     

        private void button2_Click(object sender, EventArgs e)
        {
           
            Cleaner cleaner = new Cleaner( int.Parse(CleanerSalary.Text), int.Parse(CleanerDayOfHolidays.Text), CleanerName.Text, int.Parse(CleanerYear.Text));
            CleanerName.Clear();
            CleanerYear.Clear();
            CleanerSalary.Clear();
            CleanerDayOfHolidays.Clear();
            CleanerList.Add(cleaner);
            Cleanerdata.DataSource = null;
            Cleanerdata.DataSource = CleanerList;
        }



        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cleanerdata.Visible = false;
            Companydata.Visible = false;
            Ownerdata.Visible = false;
            Managerdata.Visible = false;
            Engineerdata.Visible = false;
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    Companydata.Visible = true;
                    break;
                case 1:
                    Ownerdata.Visible = true;
                    break;
                case 2:
                    Managerdata.Visible = true;
                    break;
                case 3:
                    Engineerdata.Visible = true;
                    break;
                case 4:
                    Cleanerdata.Visible = true;
                    break;
                default:
                   
                    break;
            }

        }



        private void UpdateGrid()
        {
            Companydata.DataSource = CompanyList;
            Ownerdata.DataSource = OwnerList;
            Managerdata.DataSource = ManagerList;
            Engineerdata.DataSource = EngineerList;
            Cleanerdata.DataSource = CleanerList;
        }

        private void Удалить_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in Companydata.SelectedRows)
            {
                Companydata.Rows.Remove(row); 
            }
        }

        private void OwnerClick_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in Ownerdata.SelectedRows)
            {
                Ownerdata.Rows.Remove(row); 
            }
        }

        private void DeleteManager_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in Managerdata.SelectedRows)
            {
                Managerdata.Rows.Remove(row);
            }
        }

        private void DeleteEngineer_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in Engineerdata.SelectedRows)
            {
                Engineerdata.Rows.Remove(row);
            }
        }

        private void DeleteCleaner_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in Cleanerdata.SelectedRows)
            {
                Cleanerdata.Rows.Remove(row);
            }
        }

        private void Ownerdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          Manager  imya = (Manager)Ownerdata.Rows[Ownerdata.CurrentRow.Index].Cells[1].Value;
            string tmp ="Name:"+ imya.name + "Year:" + imya.year.ToString()+ "Salary:" + imya.salary.ToString() + "DayOfHolidays:" + imya.DayOfHolidays.ToString()+ "Experience:" + imya.Experience.ToString();

            MessageBox.Show(tmp);
        }

        private void BinarySerl()
        {

            BinarySerializer.Instance.Wcompany = CompanyList;
            BinarySerializer.Instance.Wowner = OwnerList;
            BinarySerializer.Instance.Wcleaner = CleanerList;
            BinarySerializer.Instance.Wmanager = ManagerList;
            BinarySerializer.Instance.Wengineer = EngineerList;
            BinarySerializer.SaveInstance("temp.bin");

        }

        private void BinaryDerl()
        {
            BinarySerializer.LoadInstance("temp.bin");
            CompanyList = BinarySerializer.Instance.Wcompany;
            OwnerList = BinarySerializer.Instance.Wowner;
            CleanerList = BinarySerializer.Instance.Wcleaner;
            ManagerList = BinarySerializer.Instance.Wmanager;
            EngineerList = BinarySerializer.Instance.Wengineer;
            UpdateGrid();
        }

        private void json()
        {
            JSONserialized.jsonFormatter.JCompany = CompanyList;
            JSONserialized.jsonFormatter.Jowner = OwnerList;
            JSONserialized.jsonFormatter.JCleaner = CleanerList;
            JSONserialized.jsonFormatter.JEngineer = EngineerList;
            JSONserialized.jsonFormatter.JManager = ManagerList;
            JSONserialized.Savejson("people.json");
        }

        private void Dejson()
        {
           
            JSONserialized.Loadjson("people.json");
            CompanyList = JSONserialized.jsonFormatter.JCompany;
            OwnerList = JSONserialized.jsonFormatter.Jowner;
            CleanerList = JSONserialized.jsonFormatter.JCleaner;
            EngineerList = JSONserialized.jsonFormatter.JEngineer;
            ManagerList = JSONserialized.jsonFormatter.JManager;
            UpdateGrid();
        }

        public  void textSerialezed()
        {
            TextSerialize.CreateText();
            TextSerialize.text.TCompany = CompanyList;
            TextSerialize.text.TEngineer = EngineerList;
           
            TextSerialize.text.TCleaner = CleanerList;
            TextSerialize.text.TManager = ManagerList;
            TextSerialize.SaveText();
            
        }

        private void textDeserialezed()
        {
            TextSerialize.CreateText();
            TextSerialize.LoadText();
            CompanyList = TextSerialize.text.TCompany;
            CleanerList = TextSerialize.text.TCleaner;
            EngineerList = TextSerialize.text.TEngineer;
            ManagerList = TextSerialize.text.TManager;
            
            UpdateGrid();
        }

        private void Serialize_Click(object sender, EventArgs e)
        {
            SelectS(comboBox1.Text, (sender as Button).Text);
        }
        private void Desirialize_Click(object sender, EventArgs e)
        {
            SelectS(comboBox1.Text, (sender as Button).Text);
        }
        public  void SelectS(string ext,string name)
        {
            if(name == "Serialize")
            {
                switch (ext)
                {
                    case "text":
                        {
                            textSerialezed();
                            break;
                        }
                    case "binary":
                        {
                            BinarySerl();
                            break;
                        }
                    case "json":
                        {
                            json();
                            break;
                        }
                }
            }
            else
            {
                switch (ext)
                {
                    case "text":
                        {
                            textDeserialezed();
                            break;
                        }
                    case "binary":
                        {
                            BinaryDerl();
                            break;
                        }
                    case "json":
                        {
                            Dejson();
                            break;
                        }
                }
            }
            

        }

        private readonly string pluginPath = "./";
        public static List<IArchive> plugins = new List<IArchive>();


        public void LoadPlugins()
        {
            
            //Load the DLLs from the Plugins directory
            if (Directory.Exists(pluginPath))
            {
                string[] files = Directory.GetFiles(pluginPath);
                foreach (string file in files)
                {
                    if (file.EndsWith(".dll"))
                    {
                        Assembly.LoadFile(Path.GetFullPath(file));
                    }
                }
            }

            Type interfaceType = typeof(IArchive);
            //Fetch all types that implement the interface IPlugin and are a class
            Type[] types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(p => interfaceType.IsAssignableFrom(p) && p.IsClass)
                .ToArray();
            foreach (Type type in types)
            {
                //Create a new instance of all found types
                plugins.Add((IArchive)Activator.CreateInstance(type));
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            SaveFileDialog dlg = new SaveFileDialog();
           
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;
            string ext1 = Path.GetExtension(openFileDialog1.FileName);
            if (plugins.Count == 0)
            {
                MessageBox.Show("No plugins");
                return;
            }
            string filter = string.Empty;
            foreach (IArchive alg in plugins)
            {
                filter += alg.Name + " archive (*" + alg.Format + ")|*" + alg.Format + "|";
            }
            dlg.Filter = filter.TrimEnd('|');
            if (dlg.ShowDialog() == DialogResult.Cancel)
                return;
            string newfilename = dlg.FileName;
           
            string ext = Path.GetExtension(dlg.FileName);
            
            IArchive archive = plugins.Find(x => x.Format == ext);
            archive.Compress(filename,filename+ext);
            File.Delete(filename);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (plugins.Count == 0)
            {
                MessageBox.Show("No plugins");
                return;
            }
            string filter = string.Empty;
           
            foreach (IArchive alg in plugins)
            {
                filter += "*" + alg.Format + ";";
            }
            filter = filter.TrimEnd(';');
            OpenFileDialog dlg = new OpenFileDialog();
           
            dlg.Filter = "Archives (" + filter + ")|" + filter;
            if (dlg.ShowDialog() == DialogResult.Cancel)
                return;
            string ext = Path.GetExtension(dlg.FileName);
            IArchive archive = plugins.Find(x => x.Format == ext);
            string newfilename = dlg.FileName.Replace(ext, "");


            archive.Decompress(dlg.FileName, newfilename);
            File.Delete(dlg.FileName);
        }
    }
    
}
