using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banks
{
    /// <summary>
    /// Клиент банка
    /// </summary>
    class Client
    {
        /// <summary>
        /// Конструктор клиента
        /// </summary>
        /// <param name="FIO">ФИО</param>
        /// <param name="ID">АЙДИ</param>
        /// <param name="Adress">Адресс</param>
        public Client(string FIO, int ID, string Adress)
        {
            _FIO = FIO;
            _ID = ID;
            _Adress = Adress;
        }
        /// <summary>
        /// ФИО клиента
        /// </summary>
        public string _FIO;
        /// <summary>
        /// ID клиента
        /// </summary>
        public int _ID;
        /// <summary>
        /// Адрес клиента
        /// </summary>
        public string _Adress;
        /// <summary>
        /// Текущий банкомат на которым работает клиент
        /// </summary>
        public int _ATM = -1;

        /// <summary>
        /// Счета клиента
        /// </summary>
        public List<Account> Accounts = new List<Account>();
        /// <summary>
        /// Дебетовые карточки клиента
        /// </summary>
        public List<DebitCard> DebitCards = new List<DebitCard>();

        public List<string> GetCardsStrings()
        {
            List<DebitCard> debitCards = new List<DebitCard>();
            List<string> result = new List<string>();

            foreach (Account item in Accounts)
            {
                debitCards.AddRange(item._DebitCards);
            }
            foreach (DebitCard item in debitCards)
            {
                result.Add(item._NumberCard);
            }

            return result;
        }

        public List<string> GetFreeCardsStrings(ServerBank Bank)
        {
            List<DebitCard> debitCards = new List<DebitCard>();
            List<string> result = new List<string>();

            foreach (Account item in Accounts)
            {
                debitCards.AddRange(item._DebitCards);
            }
            foreach (DebitCard item in debitCards)
            {
                bool free = true;
                foreach (AtmMachine item_atm in Bank.AtmMachines)
                {
                    if (item_atm.CurrentCard == item._NumberCard) free = false;
                }
                if (free && item._ClientCard._ID == _ID) result.Add(item._NumberCard);
            }

            return result;
        }
    }
}
