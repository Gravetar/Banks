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
        public MainForm()
        {
            InitializeComponent();

            Bank = INIT.INIT_Bank();
            Bank.Clients = INIT.INIT_Clients();

            INIT.INIT_ATM(Bank);

            _DEBUGGER = new DEBUGGER(Bank: Bank);
            DebugTimer.Start();

            List<Panel> ATMs = new List<Panel>();
            ATMs = _VISUALIZER.CreateAllATM(OnKeyboard_Click, OnInputCard_Click);
            Controls.AddRange(ATMs.ToArray());

            //Bank.AtmMachines[1].Display = MAIN_FUNCTIONS.ChangeDisplay(_VISUALIZER, Controls, Displays.Welcome); // TODO сделать для нескольких
            //Controls.Add(_VISUALIZER.DisplayKeyboard(OnKeyboard_Click));
            //Controls.Add(_VISUALIZER.DisplayAdditional(OnInputCard_Click));

            //Panel Display = Controls.Find("DISPLAY", true).Where(t => t.Tag.ToString() == "1").FirstOrDefault() as Panel; // TODO сделать для нескольких
            //AtmMachine CurrentMachine = Bank.AtmMachines[Convert.ToInt32(Display.Tag)];
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void DebugTimer_Tick(object sender, EventArgs e)
        {
            _DEBUGGER.DEBUG(ref DebugText);
        }

        private void OnInputCard_Click(object sender, EventArgs e)
        {
            Button CallerButton = sender as Button;

            AtmMachine CurrentMachine = Bank.AtmMachines[Convert.ToInt32(CallerButton.Tag)];
            Panel CurrentAtm = Controls.Find("DISPLAY", true).Where(t => t.Tag == CallerButton.Tag).FirstOrDefault() as Panel;

            CurrentMachine.Display = MAIN_FUNCTIONS.ChangeDisplay(Convert.ToInt32(CallerButton.Tag), _VISUALIZER, Controls, Displays.InputPIN);

            CallerButton.Enabled = false;
        }

        private void OnKeyboard_Click(object sender, EventArgs e)
        {
            Button CallerButton = sender as Button;

            Panel Display = Controls.Find("DISPLAY", true).FirstOrDefault() as Panel;
            AtmMachine CurrentMachine = Bank.AtmMachines[Convert.ToInt32(Display.Tag)];
            TextBox Pin_InputText = Display.Controls.Find("DISPLAY_Pin_InputText", true).FirstOrDefault() as TextBox;

            if (CallerButton.Text == "CANCEL")
            {
                if (Pin_InputText.Text.Length > 0) Pin_InputText.Text = Pin_InputText.Text.Substring(0, Pin_InputText.Text.Length-1);
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
    }
}
