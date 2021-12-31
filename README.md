# FootballWorldCupAnalysisScoreBoard
Football World Cup Score Analysis Board is an example project written in .Net Framework 4.7.2. that shows matches and scores of played games.

## Requirements
- .Net Framework 4.7.2 or higher

## Documentation
The library _FootballWorldCupAnalysisScoreBoard.dll_ contains two methods:
- AddGame(string pHomeTeamName, int pHomeTeamScore, string pAwayTeamName, int pAwayTeamScore): adds to a _OrderedDictionary_ a new game for the Home Team name and score and Away Team name and score passed as parameters.
- GetSummaryByTotalScore(OrderedDictionary pGames): returns a _List of strings_ with the games previously added ordered by total score, those games with the same total score will be returned ordered by the most recently added to our system.

## Development and testing in a local environment
Download the repository and open it with Visual Studio and run. _Program.cs_ provided is a console application that helps to use and debug the library _FootballWorldCupAnalysisScoreBoard.dll_ .

Running the _UnitTest_ project will execute the unit test written for the library.

## TBD and improvement opportunities
- Create a WindowsForm to add new games and add a button to show the summary results.
- Save the games added into a DataBase, such as MySql or MongoDB.
- Export to a text file (txt, csv, json, xml) the summary results.
