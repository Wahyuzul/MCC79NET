using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Authentication
{
    internal class User
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }

        public string Name => $"{FirstName} {LastName}";
        public string Username => $"{FirstName.Substring(0, 2)}{LastName.Substring(0, 2)}";

        public User(int ID, string FirstName, string LastName, string Password)
        {
            this.ID = ID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Password = Password;
        }

        public static List<User> users = new List<User>();
        static int userID = 1;

        public static void CreateUser()
        {
            Console.WriteLine("=====CREATE USER=====");
            string FirstName;
            do
            {
                Console.Write("First Name: ");
                FirstName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(FirstName) || FirstName.Length < 2)
                {
                    Console.WriteLine("Name must consist of at least 2 characters or more!!!");
                    Console.WriteLine();
                }
            } while (string.IsNullOrWhiteSpace(FirstName) || FirstName.Length < 2);

            string LastName;
            do
            {
                Console.Write("Last Name: ");
                LastName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(LastName) || LastName.Length < 2)
                {
                    Console.WriteLine("Name must consist of at least 2 characters or more!!!!");
                    Console.WriteLine();
                }
            } while (string.IsNullOrWhiteSpace(LastName) || LastName.Length < 2);

            string Password;
            do
            {
                Console.Write("Password: ");
                Password = Console.ReadLine();
                if (!ValidPassword(Password) || Password.Length < 6)
                {
                    Console.WriteLine("Password must have at least 6 characters consisting of at least 1 uppercase letter, 1 lowercase letter, and 1 number!!!");
                    Console.WriteLine();
                }

            } while (!ValidPassword(Password));

            User newUser = new User(userID, FirstName, LastName, Password);
            users.Add(newUser);
            Console.WriteLine("User Success to Created");
            userID++;
            Console.ReadKey();
            Console.Clear();
            Program.MainMenu();
        }
        static bool ValidPassword(string password)
        {
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{6,}$";
            return Regex.IsMatch(password, pattern);
        }

        public static void ShowUser()
        {
            Console.WriteLine("======SHOW USER======");
            if (users.Count == 0)
            {
                Console.WriteLine();
            }
            else
            {
                foreach (User user in users)
                {
                    Console.WriteLine("======================================");
                    Console.WriteLine($"ID: {user.ID}");
                    Console.WriteLine($"Name: {user.Name}");
                    Console.WriteLine($"Username: {user.Username}");
                    Console.WriteLine($"Password: {user.Password}");
                    Console.WriteLine("======================================");
                }
            }

            Console.WriteLine("Menu:");
            Console.WriteLine("1. Edit User");
            Console.WriteLine("2. Delete USer");
            Console.WriteLine("3. Back");
            Console.Write("Select Menu: ");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Input cannot be empty.");
                Console.ReadKey();
                Console.Clear();
                ShowUser();

            }
            else if (!int.TryParse(input, out int Input))
            {
                Console.WriteLine("Input must be a number.");
                Console.ReadKey();
                Console.Clear();
                ShowUser();
            }
            else if (int.TryParse(input, out int choice))
            {
                switch (choice)
                {
                    case 1:
                        EditUser();
                        break;
                    case 2:
                        DeleteUser();
                        break;
                    case 3:
                        Console.Clear();
                        Program.MenuAdmin();
                        break;
                    default:
                        Console.WriteLine("Input invalid!!!");
                        break;
                }
            }
        }

        static void EditUser()
        {
            Console.Write("Enter ID you want change: ");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("User ID cannot be empty.");
                Console.ReadKey();
                Console.Clear();
                ShowUser();

            }
            if (!int.TryParse(input, out int userId))
            {
                Console.WriteLine("User ID must be a number.");
                Console.ReadKey();
                Console.Clear();
                ShowUser();
            }

            User editUser = users.Find(user => user.ID == userId);

            if (editUser == null)
            {
                Console.WriteLine("User not found.");
                Console.ReadKey();
                Console.Clear();
                ShowUser();
            }
            else
            {
                string newFirstName;
                do
                {
                    Console.Write("First Name: ");
                    newFirstName = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(newFirstName) || newFirstName.Length < 2)
                    {
                        Console.WriteLine("Name must consist of at least 2 characters or more!!!!");
                        Console.WriteLine();
                    }
                } while (string.IsNullOrWhiteSpace(newFirstName) || newFirstName.Length < 2);

                string newLastName;
                do
                {
                    Console.Write("Last Name: ");
                    newLastName = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(newLastName) || newLastName.Length < 2)
                    {
                        Console.WriteLine("Name must consist of at least 2 characters or more!!!!");
                        Console.WriteLine();
                    }
                } while (string.IsNullOrWhiteSpace(newLastName) || newLastName.Length < 2);

                string newPassword;
                do
                {
                    Console.Write("Password: ");
                    newPassword = Console.ReadLine();
                    if (!ValidPassword(newPassword) || newPassword.Length < 6)
                    {
                        Console.WriteLine("Password must have at least 6 characters consisting of at least 1 uppercase letter, 1 lowercase letter, and 1 number!!!");
                        Console.WriteLine();
                    }

                } while (!ValidPassword(newPassword));

                editUser.FirstName = newFirstName;
                editUser.LastName = newLastName;
                editUser.Password = newPassword;

                Console.WriteLine("User Success to Edited!!!");
                Console.ReadKey();
                Console.Clear();
                Program.MenuAdmin();
            }
        }

        static void DeleteUser()
        {
            Console.Write("Enter ID to delete: ");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("User ID cannot be empty.");
                Console.ReadKey();
                Console.Clear();
                ShowUser();


            }
            if (!int.TryParse(input, out int userId))
            {
                Console.WriteLine("User ID must be a number.");
                Console.ReadKey();
                Console.Clear();
                ShowUser();
            }

            User deleteUser = users.Find(user => user.ID == userId);

            if (deleteUser == null)
            {
                Console.WriteLine("User not found!!!.");
                DeleteUser();
            }
            else
            {
                users.Remove(deleteUser);
                ResetID();
                Console.WriteLine("User Success to Deleted!!!");
                Console.ReadKey();
                Console.Clear();
                Program.MenuAdmin();
            }
        }
        static void ResetID()
        {
            userID = 1;
            foreach (User user in users)
            {
                user.ID = userID;
                userID++;
            }
        }

        public static void SearchUser()
        {
            Console.WriteLine("=====SEARCH USER=====");
            Console.Write("Enter name to search: ");
            string search = Console.ReadLine();

            List<User> searchUser = users.FindAll(user =>
                user.Name.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0);

            if (searchUser.Count == 0 || string.IsNullOrWhiteSpace(search))
            {
                Console.WriteLine("User not found!!!");
                Console.WriteLine("enter any key for back");
            }
            else
            {
                foreach (User user in searchUser)
                {
                    Console.WriteLine("======================================");
                    Console.WriteLine($"ID: {user.ID}");
                    Console.WriteLine($"Name: {user.Name}");
                    Console.WriteLine($"Username: {user.Username}");
                    Console.WriteLine($"Password: {user.Password}");
                    Console.WriteLine("======================================");
                }
            }
            Console.ReadKey();
            Console.Clear();
            Program.MenuAdmin();
        }

        public static void Login()
        {
            Console.WriteLine("=====LOGIN=====");
            Console.Write("Username: ");
            string username = Console.ReadLine();

            Console.Write("Password: ");
            string password = Console.ReadLine();

            String adminUsername = "admin";
            string adminPassword = "admin";

            User loginUser = users.Find(user =>
                string.Equals(user.Username, username, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(user.Password, password));

            if (username == adminUsername && password == adminPassword)
            {
                Console.Clear();
                Program.MenuAdmin();

            }

            else if (loginUser == null)
            {
                Console.WriteLine("Username or Password is incorrect!!!");
                Console.WriteLine("enter any key for back.");
                Console.ReadKey();
                Console.Clear();
                Program.MainMenu();
            }

            else if (username == loginUser.Username && password == loginUser.Password)
            {
                Console.WriteLine("Login successful.");
                Console.ReadKey();
                Console.Clear();
                Program.MenuUser();
            }
        }
    }
}


