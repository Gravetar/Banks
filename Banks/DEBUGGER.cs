using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banks
{
    /// <summary>
    /// Текстовый отладчик проекта
    /// </summary>
    class DEBUGGER
    {
        /// <summary>
        /// Модификатор текста
        /// </summary>
        _TextsModifier textsModifier = new _TextsModifier();

        /// <summary>
        /// Вывод информации
        /// </summary>
        bool _ClientInfo, _BankInfo, _AtmInfo;
        /// <summary>
        /// Применять стиль к выводу
        /// </summary>
        bool _Style;

        /// <summary>
        /// Главный банк
        /// </summary>
        ServerBank _Bank;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="Bank">Главный банк</param>
        /// <param name="Style">Применять стиль к выводу</param>
        /// <param name="ClientInfo">Вывод информации о клиентах</param>
        /// <param name="BankInfo">Вывод информации о банке</param>
        /// <param name="AtmInfo">Вывод информации о банкоматах</param>
        public DEBUGGER(ServerBank Bank, bool Style = false, bool ClientInfo = true, bool BankInfo = true, bool AtmInfo = true)
        {
            _ClientInfo = ClientInfo;
            _BankInfo = BankInfo;
            _AtmInfo = AtmInfo;

            _Bank = Bank;
            _Style = Style;
        }

        /// <summary>
        /// Вывод информации
        /// </summary>
        /// <param name="RTB_Result">RichTextBox для вывода</param>
        public void DEBUG(ref RichTextBox RTB_Result)
        {
            string result = ""; // Результирующая строка
            if (_ClientInfo)
            {
                result += "<ub>==========КЛИЕНТЫ==========</ub>" + "\n";
                for (int i=0; i<_Bank.Clients.Count; i++)
                {
                    result += "<b>ID:</b> " + _Bank.Clients[i]._ID + "\n";
                    result += "<b>ФИО:</b> " + _Bank.Clients[i]._FIO + "\n";
                    result += "<b>АДРЕС:</b> " + _Bank.Clients[i]._Adress + "\n";
                    result += "\n";
                    result += "----------";
                    result += "\n";
                }
            } // Если надо вывести информацию о клиенте, то
            if (_BankInfo)
            {
                result += "<ub>==========БАНК==========</ub>" + "\n";
                result += "<b>НАЗВАНИЕ</b>: " + _Bank._Name + "\n";
                result += "<b>АДРЕС</b>: " + _Bank._Adress + "\n";
                result += "\n";
            } // Если надо вывести информацию о банке, то
            if (_AtmInfo)
            {
                result += "<ub>========БАНКОМАТЫ=======</ub>" + "\n";
                for (int i = 0; i < _Bank.AtmMachines.Count; i++)
                {
                    result += "<b>Банкомат № </b>: " + i.ToString() + "\n";
                    result += "<b>СТАТУС:</b>: " + _Bank.AtmMachines[i].stateAtm + "\n";
                    result += "<b>ДИСПЛЕЙ:</b>: " + _Bank.AtmMachines[i].Display + "\n";
                    foreach (KeyValuePair<string, int> keyValue in _Bank.AtmMachines[i].bills)
                    {
                        result += string.Format("Д{0} = {1}\n",keyValue.Key, keyValue.Value);
                    }
                    result += "\n";
                }
            } // Если надо вывести информацию о банкоматах, то

            if (_Style)
            {
                textsModifier.ModifyByTag(result, ref RTB_Result); // Модифицировать RichTextBox для вывода согласно тегам
            } // Если надо применить стиль к информации, то
            else
            {
                RTB_Result.Text = result; // Применить результат к RichTextBox для вывода
                textsModifier.ClearAllByText(new string[] {"<b>", "<ub>", "</b>", "</ub>" }.ToList(), ref RTB_Result); // Очистить RichTextBox для вывода от тегов
            } // Иначе
        }


    }
}
