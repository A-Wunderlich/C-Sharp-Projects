using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] intarr = {1,2,3,4,5,6,7,8 };
            var sum1 = 0;
            //add up all odd numbers in an intiger array
            foreach (int i in intarr)
            {
                if (i % 2 != 0)
                {
                    sum1 += i;
                }

            }
            Console.WriteLine(sum1);
            //sum an array of large intagers
            int[] lgarr = { 115619, 2214561, 365191622, 465198159, 465198159, 6156161, 7651961, 8616516 };
            long sum2 = 0;
            foreach (int i in lgarr)
            {
                sum2 += i;
            }
            Console.WriteLine(sum2);
            Console.WriteLine("Enter a string: ");
            string newString = Console.ReadLine();
            var revString = Reverse(newString);
            Console.WriteLine(revString);
            Console.WriteLine("Enter a string: ");
            string repString = Console.ReadLine();
            var noRepString = RemoveRepeats(repString);
            Console.WriteLine(noRepString);
            Console.ReadLine();
            //FizzBuzz
            for (int i = 1; i <= 100; i++){
                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if (i % 3 == 0)
                {
                    Console.WriteLine("Fizz");
                }
                else if (i % 5 == 0)
                {
                    Console.WriteLine("Buzz");
                }
                else { Console.WriteLine(i); }
            }
            Console.ReadLine();
        }
        //method for reversing strings
        public static string Reverse (string n)
        {
            char[] chararr = n.ToCharArray();
            Array.Reverse(chararr);
            return new string(chararr);
        }

        //method for removing reapeats in a string
        public static string RemoveRepeats(string s)
        {
            char[] inputArr = s.ToCharArray();
            char[] outputArr = s.Distinct().ToArray();
            StringBuilder builder = new StringBuilder();
            foreach(char c in outputArr)
            {
                builder.Append(c);
            }
            var output = builder.ToString();
            return output;
        }
    }
}
