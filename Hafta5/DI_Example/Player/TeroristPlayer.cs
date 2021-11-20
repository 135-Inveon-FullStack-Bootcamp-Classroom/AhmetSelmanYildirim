using DI_Example.Gun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_Example.Player
{
    public class TeroristPlayer : IPlayer
    {
        private readonly ITeroristGun _teroristGun;

        public TeroristPlayer(ITeroristGun teroristGun)
        {
            _teroristGun = teroristGun;
        }

        public void Fire()
        {
            _teroristGun.FireGun();
        }

        public void Move()
        {
            Console.WriteLine("Terorist player moved");
        }
    }
}
