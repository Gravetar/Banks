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
        /// Кем занят банкомат
        /// </summary>
        public int CurrentClient = -1;
        /// <summary>
        /// Кем занят банкомат
        /// </summary>
        public string CurrentCard;
        /// <summary>
        /// Сколько пытались ввести пин-код на Банкомате
        /// </summary>
        public int TryInputPin = 0;
        /// <summary>
        /// Активный счет банкомата
        /// </summary>
        public string ActiveAccount = "";

        /// <summary>
        /// Дисплей банкомата
        /// </summary>
        public Displays Display = Displays.Welcome;

        /// <summary>
        /// Валюты банкомата
        /// </summary>
        public Dictionary<string, int> bills = new Dictionary<string, int>(8);
        /// <summary>
        /// Транзакции банкомата
        /// </summary>
        public List<Transaction> Transactions = new List<Transaction>();

        // СОСТОЯНИЯ КНОПОК
        public bool BTN_InputCard = true;
        public bool BTN_OutputCard = false;
        public bool BTN_OutputCash = false;
        public bool BTN_TakeCheck = false;

        public bool BTN_On = false;
        public bool BTN_Off = true;

        /// <summary>
        /// Конструктор банкомата
        /// </summary>
        /// <param name="Bills">Словарь наминалов(номинал-количество)</param>
        public AtmMachine(Dictionary<string, int> Bills)
        {
            bills = Bills;
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
    /// Виды дисплеев
    /// </summary>
    public enum Displays
    {
        /// <summary>
        /// Дисплей приветствия
        /// </summary>
        Welcome,
        /// <summary>
        /// Дисплей для ввода пин-кода
        /// </summary>
        InputPIN,
        /// <summary>
        /// Дисплей с меню
        /// </summary>
        Menu,
        /// <summary>
        /// Дисплей заберите чек
        /// </summary>
        Check,
        /// <summary>
        /// Дисплей для снятия денег
        /// </summary>
        Withdraw,
        /// <summary>
        /// Дисплей для введения другой суммы  и снития суммы
        /// </summary>
        AnotherAmount,
        /// <summary>
        /// Дисплей для перевода между счетами
        /// </summary>
        Transfer,
        /// <summary>
        /// Дисплей забрать карту
        /// </summary>
        OutCard,
        /// <summary>
        /// Дисплей выбора счета
        /// </summary>
        SelectAccount,
    }

    /// <summary>
    /// Виды дополнительных панелей
    /// </summary>
    public enum AdditionalPanels
    {
        /// <summary>
        /// Дополнительная панель для клиента
        /// </summary>
        For_Client,
        /// <summary>
        /// Дополнительная панель для оператора
        /// </summary>
        For_Operator
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

