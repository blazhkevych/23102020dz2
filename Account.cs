using System;
using static System.Console;

namespace _23102020dz2
{
    public class Account
    {
        public int AccountNumber { get; set; }
        public string Password { get; set; }
        public int Money { get; set; }
        public DateTime DateOfCreate { get; set; }

        public Account()
        {
            AccountNumber = -1;
            Password = "";
            Money = 0;
            DateOfCreate = DateTime.Now;
        }

        public void ShowInfo(Client client)
        {
            WriteLine("\t\tИнформация о вашем аккунте:");
            WriteLine("Ваше Ф.И.О: " + client.MiddleName + " " + client.FitstName + " " + client.LastName);
            WriteLine("Номер счета: " + AccountNumber);
            WriteLine("Дата создания: " + DateOfCreate);
            WriteLine("Пароль: " + Password);
            WriteLine("Денег на счету: " + Money + " грн.");
            WriteLine("Ваш номер телефона: " + client.PhoneNumber);
        }

        public void ReplenishAccount(int money)
        {
            Money += money;
        }

        public bool TakeOffMoney(int money)
        {
            if (Money < money)
            {
                Clear();
                WriteLine("На вашем аккаунте меньше денег, чем вы хотите снять!");
                ReadKey();
                return false;
            }
            Money -= money;
            return true;
        }
    }
}
