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
        AnalysisScoreBoard newAnalysisScoreBoard = new AnalysisScoreBoard();

        // Main loop
        do
        {
            // Loop to add games
            do
            {
                if (row == 0)
                    ResetConsole();

                string homeTeamName;
                int homeTeamScore;
                string awayTeamName;
                int awayTeamScore;

                // Ask for the home team name
                Console.WriteLine($"{Environment.NewLine}Home team name:");
                homeTeamName = Console.ReadLine();
                if (string.IsNullOrEmpty(homeTeamName)) break;

                // Ask for the home team score, if a non numeric value is added shows error and add a 0 value
                Console.WriteLine($"{Environment.NewLine}Home team score:");
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input)) break;
                bool successParssingScoreValue = Int32.TryParse(input, out homeTeamScore);
                if (!successParssingScoreValue)
                {
                    Console.WriteLine($"Attempted conversion of '{input}' failed, inserted 0 as score.");
                }

                // Ask for the away team name
                Console.WriteLine($"{Environment.NewLine}Away team name:");
                awayTeamName = Console.ReadLine();
                if (string.IsNullOrEmpty(awayTeamName)) break;

                // Ask for the away team score, if a non numeric value is added shows error and add a 0 value
                Console.WriteLine($"{Environment.NewLine}Away team score:");
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input)) break;
                successParssingScoreValue = Int32.TryParse(input, out awayTeamScore);
                if (!successParssingScoreValue)
                {
                    Console.WriteLine($"Attempted conversion of '{input}' failed, inserted 0 as score.");
                }

                // Add a new game with the previous values added by the user
                Console.WriteLine();
                row++;
                newAnalysisScoreBoard.AddGame(homeTeamName, homeTeamScore, awayTeamName, awayTeamScore);

                // Ask for the option to finish and show the summary of games or to continue adding new games
                Console.WriteLine($"{Environment.NewLine}Would you like to add a new game? <Y> or <Blank> Yes, <N> No");
                input = Console.ReadLine();
                toContinue = (string.IsNullOrEmpty(input) || input.ToUpper() == "Y") ? true : false;
            } while (toContinue);

            // Return the summary of games
            List<string> summaryOfGames = newAnalysisScoreBoard.GetSummaryByTotalScore(newAnalysisScoreBoard.Games);
            Console.WriteLine($"{Environment.NewLine}Summary of games by total score:");
            foreach (string gameResul in summaryOfGames)
            {
                Console.WriteLine($"{Environment.NewLine}" + gameResul);
            }

            // Ask for the option to finish
            Console.WriteLine($"{Environment.NewLine}Would you like to finish? <Y> or <Blank> Yes, <N> No");
            input = Console.ReadLine();
            if (string.IsNullOrEmpty(input) || input.ToUpper() == "Y") return;

            // If continue, ask for the option of clear the console previous messages
            Console.WriteLine($"{Environment.NewLine}Would you like to clear the console? <Y> or <Blank> Yes, <N> No");
            input = Console.ReadLine();
            if (string.IsNullOrEmpty(input) || input.ToUpper() == "Y") ResetConsole();
        } while (true);

        // Method to clean the console
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
