using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banks
{
    class DEBUGGER
    {
        _TextsModifier textsModifier = new _TextsModifier();

        bool _Style, _ClientInfo, _BankInfo;
        ServerBank _Bank;
        public DEBUGGER(ServerBank Bank, bool Style=true, bool ClientInfo = true, bool BankInfo = true)
        {
            _ClientInfo = ClientInfo;
            _BankInfo = BankInfo;
            _Bank = Bank;
            _Style = Style;
        }

        public void DEBUG(ref RichTextBox RTB_Result)
        {
            string result = "";
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
            }
            if (_BankInfo)
            {
                result += "<ub>==========БАНК==========</ub>" + "\n";
                result += "<b>НАЗВАНИЕ</b>: " + _Bank._Name + "\n";
                result += "<b>АДРЕС</b>: " + _Bank._Adress + "\n";
            }

            if (_Style)
            {
                textsModifier.ModifyByTag(result, ref RTB_Result);
            }
            else
            {
                RTB_Result.Text = result;
                textsModifier.ClearAllByText(new string[] {"<b>", "<ub>", "</b>", "</ub>" }.ToList(), ref RTB_Result);
            }
        }


    }
}
