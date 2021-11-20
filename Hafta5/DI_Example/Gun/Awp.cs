using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_Example.Gun
{
    public class Awp : ICommonGun
    {
        public void FireGun()
        {
            Console.WriteLine("Awp fired");
        }
    }
}
