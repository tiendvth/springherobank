using Spring_Hero_Banks.view;

namespace Spring_Hero_Banks
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var AccountView = new AccountView();
            AccountView.ShowMenu();
        }
    }
}