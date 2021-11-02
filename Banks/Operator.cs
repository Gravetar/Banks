using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banks
{
    class Operator
    {
        public void CheckCash(ref AtmMachine Atm, Dictionary<string, int> _bills, Dictionary<string, int> bills)
        {
            Dictionary<string, int> sub_bills = new Dictionary<string, int>
            {
                ["10"] = bills["10"] - _bills["10"],
                ["50"] = bills["50"] - _bills["50"],
                ["100"] = bills["100"] - _bills["100"],
                ["200"] = bills["200"] - _bills["200"],
                ["500"] = bills["500"] - _bills["500"],
                ["1000"] = bills["1000"] - _bills["1000"],
                ["2000"] = bills["2000"] - _bills["2000"],
                ["5000"] = bills["5000"] - _bills["5000"]
            };
            return sub_bills;
        }
        public void AddCash(ref AtmMachine Atm, int value)
        {
            Atm.replenishCash(value);
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
