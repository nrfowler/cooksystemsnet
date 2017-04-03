using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            FizzBuzz fb = new FizzBuzz(0,1);
            Console.WriteLine(fb.GetOutput());
            Console.ReadKey();
        }
    }

    public class FizzBuzz
    {
        public int startNumber;
        public int endNumber;
        public FizzBuzz()
        {

        }
        public FizzBuzz(int startNumber, int endNumber)
        {
            this.startNumber = startNumber;
            this.endNumber = endNumber;
        }
        public void SetRange(int startNumber, int endNumber) {
            this.startNumber = startNumber;
            this.endNumber = endNumber;
        }
        public string GetOutput() {
            string output = GetString(this.startNumber);
            if (this.startNumber >= this.endNumber)
                return output;
            for(int i = this.startNumber+1; i <= this.endNumber; i++)
            {
                output += " " + GetString(i);
            }
            Console.WriteLine(output);

            return output;
        }
        public string GetString(int number)
        {
            if (number % 15 == 0)
                return "fizzbuzz";
            else if (number % 5 == 0)
                return "buzz";
            else if (number % 3 == 0)
                return "fizz";
            else
                return number.ToString();
        }
    }
}
