﻿using System;
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

        /// <summary>
        /// Активированный текстовый блок для ввода с клавиатуры
        /// </summary>
        TextBox CurrentActiveTb;

        public MainForm()
        {
            InitializeComponent();

            // Установка событий на динамически создаваемые объекты
            VISUALIZER.Events.Add(OnKeyboard_Click);
            VISUALIZER.Events.Add(OnAdditional_Click);
            VISUALIZER.Events.Add(OnMainMenu_Click);
            VISUALIZER.Events.Add(OnToMenu_Click);
            VISUALIZER.Events.Add(OnWithdrawСash_Click);
            VISUALIZER.Events.Add(OnAnotherAmount_Click);
            VISUALIZER.Events.Add(OnTransfer_Click);

            VISUALIZER.Events.Add(OnTb_Click);

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
            else if(CallerButton.Text == "Забрать карту")
            {
                SelectCardCB.Enabled = true;
                // Сменить дисплей текущего банкомата на дисплей приветствия
                CurrentMachine.Display = MAIN_FUNCTIONS.ChangeDisplay(Convert.ToInt32(CallerButton.Tag), VISUALIZER, CurrentAtm.Controls, Displays.Welcome);
                // Убрать текущего клиента из текущего банкомата
                CurrentMachine.CurrentClient = -1;
                // Убрать текущего клиента из текущего банкомата
                CurrentMachine.CurrentCard = "";
                // Убрать текущий банкомат из текущего клиента
                Bank.Clients[CurrentIdUser]._ATM = -1;
                // Сменить доступность банкоматов
                MAIN_FUNCTIONS.ChangeEnabledATMs(MainControls, Bank, CurrentIdUser);
                // Найти и активировать кнопку "Вставить карту" у текущего банкомата
                (CurrentAtm.Controls.Find("BTN_ADDITIONAL_INCARD", true).FirstOrDefault() as Button).Enabled = true;
                (CurrentAtm.Controls.Find("BTN_ADDITIONAL_OUTCARD", true).FirstOrDefault() as Button).Enabled = false;
                CurrentMachine.TryInputPin = 0;
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
            if (CallerButton.Text == "CANCEL" && CurrentMachine.Display != Displays.Welcome) // Если кнопка, вызвавшая событие - CANCEL, то: ("Вытащить карту")
            {
                CurrentMachine.Display = MAIN_FUNCTIONS.ChangeDisplay(Convert.ToInt32(CallerButton.Tag), VISUALIZER, CurrentAtm.Controls, Displays.OutCard);
                (CurrentAtm.Controls.Find("BTN_ADDITIONAL_OUTCARD", true).FirstOrDefault() as Button).Enabled = true;

            }
            else if (CallerButton.Text == "CLEAR") // Если кнопка, вызвавшая событие - CLEAR, то:
            {
                if (CurrentMachine.Display == Displays.InputPIN)
                    Pin_InputText.Text = ""; // Очистить поле ввода Пин-кода
                if (CurrentMachine.Display == Displays.Transfer)
                    CurrentActiveTb.Text = ""; // Очистить поле ввода Пин-кода
            }
            else if (CallerButton.Text == "ENTER") // Если кнопка, вызвавшая событие - ENTER, то:
            {
                if (CurrentMachine.Display == Displays.InputPIN)
                {
                    if (CurrentMachine.Display == Displays.InputPIN && Pin_InputText.Text.Length == 4)
                    {
                        if (!Bank.CheckPIN(CurrentCard, Pin_InputText.Text))
                        {
                            CurrentMachine.TryInputPin += 1;
                            Label Warn = CurrentAtm.Controls.Find("DISPLAY_Pin_Warning_Label", true).FirstOrDefault() as Label;
                            Warn.Visible = true;
                            Warn.Text = "ПИН-КОД ВВЕДЕН НЕ ВЕРНО!\n";
                            Warn.Text += "Осталось попыток:" + (3 - CurrentMachine.TryInputPin).ToString();
                            _DEBUGGER.DEBUG_CONSOLE("ПИН-КОД ВВЕДЕН НЕ ВЕРНО!");
                            _DEBUGGER.DEBUG_CONSOLE("Осталось попыток:" + (3 - CurrentMachine.TryInputPin).ToString());
                            if (CurrentMachine.TryInputPin == 3)
                            {
                                Warn.Text = "КАРТА КОНФИСКОВАНА!";
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
            }
            else if (CallerButton.Text != " ") // Если кнопка, вызвавшая событие - цифры, то:
            {
                // Добавить цифру с текста кнопки, вызвавшей событие, но не больше 4ех символов
                if (CurrentMachine.Display == Displays.InputPIN && Pin_InputText.Text.Length < 4) Pin_InputText.Text += CallerButton.Text;
                if (CurrentMachine.Display == Displays.Transfer)
                {
                    if (CurrentActiveTb != null)
                    CurrentActiveTb.Text += CallerButton.Text;
                }
            }
        }
        
        //TODO поменять функцию
        private void OnWithdrawСash_Click(object sender, EventArgs e)
        {
            // Кнопка, вызвавшая событие
            Button CallerButton = sender as Button;

            // Текущий банкомат(Согласно кнопке, вызвавшей событие)
            AtmMachine CurrentMachine = Bank.AtmMachines[Convert.ToInt32(CallerButton.Tag)];
            // Текущий банкомат-визуализация(Согласно кнопке, вызвавшей событие)
            Panel CurrentAtm = MainControls.Find("ATM", true).Where(t => t.Tag.ToString() == CallerButton.Tag.ToString()).FirstOrDefault() as Panel;
            // Текущий банкомат-визуализация(Согласно кнопке, вызвавшей событие)


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
                RichTextBox RTBHELP = CurrentAtm.Controls.Find("RTB_HELP", true).FirstOrDefault() as RichTextBox;

                string resultRTBHELP = "";
                resultRTBHELP = string.Format(
                    "Банк {0} сообщает, что остаток денежных средств по счету {1} по состоянию на {2} составляет:\n" +
                    "{3} рублей"
                    ,
                    Bank._Name,
                    CurrentCard.GetAccountByCurrentCard(Bank, CurrentCard._NumberCard)._Number.ToString(),
                    DateTime.Now.ToString("dd.MM.yyyy г."),
                    CurrentCard.GetAccountByCurrentCard(Bank, CurrentCard._NumberCard)._Balance.ToString()
                    );

                RTBHELP.Text = resultRTBHELP;
            }
            else if (CallerButton.Text == "ПЕРЕВОД НАЛИЧНЫХ")
            {
                CurrentMachine.Display = MAIN_FUNCTIONS.ChangeDisplay(Convert.ToInt32(CallerButton.Tag), VISUALIZER, CurrentAtm.Controls, Displays.Transfer);
                TextBox Out = CurrentAtm.Controls.Find("DISPLAY_Pin_FirstAccount_InputText", true).FirstOrDefault() as TextBox;
                Out.Text = CurrentCard._NumberAccount;
            }
        }

        //TODO
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

        //TODO
        private void OnAnotherAmount_Click(object sender, EventArgs e)
        {
            // Кнопка, вызвавшая событие
            Button CallerButton = sender as Button;

            // Текущий банкомат(Согласно кнопке, вызвавшей событие)
            AtmMachine CurrentMachine = Bank.AtmMachines[Convert.ToInt32(CallerButton.Tag)];
            // Текущий банкомат-визуализация(Согласно кнопке, вызвавшей событие)
            Panel CurrentAtm = MainControls.Find("ATM", true).Where(t => t.Tag.ToString() == CallerButton.Tag.ToString()).FirstOrDefault() as Panel;

            CurrentMachine.Display = MAIN_FUNCTIONS.ChangeDisplay(Convert.ToInt32(CallerButton.Tag), VISUALIZER, CurrentAtm.Controls, Displays.AnotherAmount);
        }

        //TODO
        private void OnTransfer_Click(object sender, EventArgs e)
        {
            // Кнопка, вызвавшая событие
            Button CallerButton = sender as Button;

            // Текущий банкомат(Согласно кнопке, вызвавшей событие)
            AtmMachine CurrentMachine = Bank.AtmMachines[Convert.ToInt32(CallerButton.Tag)];
            // Текущий банкомат-визуализация(Согласно кнопке, вызвавшей событие)
            Panel CurrentAtm = MainControls.Find("ATM", true).Where(t => t.Tag.ToString() == CallerButton.Tag.ToString()).FirstOrDefault() as Panel;

            if (CurrentMachine.Display == Displays.Transfer)
            {
                TextBox Out = CurrentAtm.Controls.Find("DISPLAY_Pin_FirstAccount_InputText", true).FirstOrDefault() as TextBox;
                TextBox In = CurrentAtm.Controls.Find("DISPLAY_Pin_SecondAccount_InputText", true).FirstOrDefault() as TextBox;
                TextBox Value = CurrentAtm.Controls.Find("DISPLAY_Pin_TransferAmount_InputText", true).FirstOrDefault() as TextBox;
                string result = "";
                if (In.Text != string.Empty && Out.Text != string.Empty && Value.Text != string.Empty)
                    result = Bank.Transfer(Out.Text, In.Text, Convert.ToInt32(Value.Text));

                _DEBUGGER.DEBUG_CONSOLE(result);
            }
        }

        private void SelectUserCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectCardCB.Text = "Выбрать...";

            if (SelectUserCB.SelectedItem.ToString() == "(Оператор)") // Если в качестве текущего пользователя был выбран оператор то:
            {
                // Показать главную панель банкоматов
                MainPanel.Visible = true;

                label2.Visible = false;
                SelectCardCB.Visible = false;

                SETTINGS.CURRENT_USER = User.Operator; // Установить текущего пользователя приложения в "Оператор"
                for (int i = 0; i<Bank.AtmMachines.Count; i++) // Пройтись по всем банкоматам
                {
                    // Установить текущий банкомат
                    Panel CurrentAtm = MainControls.Find("ATM", true).Where(t => t.Tag.ToString() == i.ToString()).FirstOrDefault() as Panel;
                    // Сменить текущую дополнительную панель на панель оператора
                    MAIN_FUNCTIONS.ChangeAdditionalPanel(i, VISUALIZER, CurrentAtm.Controls, AdditionalPanels.For_Operator, Bank, CurrentIdUser);
                    // Заблокирвоать клавиатуру оператору
                    Panel Keyboard = MainControls.Find("KEYBOARD", true).Where(t => t.Tag.ToString() == i.ToString()).FirstOrDefault() as Panel;
                    Keyboard.Enabled = false;
                }
                // Сменить доступность банкоматов
                MAIN_FUNCTIONS.ChangeEnabledATMs(MainControls, Bank, CurrentIdUser);
            }
            else
            {
                SETTINGS.CURRENT_USER = User.Client; // Установить текущего пользователя приложения в "Клиент"
                CurrentIdUser = SelectUserCB.SelectedIndex - 1; // Установить ID текущего пользователя приложения
                SelectCardCB.Items.Clear();
                MainPanel.Visible = false;

                if (Bank.Clients[CurrentIdUser]._ATM != -1)
                {
                    SelectCardCB.Text = Bank.AtmMachines[Bank.Clients[CurrentIdUser]._ATM].CurrentCard;
                    SelectCardCB.Items.Add(Bank.AtmMachines[Bank.Clients[CurrentIdUser]._ATM].CurrentCard);
                    MainPanel.Visible = true;
                }

                SelectCardCB.Visible = true;
                label2.Visible = true;

                SelectCardCB.Items.AddRange(Bank.Clients[CurrentIdUser].GetFreeCardsStrings(Bank).ToArray());
                // Сменить доступность банкоматов
                MAIN_FUNCTIONS.ChangeEnabledATMs(MainControls, Bank, CurrentIdUser);
                for (int i = 0; i < Bank.AtmMachines.Count; i++) // Пройтись по всем банкоматам
                {
                    // Установить текущий банкомат
                    Panel CurrentAtm = MainControls.Find("ATM", true).Where(t => t.Tag.ToString() == i.ToString()).FirstOrDefault() as Panel;
                    // Сменить текущую дополнительную панель на панель клиента
                    MAIN_FUNCTIONS.ChangeAdditionalPanel(i, VISUALIZER, CurrentAtm.Controls, AdditionalPanels.For_Client, Bank, CurrentIdUser);
                    // Разблокирвоать клавиатуру клиенту
                    Panel Keyboard = MainControls.Find("KEYBOARD", true).Where(t => t.Tag.ToString() == i.ToString()).FirstOrDefault() as Panel;
                    Keyboard.Enabled = true;
                }
            }
        }

        private void SelectCardCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Показать главную панель банкоматов
            MainPanel.Visible = true;
            CurrentCard = Bank.DebitCards.Find(c => c._NumberCard == SelectCardCB.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _DEBUGGER.ChangeDebugger();
        }

        private void OnTb_Click(object sender, EventArgs e)
        {
            TextBox CallerTb = sender as TextBox;

            CurrentActiveTb = CallerTb;
        }
    }
}
