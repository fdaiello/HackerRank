using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace HackerRank
{
    public class Result
    {

        public static int[] month = new int[15];

        /*
         * Complete the 'plusMinus' function below.
         *
         * The function accepts INTEGER_ARRAY arr as parameter.
         * 
         *  Output the ration of elements that are positive, negative and zero
         */

        public static void plusMinus(List<int> arr)
        {
            // Counters
            int cPositive = 0;
            int cNegative = 0;
            int cZero = 0;

            // Loop thru array and count 
            for (int x = 0; x < arr.Count; x++)
            {
                // Check and increase counter
                if (arr[x] > 0)
                {
                    cPositive++;
                }
                else if (arr[x] < 0)
                {
                    cNegative++;
                }
                else
                {
                    cZero++;
                }
            }

            // OutPut results
            Console.WriteLine(((float)cPositive / arr.Count).ToString("N6"));
            Console.WriteLine(((float)cNegative / arr.Count).ToString("N6"));
            Console.WriteLine(((float)cZero / arr.Count).ToString("N6"));

        }

        /*
         * Complete the 'miniMaxSum' function below.
         *
         * The function accepts INTEGER_ARRAY arr as parameter.
         */

        public static void miniMaxSum(List<int> arr)
        {

            arr.Sort();
            // we need to convert at least on of the summing numbers, so the result will be a long (int64) too
            long min = (long)arr[0] + arr[1] + arr[2] + arr[3];

            arr.Reverse();
            long max = (long)arr[0] + arr[1] + arr[2] + arr[3];

            //OutPut
            Console.WriteLine($"{min} {max}");
        }
        /*
         * Complete the 'timeConversion' function below.
         *
         * The function is expected to return a STRING.
         * The function accepts STRING s as parameter.
         */

        public static string timeConversion(string s)
        {
            var cultureInfo = new CultureInfo("en-US");
            var dateTime = DateTime.Parse(s, cultureInfo);
            return dateTime.ToString("HH:mm:ss");
        }

        /*
         * Complete the 'matchingStrings' function below.
         *
         * The function is expected to return an INTEGER_ARRAY.
         * The function accepts following parameters:
         *  1. STRING_ARRAY strings
         *  2. STRING_ARRAY queries
         */

        public static List<int> matchingStrings(List<string> strings, List<string> queries)
        {
            List<int> result = new List<int>();

            foreach (string query in queries)
            {
                result.Add(strings.Where(p => p == query).Count());
            }

            return result;
        }
        /*
         * Complete the 'lonelyinteger' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts INTEGER_ARRAY a as parameter.
         */

        public static int lonelyinteger(List<int> a)
        {
            // Loop within list
            foreach (int element in a)
            {
                if (a.Where(p => p == element).Count() == 1)
                {
                    return element;
                }
            }

            return 0;
        }
        /*
         * Complete the 'flippingBits' function below.
         *
         * The function is expected to return a LONG_INTEGER.
         * The function accepts LONG_INTEGER n as parameter.
         */

        public static long flippingBits(long n)
        {
            // cast input to unsigned int
            uint x = (uint)n;

            // flip bits
            x = ~x;

            // cast to long again and return
            return x;
        }

        /*
         * Complete the 'diagonalDifference' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts 2D_INTEGER_ARRAY arr as parameter.
         */

        public static int diagonalDifference(List<List<int>> arr)
        {
            long leftDiagSum = 0;
            long rightDiagSum = 0;
            int row;

            // Calculate left diagonal sum
            row = 0;
            for (int col = 0; col < arr.Count; col++)
            {
                leftDiagSum += arr[row][col];
                row++;
            }

            // Calculate right diagonal sum
            row = 0;
            for (int col = arr.Count - 1; col >= 0; col--)
            {
                rightDiagSum += arr[row][col];
                row++;
            }

            // Return absoloute value of difference
            return (int)Math.Abs(leftDiagSum - rightDiagSum);
        }

        /*
         * Complete the 'pangrams' function below.
         *
         * The function is expected to return a STRING.
         * The function accepts STRING s as parameter.
         */
        public static string pangrams(string s)
        {

            s = s.ToUpper();

            int[] letters = new int[26];

            foreach (char c in s)
            {
                if (c >= 65 && c <= 90)
                {
                    letters[c - 65]++;
                }
            }

            if (letters.ToList().Where(p => p == 0).Any())
            {
                return "not pangram";
            }
            else
            {
                return "pangram";
            }
        }

        /*
         * Complete the 'twoArrays' function below.
         *
         * The function is expected to return a STRING.
         * The function accepts following parameters:
         *  1. INTEGER k
         *  2. INTEGER_ARRAY A
         *  3. INTEGER_ARRAY B
         */

        public static string twoArrays(int k, List<int> A, List<int> B)
        {

            List<List<int>> Ap = Permutations(A);

            foreach (List<int> list in Ap)
            {
                Console.WriteLine(String.Join(",", list));
            }

            return string.Empty;

        }
        public static List<List<int>> Permutations(List<int> list)
        {
            List<List<int>> list2 = new List<List<int>>();
            int start = 0;
            int end = list.Count - 1;

            PermutationsRecursive(list, start, end, list2);

            return list2;
        }
        public static void PermutationsRecursive(List<int> list, int start, int end, List<List<int>> list2)
        {
            if (start == end)
            {
                list2.Add(list);
            }
            else
            {
                for (int x = start; x <= end; x++)
                {
                    Swap1(list, start, end);
                    PermutationsRecursive(list, start + 1, end, list2);
                    Swap1(list, start, end);
                }
            }
        }
        public static void Swap1(List<int> list, int p1, int p2)
        {
            int tmp = list[p1];
            list[p1] = list[p2];
            list[p2] = tmp;
        }

        /*
         * Complete the 'pageCount' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts following parameters:
         *  1. INTEGER n - number of pages
         *  2. INTEGER p - page to go
         *  
         *  Return minimum number of pages to flip to go to page p, from begining or end
         */

        public static int pageCount(int n, int p)
        {
            int ret;

            // convert to even numbers
            n = n / 2 * 2;
            p = p / 2 * 2;

            // Decide start from beginning or end
            if (p <= n / 2)
            {
                // Start from beginning
                ret = p / 2;
            }
            else
            {
                // Start from end
                ret = (n - p) / 2;
            }

            return ret;

        }

        /*
         * Complete the 'towerBreakers' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts following parameters:
         *  1. INTEGER n
         *  2. INTEGER m
         *  
         *  n = number of Towers
         *  m = Tower height
         */

        public static int towerBreakers(int n, int m)
        {

            // if Tower height is less then 2, player one has no move to make
            if (m < 2)
                return 2;
            else
            {
                // If there are even number of Towers, player 2 allways copy move and winds
                // If there are odd numbers of Towers, player 1 allways win;
                if (n % 2 == 0)
                    // Even towers - 2 wins
                    return 2;
                else
                    // Odd towers - 1 wins
                    return 1;
            }
        }
        /*
         * Complete the 'caesarCipher' function below.
         *
         * The function is expected to return a STRING.
         * The function accepts following parameters:
         *  1. STRING s
         *  2. INTEGER k
         *  
         *  Rotate each char in s by k letters
         *  
         */

        public static string caesarCipher(string s, int k)
        {
            StringBuilder output = new StringBuilder();
            foreach (char c in s)
                output.Append(CipherThis(c, k));

            return output.ToString();

        }
        /*
         * Only Cipher Letters
         */
        private static char CipherThis(char c, int k)
        {
            // In case k > 26 lets get rest of divistion by 26
            k %= 26;

            // If k = 0 do nothing
            if (k > 0)
            {
                // Check if its upper case
                if (c >= 65 && c <= 90)
                {
                    int c1 = c;
                    c1 += k;
                    if (c1 > 90)
                        c1 = c1 - 90 + 64;
                    c = (char)c1;
                }

                // Check if its lower case
                else if (c >= 97 && c <= 122)
                {
                    int c1 = c;
                    c1 += k;
                    if (c1 > 122)
                        c1 = c1 - 122 + 96;
                    c = (char)c1;

                }

            }

            return c;
        }

        /*
         * Complete the 'maxMin' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts following parameters:
         *  1. INTEGER k
         *  2. INTEGER_ARRAY arr
         *  
         *  Returns: int: the minimum possible unfairness of subarray with k elements
         *  
         *  Unfairness of an array is calculated as: max(arr) - min(arr)
         *  
         */

        public static int maxMin(int k, List<int> arr)
        {
            // store min unFairness
            int mUf = int.MaxValue;

            // lets start sorting the list
            arr.Sort();

            // How many segments of k elements can we have within the list ?
            int s = arr.Count - k + 1;

            // now lets check all possible segments of k lengh
            for (int x = 0; x < s; x++)
            {

                // calc segment unFairness
                int f1 = arr[x + k - 1] - arr[x];

                // lets check if its less than current min value of unFairness stored
                if (f1 < mUf)
                    mUf = f1;
            }

            // return
            return mUf;
        }

        /*
         * Complete the 'dynamicArray' function below.
         *
         * The function is expected to return an INTEGER_ARRAY.
         * The function accepts following parameters:
         *  1. INTEGER n
         *  2. 2D_INTEGER_ARRAY queries
         */

        public static List<int> dynamicArray(int n, List<List<int>> queries)
        {
            // Last Answer
            int lastAnswer = 0;

            // Intermediate calculus
            int x;
            int y;
            int idx;

            // Dynamic array - array of lists
            List<int>[] arr = new List<int>[n];
            for (int z = 0; z < n; z++)
            {
                arr[z] = new List<int>();
            }

            // Result
            List<int> result = new List<int>();

            // For each line in queries
            foreach (List<int> row in queries)
            {
                // Check what query type is this ( 1 or 2 )
                if (row[0] == 1)
                {
                    // Query 1 x y
                    x = row[1];
                    y = row[2];
                    idx = (x ^ lastAnswer) % n;

                    // Append idx to arr[idx]
                    arr[idx].Add(y);

                }
                else if (row[0] == 2)
                {
                    // Query 2 x y
                    x = row[1];
                    y = row[2];
                    idx = (x ^ lastAnswer) % n;

                    lastAnswer = arr[idx][y % arr[idx].Count];
                    result.Add(lastAnswer);
                }
            }

            return result;

        }

        /*
         * Complete the 'gridChallenge' function below.
         *
         * The function is expected to return a STRING.
         * The function accepts STRING_ARRAY grid as parameter.
         * 
         *     sort each row alphabetically
         *     return yes if the firs column ( first letter of each string ) is also sorted, else return no
         */

        public static string gridChallenge(List<string> grid)
        {
            // Store row sorted grid
            List<List<char>> rowSortedGrid = new List<List<char>>();

            // For each row in grid
            foreach (string s in grid)
            {
                // Add sorted chars to rowSortedGrid
                rowSortedGrid.Add(s.ToCharArray().OrderBy(p => p).ToList());
            }

            // Now check if colums are sorted
            for (int row = 1; row < grid.Count; row++)
            {
                // For each column
                for (int col = 0; col < rowSortedGrid[0].Count; col++)
                {
                    // Compare with previus char - of same column, upper row
                    if (rowSortedGrid[row][col] < rowSortedGrid[row - 1][col])
                    {
                        return "NO";
                    }
                }
            }

            return "YES";

        }

        public static void updateLeapYear(int year)
        {
            if (year % 400 == 0)
            {
                month[2] = 29;
            }
            else if (year % 100 == 0)
            {
                month[2] = 29;
            }
            else if (year % 4 == 0 && year % 100 == 0)
            {
                month[2] = 29;
            }
            else
            {
                month[2] = 28;
            }
        }

        public static void storeMonth()
        {
            month[1] = 31;
            month[2] = 28;
            month[3] = 31;
            month[4] = 30;
            month[5] = 31;
            month[6] = 30;
            month[7] = 31;
            month[8] = 31;
            month[9] = 30;
            month[10] = 31;
            month[11] = 30;
            month[12] = 31;
        }

        public static int findPrimeDates(int d1, int m1, int y1, int d2, int m2, int y2)
        {
            storeMonth();

            int result = 0;

            while (true)
            {
                int x = d1;
                x = x * 100 + m1;
                x = x * 10000 + y1;
                if (x % 4 == 0 || x % 7 == 0)
                {
                    result = result + 1;
                }
                if (d1 == d2 && m1 == m2 && y1 == y2)
                {
                    break;
                }
                updateLeapYear(y1);

                d1 = d1 + 1;
                if (d1 > month[m1])
                {
                    m1 = m1 + 1;
                    d1 = 1;
                    if (m1 > 12)
                    {
                        y1 = y1 + 1;
                        m1 = m1 + 1;
                    }
                }
            }
            return result;
        }

        /*
         * Complete the 'balancedSums' function below.
         *
         * The function is expected to return a STRING.
         * The function accepts INTEGER_ARRAY arr as parameter.
         * 
         *  arr - an array of integer
         *  return: "YES" if is there an element that divides the array in two subarrays ( without the element ) that sums the same
         */

        public static string balancedSums(List<int> arr)
        {

            if (arr.Count < 2)
                return "YES";

            int before = 0;
            int after = arr.Sum() - arr[0];

            // Loop the array til las but one element
            for (int x = 0; x < arr.Count - 1; x++)
            {
                if (before == after)
                    return "YES";

                before += arr[x];
                after -= arr[x + 1];

            }

            return "NO";

        }

        public static int superDigit(string n, int k)
        {

            if (n.Length == 1)
                return Convert.ToInt32(n);
            else
            {
                long nSum = 0;
                for (int x = 0; x < n.Length; x++)
                {
                    nSum += Convert.ToInt32(n.Substring(x, 1));
                }
                return superDigit((nSum * k).ToString(), 1);
            }

        }

        public static long sumXor(long n)
        {
            if (n == 0)
                return 1;
            else
            {
                string s = Convert.ToString(n, 2);
                char[] chars = s.ToCharArray();
                int bits = chars.Where(p => p == '0').Count();
                return (long)Math.Pow(2, bits);
            }

        }

        public static List<int> climbingLeaderboard1(List<int> ranked, List<int> player)
        {
            // Store results
            List<int> results = new List<int>();

            SortedDictionary<int, string> map = new SortedDictionary<int, string>();
            int lastValue = 0;

            for ( int x =0; x< ranked.Count; x++)
            {
                if (ranked[x] != lastValue)
                {
                    map.Add(ranked[x], "rank");
                    lastValue = ranked[x];
                }
            }

            for ( int x =0; x < player.Count; x++)
            {
                if (map.ContainsKey(player[x]))
                {
                    map[player[x]] = "player";
                }
                else
                {
                    map.Add(player[x], "player");
                }
            }

            int index = map.Count;
            foreach ( KeyValuePair<int,string> kp in map)
            {
                if ( kp.Value == "player")
                    results.Add(index);
                index--;
            }

            return results;

        }
        public static List<int> climbingLeaderboard(List<int> ranked, List<int> player)
        {
            // Store results
            List<int> results = new List<int>();

            // position in rank
            int pr = 1;

            // index in ranked array;
            int ir = 0;

            // loop player scores
            for ( int x = player.Count-1; x >=0; x--)
            {
                // gets current player score
                int ps = player[x];

                // lets look in witch position current player value fits
                while ( ir < ranked.Count && ps < ranked[ir] )
                {
                    ir++;
                    // Ranked list may contain duplicate values - in this case they represent same rank position
                    // Lets check if current value is lower than past value
                    if ( ir < ranked.Count && ranked[ir] < ranked[ir - 1] )
                    {
                        // Increase position in rak
                        pr++;
                    }
                }

                // Check if current position is after current rank
                if (ir >= ranked.Count)
                {
                    // This player score value is in pr position in rank. Save it.
                    results.Add(pr+1);
                }
                else
                {
                    // This player score value is in pr position in rank. Save it.
                    results.Add(pr);
                }
            }

            results.Reverse();

            return results;
        }
        /*
		 * Complete the 'twoArrays' function below.
		 *
		 * The function is expected to return a STRING.
		 * The function accepts following parameters:
		 *  1. INTEGER k
		 *  2. INTEGER_ARRAY A
		 *  3. INTEGER_ARRAY B
		 */
        public static string twoArrays0(int k, List<int> A, List<int> B)
        {
            A.Sort();
            B.Sort();
            B.Reverse();

            for (int x = 0; x < A.Count; x++)
            {
                if (A[x] + B[x] < k)
                {
                    return "NO";
                }
            }

            return "YES";

        }

        public static string twoArrays_OkbutNotOk(int k, List<int> A, List<int> B)
        {
            // Matrix ( List of Lists ) with all possibile permutes of list A
            List<List<int>> pA = new();
            int start = 0;
            int end = A.Count - 1;
            Permute(A, start, end, pA);

            // B permutes matrix
            List<List<int>> pB = new();
            start = 0;
            end = B.Count - 1;
            Permute(B, start, end, pB);

            // Check all matches, for each line o pA, for each line of pB
            foreach (List<int> pAline in pA)
            {
                foreach (List<int> pBline in pB)
                {
                    // In this loop we are deling with each possible permite of A and B, now we have to loop each member
                    bool check = true;
                    for (int x = 0; x < pBline.Count; x++)
                    {
                        // Check if sum of elements < k - fails
                        if (pBline[x] + pAline[x] < k)
                        {
                            check = false;
                            break;
                        }
                    }
                    // If we have a valid result ( all elemets passed validation )
                    if (check)
                    {
                        return "YES";
                    }
                }
            }

            // In case we got here, no valid combination was found
            return "NO";

        }

        static void Permute(List<int> inputList, int start, int end, List<List<int>> permutes)
        {

            if (start == end)
            {
                permutes.Add(new List<int>(inputList));
            }
            else
            {
                for (int i = start; i <= end; i++)
                {
                    Swap(inputList, start, i);
                    Permute(inputList, start + 1, end, permutes);
                    Swap(inputList, start, i);
                }
            }
        }
        static void Swap(List<int> inputList, int p1, int p2)
        {
            int tmp = inputList[p1];
            inputList[p1] = inputList[p2];
            inputList[p2] = tmp;
        }

        /*
		 *  s - array of integer where to look for segments
		 *  d - sum of values of segment - criteria to check segment
		 *  m - lengh of segment
		 *  
		 *  return - number of segments found within array that matches the criteria: lengh m and elements sum d
		 */
        public static int birthday(List<int> s, int d, int m)
        {
            // Counter - segments that matches the criteria
            int c = 0;

            // Difference between array leng and segment - points all possible starts for segment search
            int y = s.Count - m;
            for (int x = 0; x <= y; x++)
            {
                // Check segment starting at position x - sum segment values
                int sum = 0;
                for (int z = x; z < m + x; z++)
                {
                    sum += s[z];
                }
                if (sum == d)
                {
                    c++;
                }
            }

            // return segments that matches criteria counter
            return c;
        }

        /*
		 * Check if integer is power of 2
		 */
        internal static bool IsPowerOfTwo(long x)
        {
            return x > 0 && ((x & (x - 1)) == 0);
        }
        /*
		 * Reduce int number by the next lower number which is a power of 
		 */
        internal static long ReduceNumber(long n)
        {
            if (n > 1)
            {
                string s = Convert.ToString(n, 2);
                string s1 = s.Substring(1);
                return Convert.ToInt64(s1, 2);
            }
            else return 1;
        }

    }
}
