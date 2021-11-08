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
    }
}
