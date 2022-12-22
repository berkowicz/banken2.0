namespace banken3
{
    public class Menu
    {
        public static void MainMenu()
        {
            bool menu = true;
            while (menu)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the bank");
                Console.WriteLine("What whould you like to do?");
                Console.WriteLine("---------------------------");
                Console.WriteLine("1. Accounts/Saldo");
                Console.WriteLine("2. Transfer");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("E. Exit");
                Console.WriteLine("---------------------------");
                Console.Write("Enter a choice: ");

                string? choice = Console.ReadLine().ToLower();

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

        public static void AccountsMenu()
        {
            bool menu = true;
            while (menu)
            {
                Console.Clear();
                Console.WriteLine("Welcome Accounts & Saldo");
                Console.WriteLine("What whould you like to do?");
                Console.WriteLine("---------------------------");
                Console.WriteLine("1. View saldo");
                Console.WriteLine("E. Exit");
                Console.WriteLine("---------------------------");
                Console.Write("Enter a choice: ");

                string? choice = Console.ReadLine().ToLower();

                switch (choice)
                {
                    case "1":
                        User.Accounts();
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

        public static void TransferMenu()
        {

        }

        public static void WithdrawMenu()
        {

        }
    }
}
