using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltAssignment2
{
    class Program
    {
        static void Main()
        {
            Queue q = new Queue();

            // empty case
            Debug.Assert(q.Size() == 0);
            Debug.Assert(q.Empty() == true);

            // add some items
            q.Push(13.5);
            q.Push(-7);

            // test!
            Debug.Assert(q.Size() == 2);
            Debug.Assert(q.Empty() == false);

            double check = q.Pop();
            Debug.Assert(q.Size() == 1);
            Debug.Assert(check == 13.5);

            q.Push(124.83);

            check = q.Pop();
            Debug.Assert(q.Size() == 1);
            Debug.Assert(check == -7);

            check = q.Pop();
            Debug.Assert(q.Size() == 0);
            Debug.Assert(check == 124.83);

            Console.WriteLine("Got it!");
        }

        public class Node
        {      
            public Node next;
            public double data;
            public Node(double val)
            {
                data = val;
                next = null;
            }
        }
        class Queue
        {                    
            private int count = 0;
            private Node head;
            
            public bool Empty()
            {
                if (count == 0)
                {
                    return true;
                }
                else
                    return false;
            }

            public int Size()
            {
                return count;
            }

            public void Push(double element)
            {          
                if (count == 0)
                {
                    Node newHead = new Node(element);                   
                    head = newHead;
                    count++;
                }
                else
                {
                    Node toAdd = new Node(element);                    
                    Node current = head;
                    while (current.next != null)
                    {
                        current = current.next;
                    }
                    current.next = toAdd;
                    count++;
                }
                
            }

            public double Pop()
            {
                if (count == 0)
                    return 0;
                Node cur = head;
                head = cur.next;
                count--;
                return cur.data;
            }
            
        }
        }

    }


        
    
