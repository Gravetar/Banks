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
        /// ID Карточки
        /// </summary>
        string ID_Card;
        /// <summary>
        /// Пин-Код
        /// </summary>
        string PIN;
        /// <summary>
        /// Дата
        /// </summary>
        DateTime Date;
        /// <summary>
        /// Время
        /// </summary>
        DateTime Time;
        /// <summary>
        /// Состояние
        /// </summary>
        int State;
    }

    class Transaction_Certificate : Transaction
    {
        /// <summary>
        /// Номер счета
        /// </summary>
        string AccountNumber;
        /// <summary>
        /// Баланс
        /// </summary>
        string Balance;
        /// <summary>
        /// Сумма последнего вклада
        /// </summary>
        string AmountLastDeposit;
    }

    class Transaction_CheckPIN : Transaction
    {
        /// <summary>
        /// Дата начала
        /// </summary>
        DateTime DateStart;
        /// <summary>
        /// Дата окончания
        /// </summary>
        DateTime DateEnd;
    }

    class Transaction_Transfer : Transaction
    {
        /// <summary>
        /// Исходный счет
        /// </summary>
        string SourceAccount;
        /// <summary>
        /// Целевой счет
        /// </summary>
        string TargetAccount;
        /// <summary>
        /// Сумма
        /// </summary>
        double Amount;
    }

    class Transaction_Withdrawal : Transaction
    {
        /// <summary>
        /// Номер счета
        /// </summary>
        string AccountNumber;
        /// <summary>
        /// Сумма
        /// </summary>
        double Ammount;
        /// <summary>
        /// Баланс
        /// </summary>
        double Balance;
    }
}
