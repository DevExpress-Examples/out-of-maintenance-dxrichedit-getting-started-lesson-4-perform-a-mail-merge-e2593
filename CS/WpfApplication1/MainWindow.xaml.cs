using System;
using System.Windows;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace WpfApplication1 {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void richEditControl1_Loaded(object sender, RoutedEventArgs e) {
            List<Employee> dataSource = (List<Employee>)Employees.DataSource;
            richEditControl1.Options.MailMerge.DataSource = dataSource;
            richEditControl1.Options.MailMerge.ViewMergedData = true;
        }
    }

    public class Employee {
        public int EmployeeID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string TitleOfCourtesy { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public string Address { get; set; }
        public string HomePhone { get; set; }
    }

    [XmlRoot("Employees")]
    public class Employees : List<Employee> {
        public static object DataSource {
            get {
                XmlSerializer s = new XmlSerializer(typeof(Employees));
                return s.Deserialize(typeof(Employees).Assembly.
                    GetManifestResourceStream(typeof(Employees).Namespace + ".Data.Employees.xml"));
            }
        }
    }
}

