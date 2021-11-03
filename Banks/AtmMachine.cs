using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banks
{
    /// <summary>
    /// Банкомат
    /// </summary>
    class AtmMachine
    {

        /// <summary>
        /// Состояние банкомата
        /// </summary>
        public StateAtm stateAtm = StateAtm.on;

        /// <summary>
        /// Валюты банкомата
        /// </summary>
        public Dictionary<string, int> bills = new Dictionary<string, int>(8);
        /// <summary>
        /// Транзакции банкомата
        /// </summary>
        public List<Transaction> Transactions = new List<Transaction>();

        /// <summary>
        /// Конструктор банкомата
        /// </summary>
        /// <param name="_bills">Словарь наминалов(номинал-количество)</param>
        public AtmMachine(Dictionary<string, int> _bills)
        {
            bills = _bills;
        }

        /// <summary>
        /// Добавить денег в банкомат
        /// </summary>
        /// <param name="Nominal">Номинал</param>
        /// <param name="Value">Количество</param>
        public void replenishCash(string Nominal, int Value)
        {
            bills[Nominal] += Value;
        }

    }

    /// <summary>
    /// Стаусы работы банкомата
    /// </summary>
    enum StateAtm
    {
        /// <summary>
        /// Включен
        /// </summary>
        on, 
        /// <summary>
        /// Отключен
        /// </summary>
        off
    }


}

