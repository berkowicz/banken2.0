namespace banken3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (User.userLogedIn == 999999)
            {
                User.LoginUser();
            }
            Menu.MainMenu();
        }
    }
}