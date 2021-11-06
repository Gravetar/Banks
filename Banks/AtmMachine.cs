﻿using System;
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
        InputPIN
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

