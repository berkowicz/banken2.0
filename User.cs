namespace banken3
{
    public class User
    {
        #region //User info
        public static int userLogedIn = 999999;
        public static string activeUsername;

        private static string[] username = { "Daniel", "Bengan", "Michelle", "David", "Lars" };
        //public static string[] usernameCopy = username;
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

        #region //LoginUser()
        public static void LoginUser()
        {
            int attempts = 3;
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
                        userLogedIn = j;
                        activeUsername = username[j];
                        j = username.Length;
                        i = 3;
                        break;
                    }
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

        public static void PrintSaldo()
        {
            Console.Clear();
            for (int i = 0; i < account[userLogedIn].Length; i++)
            {
                Console.WriteLine("{0}: {1}", account[userLogedIn][i], balance[userLogedIn][i]);
            }
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }

        #region //Transfer()
        public static void Transfer()
        {
            Console.Clear();
            Console.WriteLine("Select account to tranfer from");
            for (int i = 0; i < account[userLogedIn].Length; i++)
            {
                Console.WriteLine("{0}. {1}: {2}", i + 1, account[userLogedIn][i], balance[userLogedIn][i]);
            }
            Console.Write("\nFrom: ");
            bool from = Int32.TryParse(Console.ReadLine(), out int accFrom);
            Console.Write("To: ");
            bool to = Int32.TryParse(Console.ReadLine(), out int accTo);
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
                    if (amount > balance[userLogedIn][accFrom])
                    {
                        Console.WriteLine("You can't transfer more then your account contains");
                    }
                    else if (transfer)
                    {
                        balance[userLogedIn][accFrom] -= amount;
                        balance[userLogedIn][accTo] += amount;
                        Console.WriteLine("\nComplete!\nNew saldo");
                        Console.WriteLine("{0}: {1}", account[userLogedIn][accFrom], balance[userLogedIn][accFrom]);
                        Console.WriteLine("{0}: {1}", account[userLogedIn][accTo], balance[userLogedIn][accTo]);
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("You didn't enter a correct input\nTry again");
                    }
                }
            }
        }
        #endregion


        public static void Withdraw()
        {
            Console.Clear();
            Console.WriteLine("Select account to withdraw from");
            for (int i = 0; i < account[userLogedIn].Length; i++)
            {
                Console.WriteLine("{0}. {1}: {2}", i + 1, account[userLogedIn][i], balance[userLogedIn][i]);
            }
            Console.Write("\nFrom: ");
            bool from = Int32.TryParse(Console.ReadLine(), out int accFrom);
            accFrom -= 1;
            if (!from)
            {
                Console.WriteLine("You did not enter a correct input");
            }
            else
            {
                while (true)
                {
                    Console.WriteLine("Enter ammount to withdraw: ");
                    bool transfer = Decimal.TryParse(Console.ReadLine(), out decimal amount);
                    if (amount > balance[userLogedIn][accFrom])
                    {
                        Console.WriteLine("You can't withdraw more then your account contains");
                    }
                    else if (transfer)
                    {
                        Console.WriteLine("Enter your pin to complete: ");
                        string withdrawPin = Console.ReadLine();
                        if (withdrawPin.Equals(pin[userLogedIn]))
                        {
                            balance[userLogedIn][accFrom] -= amount;
                            Console.WriteLine("\nComplete!\nNew saldo");
                            Console.WriteLine("{0}: {1}", account[userLogedIn][accFrom], balance[userLogedIn][accFrom]);
                            Console.WriteLine("Press Enter to continue...");
                            Console.ReadLine();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Wrong pin, please try again");
                        }

                    }
                    else
                    {
                        Console.WriteLine("You didn't enter a correct input\nTry again");
                    }
                }
            }
        }
    }

}
