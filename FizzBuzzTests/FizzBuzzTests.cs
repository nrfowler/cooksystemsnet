using Microsoft.VisualStudio.TestTools.UnitTesting;
using FizzBuzz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FizzBuzz2;

namespace FizzBuzz.Tests
{
    [TestClass()]
    public class FizzBuzzTests
    {
        [TestMethod()]
        public void FizzBuzzTest()
        {
            FizzBuzz fizz = new FizzBuzz(1,20);
            Assert.IsTrue(fizz.startNumber == 1 && fizz.endNumber == 20);

        }



        [TestMethod()]
        public void SetRangeTest()
        {
            FizzBuzz fizz = new FizzBuzz();
            fizz.SetRange(1, 20);
      
            Assert.IsTrue(fizz.startNumber == 1 && fizz.endNumber == 20);

        }

        [TestMethod()]
        public void GetOutputTest()
        {
            FizzBuzz fizz = new FizzBuzz();
            fizz.SetRange(1, 20);
            Assert.AreEqual("1 2 fizz 4 buzz fizz 7 8 fizz buzz 11 fizz "+
                "13 14 fizzbuzz 16 17 fizz 19 buzz", fizz.GetOutput());

        }

        [TestMethod()]
        public void GetLuckyOutputTest()
        {
            FizzBuzzTwo fizz = new FizzBuzzTwo();
            fizz.SetRange(1, 20);
            Assert.AreEqual("1 2 lucky 4 buzz fizz 7 8 fizz buzz 11" +
                " fizz lucky 14 fizzbuzz 16 17 fizz 19 buzz", fizz.GetOutput());

        }
        [TestMethod()]
        public void GetReportTest()
        {
            FizzBuzzTwo fizz = new FizzBuzzTwo();
            fizz.SetRange(1, 20);
            //Assert.AreEqual("lucky = 2\n", fizz.GetReport());

        }
    }
}