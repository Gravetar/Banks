using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banks
{
    /// <summary>
    /// Оператор банка
    /// </summary>
    class Operator
    {
        /// <summary>
        /// Проверка сколько надо добавить денег к банкомату
        /// </summary>
        /// <param name="CurrentBills">Текущее количество денег в банкомате</param>
        /// <param name="NeedBills">Необходимое количество денег в банкомате</param>
        /// <returns>Словарь необходмого количества добавления денег</returns>
        public Dictionary<string, int> CheckCash(Dictionary<string, int> CurrentBills, Dictionary<string, int> NeedBills)
        {
            // Словарь необходмого количества добавления денег
            // Формируется:
            // Номинал = НужноеКолВоДенег[Номинал] - ТекущееКолВоДенег[Номинал]
            Dictionary<string, int> ResultBills = new Dictionary<string, int>
            {
                ["10"] = NeedBills["10"] - CurrentBills["10"],
                ["50"] = NeedBills["50"] - CurrentBills["50"],
                ["100"] = NeedBills["100"] - CurrentBills["100"],
                ["200"] = NeedBills["200"] - CurrentBills["200"],
                ["500"] = NeedBills["500"] - CurrentBills["500"],
                ["1000"] = NeedBills["1000"] - CurrentBills["1000"],
                ["2000"] = NeedBills["2000"] - CurrentBills["2000"],
                ["5000"] = NeedBills["5000"] - CurrentBills["5000"]
            };
            // Словарь необходмого количества добавления денег
            return ResultBills;
        }

        /// <summary>
        /// Добавить нужное количество денег банкомату
        /// </summary>
        /// <param name="Atm">Банкомат</param>
        /// <param name="Nedded">Словарь, показывающий сколько нужно добавить денег</param>
        public void AddCashNeedded(AtmMachine Atm, Dictionary<string, int> Nedded)
        {
            foreach (KeyValuePair<string, int> keyValue in Nedded) // Пройти по всему словарю Nedded
            {
                Atm.replenishCash(keyValue.Key, keyValue.Value); // Добавить нужное количество денег банкомату
            }
        }

        /// <summary>
        /// Запустить работу банкомата
        /// </summary>
        /// <param name="Atm">Банкомат</param>
        public void StartAtm(ref AtmMachine Atm)
        {
            Atm.stateAtm = StateAtm.on; // Поменять статус банкомата на "Включен"
        }
        /// <summary>
        /// Остановить работу банкомата
        /// </summary>
        /// <param name="Atm">Банкомат</param>
        public void StopAtm(ref AtmMachine Atm)
        {
            Atm.stateAtm = StateAtm.off; // Поменять статус банкомата на "Отключен"
        }
    }
}
