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
        public Dictionary<string, int> Games = new Dictionary<string, int>();

        ///<summary>
        ///Method to add a game. Creates a FootballTeam for every home and away team.
        ///</summary>
        ///<returns>
        ///</returns>
        public void AddGame(string homeTeamName, int homeTeamScore, string awayTeamName, int awayTeamScore)
        {
            try
            {
                // Creation of the home team object with the team name and the score
                FootballTeam homeTeamInfo = new FootballTeam(homeTeamName, homeTeamScore);
                // Creation of the away team object with the team name and the score
                FootballTeam awayTeamInfo = new FootballTeam(awayTeamName, awayTeamScore);

                // Addition of the new game to the dictionary
                Games.Add(homeTeamInfo.TeamName + " " + homeTeamInfo.TeamScore + " - " + awayTeamInfo.TeamName + " " + awayTeamInfo.TeamScore, homeTeamInfo.TeamScore + awayTeamInfo.TeamScore);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception at AnalysisScoreBoard.AddGame: " + e.ToString() + " - " + e.StackTrace);
            }
        }

        ///<summary>Method to get a summary of games by total score. Those games with the same total score will be returned ordered by the most recently added to our system.  
        ///</summary>
        ///<param name="gamesAdded">Dictionary with entry data. Key in string format and Value in int format.</param>
        ///<returns>List of strings with the games added ordered by total score.</returns>
        ///<exception cref="Exception">General exception in the method</exception>
        public List<string> GetSummaryByTotalScore(Dictionary<string,int> gamesAdded)
        {
            try
            {
                // Initialization of the sorted list with the results to return
                List<string> sortedList = new List<string>();

                /*
                Loop over the games added ordering by total score and those games with the same total score will be ordered by the most recently added
                and store the element in the sortedList
                 */
                foreach (KeyValuePair<string,int> item in gamesAdded.Reverse().OrderByDescending(r => r.Value))
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
    ///Football team definition. Creates an object FootballTeam with TeamName and TeamScore properties.
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
