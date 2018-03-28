using System;
using System.Collections.Generic;
using System.Text;
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
            if(_playera.gameresult >=3 & _playerb.gameresult == _playera.gameresult)
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

        public void IsWinnerSet()
        {
            if(_playera.setresult == 6 | _playerb.setresult==6)
            {
                sets.Add(_playera.setresult, _playerb.setresult);
            }
        }
    }
}
