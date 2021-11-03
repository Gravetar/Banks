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
                new Client(ID: 1, FIO: "Иванов Иван Иванович",Adress: "г. Волгоград ул. Иванова д. 1"),
                new Client(ID: 2, FIO: "Петров Петр Петрович", Adress: "г. Волгоград ул. Петрова д. 2")
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
            #region TODO
            // TODO: При создании динамики, сделать массив словарей
            #endregion
            // Словарь номиналов и количества денег
            Dictionary<string, int> temp_bills = new Dictionary<string, int>(8);
            temp_bills.Add("10", 1);
            temp_bills.Add("50", 1);
            temp_bills.Add("100", 1);
            temp_bills.Add("200", 1);
            temp_bills.Add("500", 1);
            temp_bills.Add("1000", 1);
            temp_bills.Add("2000", 1);
            temp_bills.Add("5000", 1);

            // Словари для дополнительных банкоматах, на основе Словарь номиналов и количества денег
            Dictionary<string, int> temp_bills2 = new Dictionary<string, int>(temp_bills);

            // Банкоматы
            AtmMachine[] machines = {
                new AtmMachine(_bills: temp_bills),
                new AtmMachine(_bills: temp_bills2),
            };

            // Добавить в банк массив банкоматов переоформленный в лист
            Bank.AtmMachines.AddRange(machines.ToList());
        }

        /// <summary>
        /// Необходимое количество денег по номиналам
        /// </summary>
        /// <returns>Словарь необходимого наличия количества денег</returns>
        public static Dictionary<string, int> INIT_MAIN_CASH()
        {
            // Словарь необходимого наличия количества денег
            Dictionary<string, int> temp_bills = new Dictionary<string, int>(8);
            temp_bills.Add("10", 10);
            temp_bills.Add("50", 10);
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
