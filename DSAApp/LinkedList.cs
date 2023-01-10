
namespace DSAApp
{
    public class D_LinkedList
    {
        Node head; //the first node of the list
        Node current; //The pointer to the current node. Used for traversal
        int size;

        public D_LinkedList()
        {
            head = null;
            current = head;
            size = 0;
        }

        public int Size
        {
            get { return size; }
        }

        public Node Head
        {
            get { return head; }
            set { head = value; }
        }

        public Node Current
        {
            get { return current; }
            set { current = value; }
        }

        public static void InsertNode(D_LinkedList list, Student data)
        {
            //Create the new node
            Node _Node = new Node(data);

            //Check if head is set. Otherwise set this to head
            if(list.Head == null)
            {
                list.Head = _Node;
            }
            else //Get last node then instert it properly
            {
                Node last = GetLast(list);
                last.Next = _Node;
                _Node.Prev = last;

            }


        }

        public static Node TraverseRight(D_LinkedList list)
        {
            if(list.Current == null)//First traversal. Set current to head then return it
            {
                list.Current = list.Head;
                return list.Current;
            }else if(list.Current != null)//Move next
            {
                list.Current = list.Current.Next;
                return list.Current;

            }

            //Always return null as default
            return null;
        }

        public static Node TraverseLeft(D_LinkedList list)
        {
            //Check if current is not null and also not head
            if(list.Current != null && list.Current != list.Head)
            {
                list.Current = list.Current.Prev;
                return list.Current;
            }

            //Always return null as default
            return null;
        }

        public static Node GetLast(D_LinkedList list)
        {
            Node _Node = list.head;

            while (_Node.Next != null)
            {
                _Node = _Node.Next;

            }

            return _Node;

        }

        public static void InsertFirst(D_LinkedList list, Student data)
        {
            Node temp = list.Head; //Temporary store our head node

            Node _Node = new Node(data); //We create a new node to instert first

            // Now set the next of this list to point to old head
            _Node.Next = temp;

            //Set the old head temp to hold this new node
            temp.Prev = _Node;

            //Set the head of the list point to this newly created node
            list.Head = _Node;


        }


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
