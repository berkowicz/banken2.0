namespace banken3
{
    internal class Program
    {
        public static int userLogedIn = 999999;

        static void Main(string[] args)
        {
            while (userLogedIn == 999999)
            {
                User.LoginUser();
            }
            Menu.MainMenu();
        }


    }
}