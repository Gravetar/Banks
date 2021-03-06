using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public RichTextBox RTB_Result;

        /// <summary>
        /// Вывод информации
        /// </summary>
        bool _ClientInfo, _BankInfo, _AtmInfo, _CardsInfo, _AccountsInfo, _Transaction;
        /// <summary>
        /// Применять стиль к выводу
        /// </summary>
        bool _Style;

        string ConsoleText = "";

        public TypeDebug _Type;

        /// <summary>
        /// Главный банк
        /// </summary>
        ServerBank _Bank;

        ContextMenuStrip _CMS_Debug;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="Bank">Главный банк</param>
        /// <param name="Style">Применять стиль к выводу</param>
        /// <param name="ClientInfo">Вывод информации о клиентах</param>
        /// <param name="BankInfo">Вывод информации о банке</param>
        /// <param name="AtmInfo">Вывод информации о банкоматах</param>
        public DEBUGGER(ServerBank Bank, ContextMenuStrip CMS_Debug, bool Style = false, bool ClientInfo = true, bool BankInfo = true, bool AtmInfo = true, bool CardsInfo = true, bool AccountsInfo = true, bool Transactions = true, TypeDebug Type = TypeDebug.Console)
        {
            _ClientInfo = ClientInfo;
            _BankInfo = BankInfo;
            _AtmInfo = AtmInfo;
            _CardsInfo = CardsInfo;
            _AccountsInfo = AccountsInfo;
            _Transaction = Transactions;

            _Bank = Bank;
            _Style = Style;
            _Type = Type;

            _CMS_Debug = CMS_Debug;

        }

        /// <summary>
        /// Вывод информации
        /// </summary>
        /// <param name="RTB_Result">RichTextBox для вывода</param>
        /// <param name="CurrentClient">Текущий клиент приложения</param>
        public void DEBUG(int CurrentClient)
        {
            _Style = (_CMS_Debug.Items.Find("StyleStrip", true).FirstOrDefault() as ToolStripMenuItem).Checked;
            _BankInfo = (_CMS_Debug.Items.Find("BankInfoStrip", true).FirstOrDefault() as ToolStripMenuItem).Checked;
            _CardsInfo = (_CMS_Debug.Items.Find("CardsInfoStrip", true).FirstOrDefault() as ToolStripMenuItem).Checked;
            _ClientInfo = (_CMS_Debug.Items.Find("ClientInfoStrip", true).FirstOrDefault() as ToolStripMenuItem).Checked;
            _AtmInfo = (_CMS_Debug.Items.Find("AtmInfoStrip", true).FirstOrDefault() as ToolStripMenuItem).Checked;
            _AccountsInfo = (_CMS_Debug.Items.Find("AccountsInfoStrip", true).FirstOrDefault() as ToolStripMenuItem).Checked;
            _Transaction = (_CMS_Debug.Items.Find("TransactionsInfoStrip", true).FirstOrDefault() as ToolStripMenuItem).Checked;

            if (_Type == TypeDebug.Debugger)
            {
                string result = ""; // Результирующая строка
                if (_ClientInfo)
                {
                    result += "<ub>==========КЛИЕНТЫ==========</ub>" + "\n";
                    result += "<b>Текущий клиент:</b> " + CurrentClient.ToString() + "\n";
                    for (int i = 0; i < _Bank.Clients.Count; i++)
                    {
                        result += "<b>ID:</b> " + _Bank.Clients[i]._ID + "\n";
                        result += "<b>ФИО:</b> " + _Bank.Clients[i]._FIO + "\n";
                        result += "<b>АДРЕС:</b> " + _Bank.Clients[i]._Adress + "\n";
                        result += "\n";
                        result += "----------";
                        result += "\n";
                    }
                } // Если надо вывести информацию о клиенте, то
                if (_CardsInfo)
                {
                    result += "<ub>==========КАРТЫ============</ub>" + "\n";
                    for (int i = 0; i < _Bank.DebitCards.Count; i++)
                    {
                        result += "<b>Номер карты:</b> " + _Bank.DebitCards[i]._NumberCard + "\n";
                        result += "<b>Номер д. счета:</b> " + _Bank.DebitCards[i]._NumberAccount + "\n";
                        result += "<b>Номер к. счета:</b> " + _Bank.DebitCards[i]._NumberAccountCredit + "\n";
                        result += "<b>Клиент:</b> " + _Bank.DebitCards[i]._ClientCard._FIO + "\n";
                        result += "\n";
                        result += "----------";
                        result += "\n";
                    }
                } // Если надо вывести информацию о картах, то
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
                        result += "<b>Статус:</b>: " + _Bank.AtmMachines[i].stateAtm + "\n";
                        result += "<b>Дисплей:</b>: " + _Bank.AtmMachines[i].Display + "\n";
                        result += "<b>Клиент:</b>: " + _Bank.AtmMachines[i].CurrentClient + "\n";
                        result += "<b>Карта:</b>: " + _Bank.AtmMachines[i].CurrentCard + "\n";
                        foreach (KeyValuePair<string, int> keyValue in _Bank.AtmMachines[i].bills)
                        {
                            result += string.Format("Д{0} = {1}\n", keyValue.Key, keyValue.Value);
                        }
                        result += "\n";
                    }
                } // Если надо вывести информацию о банкоматах, то
                if (_AccountsInfo)
                {
                    result += "<ub>========СЧЕТА===========</ub>" + "\n";
                    for (int i = 0; i < _Bank.Accounts.Count; i++)
                    {
                        result += "<b>Счет № </b>: " + _Bank.Accounts[i]._Number + "\n";
                        result += "<b>Баланс:</b>: " + _Bank.Accounts[i]._Balance + "\n";
                        result += "\n";
                    }
                } // Если надо вывести информацию о счетах, то
                if (_Transaction)
                {
                    result += "<ub>========ТРАНЗАКЦИИ======</ub>" + "\n";
                    for (int i = 0; i < _Bank.Transactions.Count; i++)
                    {
                        result += "<b>Транзакция № </b>: " + _Bank.Transactions[i]._ID_Transaction + "\n";
                        result += "<b>Тип:</b>: " + _Bank.Transactions[i]._Type + "\n";
                        result += "<b>Сумма:</b>: " + _Bank.Transactions[i]._Sum + "\n";
                        result += "<b>Баланс:</b>: " + _Bank.Transactions[i]._Balance + "\n";
                        result += "\n";
                    }
                } // Если надо вывести информацию о транзакциях, то

                if (_Style)
                {
                    textsModifier.ModifyByTag(result, ref RTB_Result); // Модифицировать RichTextBox для вывода согласно тегам
                } // Если надо применить стиль к информации, то
                else
                {
                    RTB_Result.Text = result; // Применить результат к RichTextBox для вывода
                    textsModifier.ClearAllByText(new string[] { "<b>", "<ub>", "</b>", "</ub>" }.ToList(), ref RTB_Result); // Очистить RichTextBox для вывода от тегов
                } // Иначе
            }
        }

        public void DEBUG_CONSOLE(string str)
        {
            Console.WriteLine(str);
            RTB_Result.Text += "\n" + str;
            ConsoleText += "\n" + str;
        }

        public void ChangeDebugger()
        {
            RTB_Result.Text = "DEBUGGER";

            if (_Type == TypeDebug.Debugger)
            {
                _Type = TypeDebug.Console;
                RTB_Result.Text += ConsoleText;
            }
            else _Type = TypeDebug.Debugger;
        }
    }

    enum TypeDebug
    {
        Console,
        Debugger
    }
}
