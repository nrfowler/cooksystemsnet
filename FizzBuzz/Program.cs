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

    class FizzBuzz
    {
        int startNumber;
        int endNumber;
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
            return "1";
        }
    }
}
