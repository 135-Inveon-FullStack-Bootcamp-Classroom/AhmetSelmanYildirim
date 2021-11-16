using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.ToDoProject
{
    class CardOperations
    {
        public static void listTheBoard(List<Card> mainList)
        {
            Console.WriteLine("TODO Line \n*******************");
            mainList.ForEach(i =>
            {
                if (i.Line == Line.TODO)
                {
                    Console.WriteLine("Title       : " + i.Title);
                    Console.WriteLine("Description : " + i.Description);
                    Console.WriteLine("Member      : " + i.Member.Name);
                    Console.WriteLine("Size        : " + i.Size);
                    Console.WriteLine("Line        : " + i.Line);
                    Console.WriteLine("-");
                }

            });
            Console.WriteLine("\nIN PROGRESS Line \n*******************");
            mainList.ForEach(i =>
            {
                if (i.Line == Line.IN_PROGRESS)
                {
                    Console.WriteLine("Title       : " + i.Title);
                    Console.WriteLine("Description : " + i.Description);
                    Console.WriteLine("Member      : " + i.Member.Name);
                    Console.WriteLine("Size        : " + i.Size);
                    Console.WriteLine("Line        : " + i.Line);
                    Console.WriteLine("-");
                }

            });
            Console.WriteLine("\nDONE Line \n*******************");
            mainList.ForEach(i =>
            {
                if (i.Line == Line.DONE)
                {
                    Console.WriteLine("Title       : " + i.Title);
                    Console.WriteLine("Description : " + i.Description);
                    Console.WriteLine("Member      : " + i.Member.Name);
                    Console.WriteLine("Size        : " + i.Size);
                    Console.WriteLine("Line        : " + i.Line);
                    Console.WriteLine("-");
                }

            });
        }

        public static void addCard(List<Member> members, List<Card> mainList)
        {
            try
            {
                Console.Write("Title: ");
                string title = Console.ReadLine();
                Console.Write("Description: ");
                string description = Console.ReadLine();

                // Get member
                Console.WriteLine("Member: ");
                Console.WriteLine("(1) Ahmet");
                Console.WriteLine("(2) Murat");
                Console.WriteLine("(3) Batuhan");
                Console.WriteLine("Default = Ahmet");
                var selection = int.Parse(Console.ReadLine());
                Member selectedMember = members[0];
                switch (selection)
                {
                    case 1:
                        selectedMember = members[0];
                        break;
                    case 2:
                        selectedMember = members[1];
                        break;
                    case 3:
                        selectedMember = members[2];
                        break;
                    default: Console.WriteLine("Incorrect value entered."); break;
                }

                // Get size
                Console.WriteLine("Size: ");
                Console.WriteLine("1: XS");
                Console.WriteLine("2: S");
                Console.WriteLine("3: M");
                Console.WriteLine("4: L");
                Console.WriteLine("5: XL");
                Console.WriteLine("Default = XS");
                selection = int.Parse(Console.ReadLine());
                Size size = Size.XS;
                switch (selection)
                {
                    case 1: size = Size.XS; break;
                    case 2: size = Size.S; break;
                    case 3: size = Size.M; break;
                    case 4: size = Size.L; break;
                    case 5: size = Size.XL; break;
                    default: Console.WriteLine("Do not try me, please."); break;
                }

                // Get line
                Console.WriteLine("Line: ");
                Console.WriteLine("1: TODO");
                Console.WriteLine("2: IN PROGRESS");
                Console.WriteLine("3: DONE");
                Console.WriteLine("Default = TODO");
                selection = int.Parse(Console.ReadLine());
                Line line = Line.TODO;

                switch (selection)
                {
                    case 1: line = Line.TODO; break;
                    case 2: line = Line.IN_PROGRESS; break;
                    case 3: line = Line.DONE; break;
                    default: Console.WriteLine("Do not try me, please."); break;
                }


                mainList.Add(new Card(title, description, selectedMember, size, line));

            }
            catch (FormatException e)
            {
                System.Console.WriteLine("Data type incorrect");
            }
            
        }

        public static void deleteCard(List<Card> mainList)
        {
            try
            {
                Console.WriteLine("Write title of card you want to delete.");
                Console.Write("Title: ");
                string titleToDelete = Console.ReadLine();
                int indexTitleToDelete = mainList.FindIndex(r => r.Title == titleToDelete);

                if (indexTitleToDelete == -1)
                {
                    Console.WriteLine("Cannot find the card");
                }
                else
                {
                    mainList.RemoveAt(indexTitleToDelete);
                }
            }
            catch (FormatException e)
            {
                System.Console.WriteLine("Data type incorrect");
            }

        }

        public static void updateCard(List<Card> mainList)
        {
            try
            {
                Console.WriteLine("Write title of card you want to update.");
                Console.Write("Title: ");
                string titleToUpdate = Console.ReadLine();
                int indexTitleToUpdate = mainList.FindIndex(r => r.Title == titleToUpdate);

                if (indexTitleToUpdate == -1)
                {
                    Console.WriteLine("Cannot find the card");
                }
                else
                {
                    Console.WriteLine("Card details: \n*****************");
                    Console.WriteLine("Title       : " + mainList[indexTitleToUpdate].Title);
                    Console.WriteLine("Description : " + mainList[indexTitleToUpdate].Description);
                    Console.WriteLine("Member      : " + mainList[indexTitleToUpdate].Member.Name);
                    Console.WriteLine("Size        : " + mainList[indexTitleToUpdate].Size);
                    Console.WriteLine("Line        : " + mainList[indexTitleToUpdate].Line);
                    Console.WriteLine("\nPlease choose the line you want card to move: ");
                    Console.WriteLine("(1) TODO");
                    Console.WriteLine("(2) IN PROGRESS");
                    Console.WriteLine("(3) DONE");
                    int selectedLine = int.Parse(Console.ReadLine());
                    if (selectedLine == 1) { mainList[indexTitleToUpdate].Line = Line.TODO; CardOperations.listTheBoard(mainList); }
                    else if (selectedLine == 2) { mainList[indexTitleToUpdate].Line = Line.IN_PROGRESS; CardOperations.listTheBoard(mainList); }
                    else if (selectedLine == 3) { mainList[indexTitleToUpdate].Line = Line.DONE; CardOperations.listTheBoard(mainList); }
                    else { Console.WriteLine("Incorrect value entered."); }

                }
            }
            catch (FormatException e)
            {
                System.Console.WriteLine("Data type incorrect");
            }

            
        }
    }
}
