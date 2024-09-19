using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaceWinners;

public class Program
{
    static async Task Main(string[] args)
    {
        DataService ds = new DataService();

        // Asynchronously retrieve the group (class) data
        var data = await ds.GetGroupRanksAsync();

        List<(string Name, double AvgScore)> classScores = new List<(string, double)>();

        // get the average scor 
        foreach (var group in data)
        {
            var avgScore = group.Ranks.Average();
            classScores.Add((group.Name, avgScore));
            var ranks = String.Join(", ", group.Ranks);
            Console.WriteLine($"{group.Name} - [{ranks}]");
            Console.WriteLine($"{group.Name}'s avg placement was {avgScore}");
            Console.WriteLine();
        }

        Console.WriteLine();
     
        Console.WriteLine();

        // Order by avg
        var rankedClasses = classScores.OrderBy(cs => cs.AvgScore).ToList();

        // Display places
        for (int i = 0; i < rankedClasses.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {rankedClasses[i].Name} - Average Score: {rankedClasses[i].AvgScore}");
        }
    }
}