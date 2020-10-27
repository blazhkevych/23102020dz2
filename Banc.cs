using System;
using static System.Console;

namespace _23102020dz2
{
    public class Banc
    {
        public string NameOfBank { get; set; }
        public string LocationOfBank { get; set; }
        private Account[] accounts;

        public Banc()
        {
            accounts = new Account[0];
            NameOfBank = "";
            LocationOfBank = "";
        }

        public void ShowInfo()
        {
            WriteLine("\t\t Информация о банке:");
            WriteLine("Количество аккаунтов: " + accounts.Length);
            WriteLine("Имя банка: " + NameOfBank);
            WriteLine("Местоположение банка: " + LocationOfBank);
        }

        public Account[] GetAccounts()
        {
            return accounts;
        }


        public void CreateAccount(Client client, int passwordLength)
        {
            Array.Resize(ref accounts, accounts.Length + 1);

            accounts[accounts.Length - 1] = new Account
            {
                AccountNumber = accounts.Length + 16445,
                Password = Program.PasswordGenerate(passwordLength),
                Money = 0,
                DateOfCreate = DateTime.Now
            };


            WriteLine("Ваш номер счета: " + accounts[accounts.Length - 1].AccountNumber);
            WriteLine("Ваш пароль: " + accounts[accounts.Length - 1].Password);
            WriteLine("\nЗапишите эти данные в надежное место!\nНажмите любую кнопку. . .");

            ReadKey();
            Clear();

            Write("Введите ваше Имя: ");
            string firstname = ReadLine();
            client.FitstName = firstname;

            Write("\nВведите вашу Фамилию: ");
            string middlename = ReadLine();
            client.MiddleName = middlename;

            Write("\nВведите ваше Отчество: ");
            string lastname = ReadLine();
            client.LastName = lastname;

            while (true)
            {
                Clear();
                Write("\nВведите ваш номер телефона: ");
                string phone = ReadLine();
                long testPhone;

                if (phone.Length == 12 || phone.Length == 13 && phone.StartsWith("+"))
                {
                    if (long.TryParse(phone, out testPhone))
                    {
                        client.PhoneNumber = phone;
                        break;
                    }
                    else
                    {
                        WriteLine("Некорректно введен номер!");
                    }
                }
                else
                {
                    WriteLine("Некорректно введен номер!");
                }
                ReadKey();
            }
        }


        public bool CheckAccount(int accountNumber, string password)
        {
            for (int i = 0; i < accounts.Length; i++)
            {
                if (accounts[i].AccountNumber == accountNumber)
                {
                    if (accounts[i].Password == password)
                        return true;
                }
            }
            return false;
        }

        public Account GetAccount(int number, string password)
        {
            for (int i = 0; i < accounts.Length; i++)
            {
                if (accounts[i].AccountNumber == number)
                {
                    if (accounts[i].Password == password)
                        return accounts[i];
                }
            }
            return null;
        }

        public bool TryToLogIn(Client client)
        {
            bool end = false;
            int attempts = 2;

            while (!end)
            {
                Clear();
                WriteLine("Введите номер счета: ");
                string toParse = ReadLine();
                int number;

                if (!int.TryParse(toParse, out number))
                {
                    Clear();
                    WriteLine("Некорректно введены данные!");
                    end = true;
                    ReadKey();
                }

                if (!end)
                {
                    WriteLine("\nВведите пароль: ");
                    string password = ReadLine();
                    bool isExist = CheckAccount(number, password);
                    if (!isExist)
                    {
                        Clear();
                        WriteLine("Такого аккаунта не существует!");
                        end = true;
                        ReadKey();
                    }
                    else
                    {
                        client.account = GetAccount(number, password);
                        return true;
                    }
                }

                if (attempts == 0)
                {
                    Clear();
                    WriteLine("Вы исчерпали свой лимит попыток! \nЗавершение программы. . .");
                    ReadKey();
                    return false;
                }

                end = false;
                attempts--;
            }
            return false;
        }
    }
}
