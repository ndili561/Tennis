using Microsoft.VisualStudio.TestTools.UnitTesting;
using Game;
using BLL;
using Services;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMethod()
        {
            string test = "BAAAA";
            List<string> testlist = new List<string>();
            testlist.Add(test);
            Service service = new Service();
            Bll bll = new Bll();
            Player a = new Player();
            Player b = new Player();
            a.gameresult = 4;
            b.gameresult = 3;
            Game.Game game = new Game.Game(service,bll,a,b);
            bool result = game.IsAdvatage();
            Assert.IsTrue(result);

        }
    }
}
