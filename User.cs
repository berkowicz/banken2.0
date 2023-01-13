namespace banken3
{
    internal class User
    {
        #region //User data
        internal static int userLogedIn = -1; //Index of logged in user
        internal static string activeUsername; //Used to print welcome message in menu

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
        internal static void LoginUser() //Handles userlogin and userindex
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
                        EnterToContinue();
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
                if (attempts == 0)
                {
                    Exit();
                }
            }
        }

        internal static void PrintAccount() //Prints out account and balance
        {
            Console.Clear();
            //Loops the exakt amount of accounts the user got, and print it.
            for (int i = 0; i < account[userLogedIn].Length; i++)
            {
                Console.WriteLine("{0}: {1}", account[userLogedIn][i], balance[userLogedIn][i]);
            }
            EnterToContinue();
        }

        internal static void Transfer() //Transfers money between own accounts
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
            if (accFrom >= account[userLogedIn].Length || accTo >= account[userLogedIn].Length || accFrom < 0 || accTo < 0)
            {
                IncorrectInput();
                EnterToContinue();
            }
            else
            {
                while (true)
                {
                    Console.WriteLine("Enter ammount to transfer: ");
                    bool transfer = Decimal.TryParse(Console.ReadLine(), out decimal amount);

                    //Checks for positive input value
                    if (amount > 0)
                    {
                        //Checks if money is avalible on account
                        if (amount > balance[userLogedIn][accFrom])
                        {
                            Console.WriteLine("You can't transfer more then your account contains");
                            EnterToContinue();
                            break;
                        }
                        //Transfers money
                        else if (transfer)
                        {
                            balance[userLogedIn][accFrom] -= amount;
                            balance[userLogedIn][accTo] += amount;
                            Console.WriteLine("\nComplete!\nNew balance");
                            Console.WriteLine("{0}: {1}", account[userLogedIn][accFrom], balance[userLogedIn][accFrom]);
                            Console.WriteLine("{0}: {1}", account[userLogedIn][accTo], balance[userLogedIn][accTo]);
                            EnterToContinue();
                            break;
                        }
                    }
                    //Catch faulty input
                    else
                    {
                        IncorrectInput();
                        EnterToContinue();
                        break;
                    }
                }
            }
        }

        internal static void Withdraw() //Withdraws money from account
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
            if (accFrom >= account[userLogedIn].Length && accFrom < 0)
            {
                IncorrectInput();
                EnterToContinue();
            }
            else
            {
                Console.WriteLine("Enter ammount to withdraw: ");
                bool transfer = Decimal.TryParse(Console.ReadLine(), out decimal amount);

                //Checks for positive input value
                if (amount > 0)
                {
                    //Checks if money is avalible on account
                    if (amount > balance[userLogedIn][accFrom])
                    {
                        Console.WriteLine("You can't withdraw more then your account contains");
                        EnterToContinue();
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
                                Exit();
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
                                EnterToContinue();
                                break;
                            }
                            //Catch faulty input
                            else
                            {
                                Console.WriteLine("Wrong pin, please try again");
                            }

                        }
                    }
                }
                //Catch faulty input
                else
                {
                    IncorrectInput();
                    EnterToContinue();
                }


            }
        }

        internal static void Exit() //Exit program
        {
            Console.WriteLine("\nToo many failed attempts. Program will now Exit");
            Environment.Exit(0);
        }

        internal static void EnterToContinue() //Enter to continue
        {
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }

        internal static void IncorrectInput()
        {
            Console.WriteLine("You didn't enter a correct input\nTry again");
        }
    }
}