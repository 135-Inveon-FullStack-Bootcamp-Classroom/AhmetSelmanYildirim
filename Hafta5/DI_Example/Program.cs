using DI_Example.Gun;
using System;

namespace DI_Example
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Choose your team: \n(1) Anti-Terorist Team\n(2) Terorist Team");
            int teamSelection = Int16.Parse(Console.ReadLine());

            switch (teamSelection)
            {
                case 1:
                    FightAsAntiTerorist();

                    break;
                case 2:
                    FightAsTerorist();
                    break;
                default:
                    Console.WriteLine("Enter a valid value");
                    break;
            }


        }

        private static void FightAsTerorist()
        {
            Console.WriteLine("Terorist team chosen");
            Console.WriteLine("Choose your gun: \n(1) Ak47\n(2) AWP");
            int gunSelection = Int16.Parse(Console.ReadLine());
            ITeroristGun gun;

            switch (gunSelection)
            {
                case 1:
                    Console.WriteLine("Ak47 chosen");
                    gun = new Ak47();
                    gun.FireGun();
                    break;
                case 2:
                    Console.WriteLine("AWP chosen");
                    gun = new Awp();
                    gun.FireGun();
                    break;
                default:
                    Console.WriteLine("Enter a valid value");
                    break;
            }
        }

        private static void FightAsAntiTerorist()
        {

            Console.WriteLine("Anti-Terorist team chosen");
            Console.WriteLine("Choose your gun: \n(1) M4\n(2) AWP");
            int gunSelection = Int16.Parse(Console.ReadLine());
            IAntiTeroristGun gun;

            switch (gunSelection)
            {
                case 1:
                    Console.WriteLine("M4 chosen");
                    gun = new M4();
                    gun.FireGun();
                    break;
                case 2:
                    Console.WriteLine("AWP chosen");
                    gun = new Awp();
                    gun.FireGun();
                    break;
                default:
                    Console.WriteLine("Enter a valid value");
                    break;
            }
        }
    }
}
