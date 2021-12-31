using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballWorldCupAnalysisScoreBoard
{
    public class AnalysisScoreBoard
    {
        public OrderedDictionary Games = new OrderedDictionary();

        ///<summary>
        ///Method to add a game
        ///</summary>
        ///<returns>
        ///</returns>
        public void AddGame(string pHomeTeamName, int pHomeTeamScore, string pAwayTeamName, int pAwayTeamScore)
        {
            try
            {
                FootballTeam homeTeam = new FootballTeam(pHomeTeamName, pHomeTeamScore);
                FootballTeam awayTeam = new FootballTeam(pAwayTeamName, pAwayTeamScore);

                Games.Add(homeTeam.TeamName + " " + homeTeam.TeamScore + " - " + awayTeam.TeamName + " " + awayTeam.TeamScore, homeTeam.TeamScore + awayTeam.TeamScore);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception at AnalysisScoreBoard.AddGame: " + e.ToString() + " - " + e.StackTrace);
            }
        }

        ///<summary>
        ///Method to get a summary of games by total score. Those games with the same total score will be returned ordered by the most recently added to our system.  
        ///</summary>
        ///<param name="pGames">
        ///OrderedDictionary with entry data
        ///</param>
        ///<returns>
        ///List of strings with the games added ordered by total score.
        ///</returns>
        public List<string> GetSummaryByTotalScore(OrderedDictionary pGames)
        {
            try
            {

                List<string> sortedList = new List<string>();

                var orderedDictionary = pGames.Cast<System.Collections.DictionaryEntry>().ToDictionary(c => c.Key, d => d.Value);

                var newOrderedDictionary = orderedDictionary.Reverse();

                var finalOrderedDictionary = newOrderedDictionary.OrderByDescending(r => r.Value);

                foreach (var item in finalOrderedDictionary)
                {
                    sortedList.Add((string)item.Key);
                }

                return sortedList;
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception at AnalysisScoreBoard.GetSummaryByTotalScore: " + e.ToString() + " - " + e.StackTrace);
                throw e;
            }
        }
    }

    ///<summary>
    ///Football team definition
    ///</summary>
    ///<returns>
    ///</returns>
    internal class FootballTeam
    {
        public string TeamName { get; set; }
        public int TeamScore { get; set; }

        public FootballTeam(string pTeamName, int pTeamScore)
        {
            TeamName = pTeamName;
            TeamScore = pTeamScore;
        }
    }
}
