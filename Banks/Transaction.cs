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
        public int _ID_Transaction;
        /// <summary>
        /// Тип
        /// </summary>
        public TypeTransaction _Type;
        /// <summary>
        /// Сумма
        /// </summary>
        public int _Sum;
        /// <summary>
        /// Баланс счета
        /// </summary>
        public double _Balance;

        public Transaction(int ID_Transaction, TypeTransaction Type, int sum, double Balance)
        {
            _ID_Transaction = ID_Transaction;
            _Type = Type;
            _Sum = sum;
            _Balance = Balance;
        }
    }

    public enum TypeTransaction
    {
        Перевод,
        Списание
    }
}
