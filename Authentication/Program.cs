using System;

namespace Authentication
{
    public class Program
    {
        static void Main(string[] args)
        {
            MainMenu();
        }

        public static void MainMenu()
        {
            while (true)
            {

                Console.WriteLine("1. Login");
                Console.WriteLine("2. Register");
                Console.WriteLine("3. Exit");
                Console.Write("Menu: ");
                string input = Console.ReadLine() ?? "";

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Input cannot be empty.");
                    Console.ReadKey();
                    Console.Clear();
                    MainMenu();

                }
                else if (!int.TryParse(input, out int number))
                {
                    Console.WriteLine("Input must be a number.");
                    Console.ReadKey();
                    Console.Clear();
                    MainMenu();
                }
                else if (int.TryParse(input, out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            User.Login();
                            break;
                        case 2:
                            Console.Clear();
                            User.CreateUser();
                            break;
                        case 3:
                            System.Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine();
                            break;
                    }
                }
            }
        }
        public static void MenuAdmin()
        {
            while (true)
            {
                Console.WriteLine("=====ADMIN MENU=====");
                Console.WriteLine("-------------------------------");
                Console.WriteLine("1. Show User");
                Console.WriteLine("2. Search User");
                Console.WriteLine("3. Logout");
                Console.WriteLine("4. Exit");
                Console.WriteLine("-------------------------------");
                Console.Write("Input : ");
                string input = Console.ReadLine() ?? "";
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Input cannot be empty.");
                    Console.ReadKey();
                    Console.Clear();
                    MenuAdmin();

                }
                else if (!int.TryParse(input, out int number))
                {
                    Console.WriteLine("Input must be a number.");
                    Console.ReadKey();
                    Console.Clear();
                    MenuAdmin();
                }
                else if (int.TryParse(input, out int choice))
                {
                    Console.Clear();
                    switch (choice)
                    {
                        case 1:
                            User.ShowUser();
                            Console.Clear();
                            break;
                        case 2:
                            User.SearchUser();
                            Console.Clear();
                            break;
                        case 3:
                            Console.WriteLine("Logout Successful!!!");
                            Console.ReadKey();
                            Console.Clear();
                            MainMenu();
                            break;
                        case 4:
                            System.Environment.Exit(0);
                            Console.Clear();
                            break;
                        default:
                            Console.WriteLine("Invalid input");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }
                }
            }
        }

        public static void MenuUser()
        {
            while (true)
            {
                Console.WriteLine("==============================================");
                Console.WriteLine("              MENU GANJIL GENAP");
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("1. Cek Ganjil Genap");
                Console.WriteLine("2. Print Ganjil/Genap (dengan limit)");
                Console.WriteLine("3. Logout");
                Console.WriteLine("4. Exit");
                Console.WriteLine("----------------------------------------------");
                Console.Write("Pilihan: ");
                string input = Console.ReadLine() ?? "";

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Input cannot be empty.");
                    Console.ReadKey();
                    Console.Clear();
                    MenuUser();

                }
                else if (!int.TryParse(input, out int number))
                {
                    Console.WriteLine("Input must be a number.");
                    Console.ReadKey();
                    Console.Clear();
                    MenuUser();
                }
                else if (int.TryParse(input, out int choice))
                {
                    Console.Clear();
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Masukan Bilangan yang ingin di cek: ");
                            int bilangan = Convert.ToInt32(Console.ReadLine());
                            EventOddCheck(bilangan);
                            Console.WriteLine();
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        case 2:
                            Console.Write("Pilih (Ganjil/Genap): ");
                            string inputBilangan = Console.ReadLine() ?? "";
                            if (inputBilangan == "Ganjil")
                            {
                                Console.Write("Masukan Limit: ");
                                int limit = Convert.ToInt32(Console.ReadLine());
                                if (limit > 0)
                                {
                                    PrintEvenOdd(limit, inputBilangan);
                                }
                                else
                                {
                                    Console.WriteLine("Input limit tidak valid!!!");
                                    Console.WriteLine();
                                }
                            }
                            else if (inputBilangan == "Genap")
                            {
                                Console.Write("Masukan Limit: ");
                                int limit = Convert.ToInt32(Console.ReadLine());
                                if (limit > 0)
                                {
                                    PrintEvenOdd(limit, inputBilangan);
                                }
                                else
                                {
                                    Console.WriteLine("Input limit tidak valid!!!");
                                    Console.WriteLine();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Input pilihan tidak valid!!!");
                                Console.WriteLine();
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        case 3:
                            Console.WriteLine("Logout Successful!!!");
                            Console.ReadKey();
                            Console.Clear();
                            MainMenu();
                            break;
                        case 4:
                            System.Environment.Exit(0);
                            break;

                        default:
                            Console.WriteLine("Pilihan tidak valid!!!");
                            Console.WriteLine();
                            Console.ReadKey();
                            Console.Clear();
                            MenuUser();
                            break;
                    }
                }


                static void PrintEvenOdd(int limit, string choice)
                {
                    if (choice == "Ganjil")
                    {
                        Console.WriteLine($"Print bilangan 1-{limit}: ");
                        for (int i = 1; i <= limit; i++)
                        {
                            if (i % 2 == 1)
                            {
                                Console.Write(i);
                                Console.Write(" ");
                            }
                        }
                        Console.WriteLine();
                        Console.WriteLine();
                    }
                    else if (choice == "Genap")
                    {
                        Console.WriteLine($"Print bilangan 1-{limit}: ");
                        for (int i = 1; i <= limit; i++)
                        {
                            if (i % 2 == 0)
                            {

                                Console.Write(i);
                                Console.Write(" ");
                            }

                        }
                        Console.WriteLine();
                        Console.WriteLine();
                    }
                }

                static void EventOddCheck(int input)
                {
                    if (input % 2 == 0)
                    {
                        Console.WriteLine("Genap");
                    }
                    else
                    {
                        Console.WriteLine("Ganjil");
                    }
                }
            }
        }
    }
}
