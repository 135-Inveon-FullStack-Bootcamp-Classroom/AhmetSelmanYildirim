using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_Example.Gun
{
    class M4 : IAntiTeroristGun
    {
        public void FireGun()
        {
            Console.WriteLine("M4 fired");
        }
    }
}
