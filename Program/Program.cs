using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballWorldCupAnalysisScoreBoard;

class Program
{
    public static void Main(string[] args)
    {
        int row = 0;
        bool toContinue = true;
        string input;
        AnalysisScoreBoard newBoard = new AnalysisScoreBoard();

        do
        {
            do
            {
                if (row == 0)
                    ResetConsole();

                string HomeTeamName;
                int HomeTeamScore;
                string AwayTeamName;
                int AwayTeamScore;

                Console.WriteLine($"{Environment.NewLine}Home team name:");
                HomeTeamName = Console.ReadLine();
                if (string.IsNullOrEmpty(HomeTeamName)) break;

                Console.WriteLine($"{Environment.NewLine}Home team score:");
                HomeTeamScore = int.Parse(Console.ReadLine());
                if (string.IsNullOrEmpty(HomeTeamScore.ToString())) break;

                Console.WriteLine($"{Environment.NewLine}Away team name:");
                AwayTeamName = Console.ReadLine();
                if (string.IsNullOrEmpty(AwayTeamName)) break;

                Console.WriteLine($"{Environment.NewLine}Away team score:");
                AwayTeamScore = int.Parse(Console.ReadLine());
                if (string.IsNullOrEmpty(AwayTeamScore.ToString())) break;

                Console.WriteLine();
                row++;
                newBoard.AddGame(HomeTeamName, HomeTeamScore, AwayTeamName, AwayTeamScore);

                Console.WriteLine($"{Environment.NewLine}Would you like to add a new game? <Y> or <Blank> Yes, <N> No");
                input = Console.ReadLine();
                toContinue = (string.IsNullOrEmpty(input) || input.ToUpper() == "Y") ? true : false;
            } while (toContinue);

            List<string> Games = newBoard.GetSummaryByTotalScore(newBoard.Games);
            Console.WriteLine($"{Environment.NewLine}Summary of games by total score:");
            foreach (string game in Games)
            {
                Console.WriteLine($"{Environment.NewLine}" + game);
            }

            Console.WriteLine($"{Environment.NewLine}Would you like to finish? <Y> or <Blank> Yes, <N> No");
            input = Console.ReadLine();
            if (string.IsNullOrEmpty(input) || input.ToUpper() == "Y") return;

            Console.WriteLine($"{Environment.NewLine}Would you like to clear the console? <Y> or <Blank> Yes, <N> No");
            input = Console.ReadLine();
            if (string.IsNullOrEmpty(input) || input.ToUpper() == "Y") ResetConsole();
        } while (true);

        void ResetConsole()
        {
            if (row > 0)
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            Console.Clear();
            Console.WriteLine($"{Environment.NewLine}Add a new game as asked and press <Enter>:{Environment.NewLine}");
            row++;
        }
    }
}
