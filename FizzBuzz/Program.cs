using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            FizzBuzzTwo fb = new FizzBuzzTwo(1,20);
            Console.WriteLine(fb.GetReport());
            Console.ReadKey();
        }
    }
    public class FizzBuzzTwo : FizzBuzz
    {
        public FizzBuzzTwo(int startNumber, int endNumber)
        {
            this.startNumber = startNumber;
            this.endNumber = endNumber;
        }
        public override string GetString(int number)
        {
            if (number.ToString().Contains("3"))
                return "lucky";
            else if (number % 15 == 0)
                return "fizzbuzz";
            else if (number % 5 == 0)
                return "buzz";
            else if (number % 3 == 0)
                return "fizz";
            else
                return number.ToString();
        }
        public string GetReport()
        {
            string output = "lucky = ";
            string fizzbuzz = GetOutput();
            output += Regex.Matches(fizzbuzz, "lucky").Count.ToString()+"\n";
            output+="fizz = "+ Regex.Matches(fizzbuzz, @"\sfizz$|^fizz\s|\sfizz\s").Count.ToString() + "\n";
            output += "buzz = " + Regex.Matches(fizzbuzz, @"\sbuzz$|^buzz\s|\sbuzz\s").Count.ToString() + "\n";
            output += "fizzbuzz = " + Regex.Matches(fizzbuzz, "fizzbuzz").Count.ToString() + "\n";
            output += "integer = " + Regex.Matches(fizzbuzz, @"\d+").Count.ToString();
            return output;
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
        public  string GetOutput() {
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
        public virtual string GetString(int number)
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
