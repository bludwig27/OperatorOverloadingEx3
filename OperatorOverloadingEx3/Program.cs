using System;

namespace OperatorOverloadingEx3
{
    public class Pack
    {
        public string Name { get; set; }
        public int Males { get; set; }
        public int Females { get; set; }
        public int Territory { get; set; }
        public static Pack operator++(Pack pack)
        {
            pack.Females++;
            return pack;
        }
        public static Pack operator --(Pack pack)
        {
            pack.Females--;
            return pack;
        }
        public static Pack operator +(Pack pack, int i)
        {
            pack.Territory += i;
            return pack;
        }
        public static bool operator <(Pack pack1, Pack pack2)
        {
            bool smaller = false;
            if (pack1.Territory < pack2.Territory) smaller = true;
            return smaller;
        }
        public static bool operator >(Pack pack1, Pack pack2)
        {
            bool larger = false;
            if (pack1.Territory > pack2.Territory) larger = true;
            return larger;
        }
        public static bool operator ==(Pack pack1, Pack pack2)
        {
            bool equal = false;
            if (pack1.Territory== pack2.Territory) equal = true;
            return equal;
        }
        public static bool operator !=(Pack pack1, Pack pack2)
        {
            bool unequal = false;
            if (pack1.Territory != pack2.Territory) unequal = true;
            return unequal;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Pack[] myPack = new Pack[10];
            for (int i = 0; i < myPack.Length; i++)
            {
                myPack[i] = new Pack();
            }
            Console.WriteLine("Welcome to the Isle Royale Wolf Pack tracking program!");
            int index = 0;
            int entry = 0;
            string answer;
            int selection = Menu();
            while (selection != 5)
            {
                switch (selection)
                {
                    case 1:
                        if (index < 10)
                        {
                            Console.Write("Enter name of new wolf pack: ");
                            myPack[index].Name = Console.ReadLine();
                            Console.WriteLine();
                            Console.Write("Number of females in the pack: ");
                            myPack[index].Females = int.Parse(Console.ReadLine());
                            Console.WriteLine();
                            Console.Write("Number of males in the pack: ");
                            myPack[index].Males = int.Parse(Console.ReadLine());
                            Console.WriteLine();
                            Console.Write("Territory size (sq. mi.): ");
                            myPack[index].Territory = int.Parse(Console.ReadLine());
                            Console.WriteLine();
                            index++;
                        }
                        else
                        {
                            Console.WriteLine("Too many entries! This program can only hold 10.");
                        }
                        break;
                    case 2:
                        for (int i = 0; i < myPack.Length; i++)
                        {
                            if (myPack[i].Name != null && myPack[i].Name != "")
                            {
                                Console.WriteLine($"Pack {i + 1}: {myPack[i].Name}");
                                Console.WriteLine($"Females: {myPack[i].Females}  Males: {myPack[i].Males}");
                                Console.WriteLine($"Total pack members: {myPack[i].Females + myPack[i].Males}");
                                Console.WriteLine($"Territory: {myPack[i].Territory} square miles");
                            }
                        }
                        break;
                    case 3:
                        entry = pickEntry(index);
                        Console.WriteLine("Current record:");
                        Console.WriteLine($"Pack {entry+1}: {myPack[entry].Name}");
                        Console.WriteLine($"Females: {myPack[entry].Females}  Males: {myPack[entry].Males}");
                        Console.WriteLine($"Total pack members: {myPack[entry].Females + myPack[entry].Males}");
                        Console.WriteLine($"Territory: {myPack[entry].Territory} square miles");
                        Console.Write("Would you like to increase the number of females by 1? Y for yes.");
                        answer = Console.ReadLine();
                        if (answer == "Y" || answer == "y")
                        {
                            myPack[entry]++;
                            Console.WriteLine("Done!");
                        }
                        Console.Write("Would you like to decrease the number of females by 1? Y for yes.");
                        answer = Console.ReadLine();
                        if (answer == "Y" || answer == "y")
                        {
                            myPack[entry]--;
                            Console.WriteLine("Done!");
                        }
                        Console.Write("Would you like to increase the number of males by 1? Y for yes.");
                        answer = Console.ReadLine();
                        if (answer == "Y" || answer == "y")
                        {
                            myPack[entry].Males++;
                            Console.WriteLine("Done!");
                        }
                        Console.Write("Would you like to decrease the number of males by 1? Y for yes.");
                        answer = Console.ReadLine();
                        if (answer == "Y" || answer == "y")
                        {
                            myPack[entry].Males--;
                            Console.WriteLine("Done!");
                        }
                        Console.WriteLine($"Current territory size is {myPack[entry].Territory} square miles.");
                        Console.Write("How much would you like to add? (Enter a negative number to subtract, or 0 to leave as is.) ");
                        answer = Console.ReadLine();
                        int mi = Convert.ToInt32(answer);
                        myPack[entry] += mi;
                        Console.WriteLine($"The new territory size for pack {entry} is {myPack[entry].Territory}.");
                        break;
                    case 4:
                        Console.Write($"What entry (1 through {index}) should be the base of the comparison? ");
                        int choice = Convert.ToInt32(Console.ReadLine());
                        choice -= 1;
                        Console.WriteLine($"You have selected the {myPack[choice].Name} pack.");
                        Console.Write($"What entry (1 through {index}) should be compared to? ");
                        int choice2 = Convert.ToInt32(Console.ReadLine());
                        choice2 -= 1;
                        Console.WriteLine($"You have selected the {myPack[choice2].Name} pack.");
                        Console.WriteLine();
                        Console.WriteLine("Between the two of them...");
                        if (myPack[choice] > myPack[choice2])
                        {
                            Console.WriteLine($"{myPack[choice].Name} has more territory.");
                        }
                        else if (myPack[choice] < myPack[choice2])
                        {
                            Console.WriteLine($"{myPack[choice2].Name} has more territory.");
                        }
                        else
                        {
                            Console.WriteLine("The packs have equal territory.");
                        }
                        if (myPack[choice].Females > myPack[choice2].Females)
                        {
                            Console.WriteLine($"{myPack[choice].Name} has more females.");
                        }
                        else if (myPack[choice].Females < myPack[choice2].Females)
                        {
                            Console.WriteLine($"{myPack[choice2].Name} has more females.");
                        }
                        else
                        {
                            Console.WriteLine("The packs have an equal number of females.");
                        }
                        if (myPack[choice].Males > myPack[choice2].Males)
                        {
                            Console.WriteLine($"{myPack[choice].Name} has more males.");
                        }
                        else if (myPack[choice].Males < myPack[choice2].Males)
                        {
                            Console.WriteLine($"{myPack[choice2].Name} has more males.");
                        }
                        else
                        {
                            Console.WriteLine("The packs have an equal number of males.");
                        }
                        if ((myPack[choice].Males + myPack[choice].Females) > (myPack[choice2].Males + myPack[choice2].Females))
                        {
                            Console.WriteLine($"{myPack[choice].Name} has the most total members.");
                        }
                        else if ((myPack[choice].Males + myPack[choice].Females) < (myPack[choice2].Males + myPack[choice2].Females))
                        {
                            Console.WriteLine($"{myPack[choice2].Name} has the most total members.");
                        }
                        else
                        {
                            Console.WriteLine("The packs have an equal number of total members.");
                        }
                        break;
                }
                selection = Menu();
            }
        }
            public static int Menu()
            {
                int choice = 0;
                Console.WriteLine("Please choose from the following:");
                Console.WriteLine("1 - Add a new pack");
                Console.WriteLine("2 - Display pack information");
                Console.WriteLine("3 - Update pack information");
                Console.WriteLine("4 - Compare packs");
                Console.WriteLine("5 - Quit");
                while (!int.TryParse(Console.ReadLine(), out choice))
                    Console.WriteLine("Please select 1 - 5");
                return choice;
            }
            public static int pickEntry(int index)
            {
                Console.WriteLine("What entry would you like to change?");
                Console.WriteLine($"1 through {index}");
                int entry;
                while (!int.TryParse(Console.ReadLine(), out entry))
                    Console.WriteLine($"Please select 1 - {index}");
                entry -= 1;  // subtract 1 to begin index at 0
                return entry;
            }
        }
    }
