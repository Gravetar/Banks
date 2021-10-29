using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banks
{
    class AtmMachine
    {
        /// <summary>
        /// Состояния банкомата
        /// </summary>
        public StateAtm stateAtm = StateAtm.on;

        public double Cash = 0;

        /// <summary>
        /// Транзакции банкомата
        /// </summary>
        public List<Transaction> Transactions = new List<Transaction>();

        public void replenishCash(double value)
        {
            Cash += value;
        }

    }

    enum StateAtm
    {
        on, off
    }


}

