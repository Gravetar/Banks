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
        /// <summary>
        /// Главный банк
        /// </summary>
        ServerBank Bank;

        /// <summary>
        /// Отладчик приложения
        /// </summary>
        DEBUGGER _DEBUGGER;
        /// <summary>
        /// Главный визуализатор
        /// </summary>
        VISUALIZER VISUALIZER = new VISUALIZER();

        /// <summary>
        /// Главная панель банкоматов
        /// </summary>
        Control.ControlCollection MainControls;

        /// <summary>
        /// ID текущего пользователя
        /// </summary>
        int CurrentIdUser;

        /// <summary>
        /// Номер текущей карточки
        /// </summary>
        DebitCard CurrentCard;

        public MainForm()
        {
            InitializeComponent();

            // Установка событий на динамически создаваемые объекты
            VISUALIZER.Events.Add(OnKeyboard_Click);
            VISUALIZER.Events.Add(OnAdditional_Click);
            VISUALIZER.Events.Add(OnMainMenu_Click);
            VISUALIZER.Events.Add(OnToMenu_Click);
            VISUALIZER.Events.Add(OnWithdrawСash_Click);

            // Компоненты главной панели банкоматов
            MainControls = MainPanel.Controls;

            // Инициализация главного банка
            Bank = INIT.INIT_Bank();
            // Инициализация клиентов главного банка
            Bank.Clients = INIT.INIT_Clients();
            // Инициализация банкоматов главного банка
            INIT.INIT_ATM(Bank);

            INIT.INIT_Cards(Bank);
            INIT.INIT_Account(Bank, Bank.DebitCards);

            INIT.INIT_Account_Client(Bank);

            // Создание отладчика на основе главного банка
            _DEBUGGER = new DEBUGGER(Bank);
            _DEBUGGER.RTB_Result = DebugText;
            // Запустить работу таймера отладчика
            DebugTimer.Start();

            // Начальные действия приложения
            OnStart();
        }

        /// <summary>
        /// Начальные действия приложения
        /// </summary>
        void OnStart()
        {
            // Лист банкоматов
            List<Panel> ATMs;
            // Создать визуализацию всех банкоматов
            ATMs = VISUALIZER.CreateAllATM();
            // Добавить созданные визуализации в Главную панель банкоматов
            MainControls.AddRange(ATMs.ToArray());

            // Добавить оператор в ComboBox выбора текущего пользователя приложения
            SelectUserCB.Items.Add("(Оператор)");
            // Добавить всех клиентов в ComboBox выбора текущего пользователя приложения
            for (int i = 0; i < Bank.Clients.Count; i++) // Пройтись по всем клиентам из списка клиентов банка
            {
                SelectUserCB.Items.Add(Bank.Clients[i]._ID.ToString() + ": " + Bank.Clients[i]._FIO); // Добавить ID и ФИО клиента в ComboBox
            }
        }

        private void DebugTimer_Tick(object sender, EventArgs e)
        {
            // Запустить отладку
            _DEBUGGER.DEBUG(CurrentIdUser);
        }

        private void OnAdditional_Click(object sender, EventArgs e)
        {
            // Кнопка, вызвавшая событие
            Button CallerButton = sender as Button;

            // Текущий банкомат(Согласно кнопке, вызвавшей событие)
            AtmMachine CurrentMachine = Bank.AtmMachines[Convert.ToInt32(CallerButton.Tag)];
            // Текущий банкомат-визуализация(Согласно кнопке, вызвавшей событие)
            Panel CurrentAtm = MainControls.Find("ATM", true).Where(t => t.Tag.ToString() == CallerButton.Tag.ToString()).FirstOrDefault() as Panel;

            // Обработка кнопок на дополнительной панели
            // Для панели клиента
            if (CallerButton.Text == "Вставить карту")
            {
                // Дисплей текущего банкомата
                CurrentMachine.Display = MAIN_FUNCTIONS.ChangeDisplay(Convert.ToInt32(CallerButton.Tag), VISUALIZER, CurrentAtm.Controls, Displays.InputPIN);
                // Установить текущего клиента текущему банкомату
                CurrentMachine.CurrentClient = CurrentIdUser;
                // Установить текущему клиенту текущий банкомат
                Bank.Clients[CurrentIdUser]._ATM = Convert.ToInt32(CallerButton.Tag);
                // Сменить доступность банкоматов
                MAIN_FUNCTIONS.ChangeEnabledATMs(MainControls, Bank, CurrentIdUser);

                CurrentMachine.CurrentCard = CurrentCard._NumberCard;

                // Деактивировать кнопку, вызвавшей событие(Вставить карту)
                CallerButton.Enabled = false;
            }

            // Для панели Оператора
            else if (CallerButton.Text == "Включить")
            {
                CurrentMachine.stateAtm = StateAtm.on; // Включить текущий банкомат
                CallerButton.Enabled = false; // Деактивировать кнопку, вызвавшей событие(Включить)
                (CurrentAtm.Controls.Find("BTN_ADDITIONAL_OffATM", true).FirstOrDefault() as Button).Enabled = true; // Найти кнопку "Выключить" и диактивировать ее
            }
            else if (CallerButton.Text == "Выключить")
            {
                CurrentMachine.stateAtm = StateAtm.off;  // Выключить текущий банкомат
                CallerButton.Enabled = false;  // Деактивировать кнопку, вызвавшей событие(Включить)
                (CurrentAtm.Controls.Find("BTN_ADDITIONAL_OnATM", true).FirstOrDefault() as Button).Enabled = true; // Найти кнопку "Включить" и активировать ее
            }
            else if (CallerButton.Text == "Внести наличные")
            {
                // Внести недостающие наличные в банкомат
                Bank.Operator.AddCashNeedded(CurrentMachine, Bank.Operator.CheckCash(CurrentMachine.bills, INIT.INIT_MAIN_CASH()));
            }
        }

        private void OnKeyboard_Click(object sender, EventArgs e)
        {
            // Кнопка, вызвавшая событие
            Button CallerButton = sender as Button;

            // Текущий банкомат(Согласно кнопке, вызвавшей событие)
            AtmMachine CurrentMachine = Bank.AtmMachines[Convert.ToInt32(CallerButton.Tag)];
            // Текущий банкомат-визуализация(Согласно кнопке, вызвавшей событие)
            Panel CurrentAtm = MainControls.Find("ATM", true).Where(t => t.Tag.ToString() == CallerButton.Tag.ToString()).FirstOrDefault() as Panel;
            // Текущий дисплей
            Panel CurrentDisplay = CurrentAtm.Controls.Find("DISPLAY", true).FirstOrDefault() as Panel;
            // Текущий текстовый блок для ввода Пин-кода
            TextBox Pin_InputText = CurrentDisplay.Controls.Find("DISPLAY_Pin_InputText", true).FirstOrDefault() as TextBox;

            // Обработка кнопок клавиатуры
            if (CallerButton.Text == "CANCEL") // Если кнопка, вызвавшая событие - CANCEL, то: ("Вытащить карту")
            {
                SelectCardCB.Enabled = true;
                // Сменить дисплей текущего банкомата на дисплей приветствия
                CurrentMachine.Display = MAIN_FUNCTIONS.ChangeDisplay(Convert.ToInt32(CallerButton.Tag), VISUALIZER, CurrentAtm.Controls, Displays.Welcome);
                // Убрать текущего клиента из текущего банкомата
                CurrentMachine.CurrentClient = -1;
                // Убрать текущий банкомат из текущего клиента
                Bank.Clients[CurrentIdUser]._ATM = -1;
                // Сменить доступность банкоматов
                MAIN_FUNCTIONS.ChangeEnabledATMs(MainControls, Bank, CurrentIdUser);
                // Найти и активировать кнопку "Вставить карту" у текущего банкомата
                (CurrentAtm.Controls.Find("BTN_ADDITIONAL_INCARD", true).FirstOrDefault() as Button).Enabled = true;
                CurrentMachine.TryInputPin = 0;
            }
            else if (CallerButton.Text == "CLEAR" && CurrentMachine.Display == Displays.InputPIN) // Если кнопка, вызвавшая событие - CLEAR, то:
            {
                Pin_InputText.Text = ""; // Очистить поле ввода Пин-кода
            }
            else if (CallerButton.Text == "ENTER" && CurrentMachine.Display == Displays.InputPIN) // Если кнопка, вызвавшая событие - ENTER, то:
            {
                if (CurrentMachine.Display == Displays.InputPIN && Pin_InputText.Text.Length == 4) 
                {
                    if (!Bank.CheckPIN(CurrentCard, Pin_InputText.Text))
                    {
                        CurrentMachine.TryInputPin += 1;
                        _DEBUGGER.DEBUG_CONSOLE("ПИН-КОД ВВЕДЕН НЕ ВЕРНО!");
                        _DEBUGGER.DEBUG_CONSOLE("Осталось попыток:" + (3 - CurrentMachine.TryInputPin).ToString());
                        if (CurrentMachine.TryInputPin == 3)
                        {
                            _DEBUGGER.DEBUG_CONSOLE("Карта конфискована!");
                            CurrentMachine.TryInputPin = 0;
                            // TODO Карта конфискована!
                        }
                    }
                    else
                    {
                        _DEBUGGER.DEBUG_CONSOLE("ПИН-КОД ВВЕДЕН ВЕРНО!");
                        CurrentMachine.Display = MAIN_FUNCTIONS.ChangeDisplay(Convert.ToInt32(CallerButton.Tag), VISUALIZER, CurrentAtm.Controls, Displays.Menu);
                    }
                }
            }
            else if (CallerButton.Text != " ") // Если кнопка, вызвавшая событие - цифры, то:
            {
                // Добавить цифру с текста кнопки, вызвавшей событие, но не больше 4ех символов
                if (CurrentMachine.Display == Displays.InputPIN && Pin_InputText.Text.Length < 4) Pin_InputText.Text += CallerButton.Text;
            }
        }

        private void OnWithdrawСash_Click(object sender, EventArgs e)
        {
            // Кнопка, вызвавшая событие
            Button CallerButton = sender as Button;

            // Текущий банкомат(Согласно кнопке, вызвавшей событие)
            AtmMachine CurrentMachine = Bank.AtmMachines[Convert.ToInt32(CallerButton.Tag)];
            // Текущий банкомат-визуализация(Согласно кнопке, вызвавшей событие)
            Panel CurrentAtm = MainControls.Find("ATM", true).Where(t => t.Tag.ToString() == CallerButton.Tag.ToString()).FirstOrDefault() as Panel;

            _DEBUGGER.DEBUG_CONSOLE(CallerButton.Text);

        }

        private void OnMainMenu_Click(object sender, EventArgs e)
        {
            // Кнопка, вызвавшая событие
            Button CallerButton = sender as Button;

            // Текущий банкомат(Согласно кнопке, вызвавшей событие)
            AtmMachine CurrentMachine = Bank.AtmMachines[Convert.ToInt32(CallerButton.Tag)];
            // Текущий банкомат-визуализация(Согласно кнопке, вызвавшей событие)
            Panel CurrentAtm = MainControls.Find("ATM", true).Where(t => t.Tag.ToString() == CallerButton.Tag.ToString()).FirstOrDefault() as Panel;
            if (CallerButton.Text == "СНЯТЬ НАЛИЧНЫЕ") // Если кнопка, вызвавшая событие - CANCEL, то: ("Вытащить карту")
            {
                // Сменить дисплей текущего банкомата на дисплей приветствия
                CurrentMachine.Display = MAIN_FUNCTIONS.ChangeDisplay(Convert.ToInt32(CallerButton.Tag), VISUALIZER, CurrentAtm.Controls, Displays.Withdraw);

            }
            else if (CallerButton.Text == "СПРАВКА")
            {
                // Сменить дисплей текущего банкомата на дисплей приветствия
                CurrentMachine.Display = MAIN_FUNCTIONS.ChangeDisplay(Convert.ToInt32(CallerButton.Tag), VISUALIZER, CurrentAtm.Controls, Displays.Help);
            }
            else if (CallerButton.Text == "ПЕРЕВОД НАЛИЧНЫХ")
            {
                _DEBUGGER.DEBUG_CONSOLE("ПЕРЕВОД НАЛИЧНЫХ");
            }
        }

        private void OnToMenu_Click(object sender, EventArgs e)
        {
            // Кнопка, вызвавшая событие
            Button CallerButton = sender as Button;

            // Текущий банкомат(Согласно кнопке, вызвавшей событие)
            AtmMachine CurrentMachine = Bank.AtmMachines[Convert.ToInt32(CallerButton.Tag)];
            // Текущий банкомат-визуализация(Согласно кнопке, вызвавшей событие)
            Panel CurrentAtm = MainControls.Find("ATM", true).Where(t => t.Tag.ToString() == CallerButton.Tag.ToString()).FirstOrDefault() as Panel;
            
            CurrentMachine.Display = MAIN_FUNCTIONS.ChangeDisplay(Convert.ToInt32(CallerButton.Tag), VISUALIZER, CurrentAtm.Controls, Displays.Menu);
        }

        private void SelectUserCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectCardCB.Text = "Выбрать...";

            if (SelectUserCB.SelectedItem.ToString() == "(Оператор)") // Если в качестве текущего пользователя был выбран оператор то:
            {
                // Показать главную панель банкоматов
                MainPanel.Visible = true;
                SETTINGS.CURRENT_USER = User.Operator; // Установить текущего пользователя приложения в "Оператор"
                for (int i = 0; i<Bank.AtmMachines.Count; i++) // Пройтись по всем банкоматам
                {
                    // Установить текущий банкомат
                    Panel CurrentAtm = MainControls.Find("ATM", true).Where(t => t.Tag.ToString() == i.ToString()).FirstOrDefault() as Panel;
                    // Сменить текущую дополнительную панель на панель оператора
                    MAIN_FUNCTIONS.ChangeAdditionalPanel(i, VISUALIZER, CurrentAtm.Controls, AdditionalPanels.For_Operator, Bank, CurrentIdUser);
                }
                // Сменить доступность банкоматов
                MAIN_FUNCTIONS.ChangeEnabledATMs(MainControls, Bank, CurrentIdUser);
            }
            else
            {
                SETTINGS.CURRENT_USER = User.Client; // Установить текущего пользователя приложения в "Клиент"
                CurrentIdUser = SelectUserCB.SelectedIndex - 1; // Установить ID текущего пользователя приложения
                SelectCardCB.Items.Clear();

                if (Bank.Clients[CurrentIdUser]._ATM != -1)
                {
                    SelectCardCB.Text = Bank.AtmMachines[Bank.Clients[CurrentIdUser]._ATM].CurrentCard;
                    SelectCardCB.Items.Add(Bank.AtmMachines[Bank.Clients[CurrentIdUser]._ATM].CurrentCard);
                }

                SelectCardCB.Visible = true;
                label2.Visible = true;
                MainPanel.Visible = false;

                SelectCardCB.Items.AddRange(Bank.Clients[CurrentIdUser].GetFreeCardsStrings(Bank).ToArray());
            }
        }

        private void SelectCardCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Показать главную панель банкоматов
            MainPanel.Visible = true;
            CurrentCard = Bank.DebitCards.Find(c => c._NumberCard == SelectCardCB.Text);

            for (int i = 0; i < Bank.AtmMachines.Count; i++) // Пройтись по всем банкоматам
            {
                // Установить текущий банкомат
                Panel CurrentAtm = MainControls.Find("ATM", true).Where(t => t.Tag.ToString() == i.ToString()).FirstOrDefault() as Panel;
                // Сменить текущую дополнительную панель на панель клиента
                MAIN_FUNCTIONS.ChangeAdditionalPanel(i, VISUALIZER, CurrentAtm.Controls, AdditionalPanels.For_Client, Bank, CurrentIdUser);
            }
            // Сменить доступность банкоматов
            MAIN_FUNCTIONS.ChangeEnabledATMs(MainControls, Bank, CurrentIdUser);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _DEBUGGER.ChangeDebugger();
        }
    }
}
