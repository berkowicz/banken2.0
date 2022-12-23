namespace banken3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (User.userLogedIn == -1)
            {
                User.LoginUser();
            }
            Menu.MainMenu();
        }
    }
}