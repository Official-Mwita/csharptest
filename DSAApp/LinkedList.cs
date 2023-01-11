
using System.Runtime.Remoting.Messaging;

namespace DSAApp
{
    public class D_LinkedList
    {
        Node head; //the first node of the list
        Node next; //The pointer to the current node. Used for traversal
        Node prev; //Pointer to the prev node
        int size;

        public D_LinkedList()
        {
            head = null;
            next = head;
            prev = head;
            size = 0;
        }

        public int Size
        {
            get { return size; }
            set { size = value; }
        }

        public Node Head
        {
            get { return head; }
            set { head = value; }
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

            //After every addition increment
            list.Size = list.Size + 1;


        }

        public static Node TraverseRight(D_LinkedList list)
        {

            if(list.prev == list.next  && list.head != null)//Start of traversal
            {
                list.next = list.head.Next;
                list.prev = list.head;

            }
            else
            {
                if(list.next.Next != null)
                {
                    list.prev = list.next;
                    list.next = list.next.Next;

                }
                    
            }

            return list.next;
        }

        public static Node TraverseLeft(D_LinkedList list)
        {
            //First initilization
            if(list.next == list.prev && list.head != null)
            {
                list.next = list.head;
                //list.prev = list.head;
            }else
            {  
                if(list.next != list.head && list.next != null)
                {
                    list.next = list.prev;
                    list.prev = list.next.Prev;
                }
               
                
            }

            return list.prev;
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

             //After every addition increment
            list.Size = list.Size + 1;

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
