using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banks
{
    /// <summary>
    /// Транзакции
    /// </summary>
    class Transaction
    {
        /// <summary>
        /// ID Транзакции
        /// </summary>
        string ID_Transaction;
        /// <summary>
        /// Тип
        /// </summary>
        TypeTransaction Type;
        /// <summary>
        /// Сумма
        /// </summary>
        int Sum;
        /// <summary>
        /// Баланс счета
        /// </summary>
        string Balance;
    }

    public enum TypeTransaction
    {
        Transfer,
        Withdrawal
    }
}
