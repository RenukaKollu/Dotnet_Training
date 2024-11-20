using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment3
{
    class CricketTeam
    {
       
        public (int MatchCount, int TotalScore, double AverageScore) PointsCalculation(int noOfMatches)
        {
            int totalScore = 0;

            Console.WriteLine($"Enter the scores for {noOfMatches} matches:");
            for (int i = 1; i <= noOfMatches; i++)
            {
                int score;
                while (true)
                {
                    Console.Write($"Enter score for match {i}: ");
                    if (int.TryParse(Console.ReadLine(), out score) && score >= 0)
                    {
                        totalScore += score;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a positive integer.");
                    }
                }
            }

            double averageScore = (double)totalScore / noOfMatches;
            return (noOfMatches, totalScore, averageScore);
        }
    }

    class CricketClass
    {
        static void Main(string[] args)
        {
            CricketTeam team = new CricketTeam();

            Console.Write("Enter the number of matches: ");
            int noOfMatches;
            while (!int.TryParse(Console.ReadLine(), out noOfMatches) || noOfMatches <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive integer for number of matches.");
            }

            
            var result = team.PointsCalculation(noOfMatches);

           
            Console.WriteLine("\nResults:");
            Console.WriteLine($"Number of Matches: {result.MatchCount}");
            Console.WriteLine($"Total Score: {result.TotalScore}");
            Console.WriteLine($"Average Score: {result.AverageScore:F2}");
            Console.Read();
        }
    }
    
}
