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

        //[TestMethod]
        //public void testscore4()
        //{
        //    Assert.AreEqual(game.score(5), 0);
        //}

        //[TestMethod]
        //public void testdeuce()
        //{

        //    //a.gameresult = 3;
        //    //b.gameresult = 3;
        //    //bool result = game.IsDeuce();
        //    //Assert.IsTrue(result);

        //}

        //[TestMethod]
        //public void winner()
        //{
        //    //a.gameresult = 10;
        //    //b.gameresult = 4;
        //    //bool result = game.isWinnerGame();
        //    //Assert.IsTrue(result);
        //}

        //[TestMethod]
        //public void addsets()
        //{
        //    //a.gameresult = 10;
        //    //b.gameresult = 4;
        //    //game.addset();
        //    //Assert.AreEqual(a.setresult, 1);
        //}

        //[TestMethod]
        //public void iswinnerset()
        //{
        //    //a.setresult = 6;
        //    //b.setresult = 4;
        //    //game.IsWinnerSet();
        //    //Assert.IsTrue(game.sets.Count == 0);
        //}

        //[TestMethod]
        //public void gameresult()
        //{


        //}

    }
}
