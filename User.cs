namespace banken3
{
    public class User
    {
        private static string[] username = { "Daniel", "Bengan", "Michelle" };
        private static string[] pin = { "1234", "0000", "0001" };
        private static string[][] account =
        {
            new string[] {"Salary", "Savings"},
            new string[] { "Salary", "Savings", "Stolen" },
            new string[] { "Salary", "Savings", "Stolen", "Stock" },
            new string[] { "Salary", "Savings", "Stolen", "Stock", "Stonks" }
        };

        private static decimal[][] balance =
        {
            new decimal[] {50000, 2000},
            new decimal[] { 50000, 2000, 90},
            new decimal[] { 50000, 2000, 90, 200000 },
            new decimal[] { 50000, 2000, 90, 200000, -100000 }
        };

        #region //LoginUser()
        public static void LoginUser()
        {
            Console.WriteLine("Login");
            while (true)
            {
                for (int i = 0; i < username.Length; i++)
                {
                    Console.Write("Enter username: ");
                    if (username[i].Equals(Console.ReadLine()))
                    {
                        //Username successful
                        for (int j = 0; j <= 2; j++)
                        {
                            Console.Write("Enter password: ");
                            //Password successful
                            if (pin[i].Equals(Console.ReadLine()))
                            {
                                Console.WriteLine("Login Successful");
                                Console.WriteLine("Press Enter to continue...");
                                Console.ReadLine();
                                Program.userLogedIn = i;
                                i = username.Length;
                                break;
                            }
                            //Too many tries
                            else if (j == 2)
                            {
                                Console.WriteLine("Too many tries. Program will now exit...");
                                i = username.Length;
                                break;
                            }
                            //Wrong password
                            else
                            {
                                Console.WriteLine("Login failed, wrong password");
                            }
                        }
                    }
                    //Too many tries
                    else if (i == 2)
                    {
                        Console.WriteLine("Too many tries. Program will now exit...");
                        break;
                    }
                    //Username not found
                    else
                    {
                        Console.WriteLine("Login failed, username not found");
                    }
                }
                break;
            }
        }
        #endregion


        public static void Accounts()
        {
            for (int i = 0; i < account[Program.userLogedIn].Length; i++)
            {
                Console.WriteLine("{0}: {1}", account[Program.userLogedIn][i], balance[Program.userLogedIn][i]);
            }
            Console.ReadLine();
        }
    }
}
