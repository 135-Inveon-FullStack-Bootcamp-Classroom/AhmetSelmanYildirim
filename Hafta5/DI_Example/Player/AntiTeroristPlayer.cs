using DI_Example.Gun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_Example.Player
{
    public class AntiTeroristPlayer : IPlayer
    {
        private readonly IAntiTeroristGun _antiTeroristGun;

        public AntiTeroristPlayer(IAntiTeroristGun antiTeroristGun)
        {
            _antiTeroristGun = antiTeroristGun;
        }

        public void Fire()
        {
            _antiTeroristGun.FireGun();
        }

        public void Move()
        {
            Console.WriteLine("Anti-Terorist player moved");
        }
    }
}
