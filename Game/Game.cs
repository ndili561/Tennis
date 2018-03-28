using System;
using System.Collections.Generic;
using System.Text;
using BLL;
using Services;
namespace Game
{
    public class Game
    {
        private readonly IService _service;
        private readonly IBll _bll;
        private readonly Player _playera;
        private readonly Player _playerb;

        public Game(IService service, IBll bll, Player a, Player b)
        {
            _service = service;
            _bll = bll;
            _playera = a;
            _playerb = b;
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
    }
}
