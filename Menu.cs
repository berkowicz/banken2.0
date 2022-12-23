namespace banken3
{
    public class Menu
    {
        #region //MainMenu()
        public static void MainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome, {0}", User.activeUsername);
                Console.WriteLine("What whould you like to do?");
                Console.WriteLine("---------------------------");
                Console.WriteLine("1. Accounts/Balance");
                Console.WriteLine("2. Transfer");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("E. Logout");
                Console.WriteLine("---------------------------");
                Console.Write("Enter a choice: ");

                string choice = Console.ReadLine().ToLower();

                switch (choice)
                {
                    case "1":
                        AccountsMenu();
                        break;
                    case "2":
                        TransferMenu();
                        break;
                    case "3":
                        WithdrawMenu();
                        break;
                    case "e": //Log out user and initialize login function
                        Console.Clear();
                        Console.WriteLine("\nYou are now logged out!");
                        Console.WriteLine("Press Enter to login again...");
                        Console.ReadLine();
                        User.userLogedIn = -1;
                        User.LoginUser();
                        break;
                    default:
                        Console.WriteLine("You did not enter one of the options");
                        Console.ReadLine();
                        break;
                }
            }
        }
        #endregion

        #region //AccpountsMenu()
        public static void AccountsMenu()
        {
            bool menu = true;
            while (menu)
            {
                Console.Clear();
                Console.WriteLine("Accounts & Balance");
                Console.WriteLine("What whould you like to do?");
                Console.WriteLine("---------------------------");
                Console.WriteLine("1. View Balance");
                Console.WriteLine("E. Exit");
                Console.WriteLine("---------------------------");
                Console.Write("Enter a choice: ");

                string choice = Console.ReadLine().ToLower();

                switch (choice)
                {
                    case "1":
                        User.PrintAccount();
                        break;
                    case "e":
                        menu = false;
                        break;
                    default:
                        Console.WriteLine("You did not enter one of the options");
                        Console.ReadLine();
                        break;
                }
            }
        }
        #endregion

        #region //TransferMenu()
        public static void TransferMenu()
        {
            bool menu = true;
            while (menu)
            {
                Console.Clear();
                Console.WriteLine("Transfer");
                Console.WriteLine("What whould you like to do?");
                Console.WriteLine("---------------------------");
                Console.WriteLine("1. Transfer (own accounts)");
                Console.WriteLine("E. Exit");
                Console.WriteLine("---------------------------");
                Console.Write("Enter a choice: ");

                string choice = Console.ReadLine().ToLower();

                switch (choice)
                {
                    case "1":
                        User.Transfer();
                        break;
                    case "e":
                        menu = false;
                        break;
                    default:
                        Console.WriteLine("You did not enter one of the options");
                        Console.ReadLine();
                        break;
                }
            }
        }
        #endregion

        #region //WithdrawMenu()
        public static void WithdrawMenu()
        {
            bool menu = true;
            while (menu)
            {
                Console.Clear();
                Console.WriteLine("Withdraw");
                Console.WriteLine("What whould you like to do?");
                Console.WriteLine("---------------------------");
                Console.WriteLine("1. Withdraw");
                Console.WriteLine("E. Exit");
                Console.WriteLine("---------------------------");
                Console.Write("Enter a choice: ");

                string choice = Console.ReadLine().ToLower();

                switch (choice)
                {
                    case "1":
                        User.Withdraw();
                        break;
                    case "e":
                        menu = false;
                        break;
                    default:
                        Console.WriteLine("You did not enter one of the options");
                        Console.ReadLine();
                        break;
                }
            }
        }
        #endregion
    }
}
