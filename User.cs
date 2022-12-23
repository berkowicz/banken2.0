namespace banken3
{
    public class User
    {
        #region //User data
        public static int userLogedIn = -1; //Index of logged in user
        public static string activeUsername; //Used to print welcome message in menu

        private static string[] username = { "Daniel", "Bengan", "Michelle", "David", "Lars" };
        private static string[] pin = { "1337", "2222", "3333", "4444", "5555" };

        private static string[][] account =
        {
            new string[] { "Salary", "Savings" },
            new string[] { "Salary", "Savings", "Stolen" },
            new string[] { "Salary", "Savings", "Stolen", "Stocks" },
            new string[] { "Salary", "Savings", "Stolen", "Stocks", "Pension" },
            new string[] { "Salary", "Savings", "Stolen", "Stocks", "Pension", "House" }
        };

        private static decimal[][] balance =
        {
            new decimal[] { 50000.00M, 2000.00M },
            new decimal[] { 50000.00M, 2000.00M, 90.00M },
            new decimal[] { 50000.00M, 2000.00M, 90.00M, 200000.00M },
            new decimal[] { 50000.00M, 2000.00M, 90.00M, 200000.00M, 5000000.00M },
            new decimal[] { 50000.00M, 2000.00M, 90.00M, 200000.00M, 5000000.00M, 300000.00M }
        };
        #endregion

        #region //LoginUser(); Handles userlogin and userindex
        public static void LoginUser()
        {
            Console.Clear();
            int attempts = 3; //Countdown counter for loggin attempts
            Console.WriteLine("Login");
            for (int i = 0; i <= 2; i++)
            {
                Console.Write("\nEnter username: ");
                string tempUsername = Console.ReadLine();
                Console.Write("Enter pin: ");
                string tempPin = Console.ReadLine();

                for (int j = 0; j < username.Length; j++)
                {
                    //Login successful
                    if (username[j].Equals(tempUsername) && pin[j].Equals(tempPin))
                    {
                        Console.WriteLine("Login Successful");
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        userLogedIn = j; //sets an index of whom is logged in
                        activeUsername = username[j]; //Sets active username
                        j = username.Length; //Breaks out of the outer forloop
                        i = 3;
                        break;
                    }
                    //Controlls and prints counter
                    else if (j == username.Length - 1)
                    {
                        --attempts;
                        Console.WriteLine("Login failed");
                        Console.WriteLine("{0} attemps left", attempts);
                    }
                }
                //Exits program if 3 failed attempts
                if (i == 2)
                {
                    Console.WriteLine("\nToo many failed attempts. Program will now Exit");
                    Environment.Exit(0);
                }
            }
        }
        #endregion

        #region //PrintAccount(); Prints out account and balance
        public static void PrintAccount()
        {
            Console.Clear();
            //Loops the exakt amount of accounts the user got, and print it.
            for (int i = 0; i < account[userLogedIn].Length; i++)
            {
                Console.WriteLine("{0}: {1}", account[userLogedIn][i], balance[userLogedIn][i]);
            }
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
        #endregion

        #region //Transfer(); Transfers money between own accounts
        public static void Transfer()
        {
            Console.Clear();
            Console.WriteLine("Select account to tranfer from");
            //Prints out all users accounts & balances
            for (int i = 0; i < account[userLogedIn].Length; i++)
            {
                Console.WriteLine("{0}. {1}: {2}", i + 1, account[userLogedIn][i], balance[userLogedIn][i]);
            }
            Console.Write("\nFrom: ");
            bool from = Int32.TryParse(Console.ReadLine(), out int accFrom);
            Console.Write("To: ");
            bool to = Int32.TryParse(Console.ReadLine(), out int accTo);
            //-1 to equal the index of the account
            accTo -= 1;
            accFrom -= 1;
            if (!from || !to)
            {
                Console.WriteLine("You did not enter a correct input");
            }
            else
            {
                while (true)
                {
                    Console.WriteLine("Enter ammount to transfer: ");
                    bool transfer = Decimal.TryParse(Console.ReadLine(), out decimal amount);

                    //Checks if money is avalible on account
                    if (amount > balance[userLogedIn][accFrom])
                    {
                        Console.WriteLine("You can't transfer more then your account contains");
                    }
                    //Transfers money
                    else if (transfer)
                    {
                        balance[userLogedIn][accFrom] -= amount;
                        balance[userLogedIn][accTo] += amount;
                        Console.WriteLine("\nComplete!\nNew balance");
                        Console.WriteLine("{0}: {1}", account[userLogedIn][accFrom], balance[userLogedIn][accFrom]);
                        Console.WriteLine("{0}: {1}", account[userLogedIn][accTo], balance[userLogedIn][accTo]);
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        break;
                    }
                    //Catch faulty input
                    else
                    {
                        Console.WriteLine("You didn't enter a correct input\nTry again");
                    }
                }
            }
        }
        #endregion

        #region //Withdraw(); Withdraws money from account
        public static void Withdraw()
        {
            Console.Clear();
            Console.WriteLine("Select account to withdraw from");
            //Prints out all users accounts & balances
            for (int i = 0; i < account[userLogedIn].Length; i++)
            {
                Console.WriteLine("{0}. {1}: {2}", i + 1, account[userLogedIn][i], balance[userLogedIn][i]);
            }
            Console.Write("\nFrom: ");
            bool from = Int32.TryParse(Console.ReadLine(), out int accFrom);
            //-1 to equal the index of the account
            accFrom -= 1;
            if (!from)
            {
                Console.WriteLine("You did not enter a correct input");
            }
            else
            {
                Console.WriteLine("Enter ammount to withdraw: ");
                bool transfer = Decimal.TryParse(Console.ReadLine(), out decimal amount);

                //Checks if money is avalible on account
                if (amount > balance[userLogedIn][accFrom])
                {
                    Console.WriteLine("You can't withdraw more then your account contains");
                }
                //Money is avalible & input got parsed
                else if (transfer)
                {
                    int attempts = 3; //Countdown counter for loggin attempts
                    while (true)
                    {
                        //Catches 3 failed attemps
                        if (attempts == 0)
                        {
                            Console.WriteLine("\nToo many failed attempts.");
                            Console.WriteLine("Press Enter to continue...");
                            Console.ReadLine();
                            break;
                        }
                        Console.WriteLine("Enter your pin to complete: ");
                        string withdrawPin = Console.ReadLine();

                        //Controlls and prints counter
                        if (!withdrawPin.Equals(pin[userLogedIn]))
                        {
                            --attempts;
                            Console.WriteLine("Verification failed");
                            Console.WriteLine("{0} attemps left\n", attempts);
                        }
                        //Withdraws money
                        else if (withdrawPin.Equals(pin[userLogedIn]))
                        {
                            balance[userLogedIn][accFrom] -= amount;
                            Console.WriteLine("\nComplete!\nNew balance");
                            Console.WriteLine("{0}: {1}", account[userLogedIn][accFrom], balance[userLogedIn][accFrom]);
                            Console.WriteLine("Press Enter to continue...");
                            Console.ReadLine();
                            break;
                        }
                        //Catch faulty input
                        else
                        {
                            Console.WriteLine("Wrong pin, please try again");
                        }

                    }
                }
                //Catch faulty input
                else
                {
                    Console.WriteLine("You didn't enter a correct input\nTry again");
                }

            }
        }
        #endregion
    }
}
