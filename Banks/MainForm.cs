using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banks
{
    public partial class MainForm : Form
    {
        ServerBank Bank;

        DEBUGGER _DEBUGGER;
        VISUALIZER _VISUALIZER = new VISUALIZER();

        Control.ControlCollection MainControls;

        int CurrentIdUser;
        public MainForm()
        {
            InitializeComponent();
            MainControls = MainPanel.Controls;

            Bank = INIT.INIT_Bank();
            Bank.Clients = INIT.INIT_Clients();

            INIT.INIT_ATM(Bank);

            _DEBUGGER = new DEBUGGER(Bank: Bank);
            DebugTimer.Start();

            List<Panel> ATMs = new List<Panel>();
            ATMs = _VISUALIZER.CreateAllATM(OnKeyboard_Click, OnInputCard_Click);
            MainControls.AddRange(ATMs.ToArray());

            SelectUserCB.Items.Add("(Оператор)");
            for (int i = 0; i<Bank.Clients.Count; i++)
            {
                SelectUserCB.Items.Add(Bank.Clients[i]._ID.ToString() + ": " + Bank.Clients[i]._FIO);
            }
        }

        private void DebugTimer_Tick(object sender, EventArgs e)
        {
            _DEBUGGER.DEBUG(ref DebugText);
        }

        private void OnInputCard_Click(object sender, EventArgs e)
        {
            Button CallerButton = sender as Button;

            AtmMachine CurrentMachine = Bank.AtmMachines[Convert.ToInt32(CallerButton.Tag)];
            Panel CurrentAtm = MainControls.Find("ATM", true).Where(t => t.Tag.ToString() == CallerButton.Tag.ToString()).FirstOrDefault() as Panel;

            CurrentMachine.Display = MAIN_FUNCTIONS.ChangeDisplay(Convert.ToInt32(CallerButton.Tag), _VISUALIZER, CurrentAtm.Controls, Displays.InputPIN);

            CurrentMachine.CurrentClient = CurrentIdUser;
            Bank.Clients[CurrentIdUser]._ATM = Convert.ToInt32(CallerButton.Tag);
            MAIN_FUNCTIONS.ChangeEnabledATMs(MainControls, Bank, CurrentIdUser);

            CallerButton.Enabled = false;
        }

        private void OnKeyboard_Click(object sender, EventArgs e)
        {
            Button CallerButton = sender as Button;

            Panel CurrentAtm = MainControls.Find("ATM", true).Where(t => t.Tag.ToString() == CallerButton.Tag.ToString()).FirstOrDefault() as Panel;
            Panel Display = CurrentAtm.Controls.Find("DISPLAY", true).FirstOrDefault() as Panel;
            AtmMachine CurrentMachine = Bank.AtmMachines[Convert.ToInt32(CallerButton.Tag)];
            TextBox Pin_InputText = Display.Controls.Find("DISPLAY_Pin_InputText", true).FirstOrDefault() as TextBox;

            if (CallerButton.Text == "CANCEL")
            {
                CurrentMachine.Display = MAIN_FUNCTIONS.ChangeDisplay(Convert.ToInt32(CallerButton.Tag), _VISUALIZER, CurrentAtm.Controls, Displays.Welcome);
                CurrentMachine.CurrentClient = -1;
                Bank.Clients[CurrentIdUser]._ATM = -1;
                MAIN_FUNCTIONS.ChangeEnabledATMs(MainControls, Bank, CurrentIdUser);

                (CurrentAtm.Controls.Find("BTN_ADDITIONAL_INCARD", true).FirstOrDefault() as Button).Enabled = true;
            }
            else if (CallerButton.Text == "CLEAR")
            {
                Pin_InputText.Text = "";
            }
            else if (CallerButton.Text == "ENTER")
            {
                if (Pin_InputText.Text.Length == 4) Console.WriteLine("ПИН-КОД ВВЕДЕН!");
            }
            else if (CallerButton.Text != " ")
            {
                if (CurrentMachine.Display == Displays.InputPIN && Pin_InputText.Text.Length < 4) Pin_InputText.Text += CallerButton.Text;
            }
        }

        private void SelectUserCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            MainPanel.Visible = true;
            if (SelectUserCB.SelectedItem.ToString() == "(Оператор)")
            {
                SETTINGS.CURRENT_USER = User.Operator;
                CurrentIdUser = -1;
            }
            else
            {
                SETTINGS.CURRENT_USER = User.Client;
                CurrentIdUser = SelectUserCB.SelectedIndex - 1;
                MAIN_FUNCTIONS.ChangeEnabledATMs(MainControls, Bank, CurrentIdUser);
            }
        }
    }
}
