using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banks
{
    /// <summary>
    /// Инициализация объектов
    /// </summary>
    class INIT
    {
        /// <summary>
        /// Инициализация клиентов банка
        /// </summary>
        /// <returns>Лист сформированных клиентов</returns>
        public static List<Client> INIT_Clients()
        {
            // Клиенты
            Client[] clients =
            {
                new Client(ID: 0, FIO: "Иванов Иван Иванович",Adress: "г. Волгоград ул. Иванова д. 1"),
                new Client(ID: 1, FIO: "Петров Петр Петрович", Adress: "г. Волгоград ул. Петрова д. 2"),
                new Client(ID: 2, FIO: "Николаев Николай Николаевич", Adress: "г. Волгоград ул. Неколаева д. 3")
            };

            // Вернуть массив клиентов переоформленный в лист
            return clients.ToList();
        }

        /// <summary>
        /// Инициализация банка
        /// </summary>
        /// <returns>Сформированный банк</returns>
        public static ServerBank INIT_Bank()
        {
            // Банк
            ServerBank Bank = new ServerBank("Банк Сбер", "г.Волгоград ул.Банковская д. 5");
            // Вернуть банк
            return Bank;
        }

        /// <summary>
        /// Инициализация банкоматов
        /// </summary>
        /// <param name="Bank">Главный банк</param>
        public static void INIT_ATM(ServerBank Bank)
        {
            List<AtmMachine> machines = new List<AtmMachine>();

            // Банкоматы
            for (int i = 0; i<SETTINGS.ATM_COUNT; i++)
            {
                machines.Add(new AtmMachine(new Dictionary<string, int> // Словарь номиналов и количества денег
                {
                    { "100", 0 },
                    { "200", 0 },
                    { "500", 0 },
                    { "1000", 0 },
                    { "2000", 0 },
                    { "5000", 1 }
                }));
            }

            // Добавить в банк лист банкоматов
            Bank.AtmMachines.AddRange(machines);
        }

        /// <summary>
        /// Инициализация карточек
        /// </summary>
        /// <param name="Bank">Главный банк</param>
        public static void INIT_Cards(ServerBank Bank)
        {
            // Карточки
            DebitCard[] cards =
            {
                new DebitCard(ID: 1, PIN: "1234", DateStart: new DateTime(2021, 11, 13), DateEnd: new DateTime(2025, 11, 13), Limit: 10000, Total: 10000, NumberAccount: "0", NumberAccountCredit: "2", NumberCard: "1234 3213 3213 1234", ClientCard: Bank.Clients[0]),
                new DebitCard(ID: 2, PIN: "1234", DateStart: new DateTime(2021, 11, 13), DateEnd: new DateTime(2025, 11, 13), Limit: 200000, Total: 20000, NumberAccount: "0", NumberAccountCredit: "3", NumberCard: "5847 5967 3485 9607", ClientCard: Bank.Clients[1]),
                new DebitCard(ID: 3, PIN: "1234", DateStart: new DateTime(2021, 11, 13), DateEnd: new DateTime(2025, 11, 13), Limit: 300000, Total: 30000, NumberAccount: "1", NumberAccountCredit: "4", NumberCard: "1859 6584 9385 9584", ClientCard: Bank.Clients[2]),

                new DebitCard(ID: 4, PIN: "1234", DateStart: new DateTime(2021, 11, 13), DateEnd: new DateTime(2025, 11, 13), Limit: 100000, Total: 10000, NumberAccount: "0", NumberAccountCredit: "2", NumberCard: "1555 3213 3213 1234", ClientCard: Bank.Clients[0]),
            };

            // Добавить в банк карточки
            Bank.DebitCards.AddRange(cards);
        }

        /// <summary>
        /// Инициализация потерянных или украденных карт
        /// </summary>
        /// <param name="Bank">Главный банк</param>
        public static void INIT_StealLoseCards(ServerBank Bank)
        {
            // Карточки
            string[] cards =
            {"5847 5967 3485 9607", };

            // Добавить в банк карточки
            Bank.StealLoseCards.AddRange(cards);
        }

        /// <summary>
        /// Инициализация счетов
        /// </summary>
        /// <param name="Bank">Главный банк</param>
        public static void INIT_Account(ServerBank Bank, List<DebitCard> debitCards)
        {
            // Основные счета
            Account[] checkingaccounts =
            {
                new Account(DebitCards: debitCards.FindAll(c => c._NumberAccount == "0"), Number: "0", Balance: 11000, Type: TypeAccount.Checking),
                new Account(DebitCards: debitCards.FindAll(c => c._NumberAccount == "1"), Number: "1", Balance: 20000, Type: TypeAccount.Checking),
                new Account(DebitCards: debitCards.FindAll(c => c._NumberAccount == "2"), Number: "2", Balance: 30000, Type: TypeAccount.Checking),
                new Account(DebitCards: debitCards.FindAll(c => c._NumberAccount == "3"), Number: "3", Balance: 15000, Type: TypeAccount.Checking),
                new Account(DebitCards: debitCards.FindAll(c => c._NumberAccount == "4"), Number: "4", Balance: 17000, Type: TypeAccount.Checking),

            };

            // Добавить в банк счета
            Bank.Accounts.AddRange(checkingaccounts);
        }
        /// <summary>
        /// Присвоение счетов клиентам
        /// </summary>
        /// <param name="Bank">Главный банк</param>
        public static void INIT_Account_Client(ServerBank Bank)
        {
            Bank.Clients[0].Accounts.Add(Bank.Accounts[0]);
            Bank.Clients[0].Accounts.Add(Bank.Accounts[2]);

            Bank.Clients[1].Accounts.Add(Bank.Accounts[0]);
            Bank.Clients[1].Accounts.Add(Bank.Accounts[3]);

            Bank.Clients[2].Accounts.Add(Bank.Accounts[1]);
            Bank.Clients[2].Accounts.Add(Bank.Accounts[4]);
        }

        /// <summary>
        /// Необходимое количество денег по номиналам
        /// </summary>
        /// <returns>Словарь необходимого наличия количества денег</returns>
        public static Dictionary<string, int> INIT_MAIN_CASH()
        {
            // Словарь необходимого наличия количества денег
            Dictionary<string, int> temp_bills = new Dictionary<string, int>(6);
            temp_bills.Add("100", 10);
            temp_bills.Add("200", 10);
            temp_bills.Add("500", 10);
            temp_bills.Add("1000", 10);
            temp_bills.Add("2000", 10);
            temp_bills.Add("5000", 10);
            // Вернуть Словарь необходимого наличия количества денег
            return temp_bills;
        }
    }
}
