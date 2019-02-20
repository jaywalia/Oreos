using System;
using System.Collections.Generic;
using System.Linq;

namespace Oreos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Cookie monster looking for Oreos!");
            int found = 0;
            for (int i = 1; i < 1000000; i++)
            {
                if (i % 11 == 0)
                {
                    // if( IsPalindrome(i.ToString()))
                    // {
                    //      Console.WriteLine($"{i} <<<<<<<<<<<<<<<<<<<<<<<< Found Palindrome!!!");
                    // }
                    // if( i > 10000 && i < 99999 && IsXYYYX(i) )
                    // {
                    //     Console.WriteLine($"{i} <<<<<<<<<<<<<<<<<<<<<<<< Found isXYYYX!!!");
                    // }
                    if( IsOreo(i.ToString()))
                    {
                        Console.WriteLine($"{i} <<<<<<<<<<<<<<<<<<<<<<<< Found Oreo. Yummy!!!");
                        found++;
                    }
                }
            }
            Console.WriteLine($"Found {found} oreos!!!");
        }

        static bool IsXYYYX(int i)
        {
            bool isXYYYX = false;
            Stack<int> s = new Stack<int>();
            // break into digits
            int n = i;
            while (n > 0)
            {
                int d = GetOnesDigit(n);
                // save the digit
                //Console.WriteLine($"{n}, {d}");
                s.Push(d);

                // cycle for next digit
                n /= 10;
            }

            // pop out digits
            if (s.Count == 5)
            {
                int tt = s.Pop();
                int th = s.Pop();
                int hu = s.Pop();
                int te = s.Pop();
                int o = s.Pop();

                if (o == tt && te == th && te == hu)
                {
                    isXYYYX = true;
                }
            }
            return isXYYYX;
        }

        static int GetOnesDigit(int n)
        {
            return n % 10;
        }

        static bool IsPalindrome(string s)
        {
            return s.SequenceEqual(s.Reverse());
        }

        // xyx, xyyx, xyyyx, and so on
        static bool IsOreo(string s)
        {
            bool isOreo = false;
            
            char[] oreo = s.ToCharArray();
            
            // check cookies
            char leftCookie = oreo[0]; // cookie on left
            char rightCookie = oreo[oreo.Length -1]; // cookie on right
            bool sameCookies = leftCookie == rightCookie;

            // check filling
            bool smoothFilling = false;
            char[] filling = oreo.Skip(1).Take(oreo.Length - 2).ToArray();
            // every layer of filling needs to be same as first layer of filling
            smoothFilling = filling.Count() > 0  // filling exists
                            && filling[0] != leftCookie // filling is not made of cookies
                            && filling[0] != rightCookie // this check is redundant
                            && filling.All(f => f == filling[0]); // filling is consistent

            isOreo = sameCookies && smoothFilling;

            return isOreo ;
        }
    }
}
