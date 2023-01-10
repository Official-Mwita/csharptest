
namespace DSAApp
{
    public class D_LinkedList
    {

    }

    public class Node
    {
        Node next, prev;
        Student data;

        public Node(Student _Student)
        {
            data = _Student;

        }

        public Student Data
        {
            get { return data; }
        }

        public Node Next
        {
            get { return next; }
            set { next = value; }
        }

        public Node Prev
        {
            get { return prev; }
            set { prev = value; }
        }

    }

    public class Student
    {

        string name;
        string grade;

        public Student(string _name, string _grade)
        {
            name = _name;
            grade = _grade;
        }

        public string Name
        {
            get { return name; }
        }

        public string Grade
        {
            get { return grade; }
        }

    }
}
