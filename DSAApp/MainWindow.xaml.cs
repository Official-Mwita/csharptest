using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;

namespace DSAApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        SqlConnection con;
        D_LinkedList StudentList;
        public MainWindow()
        {
            InitializeComponent();

            //Create database connection project
            con = new SqlConnection("Data Source=ADMIN;Initial Catalog=jose;Integrated Security=True;");

            //Initialize our linked list
            StudentList = new D_LinkedList();

            //Fetch data on initialization
            fetchData();

        }

        private void rbutton_Click(object sender, RoutedEventArgs e)
        {
           D_LinkedList.TraverseRight(StudentList);

            //if(StudentList)
            if(StudentList.Next != null)
            {
                 leftlabel.Content = StudentList.Next.Data.Name;
                 gradeLeft.Content = StudentList.Next.Data.Grade;

            }
            if(StudentList.Prev != null)
            {
                 rightabel.Content =StudentList.Prev.Data.Name;
                 gradeRight.Content = StudentList.Prev.Data.Grade;
            }
           
        }

        private void lbutton_Click(object sender, RoutedEventArgs e)
        {
            D_LinkedList.TraverseLeft(StudentList);

            //if(StudentList)
            if(StudentList.Next != null)
            {
                 leftlabel.Content = StudentList.Next.Data.Name;
                 gradeLeft.Content = StudentList.Next.Data.Grade;

            }
            if(StudentList.Prev != null)
            {
                 rightabel.Content =StudentList.Prev.Data.Name;
                 gradeRight.Content = StudentList.Prev.Data.Grade;
            }
   

        }
        private void fetchData()
        {
            con.Open();

            SqlCommand command = new SqlCommand("SELECT * FROM Student", con);

            SqlDataReader reader = command.ExecuteReader();

             while (reader.Read())
            {
                Student data = new Student(reader.GetString(0),  reader.GetString(1));
                D_LinkedList.InsertNode(StudentList, data);
            }

        }
    }
}
