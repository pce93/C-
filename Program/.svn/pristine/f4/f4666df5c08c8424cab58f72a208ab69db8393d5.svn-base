using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment8
{
    class Program
    {
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        static void Main(string[] args)
        {
            Tree unOrdered = new Tree();
            Tree Ordered = new Tree();
            string[] booklist = new string[500];
            
            string bookname;
            for (int i = 0; i < 10000; i++)
            {
                bookname = RandomString(10);
                if (i < 500)
                {
                    booklist[i] = bookname;
                }
                Book a = new Book(bookname, "Oliver", "John", 1989);
                unOrdered.addBook(a);
                Ordered.orderedBook(a);
            }
            

            /*Stopwatch timer = Stopwatch.StartNew();

            // stuff you want to time
            for (int i = 0; i < 100000; i++)
            {
                if (i < 500)
                    Console.WriteLine(unOrdered.FindU(booklist[i]));
                else
                    Console.WriteLine(unOrdered.FindU(RandomString(10)));
                
                if (i < 500)
                    Console.WriteLine(Ordered.Find(booklist[i]));
                else
                    Console.WriteLine(Ordered.Find(RandomString(10)));
            }
            timer.Stop();
            TimeSpan timespan = timer.Elapsed;
            Console.WriteLine(timespan.TotalMilliseconds);*/


            // Test find on both the unordered tree and the ordered tree
            Console.WriteLine(unOrdered.FindU(booklist[4]));
            Console.WriteLine();
            Console.WriteLine(Ordered.Find(booklist[4]));
            Console.WriteLine();
            Console.WriteLine(unOrdered.FindU(RandomString(10)));
            Console.WriteLine();
            Console.WriteLine(Ordered.Find(RandomString(10)));
            Console.WriteLine();

            Console.Write("Press Enter to show the contents of the unordered tree. ");
            Console.ReadKey();
            unOrdered.display();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.Write("Press Enter to show the contents of the ordered tree. ");
            Console.ReadKey();
            Ordered.display();
            Console.WriteLine();

            // Unordered find takes about 320-420 milliseconds to complete a search of 500 saved books and 500 random books
            // Ordered find takes about 210-330 milliseconds to complete a search of 500 saved books and 500 random books

            // Scaling the search of the unordered tree to 10000 books scales the time to 2500~2600 milliseconds
            // Scaling the search of the unordered tree to 100000 books scales the time to 23000-24000 milliseconds
            // Scaling the search of the unordered tree to 100000 books scales the time to 220000-240000 milliseconds
        }
    }
    class Node
    {
        private Book data;
        private Node left;
        private Node right;
        public Book Data
        {
            get { return data; }
            set { data = value; }
        }
        public Node Left
        {
            get { return left; }
            set { left = value; }
        }
        public Node Right
        {
            get { return right; }
            set { right = value; }
        }
        public Node(Book d)
        {
            data = d;
            left = null;
            right = null;
        }
        public bool FindByTitleU(string bookname, Node r)
        {
            if (r.data.Title == bookname)
            {
                return true;
            }
            if (r.left != null)
            {
                return FindByTitleU(bookname, r.left);
            }
            if (r.right != null)
            {
                return FindByTitleU(bookname, r.right);
            }
            return false;

        }
        
        public bool FindByTitle(string bookname, Node r)
        {
            if (r == null)
                return false;
            if (r.data.Title == bookname)
                return true;
            else if (bookname.CompareTo(r.data.Title) < 0)
            {
                return FindByTitle(bookname, r.left);
            }
            else if (bookname.CompareTo(r.data.Title) > 0)
            {
                return FindByTitle(bookname, r.right);
            }
            return false;
        }

        public void addNode(ref Node node, Book book)
        {
            if (node == null)
            {
                node = new Node(book);

            }
            else
                addNode(ref node.left, book);
        }
        public void orderedNode(ref Node node, Book book)
        {
            if (node == null)
            {
                node = new Node(book);

            }

            if(book.Title.CompareTo(node.data.Title) < 0)
            {
                orderedNode(ref node.left, book);
            }
            else if (book.Title.CompareTo(node.data.Title) > 0)
            {
                orderedNode(ref node.right, book);
            }

        }
        public void display(Node n)
        {
            if (n == null)
                return;

            display(n.left);
            Console.WriteLine(n.data.Title);
            display(n.right);
        }
    }
    class Book
    {
        public Book(string t, string l, string f, int y)
        {
            title = t;
            lastName = l;
            firstName = f;
            year = y;
        }
        private string title;
        private string lastName;
        private string firstName;
        private int year;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

    }

    class Tree
    {
        public Node root;
        public Tree()
        {
            root = null;
        }
        public bool isEmpty()
        {
            return root == null;
        }
        public string FindU(string s)
        {
            if (root.FindByTitleU(s, root) == true)
                return s;
            else
                return "Not found";
        }
        public string Find (string s)
        {
            if (root.FindByTitle(s, root) == true)
                return s;
            else
                return "Not found";
        }
        public void addBook(Book y)
        {
            if (isEmpty())
            {
                root = new Node(y);
            }
            else
            {
                root.addNode(ref root, y);
            }


        }
        public void orderedBook(Book y)
        {
            if (isEmpty())
            {
                root = new Node(y);
            }
            else
            {
                root.orderedNode(ref root, y);
            }


        }
        public void display()
        {
            if (!isEmpty())
                root.display(root);
        }
    }



}