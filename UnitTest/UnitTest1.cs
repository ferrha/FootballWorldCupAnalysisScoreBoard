using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FootballWorldCupAnalysisScoreBoard;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAddGame1()
        {
            // Test the addition of new games.
            AnalysisScoreBoard newBoard = new AnalysisScoreBoard();
            newBoard.AddGame("Spain", 12, "Malta", 0);
            newBoard.AddGame("Germany", 1, "Italy", 2);
            newBoard.AddGame("Argentina", 10, "Peru", 2);
            newBoard.AddGame("Austria", 1, "Switzerland", 9);
            newBoard.AddGame("Andorra", 1, "Ukraine", 11);

            Assert.AreEqual(5, newBoard.Games.Count);

            Assert.AreEqual("Spain 12 - Malta 0", newBoard.Games.Cast<DictionaryEntry>().ElementAt(0).Key.ToString());
            Assert.AreEqual(12, newBoard.Games.Cast<DictionaryEntry>().ElementAt(0).Value);
            Assert.AreNotEqual("Spain 12 - Malta 1", newBoard.Games.Cast<DictionaryEntry>().ElementAt(0).Key.ToString());
            Assert.AreNotEqual(13, newBoard.Games.Cast<DictionaryEntry>().ElementAt(0).Value);

            Assert.AreEqual("Germany 1 - Italy 2", newBoard.Games.Cast<DictionaryEntry>().ElementAt(1).Key.ToString());
            Assert.AreEqual(3, newBoard.Games.Cast<DictionaryEntry>().ElementAt(1).Value);

            Assert.AreEqual("Argentina 10 - Peru 2", newBoard.Games.Cast<DictionaryEntry>().ElementAt(2).Key.ToString());
            Assert.AreEqual(12, newBoard.Games.Cast<DictionaryEntry>().ElementAt(2).Value);

            Assert.AreEqual("Austria 1 - Switzerland 9", newBoard.Games.Cast<DictionaryEntry>().ElementAt(3).Key.ToString());
            Assert.AreEqual(10, newBoard.Games.Cast<DictionaryEntry>().ElementAt(3).Value);

            Assert.AreEqual("Andorra 1 - Ukraine 11", newBoard.Games.Cast<DictionaryEntry>().ElementAt(4).Key.ToString());
            Assert.AreEqual(12, newBoard.Games.Cast<DictionaryEntry>().ElementAt(4).Value);
        }

        [TestMethod]
        public void TestGetSummaryByTotalScore1()
        {
            // Test the summary returned in the correct order
            AnalysisScoreBoard newBoard = new AnalysisScoreBoard();
            newBoard.AddGame("Spain", 12, "Malta", 0);
            newBoard.AddGame("Germany", 1, "Italy", 2);
            newBoard.AddGame("Argentina", 10, "Peru", 2);
            newBoard.AddGame("Austria", 1, "Switzerland", 9);
            newBoard.AddGame("Andorra", 1, "Ukraine", 11);

            List<string> Games = newBoard.GetSummaryByTotalScore(newBoard.Games);

            Assert.AreEqual(5, Games.Count);

            Assert.AreEqual("Andorra 1 - Ukraine 11", Games[0]);
            Assert.AreEqual("Argentina 10 - Peru 2", Games[1]);
            Assert.AreEqual("Spain 12 - Malta 0", Games[2]);
            Assert.AreEqual("Austria 1 - Switzerland 9", Games[3]);
            Assert.AreEqual("Germany 1 - Italy 2", Games[4]);

            // Test if a new game is added with the highest score is returned the first one
            newBoard.AddGame("Chile", 2, "Brazil", 10);

            List<string> GamesPlusOne = newBoard.GetSummaryByTotalScore(newBoard.Games);

            Assert.AreEqual(6, GamesPlusOne.Count);

            Assert.AreEqual("Chile 2 - Brazil 10", GamesPlusOne[0]);
            Assert.AreEqual("Andorra 1 - Ukraine 11", GamesPlusOne[1]);
            Assert.AreEqual("Argentina 10 - Peru 2", GamesPlusOne[2]);
            Assert.AreEqual("Spain 12 - Malta 0", GamesPlusOne[3]);
            Assert.AreEqual("Austria 1 - Switzerland 9", GamesPlusOne[4]);
            Assert.AreEqual("Germany 1 - Italy 2", GamesPlusOne[5]);

            // Test if new games are added with multiple score results
            newBoard.AddGame("France", 2, "Portugal", 3);
            newBoard.AddGame("England", 2, "Ireland", 2);
            newBoard.AddGame("Canada", 1, "Russia", 1);

            List<string> GamesPlusThree = newBoard.GetSummaryByTotalScore(newBoard.Games);

            Assert.AreEqual(9, GamesPlusThree.Count);

            Assert.AreEqual("Chile 2 - Brazil 10", GamesPlusThree[0]);
            Assert.AreEqual("Andorra 1 - Ukraine 11", GamesPlusThree[1]);
            Assert.AreEqual("Argentina 10 - Peru 2", GamesPlusThree[2]);
            Assert.AreEqual("Spain 12 - Malta 0", GamesPlusThree[3]);
            Assert.AreEqual("Austria 1 - Switzerland 9", GamesPlusThree[4]);
            Assert.AreEqual("France 2 - Portugal 3", GamesPlusThree[5]);
            Assert.AreEqual("England 2 - Ireland 2", GamesPlusThree[6]);
            Assert.AreEqual("Germany 1 - Italy 2", GamesPlusThree[7]);
            Assert.AreEqual("Canada 1 - Russia 1", GamesPlusThree[8]);
        }
    }
}
