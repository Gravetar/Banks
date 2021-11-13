using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banks
{
    /// <summary>
    /// Карточка банка
    /// </summary>
    class DebitCard
    {
        /// <summary>
        /// Конструктор карты
        /// </summary>
        /// <param name="ID">ID</param>
        /// <param name="PIN">Пин-код</param>
        /// <param name="DateStart">Дата начала</param>
        /// <param name="DateEnd">Дата окончания</param>
        /// <param name="Limit">Лимит</param>
        /// <param name="Total">Итого</param>
        /// <param name="NumberAccount">Номер счета</param>
        /// <param name="NumberCard">Номер карты</param>
        /// <param name="Card_Status">Состояние</param>
        public DebitCard(
            int ID, 
            string PIN, 
            DateTime DateStart, 
            DateTime DateEnd, 
            double Limit, 
            double Total,
            string NumberAccount,
            string NumberCard,
            CardStatus Card_Status = CardStatus.Valid)
        {
            _ID = ID;
            _PIN = PIN;
            _DateStart = DateStart;
            _DateEnd = DateEnd;
            _Limit = Limit;
            _Total = Total;
            _NumberAccount = NumberAccount;
            _Card_Status = Card_Status;
            _NumberCard = NumberCard;
        }


        /// <summary>
        /// ID
        /// </summary>
        int _ID;
        /// <summary>
        /// Пин-код
        /// </summary>
        public string _PIN;
        /// <summary>
        /// Дата начала
        /// </summary>
        DateTime _DateStart;
        /// <summary>
        /// Дата окончания
        /// </summary>
        DateTime _DateEnd;
        /// <summary>
        /// Состояние
        /// </summary>
        CardStatus _Card_Status;
        /// <summary>
        /// Лимит
        /// </summary>
        double _Limit;
        /// <summary>
        /// Итого
        /// </summary>
        double _Total;
        /// <summary>
        /// Номер счета
        /// </summary>
        public string _NumberAccount;
        /// <summary>
        /// Номер карты
        /// </summary>
        public string _NumberCard;

        public Client GetClient(ServerBank Bank)
        {
            Account acc = Bank.Accounts.Find(a => a._Number == _NumberAccount);
            foreach (Client item_client in Bank.Clients)
            {
                foreach (Account item_account in item_client.Accounts)
                {
                    if (item_account._Number == _NumberAccount)
                        return item_client;
                }
            }
            return null;
        }
    }

    /// <summary>
    /// Состояния карточки
    /// </summary>
    public enum CardStatus
    {
        /// <summary>
        /// Заблокирована
        /// </summary>
        Block,
        /// <summary>
        /// Действительна
        /// </summary>
        Valid
    }
}
