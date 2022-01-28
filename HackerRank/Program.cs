using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using HackerRank;

class Solution
{
    public static void Main(String[] args)
    {

        TestClimbLeaderHank();

    }
    public static void TestClimbLeaderHankFile()
    {
        string filename = Directory.GetCurrentDirectory() + "output.txt";
        TextWriter textWriter = new StreamWriter(filename, true);

        int rankedCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> ranked = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(rankedTemp => Convert.ToInt32(rankedTemp)).ToList();

        int playerCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> player = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(playerTemp => Convert.ToInt32(playerTemp)).ToList();

        List<int> result = Result.climbingLeaderboard(ranked, player);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
    public static void TestClimbLeaderHankFile2()
    {
        string filename = Directory.GetCurrentDirectory() + @"\output8.txt";
        TextWriter textWriter = new StreamWriter(filename, true);

        string inFileName = Directory.GetCurrentDirectory() + @"\testecase8.txt";
        StreamReader sr = new StreamReader(inFileName);

        int rankedCount = Convert.ToInt32(sr.ReadLine().Trim());

        List<int> ranked = sr.ReadLine().TrimEnd().Split(' ').ToList().Select(rankedTemp => Convert.ToInt32(rankedTemp)).ToList();

        int playerCount = Convert.ToInt32(sr.ReadLine().Trim());

        List<int> player = sr.ReadLine().TrimEnd().Split(' ').ToList().Select(playerTemp => Convert.ToInt32(playerTemp)).ToList();

        List<int> result = Result.climbingLeaderboard(ranked, player);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }

    public static void TestClimbLeaderHank()
    {
        List<int> rank = new List<int>() { 100, 90, 90, 80 };
        List<int> scores = new List<int>() { 0, 0, 1, 1, 2, 2 };

        Console.WriteLine(String.Join(",", Result.climbingLeaderboard(rank, scores)));
        Console.WriteLine("Expected: 4,4,4,4,4,4");


        rank = new List<int>() { 100, 100, 50, 40, 40, 20, 10 };
        scores = new List<int>() { 5, 25, 50, 120 };

        Console.WriteLine(String.Join(",", Result.climbingLeaderboard(rank, scores)));
        Console.WriteLine("Expected: 6,4,2,1");


        rank = new List<int>() { 100, 90, 90, 80 };
        scores = new List<int>() { 70, 80, 105 };

        Console.WriteLine(String.Join(",", Result.climbingLeaderboard(rank, scores)));
        Console.WriteLine("Expected: 4,3,1");

        List<int> rank2 = new List<int>() { 100 };
        List<int> scores2 = new List<int>() { 5, 10, 15 };

        Console.WriteLine(String.Join(",", Result.climbingLeaderboard(rank2, scores2)));
        Console.WriteLine("Expected: 2,2,2");

        rank = new List<int>() { 100, 90, 90, 80, 80, 80, 40 };
        scores = new List<int>() { 0, 0, 0, 30, 30, 30 };

        Console.WriteLine(String.Join(",", Result.climbingLeaderboard(rank, scores)));
        Console.WriteLine("Expected: 5,5,5,5,5,5");

    }
}

