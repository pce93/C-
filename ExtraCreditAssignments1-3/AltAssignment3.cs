using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltAssignment3
{
    class AltAssignment3
    {
        static void Main()
        {
            Stack stk = new Stack(1);
            String input;
            double total = 0;
            Console.WriteLine("Welcome to best calculator ever! Please input an arthmetic operation and a number followed by a ' ', press 'u' to undo, and type 'exit' to quit.");
            Console.WriteLine(total);
            while (true)
            {
                input = Console.ReadLine();
                if (input == "Exit" || input == "exit")
                {
                    break;
                }
                if (input == "u")
                {
                    total = stk.Pop();
                    Console.WriteLine(total);
                    continue;
                }
                if (!input.Contains(" "))
                {
                    Console.WriteLine("Whoops, you forgot to put a space between the number and operation!");
                    continue;
                }
                Char delimiter = ' ';
                String[] substrings = input.Split(delimiter);
                String operation = substrings[0];
                double number = Convert.ToDouble(substrings[1]);
                switch (operation)
                {
                    case "+":
                        stk.Push(total);
                        total = total + number;
                        break;
                    case "-":
                        stk.Push(total);
                        total = total - number;
                        break;
                    case "/":
                        stk.Push(total);
                        total = total / number;
                        break;
                    case "*":
                        stk.Push(total);
                        total = total * number;
                        break;


                }

                Console.WriteLine(total);
            }

        }

        class Stack
        {
            private double[] stack;
            private int count;
            private int size;
            public Stack(int n)
            {
                stack = new double[n];
                count = 0;
                size = n;
            }

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
                if (count == size)
                {
                    Resize();
                }
                stack[count] = element;
                count++;
            }

            public double Pop()
            {
                if (count == 0)
                {
                    return 0;
                }
                double n = stack[count - 1];
                stack[count - 1] = 0;
                count--;
                return n;
            }

            private void Resize()
            {
                Array.Resize(ref stack, size * 2);
                size = size * 2;
            }
        }
    }
}