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
            Client ClientCard,
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
            _ClientCard = ClientCard;
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
        /// <summary>
        /// Клиент, привязанный к карте
        /// </summary>
        public Client _ClientCard;
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
