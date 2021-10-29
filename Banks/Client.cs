using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banks
{
    //hello
    class Client
    {
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
        /// Счета клиента
        /// </summary>
        public List<Account> Accounts = new List<Account>();
        /// <summary>
        /// Дебетовые карточки клиента
        /// </summary>
        public List<DebitCard> DebitCards = new List<DebitCard>();
    }
}
