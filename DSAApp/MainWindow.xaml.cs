
using System.Windows;
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

            //User interface reset
            rbutton.IsEnabled   = false;
            lbutton.IsEnabled   = false;
            gradeLabelLeft.Visibility = Visibility.Hidden;
            gradeLabelRight.Visibility = Visibility.Hidden;


            //Fetch data on initialization
            fetchData();

        }

        private void rbutton_Click(object sender, RoutedEventArgs e)
        {
           Node _Node = D_LinkedList.TraverseRight(StudentList);

            if(_Node.Next != null)
            {
                //Right labels holds next while left labels holds current
                rightabel.Content = _Node.Next.Data.Name;
                gradeRight.Content = _Node.Next.Data.Grade;

                leftlabel.Content = _Node.Data.Name;
                gradeLeft.Content = _Node.Data.Grade;

                //Enable previous if disabled but can traverse
                if (!lbutton.IsEnabled && _Node.Prev != null)
                    lbutton.IsEnabled = true;

            }
            else
            {
                rbutton.IsEnabled = false;

                //Enable left button if disable but prev has value enable it
                if(_Node.Prev != null)
                    lbutton.IsEnabled = true;
            }
           
        }

        private void lbutton_Click(object sender, RoutedEventArgs e)
        {
            Node _Node = D_LinkedList.TraverseLeft(StudentList);

            if (_Node.Prev != null)
            {
                //Left labels holds prev while right labels holds current
                leftlabel.Content = _Node.Prev.Data.Name;
                gradeLeft.Content = _Node.Prev.Data.Grade;

                rightabel.Content = _Node.Data.Name;
                gradeRight.Content = _Node.Data.Grade;

                //Enable right if disabled but can traverse
                if (!rbutton.IsEnabled && _Node.Next != null)
                    rbutton.IsEnabled = true;

            }
            else
            {
                //left buttons will always display first node values when at the head node
                //i.e no previous node
                leftlabel.Content = StudentList.Head.Data.Name;
                gradeLeft.Content = StudentList.Head.Data.Grade;

                lbutton.IsEnabled = false;

                //Enable left button if disable but prev has value enable it
                if (_Node.Next != null)
                {
                    rightabel.Content = _Node.Next.Data.Name;
                    gradeRight.Content = _Node.Next.Data.Grade;
                    rbutton.IsEnabled = true;

                }
                    
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

            //Make initialize screen initilization
            if (StudentList.Size > 0)
            {
                gradeLabelLeft.Visibility = Visibility.Visible;
                gradeLabelRight.Visibility = Visibility.Visible;

                //Make first list traversal
                D_LinkedList.TraverseRight(StudentList);
            }

            
           if(StudentList.Size == 1)
            {

                leftlabel.Content = StudentList.Current.Data.Name;
                gradeLeft.Content = StudentList.Current.Data.Grade;
                rightabel.Content = StudentList.Current.Data.Name;
                gradeRight.Content = StudentList.Current.Data.Grade;

            }else if (StudentList.Size > 1)
            {
                leftlabel.Content = StudentList.Current.Data.Name;
                gradeLeft.Content = StudentList.Current.Data.Grade;

                //D_LinkedList.TraverseRight(StudentList);
                rightabel.Content = StudentList.Current.Next.Data.Name;
                gradeRight.Content = StudentList.Current.Next.Data.Grade;

            }

           //Enable traversal buttons if size is 3 or more
            if (StudentList.Size > 2)
            {
                //Can be traversed enable traversal buttons
                rbutton.IsEnabled = true;
                //lbutton.IsEnabled = true;

            }


        }
    }
}
