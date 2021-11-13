using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banks
{
    /// <summary>
    /// Счет банка
    /// </summary>
    class Account
    {
        /// <summary>
        /// Дебетовые карточки счета
        /// </summary>
        public List<DebitCard> _DebitCards = new List<DebitCard>();

        /// <summary>
        /// Номер счета
        /// </summary>
        public string _Number;
        /// <summary>
        /// Баланс
        /// </summary>
        double _Balance;
        /// <summary>
        /// Тип счета
        /// </summary>
        TypeAccount _Type;

        /// <summary>
        /// Сумма последнего вклада(Для Type = Checking)
        /// </summary>
        public double _AmountLastDeposit;

        /// <summary>
        /// Процентная ставка(Для Type = Saving)
        /// </summary>
        public double _InterestRate;

        public Account(List<DebitCard> DebitCards, string Number, double Balance, TypeAccount Type)
        {
            _DebitCards = DebitCards;
            _Number = Number;
            _Balance = Balance;
            _Type = Type;
        }
    }

    /// <summary>
    /// Типы счетов
    /// </summary>
    public enum TypeAccount
    {
        /// <summary>
        /// Текущий
        /// </summary>
        Checking,
        /// <summary>
        /// Сберегаельный
        /// </summary>
        Saving
    }
}
