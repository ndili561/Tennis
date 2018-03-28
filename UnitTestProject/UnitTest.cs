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
            string test = "BAAAA";
            List<string> testlist = new List<string>();
            testlist.Add(test);       
            a.gameresult = 4;
            b.gameresult = 3;
            bool result = game.IsAdvatage();
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void testscore()
        {         
            Assert.AreEqual(game.score(1), 15);
        }

        [TestMethod]
        public void testscore2()
        {       
            Assert.AreEqual(game.score(2), 30);
        }

        [TestMethod]
        public void testscore3()
        {
            Assert.AreEqual(game.score(3), 40);
        }

        [TestMethod]
        public void testscore4()
        {
            Assert.AreEqual(game.score(5), 0);
        }

        [TestMethod]
        public void testdeuce()
        {
            
            a.gameresult = 3;
            b.gameresult = 3;
            bool result = game.IsDeuce();
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void winner()
        {
            a.gameresult = 10;
            b.gameresult = 4;
            bool result = game.isWinnerGame();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void addsets()
        {
            a.gameresult = 10;
            b.gameresult = 4;
            game.addset();
            Assert.AreEqual(a.setresult, 1);
        }

        [TestMethod]
        public void iswinnerset()
        {
            a.setresult = 6;
            b.setresult = 4;
            game.IsWinnerSet();
            Assert.IsTrue(game.sets.Count == 0);
        }

        [TestMethod]
        public void gameresult()
        {
            List<string> list = new List<string>() { "AA","AA","AAAA" };
            List<string> r = game.playGame(list);
        }

    }
}
