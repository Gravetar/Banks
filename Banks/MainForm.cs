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
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void DebugTimer_Tick(object sender, EventArgs e)
        {
            _DEBUGGER.DEBUG(ref DebugText);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Bank.Operator.AddCashNeedded(Bank.AtmMachines[0], Bank.Operator.CheckCash(Bank.AtmMachines[0].bills, INIT.INIT_MAIN_CASH()));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MAIN_FUNCTIONS.ChangeDisplay(_VISUALIZER, Controls, Displays.Welcome);
        }
    }
}
