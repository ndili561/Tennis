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
        public Dictionary<int, int> sets { get; set; }

        public Game(IService service, Player a, Player b)
        {
            _service = service;
            _playera = a;
            _playerb = b;
            sets = new Dictionary<int, int>();
        }

        public bool IsAdvatage()
        {
            if(_playera.gameresult>=4 && _playera.gameresult ==_playerb.gameresult +1)
            {
                return true;
            }
            if(_playerb.gameresult>+ 4 && _playerb.gameresult == _playera.gameresult + 1)
            {
                return true;
            }
            return false;

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
                default:
                    return 0;
            }
           
        }

        public bool IsDeuce()
        {
            if((_playera.gameresult >=3 | _playerb.gameresult>3)& _playerb.gameresult == _playera.gameresult)
            {
                return true;
            }
            return false;
        }

        public bool isWinnerGame()
        {
            if(_playera.gameresult>=4 && _playera.gameresult > _playerb.gameresult + 2)
            {
                return true;
            }
            if(_playerb.gameresult >= 4 && _playerb.gameresult > _playera.gameresult + 2)
            {
                return true;
            }
            return false;
        }

        public void addset()
        {
            if (isWinnerGame())
            {
                if (_playera.gameresult > _playerb.gameresult)
                {
                    _playera.setresult += 1;
                }
                if (_playerb.gameresult > _playera.gameresult)
                {
                    _playerb.setresult += 1;
                }
            }
        }

        public bool IsWinnerSet()
        {
            if(_playera.setresult == 0 | _playerb.setresult==0)
            {
              
                return true;
            }
            return false;
        }

        public List<string> playGame(List<string> list)
        {
            string advatage = "A";
            List<string> result = new List<string>();
            foreach(string str in list)
            {
                _playera.gameresult = this.score( str.Count(x => x == 'A'));
                _playerb.gameresult = this.score( str.Count(x => x == 'B'));
                if (IsDeuce())
                {
                    if(_playera.gameresult == 0)
                    {
                        result.Add(advatage+"-"+_playerb.gameresult.ToString());
                    }
                    if (_playerb.gameresult == 0)
                    {
                        result.Add(_playera.gameresult.ToString()+"-"+advatage);
                    }
                }
                if (IsWinnerSet())
                {
                    if (_playera.gameresult == 0)
                    {
                        result.Add(_playera.setresult + 1 + "-" + _playerb.setresult);
                    }
                    if (_playerb.gameresult == 0)
                    {
                        result.Add(_playera.setresult + "-" + _playerb.setresult+1);
                    }


                }
                result.Add(_playera.gameresult.ToString()+"-"+_playerb.gameresult.ToString());

            }
            return result;
        }
    }
}
