using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banks
{
    class INIT
    {
        public static List<Client> INIT_Clients()
        {
            Client[] clients =
            {
                new Client(ID: 1, FIO: "Иванов Иван Иванович",Adress: "г. Волгоград ул. Иванова д. 1"),
                new Client(ID: 2, FIO: "Петров Петр Петрович", Adress: "г. Волгоград ул. Петрова д. 2")
            };

            return clients.ToList();
        }

        public static ServerBank INIT_Bank()
        {
            ServerBank Bank = new ServerBank("Банк Сбер", "г.Волгоград ул.Банковская д. 5");

            return Bank;
        }

        public static void INIT_ATM(ServerBank Bank)
        {
            //ВРЕМЕННОЕ РЕШЕНИЕ

            // TODO: При создании динамики, сделать массив словарей
            Dictionary<string, int> temp_bills = new Dictionary<string, int>(8);
            temp_bills.Add("10", 1);
            temp_bills.Add("50", 1);
            temp_bills.Add("100", 1);
            temp_bills.Add("200", 1);
            temp_bills.Add("500", 1);
            temp_bills.Add("1000", 1);
            temp_bills.Add("2000", 1);
            temp_bills.Add("5000", 1);

            Dictionary<string, int> temp_bills2 = new Dictionary<string, int>(temp_bills);

            AtmMachine[] machines = {
                new AtmMachine(_bills: temp_bills),
                new AtmMachine(_bills: temp_bills2),
            };


            Bank.AtmMachines.AddRange(machines.ToList());
        }

        public static Dictionary<string, int> INIT_MAIN_CASH()
        {
            //ВРЕМЕННОЕ РЕШЕНИЕ
            Dictionary<string, int> temp_bills = new Dictionary<string, int>(8);
            temp_bills.Add("10", 10);
            temp_bills.Add("50", 10);
            temp_bills.Add("100", 10);
            temp_bills.Add("200", 10);
            temp_bills.Add("500", 10);
            temp_bills.Add("1000", 10);
            temp_bills.Add("2000", 10);
            temp_bills.Add("5000", 10);

            return temp_bills;
        }
    }
}
