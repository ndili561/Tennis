using Microsoft.VisualStudio.TestTools.UnitTesting;
using Game;
using Services;
using System.Collections.Generic;
using System.IO;



namespace UnitTestProject
{
    [TestClass]
    public class UnitTest
    {

        Game.Game game;
        Player a;
        Player b;
        Service service;
        Program prg;

        [TestInitialize]
        public void setup()
        {

            prg = new Program();
            service = new Service();
            a = new Player();
            b = new Player();           
            game = new Game.Game(service,  a, b);

        }
        [TestMethod]
        public void TestMethodAdvantage()
        {
            List<string> list = new List<string>() { "BBBAAA" };
            game.playGame(list);
            List<string> result = game.games;
            Assert.AreEqual(result.Contains("40-40"), true);

        }

        [TestMethod]
        public void testscore()
        {
            List<string> list = new List<string>() { "BBBAAA","AAAA" };
            game.playGame(list);
            List<string> result = game.games;
            Assert.IsTrue(result.Count==2);
        }

        [TestMethod]
        public void testscore2()
        {
            List<string> list = new List<string>() { "AAA" };
            game.playGame(list);
            List<string> result = game.games;
            Assert.IsTrue(result.Contains("40-0"));
        }

        [TestMethod]
        public void testscore3()
        {
            List<string> list = new List<string>() { "AAB" };
            game.playGame(list);
            List<string> result = game.games;
            Assert.IsTrue(result.Contains("30-15"));
        }

        [TestMethod]
        public void testscore4()
        {
            List<string> list = new List<string>() { "AAAABBB" };
            game.playGame(list);
            List<string> result = game.games;
            Assert.IsTrue(game.sets.Count ==0);
            Assert.IsTrue(game.games.Contains("A-40"));


        }

        [TestMethod]
        public void testdraw()
        {
            List<string> list = new List<string>() { "AB" };
            game.playGame(list);
            List<string> result = game.games;
            Assert.IsTrue(result.Contains("15-15"));



        }

        [TestMethod]
        public void winner()
        {
            List<string> list = new List<string>() { "AABB" };
            game.playGame(list);
            List<string> result = game.games;
            Assert.IsTrue(result.Contains("30-30"));
        }

        [TestMethod]
        public void tetscore()
        {
            List<string> list = new List<string>() { "AAAAAB" };
            game.playGame(list);
            List<string> result = game.games;
            Assert.IsTrue(result.Contains(""));
            Assert.IsTrue(game.sets.Count == 0);
        }



    }
}
