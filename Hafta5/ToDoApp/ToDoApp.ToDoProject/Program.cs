using System;
using System.Collections.Generic;

namespace ToDoApp.ToDoProject
{
    class Program
    {

        static void Main(string[] args)
        {

            // Member list
            List<Member> members = new()
            {
                new Member(1, "Ahmet"),
                new Member(2, "Murat"),
                new Member(3, "Batuhan")
            };

            List<Card> mainList = new();

            mainList.Add(new Card("Ekmek al", "Marketten 2 ekmek al", members[0], Size.L, Line.TODO));
            mainList.Add(new Card("Kitap oku", "50 sayfa kitap oku", members[1], Size.M, Line.IN_PROGRESS));
            mainList.Add(new Card("Odayı topla", "Eşyaları yerine koy", members[2], Size.XL, Line.DONE));

            int q = 1;
            while (q == 1)
            {
                Console.WriteLine("\nChoose");
                Console.WriteLine("(1) List Board ");
                Console.WriteLine("(2) Add Card ");
                Console.WriteLine("(3) Delete Card");
                Console.WriteLine("(4) Replace Card");
                Console.WriteLine("(5) Quit");
                string choose = Console.ReadLine();

                try
                {
                    switch (int.Parse(choose))
                    {
                        // Listing
                        case 1: CardOperations.listTheBoard(mainList); break;

                        // Adding
                        case 2: CardOperations.addCard(members, mainList); break;

                        case 3: CardOperations.deleteCard(mainList); break;

                        case 4: CardOperations.updateCard(mainList); break;

                        case 5: q = 0; break;

                        default: Console.WriteLine("Do not try me, please."); break;
                    }
                }
                catch (FormatException e)
                {
                    System.Console.WriteLine("Data type incorrect");
                }

            }



        }
    }
}
