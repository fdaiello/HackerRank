using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank_ProblemSolvingBasic_Test
{
    public class Result
    {
        public static int mostBalancedPartition(List<int> parent, List<int> files_size)
        {
            int minDiff = int.MaxValue;
            long totalSum = files_size.Sum();

            long[] subTreeSum = new long[parent.Count];

            Dfs(parent, files_size, 0, totalSum, ref minDiff, ref subTreeSum);

            return minDiff;

        }
        public static void Dfs(List<int> parent, List<int> files_Size, int node, long totalSum, ref int minDiff, ref long[] subTreeSum)
        {

            subTreeSum[node] = files_Size[node];

            var children = new List<int>();
            for ( int i=0; i<parent.Count; i++)
            {
                if (parent[i] == node)
                    children.Add(i);
            }

            foreach ( var child in children)
            {
                Dfs(parent, files_Size, child, totalSum, ref minDiff, ref subTreeSum);
                subTreeSum[node] += subTreeSum[child];
            }

            minDiff = (int)Math.Min(minDiff, Math.Abs(totalSum-2*subTreeSum[node]));


        }
        public static void TestMinimumBalance()
        {
            var parent = new List<int>() { -1, 0, 0, 1, 1, 2 };
            var filesSize = new List<int>() { 1, 2, 2, 1, 1, 1 };
            Console.WriteLine(mostBalancedPartition(parent, filesSize));
            Console.WriteLine("Expected: 0");

            parent = new List<int>() { -1, 0, 0, 0 };
            filesSize = new List<int>() { 10, 11, 10, 10 };
            Console.WriteLine(mostBalancedPartition(parent, filesSize));
            Console.WriteLine("Expected: 19");

        }
        public static List<long> findSum(List<int> numbers, List<List<int>> queries)
        {
            var result = new List<long>();
            int st;
            int end;
            long sum;
            long nZeros;
            long zeroMultiplier;

            var pNumers = new long[numbers.Count+1];
            for (int i = 1; i <= numbers.Count; i++)
            {
                pNumers[i] = numbers[i-1] + pNumers[i - 1];
            }

            var pZeros = new int[numbers.Count + 1];
            for (int i = 1; i <= numbers.Count; i++)
            {
                pZeros[i] = (numbers[i - 1]==0 ? 1 : 0 ) + pZeros[i - 1];
            }


            foreach ( var query in queries)
            {
                st = query[0];
                end = query[1];
                zeroMultiplier = query[2];

                nZeros = pZeros[end]-pZeros[st-1];
                sum = pNumers[end]-pNumers[st-1];
                result.Add(sum + nZeros * zeroMultiplier);
            }
            return result;
        }
        public static void TestFindSum()
        {
            var numbers = new List<int>() { int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue };
            var query = new List<int>() { 1, 4, 5 };
            var queries = new List<List<int>>() { query };
            Console.WriteLine (String.Join(",",findSum(numbers, queries)));
            Console.WriteLine($"Expected: {(long)int.MaxValue*4}");

            numbers = new List<int>() { -5, 0 };
            var query1 = new List<int>() { 2, 2, 20 };
            var query2 = new List<int>() { 1, 2, 10 };
            queries = new List<List<int>>() { query1, query2 };
            Console.WriteLine(String.Join(",",findSum(numbers, queries)));
            Console.WriteLine("Expected: 20, 5");

            numbers = new List<int>() { -1, -2, 0, 0 };
            query = new List<int>() { 1, 4, 10 };
            queries = new List<List<int>>() { query };
            Console.WriteLine(String.Join(",", findSum(numbers, queries)));
            Console.WriteLine("Expected: 17");

        }
    }
}
