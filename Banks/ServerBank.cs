using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banks
{
     /// <summary>
    /// Главный Банк
    /// </summary>
    class ServerBank
    {
        /// <summary>
        /// Конструктор банка
        /// </summary>
        /// <param name="Name">Название банка</param>
        /// <param name="Address">Адрес банка</param>
        public ServerBank(string Name, string Address)
        {
            _Name = Name;
            _Adress = Address;
        }
        /// <summary>
        /// Название банка
        /// </summary>
        public string _Name;
        /// <summary>
        /// Адрес банка
        /// </summary>
        public string _Adress;

        /// <summary>
        /// Дебетовые карточки, обслуживаемые банком
        /// </summary>
        public List<DebitCard> DebitCards = new List<DebitCard>();
        /// <summary>
        /// Конфискованные карточки
        /// </summary>
        public List<DebitCard> ConfiscatedCards = new List<DebitCard>();
        /// <summary>
        /// Банкоматы банка
        /// </summary>
        public List<AtmMachine> AtmMachines = new List<AtmMachine>();
        /// <summary>
        /// Клиенты банка
        /// </summary>
        public List<Client> Clients = new List<Client>();
        /// <summary>
        /// Cчета банка
        /// </summary>
        public List<Account> Accounts = new List<Account>();

        /// <summary>
        /// Оператор банка
        /// </summary>
        public Operator Operator = new Operator();

        public bool CheckPIN(DebitCard debitCard, string PIN)
        {
            return debitCard._PIN == PIN;
        }
        public bool CheckConfiscatedCard(DebitCard debitCard)
        {
            bool result = false;
            if (ConfiscatedCards.Find(c=>c._NumberCard == debitCard._NumberCard) != null)
            {
                result = true;
            }
            return result;
        }

        public bool CheckAccount(int IdUser, string InAccount)
        {
            Client client = Clients[IdUser];

            foreach (Account item in client.Accounts)
            {
                if (item._Number == InAccount) return true;
            }

            return false;
        }

        public string Transfer(string AccountOut, string AccountIn, int Value)
        {
            Account Out = Accounts.Find(a => a._Number == AccountOut); // Откуда
            Account In = Accounts.Find(a => a._Number == AccountIn); // Куда

            if (Out != null &&  In != null )
            {
                if (Out._Balance >= Value)
                {
                    Out._Balance -= Value;
                    In._Balance += Value;
                    return "Перевод успешно произведен!";
                }
                else return "На счете недостаточно средств!";
            }
            else
            {
                return "Счет, куда направлен перевод не найден!";
            }
        }

        public string Withdraw(string AccountOut, int Value, AtmMachine Atm)
        {
            Account Out = Accounts.Find(a => a._Number == AccountOut); // Откуда
            string Max = "";
            int sum = 0;
            Dictionary<string, int>  bills = Atm.bills;
            Dictionary<string, int> billsOut = new Dictionary<string, int> // Словарь номиналов и количества денег
                {
                    { "100", 0 },
                    { "200", 0 },
                    { "500", 0 },
                    { "1000", 0 },
                    { "2000", 0 },
                    { "5000", 0 }
                };
            if (Value % 100 != 0)
            {
                return "НЕВЕРНО ВВЕДЕНА СУММА!";
            }

            while(Value != 0)
            {
                foreach (KeyValuePair<string, int> keyValue in bills)
                {
                    if (Int32.Parse(keyValue.Key) <= Value && keyValue.Value != 0)
                    {
                        Max = keyValue.Key;
                    }
                }
                if (bills[Max] > 0)
                {
                    bills[Max]--;
                    billsOut[Max]++;
                    sum += Int32.Parse(Max);
                    Value -= Int32.Parse(Max);
                    Console.WriteLine(Max);
                }
                else
                {
                    return "В БАНКОМАТЕ НЕДОСТАТОЧНО КУПЮР!";
                }
                
            }
            Console.WriteLine(Out._Balance);
            if ((Out._Balance -= sum) >= 0)
            {
                Console.WriteLine(Out._Balance);
                Console.WriteLine(sum);
                return "ПРОИЗВЕДЕНА ВЫДАЧА НАЛИЧНЫХ";
            }
            else
            {
                Out._Balance += sum;
                return "НЕДОСТАТОЧНО СРЕДСТВ НА СЧЕТЕ!";
            }
        }
    }
}
