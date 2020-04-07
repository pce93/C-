using System;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
             //Problem 1: Take two numbers as input from the user
             //Multiply them and display their product.
             string x;
             string y;
             int ans;
             Console.WriteLine("Input two numbers to multiply them: ");
             x = Console.ReadLine();
             y = Console.ReadLine();
             ans = Convert.ToInt32(x) * Convert.ToInt32(y);
             Console.WriteLine(ans);

             //Problem 2: Take five numbers as input from the user. 
             //Calculate and display the average. 
             //Make sure the displayed average is a float, so that the numbers to the right of the decimal aren't cut off.
             string a, b, c, d, e;
             double ans2;
             Console.WriteLine("Input five numbers to determine the average: ");
             a = Console.ReadLine();
             b = Console.ReadLine();
             c = Console.ReadLine();
             d = Console.ReadLine();
             e = Console.ReadLine();
             ans2 = Convert.ToInt32(a) + Convert.ToInt32(b) + Convert.ToInt32(c) + Convert.ToInt32(d) + Convert.ToInt32(e);
             ans2 = ans2 / 5.0;
             Console.WriteLine(ans2);



             //Problem 3: Take two numbers as input from the user
             //If the two numbers are equal, display "Equal".
             //If the two numbers are not equal, display "Not Equal".
             string x2;
             string y2;
             Console.WriteLine("Input two numbers to check whether they are equal or not: ");
             x2 = Console.ReadLine();
             y2 = Console.ReadLine();
             if (Convert.ToInt32(x2) == Convert.ToInt32(y2))
             {
                 Console.WriteLine("Equal");
             }
             else
             {
                 Console.WriteLine("Not Equal");
             }

             //Problem 4: Take two numbers as input from the user.
             //If both numbers are even, display "Even".
             //If both numbers are odd, display "Odd".
             //If one is even and one is odd, display "Even/Odd".
             string x3;
             string y3;
             Console.WriteLine("Input two numbers to check whether they are even or odd: ");
             x3 = Console.ReadLine();
             y3 = Console.ReadLine();
             if (Convert.ToInt32(x3) % 2 == 0 && Convert.ToInt32(y3) % 2 == 0)
             {
                 Console.WriteLine("Even");
             }
             else if (Convert.ToInt32(x3) % 2 != 0 && Convert.ToInt32(y3) % 2 != 0)
             {
                 Console.WriteLine("Odd");
             }
             else
             {
                 Console.WriteLine("Even/Odd");
             }
             //Problem 5: Take 3 numbers as user input.
             //Display the largest number.
             string x4;
             string y4;
             string z;
             Console.WriteLine("Input three numbers to check which one is the largest: ");
             x4 = Console.ReadLine();
             y4 = Console.ReadLine();
             z = Console.ReadLine();
             if (Convert.ToInt32(x4) >= Convert.ToInt32(y4) && Convert.ToInt32(x4) >= Convert.ToInt32(z))
             {
                 Console.WriteLine(Convert.ToInt32(x4));
             }
             else if (Convert.ToInt32(y4) >= Convert.ToInt32(x4) && Convert.ToInt32(y4) >= Convert.ToInt32(z))
             {
                 Console.WriteLine(Convert.ToInt32(y4));
             }
             else
                 Console.WriteLine(Convert.ToInt32(z));

            Console.WriteLine();

            //Problem 6: Using a loop, take 10 numbers as input from the user.
            //Display their sum.
            Console.Write("6.   ");
             int sum = 0;
             for(int i = 0; i < 10; i++)
             {
                 sum = sum + Convert.ToInt32(Console.ReadLine());
             }
             Console.WriteLine(sum);
             Console.WriteLine();

            //Problem 7: Take a number N as input from the user.
            //Using a loop, display the first N counting numbers.
            //e.g. Input: 8
            //Display: 1 2 3 4 5 6 7 8
            Console.Write("7.   ");
             int n = 0;
             n = Convert.ToInt32(Console.ReadLine());
             for (int i = 1; i <= n; i++)
             {
                 Console.Write(i);
                 Console.Write(" ");
            }
            Console.WriteLine();
            Console.WriteLine();

            //Problem 8: Take a number N as input from the user.
            //Using loops, display N rows. The first row should have 1, the second row should have 1 2, third row should have 1 2 3, ... etc.
            //e.g. Input: 4
            //Display: 1
            //         1 2
            //         1 2 3
            //         1 2 3 4
            //Note: This can be done using two nested for loops.
            Console.Write("8.   ");
            int N = 0;
            N = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            for (int i = 1; i <= N; i++)
            {
            
                for (int j = 1; j<= i; j++)
                {
                    Console.Write(j);
                }
                Console.Write("\n");
            }
            Console.WriteLine();

            
            //Problem 9: Write a loop structure which takes a string as user input inside the loop.
            //When the user enters "quit", exit the loop.
            //Note: A while loop is a good candidate for this problem.
            Console.Write("9.   ");
            String word = "start"; 
            while(word != "quit")
            {
                word = Console.ReadLine();
            }
            Console.WriteLine();
            //Problem 10: Create an array of 10 integers (not user input; hardcode the values for now).
            //Display the sum of the elements.
            Console.Write("10.   ");
            int sum1 = 0;
            int[] array = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            for(int i = 0; i < 10; i++)
            {
                sum1 = sum1 + array[i];
            }
            Console.WriteLine(sum1);
            Console.WriteLine();
            
            //Problem 11: Take 5 integers as user input and store them in an array.
            //Dislay their average. Note: Make sure the average is displayed as a float.
            Console.Write("11.   ");
            int[] array1 = new int[5];
            float avg = 0; 
            for (int i = 0; i < 5; i++)
            {
                array1[i] = Convert.ToInt32(Console.ReadLine());
                avg = avg + array1[i];
            }
            avg = avg / 5;
            Console.WriteLine(avg);
            
            //Problem 12: Take 5 integers as user input and store them in an array.
            //Display the smallest number in the array.
            //Display the largest number in the array.
            Console.Write("12.   ");
            int[] array2 = new int[5];
            for (int i = 0; i < 5; i++)
            {
                array2[i] = Convert.ToInt32(Console.ReadLine());
            }
            int small = array2[0];
            int large = array2[4];

            for (int i = 0; i < 5; i++)

            {
                if (array2[i] < small)
                {
                    small = array2[i];

                }
            }

            for (int i = 0; i < 5; i++)
            {

                if (array2[i] > large)
                {
                    large = array2[i];

                }
            }
            Console.WriteLine(small);
            Console.WriteLine(large);
            Console.WriteLine();
            
        }
    }
}