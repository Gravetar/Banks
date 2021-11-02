using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banks
{
    class Operator
    {

        public void AddCash(AtmMachine Atm, string Nominal, int value)
        {
            Atm.replenishCash(Nominal, value);
        }
        public void StartAtm(ref AtmMachine Atm)
        {
            Atm.stateAtm = StateAtm.on;
        }
        public void StopAtm(ref AtmMachine Atm)
        {
            Atm.stateAtm = StateAtm.off;
        }
    }
}
