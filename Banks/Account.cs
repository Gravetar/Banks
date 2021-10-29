using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banks
{
    class Account
    {
        /// <summary>
        /// Дебетовые карточки счета
        /// </summary>
        public List<DebitCard> DebitCards = new List<DebitCard>();

        /// <summary>
        /// Номер счета
        /// </summary>
        string Number;
        /// <summary>
        /// Баланс
        /// </summary>
        double Balance;
    }

    class СheckingAccount : Account
    {
        /// <summary>
        /// Сумма последнего вклада
        /// </summary>
        public double AmountLastDeposit;
    }

    class SavingsAccount : Account
    {
        /// <summary>
        /// Процентная ставка
        /// </summary>
        public double InterestRate;
    }
}
