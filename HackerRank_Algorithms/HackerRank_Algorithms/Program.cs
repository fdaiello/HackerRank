using System;
using System.Linq;

namespace HackerRank_Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            TestSuperReducedString();
        }
        #region SuperReducedString
        public static void TestSuperReducedString()
        {
            Console.WriteLine(SuperReducedString("baab"));
            Console.WriteLine("Expected: -empty string-");
        }
        public static string SuperReducedString(string s)
        {
            var cList = s.ToCharArray().ToList();

            int p;
            bool removed;

            do
            {
                removed = false;
                p = 0;
                while (p < cList.Count - 1)
                {
                    if (cList[p] == cList[p + 1])
                    {
                        cList.RemoveAt(p);
                        cList.RemoveAt(p);
                        removed = true;
                    }
                    else
                        p++;
                }
            } while (removed);

            if (cList.Count > 0)
                return new String(cList.ToArray());
            else
                return "Empty String";
        }
        #endregion
    }
}
