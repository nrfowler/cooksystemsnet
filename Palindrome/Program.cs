using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Is {0} palindrome? {1}", "noon", isPalindrome("noon"));
            Console.WriteLine("Is {0} palindrome? {1}", "dusk", isPalindrome("dusk"));
            Console.WriteLine("Is {0} palindrome? {1}", "deleveled", isPalindrome("deleveled"));
            Console.WriteLine("Is {0} palindrome? {1}", "racecar", isPalindrome("racecar"));
            Console.WriteLine("Is {0} palindrome? {1}", "bobby", isPalindrome("bobby"));
            Console.ReadKey();
        }
    static bool isPalindrome(string pal)
    {
            return (pal.ToLower().ToCharArray().Reverse().SequenceEqual(pal.ToLower().ToCharArray()));

    }
    }
}
