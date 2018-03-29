using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Services;
namespace Game
{
    public class Game
    {
        private readonly IService _service;
        private readonly Player _playera;
        private readonly Player _playerb;
        public List<string> sets { get; set; }
        public List<string> games { get; set; }
        public List<string> setsPlayed { get; set; }

        public Game(IService service, Player a, Player b)
        {
            _service = service;
            _playera = a;
            _playerb = b;
            sets = new List<string>();
            games = new List<string>();
            setsPlayed = new List<string>();
        }



        public int score(int score)
        {
            switch (score)
            {
                case 1:
                    return 15;
                case 2:
                    return 30;
                case 3:
                    return 40;
                case 4:
                    return 99;
                default:
                    return 0;
            }
           
        }

   


        public (List<string>,List<string>,List<string>) addGameAndSets(int a, int b)
        {
          
            if (a==40 & b<=30)
            {
               _playera.setresult += 1;
                sets.Add(_playera.setresult.ToString() + "-" + _playerb.setresult.ToString());
            }
            else if(b == 40 & a <= 30)
            {
                _playerb.setresult += 1;
                sets.Add(_playera.setresult.ToString() + "-" + _playerb.setresult.ToString());
            }
            else if (a==99 & b!=40 )
            {
                _playera.setresult += 1;
                sets.Add(_playera.setresult.ToString() + "-" + _playerb.setresult.ToString());
            }
            else if (b == 99 & a != 40)
            {
                _playerb.setresult += 1;
                sets.Add(_playera.setresult.ToString() + "-" + _playerb.setresult.ToString());
            }
            if (a == 99 & b==40)
            {
                string adv = a.ToString();
                adv = "A";
                games.Add(adv + "-" + b.ToString());
            }
            else if(b == 99 & a==40)
            {
                string adv = b.ToString();
                adv = "A";
                games.Add(a.ToString() + "-" + adv);

            }else if (a == 0)
            {
                _playera.setresult += 1;
                sets.Add(_playera.setresult.ToString() + "-" + _playerb.setresult.ToString());
            }else if (b == 0)
            {
                _playerb.setresult += 1;
                sets.Add(_playera.setresult.ToString() + "-" + _playerb.setresult.ToString());

            }
            else
            {               
                _playera.gameresult = a.ToString();
                _playerb.gameresult = b.ToString();
                games.Add(_playera.gameresult.ToString() + "-" + _playerb.gameresult.ToString());
                
            }
            if(_playera.setresult==6 | _playerb.setresult == 6)
            {
                this.addCompletedSets(_playera.setresult, _playerb.setresult);
            }
            return (games, sets,setsPlayed);
                 
        }

        private void addCompletedSets(int setresult1, int setresult2)
        {
            setsPlayed.Add(setresult1 + "-" + setresult2);
        }

   


        public (List<string>, List<string>,List<string>) playGame(List<string> list)
        {
            int pointap = 0;
            int pointbp = 0;
            List<string> sets = new List<string>();
            List<string> games = new List<string>();
            foreach (string str in list)
            {
                if (str.Any(c => c.Equals('A')))
                {                                  
                  pointap = this.score(str.Count(x => x == 'A'));
                }
                      
                if (str.Any(c => c.Equals('B')))
                {
                   pointbp = this.score(str.Count(x => x == 'B'));
                }
             (games,sets,setsPlayed) = addGameAndSets(pointap,pointbp);
                
            }
            return (games, sets,setsPlayed);
        }
    }
}
