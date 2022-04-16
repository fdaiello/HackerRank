using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank_InterviewPreparation
{
    class Program
    {
        public static int migratoryBirds(List<int> arr)
        {
            var map = new Dictionary<int, int>();
            for ( int i =0; i<arr.Count; i++)
            {
                if ( map.ContainsKey(arr[i]))
                {
                    map[arr[i]]++;
                }
                else
                {
                    map.Add(arr[i], 1);
                }
            }

            return map.OrderByDescending(p => p.Value).ThenBy(p=>p.Key).FirstOrDefault().Key;

        }
        public static int divisibleSumPairs(int n, int k, List<int> ar)
        {
            int pairCount = 0;

            for ( int i =0; i < ar.Count; i++)
            {
                for ( int j=i+1; j<ar.Count; j++)
                {
                    if ((ar[i] + ar[j]) % k == 0)
                        pairCount++;
                }
            }

            return pairCount;
        }

        static void Main(string[] args)
        {
            TestSelectionSort();
        }
        /*
         * https://www.hackerrank.com/challenges/minimum-swaps-2/problem
         */

        /*
         *  Correct solution, but too slow.
         */
        static int minimumSwaps(int[] arr)
        {
            int swapcount = 0;
            int tmp;

            for ( int i=0; i<arr.Length; i++)
            {
                if (arr[i] != i+1)
                {
                    for ( int j=i+1; j<arr.Length; j++)
                    {
                        if ( arr[j]==i+1 )
                        {
                            // Swap arr[i] - arr[j]
                            swapcount++;
                            tmp = arr[j];
                            arr[j] = arr[i];
                            arr[i] = tmp;

                        }
                    }
                }
            }

            return swapcount;
        }
        public static void TestMinimumSwaps()
        {

            var arr = new int[4] { 4, 3, 1, 2 };
            Console.WriteLine(minimumSwaps(arr));
            Console.WriteLine("Expected: 3");

            arr = new int[7] { 7, 1, 3, 2, 4, 5, 6 };
            Console.WriteLine(minimumSwaps(arr));
            Console.WriteLine("Expected: 5");

            arr = new int[5] { 2, 3, 4, 1, 5 };
            Console.WriteLine(minimumSwaps(arr));
            Console.WriteLine("Expected: 3");

            arr = new int[7] { 1, 3, 5, 2, 4, 6, 7};
            Console.WriteLine(minimumSwaps(arr));
            Console.WriteLine("Expected: 3");
        }
        /*
         *  Selection Sort
         */
        public static int[] SelectionSort( int[] arr)
        {

            // start index
            var startIndex = 0;

            // loop for all starting positions
            while ( startIndex < arr.Length)
            {
                int minValue = int.MaxValue;
                int minPosition = 0;

                // Traverse array from start position
                for ( int i=startIndex; i< arr.Length; i++)
                {
                    // Look for the minimum value
                    if (arr[i] < minValue)
                    {
                        minValue = arr[i];
                        minPosition = i;
                    }
                }

                // Check if found a value lower than the on at start index
                if ( minValue < arr[startIndex])
                {
                    // Swap
                    int tmp = arr[startIndex];
                    arr[startIndex] = minValue;
                    arr[minPosition] = tmp;
                }
                startIndex++;
            }

            return arr;
        }
        public static void TestSelectionSort()
        {
            var arr = new int[4] { 4, 3, 1, 2 };
            Console.WriteLine(String.Join(",",SelectionSort(arr)));

            arr = new int[7] { 7, 1, 3, 2, 4, 5, 6 };
            Console.WriteLine(String.Join(",", SelectionSort(arr)));

            arr = new int[5] { 2, 3, 4, 1, 5 };
            Console.WriteLine(String.Join(",", SelectionSort(arr)));

            arr = new int[7] { 1, 3, 5, 2, 4, 6, 7 };
            Console.WriteLine(String.Join(",", SelectionSort(arr)));
        }

        public static long repeatedString(string s, long n)
        {
            long countA = 0;
            int countRestA = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'a')
                    countA++;
            }
            for (int i = 0; i < n % s.Length; i++)
            {
                if (s[i] == 'a')
                    countRestA++;
            }

            return countA * (n / s.Length ) + countRestA;
        }
        public static void TestRepeatedString()
        {
            string s = "epsxyyflvrrrxzvnoenvpegvuonodjoxfwdmcvwctmekpsnamchznsoxaklzjgrqruyzavshfbmuhdwwmpbkwcuomqhiyvuztwvq";
            long n = 549382313570;
            Console.WriteLine(repeatedString(s, n));
            Console.WriteLine("Expected: 16481469408");

            s = "ojowrdcpavatfacuunxycyrmpbkvaxyrsgquwehhurnicgicmrpmgegftjszgvsgqavcrvdtsxlkxjpqtlnkjuyraknwxmnthfpt";
            n = 685118368975;
            Console.WriteLine(repeatedString(s, n));
            Console.WriteLine("Expected: 41107102139");
        }
    }
}
