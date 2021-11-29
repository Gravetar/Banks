﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Banks
{
    /// <summary>
    /// Визуализатор проекта
    /// </summary>
    class VISUALIZER
    {
        /// <summary>
        /// Лист событий:
        /// 0 = OnKeyboard_Click
        /// 1 = OnAdditional_Click
        /// 2 = OnMainMenu_Click
        /// 3 = OnToMenu_Click
        /// 4 = OnWithdrawСash_Click
        /// 5 = OnAnotherAmount_Click
        /// 6 = OnTransfer_Click
        /// 7 = OnTb_Click
        /// </summary>
        public List<EventHandler> Events = new List<EventHandler>(2);

        /// <summary>
        /// Динамическое создание всех бакноматов
        /// </summary>
        /// <returns>Лист панелей банкомата</returns>
        public List<Panel> CreateAllATM()
        {
            // Лист банкоматов
            List<Panel> Machines = new List<Panel>();
            // Создать банкоматы согласно их количеству
            for (int i = 0; i < SETTINGS.ATM_COUNT; i++)
            {
                // Дисплей текуще-создоваемого банкомата
                Panel Display = new Panel();
                // Клавиатура текуще-создоваемого банкомата
                Panel Keyboard;
                // Дополнительная панель текуще-создоваемого банкомата
                Panel Additional = new Panel();

                // Установить дисплей банкомата(приветственный дисплей)
                DisplayWelcome(i, ref Display);
                // Установить клавиатуру банкомата
                Keyboard = DisplayKeyboard(i);
                // Установить дополнительнау панель банкомата
                DisplayAdditional(i, ref Additional);
                // Добавить созданный банкомат в лист банкоматов
                Machines.Add(CreateATM(i, Display, Keyboard, Additional));
                // Установить расстояние между банкоматами
                Machines[i].Margin = new Padding(20);
            }
            // Вернуть лист панелей банкомата
            return Machines;
        }

        /// <summary>
        /// Создать панель банкомата
        /// </summary>
        /// <param name="Machine">Номер банкомата</param>
        /// <param name="Display">Дисплей банкомата</param>
        /// <param name="Keyboard">Клавиатура банкомата</param>
        /// <param name="Additional">Дополнительная панель банкомата</param>
        /// <returns>Панель банкомата</returns>
        public Panel CreateATM(int Machine, Panel Display, Panel Keyboard, Panel Additional)
        {
            // Основная панель банкомата
            Panel ATM = new Panel();
            ATM.Name = "ATM";
            ATM.Location = new Point(100, 100);
            ATM.AutoSize = true;
            ATM.BorderStyle = BorderStyle.Fixed3D;
            ATM.Tag = Machine;
            // Добавить Дисплей, клавиатуру и дополнительную панель в основную панель банкомата
            ATM.Controls.AddRange(new Control[] { Display, Keyboard, Additional});
            // Вернуть панель банкомата
            return ATM;
        }

        /// <summary>
        /// Чистый дисплей
        /// </summary>
        /// <param name="Display">Изменяемый дисплей(панель)</param>
        public void DisplayClear(ref Panel Display)
        {
            // Основной дисплей
            Panel DISPLAY_Clear = new Panel();
            DISPLAY_Clear.Name = "DISPLAY";
            DISPLAY_Clear.Location = new Point(100, 100);
            DISPLAY_Clear.Size = SETTINGS.DISPLAY_SIZE;
            DISPLAY_Clear.BorderStyle = BorderStyle.Fixed3D;
            // Вернуть панель основного дисплей
            Display = DISPLAY_Clear;
        }

        /// <summary>
        /// Дисплей приветствия
        /// </summary>
        /// <param name="Display">Изменяемый дисплей(панель)</param>
        public void DisplayWelcome(int Machine, ref Panel Display)
        {
            // Основной дисплей
            Panel DISPLAY_Welcome = new Panel();
            DISPLAY_Welcome.Name = "DISPLAY";
            DISPLAY_Welcome.Location = new Point(0, 0);
            DISPLAY_Welcome.Size = SETTINGS.DISPLAY_SIZE;
            DISPLAY_Welcome.BorderStyle = BorderStyle.Fixed3D;
            DISPLAY_Welcome.Tag = Machine.ToString();

            //Текст приветствия на дисплее
            Label DISPLAY_Welcome_MainText = new Label();
            DISPLAY_Welcome_MainText.Name = "DISPLAY_Welcome_MainText";
            DISPLAY_Welcome_MainText.Text = SETTINGS.WELCOME_TEXT;
            DISPLAY_Welcome_MainText.TextAlign = ContentAlignment.MiddleCenter;
            DISPLAY_Welcome_MainText.AutoSize = true;
            DISPLAY_Welcome_MainText.Location = new Point((DISPLAY_Welcome.Width / 2) - DISPLAY_Welcome_MainText.Size.Width, (DISPLAY_Welcome.Height / 2) - DISPLAY_Welcome_MainText.Size.Height);

            // Добавить в основной дисплей:
                // Текст приветствия на дисплее
            DISPLAY_Welcome.Controls.Add(DISPLAY_Welcome_MainText);
            // Изменяемый дисплей(панель) изменить на Основной дисплей
            Display = DISPLAY_Welcome;
        }

        /// <summary>
        /// Дисплей заберите карту
        /// </summary>
        /// <param name="Display">Изменяемый дисплей(панель)</param>
        public void DisplayOutCard(int Machine, ref Panel Display)
        {
            // Основной дисплей
            Panel DISPLAY_OutCard = new Panel();
            DISPLAY_OutCard.Name = "DISPLAY";
            DISPLAY_OutCard.Location = new Point(0, 0);
            DISPLAY_OutCard.Size = SETTINGS.DISPLAY_SIZE;
            DISPLAY_OutCard.BorderStyle = BorderStyle.Fixed3D;
            DISPLAY_OutCard.Tag = Machine.ToString();

            //Текст приветствия на дисплее
            Label DISPLAY_OutCard_MainText = new Label();
            DISPLAY_OutCard_MainText.Name = "DISPLAY_OutCard_MainText";
            DISPLAY_OutCard_MainText.Text = SETTINGS.OUTCARD_TEXT;
            DISPLAY_OutCard_MainText.TextAlign = ContentAlignment.MiddleCenter;
            DISPLAY_OutCard_MainText.AutoSize = true;
            DISPLAY_OutCard_MainText.Location = new Point((DISPLAY_OutCard.Width / 2) - DISPLAY_OutCard_MainText.Size.Width, (DISPLAY_OutCard.Height / 2) - DISPLAY_OutCard_MainText.Size.Height);

            // Добавить в основной дисплей:
            // Текст приветствия на дисплее
            DISPLAY_OutCard.Controls.Add(DISPLAY_OutCard_MainText);
            // Изменяемый дисплей(панель) изменить на Основной дисплей
            Display = DISPLAY_OutCard;
        }

        /// <summary>
        /// Дисплей для ввода пин-кода
        /// </summary>
        /// <param name="Display">Изменяемый дисплей(панель)</param>
        public void DisplayInputPIN(int Machine, ref Panel Display)
        {
            // Основной дисплей
            Panel DISPLAY_Pin = new Panel();
            DISPLAY_Pin.Name = "DISPLAY";
            DISPLAY_Pin.Size = SETTINGS.DISPLAY_SIZE;
            DISPLAY_Pin.BorderStyle = BorderStyle.Fixed3D;
            DISPLAY_Pin.Tag = Machine.ToString();

            // Панель для элементов основного дисплея(для правильного отображения) 
            TableLayoutPanel DISPLAY_Pin_TLP = new TableLayoutPanel();
            DISPLAY_Pin_TLP.Name = "DISPLAY_PIN_FLP";
            DISPLAY_Pin_TLP.ColumnCount = 3;
            DISPLAY_Pin_TLP.AutoSize = true;
            DISPLAY_Pin_TLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            DISPLAY_Pin_TLP.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            DISPLAY_Pin_TLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            DISPLAY_Pin_TLP.Padding = new Padding(0, 50, 0, 0);

            // Текст с просьбой
            Label DISPLAY_Pin_MainText = new Label();
            DISPLAY_Pin_MainText.Name = "DISPLAY_Pin_MainText";
            DISPLAY_Pin_MainText.Text = "Введите пин-код!";
            DISPLAY_Pin_MainText.AutoSize = true;
            DISPLAY_Pin_MainText.Anchor = AnchorStyles.None;

            // Текстовый блок для ввода
            TextBox DISPLAY_Pin_InputText = new TextBox();
            DISPLAY_Pin_InputText.Name = "DISPLAY_Pin_InputText";
            DISPLAY_Pin_InputText.ReadOnly = true;
            DISPLAY_Pin_InputText.Size = new Size(150, 100);
            DISPLAY_Pin_InputText.Anchor = AnchorStyles.None;

            //Текст с предупреждением
            Label DISPLAY_Pin_Warning_Label = new Label();
            DISPLAY_Pin_Warning_Label.Name = "DISPLAY_Pin_Warning_Label";
            DISPLAY_Pin_Warning_Label.TextAlign = ContentAlignment.MiddleCenter;
            DISPLAY_Pin_Warning_Label.Margin = new Padding(0, 10, 0, 0);
            DISPLAY_Pin_Warning_Label.Visible = false;
            DISPLAY_Pin_Warning_Label.AutoSize = true;
            DISPLAY_Pin_Warning_Label.ForeColor = Color.Red;
            DISPLAY_Pin_Warning_Label.Anchor = AnchorStyles.None;

            //Добавить в Панель для элементов основного дисплея:
            // Текст с просьбой
            DISPLAY_Pin_TLP.Controls.Add(DISPLAY_Pin_MainText, 1, 1);
            // Текстовый блок для ввода
            DISPLAY_Pin_TLP.Controls.Add(DISPLAY_Pin_InputText, 1, 2);
            //Текст с предупреждением
            DISPLAY_Pin_TLP.Controls.Add(DISPLAY_Pin_Warning_Label, 1, 3);
            // Добавить в основной дисплей:
            // Панель для элементов основного дисплея
            DISPLAY_Pin.Controls.Add(DISPLAY_Pin_TLP);
            // Изменяемый дисплей(панель) изменить на Основной дисплей
            Display = DISPLAY_Pin;
        }

        /// <summary>
        /// Дисплей с меню выбора
        /// </summary>
        /// <param name="Display">Изменяемый дисплей(панель)</param>
        public void DisplayMenu(int Machine, ref Panel Display)
        {
            // Основной дисплей
            Panel DISPLAY_Menu = new Panel();
            DISPLAY_Menu.Name = "DISPLAY";
            DISPLAY_Menu.Location = new Point(0, 0);
            DISPLAY_Menu.Size = SETTINGS.DISPLAY_SIZE;
            DISPLAY_Menu.BorderStyle = BorderStyle.Fixed3D;
            DISPLAY_Menu.Tag = Machine.ToString();

            // Панель для кнопок с основными операциями
            FlowLayoutPanel DISPLAY_MENU_FLP = new FlowLayoutPanel();
            DISPLAY_MENU_FLP.Name = "DISPLAY_MENU_FLP";
            DISPLAY_MENU_FLP.FlowDirection = FlowDirection.TopDown;
            DISPLAY_MENU_FLP.AutoSize = true;
            DISPLAY_MENU_FLP.Padding = new Padding(10, 10, 10, 10);

            Button BTN_MENU_WITHDRAW = new Button();
            BTN_MENU_WITHDRAW.Name = "BTN_MENU_WITHDRAW"; 
            BTN_MENU_WITHDRAW.Size = new Size(180, 30);
            BTN_MENU_WITHDRAW.Text = "СНЯТЬ НАЛИЧНЫЕ";
            BTN_MENU_WITHDRAW.Tag = Machine;
            BTN_MENU_WITHDRAW.Click += new EventHandler(Events[2]);
            DISPLAY_MENU_FLP.Controls.Add(BTN_MENU_WITHDRAW);

            Button BTN_MENU_HELP = new Button();
            BTN_MENU_HELP.Name = "BTN_MENU_WITHDRAW"; 
            BTN_MENU_HELP.Size = new Size(180, 30);
            BTN_MENU_HELP.Text = "СПРАВКА";
            BTN_MENU_HELP.Tag = Machine;
            BTN_MENU_HELP.Click += new EventHandler(Events[2]);
            DISPLAY_MENU_FLP.Controls.Add(BTN_MENU_HELP);

            Button BTN_MENU_TRANSFER = new Button();
            BTN_MENU_TRANSFER.Name = "BTN_MENU_WITHDRAW"; 
            BTN_MENU_TRANSFER.Size = new Size(180, 30);
            BTN_MENU_TRANSFER.Text = "ПЕРЕВОД НАЛИЧНЫХ";
            BTN_MENU_TRANSFER.Tag = Machine;
            BTN_MENU_TRANSFER.Click += new EventHandler(Events[2]);
            DISPLAY_MENU_FLP.Controls.Add(BTN_MENU_TRANSFER);

            // Добавить в основной дисплей:
            // Дисплей меню
            DISPLAY_Menu.Controls.Add(DISPLAY_MENU_FLP);
            // Изменяемый дисплей(панель) изменить на Основной дисплей
            Display = DISPLAY_Menu;
        }

        /// <summary>
        /// Дисплей справки
        /// </summary>
        /// <param name="Display">Изменяемый дисплей(панель)</param>
        public void DisplayHelp(int Machine, ref Panel Display)
        {
            // Основной дисплей
            Panel DISPLAY_Help = new Panel();
            DISPLAY_Help.Name = "DISPLAY";
            DISPLAY_Help.Location = new Point(0, 0);
            DISPLAY_Help.Size = SETTINGS.DISPLAY_SIZE;
            DISPLAY_Help.BorderStyle = BorderStyle.Fixed3D;
            DISPLAY_Help.Tag = Machine.ToString();

            // Панель 
            FlowLayoutPanel DISPLAY_HELP_FLP = new FlowLayoutPanel();
            DISPLAY_HELP_FLP.Name = "DISPLAY_HELP_FLP";
            DISPLAY_HELP_FLP.FlowDirection = FlowDirection.TopDown;
            DISPLAY_HELP_FLP.AutoSize = true;

            RichTextBox RTB_HELP = new RichTextBox();
            RTB_HELP.Name = "RTB_HELP";
            RTB_HELP.Size = new Size(200, 155);
            RTB_HELP.ReadOnly = true;
            DISPLAY_HELP_FLP.Controls.Add(RTB_HELP);

            Button BTN_HELP_BACK = new Button();
            BTN_HELP_BACK.Name = "BTN_HELP_BACK"; 
            BTN_HELP_BACK.Size = new Size(200, 20);
            BTN_HELP_BACK.Text = "ВЕРНУТЬСЯ НАЗАД";
            BTN_HELP_BACK.ForeColor = Color.Red;
            BTN_HELP_BACK.Tag = Machine;
            BTN_HELP_BACK.Click += new EventHandler(Events[3]);
            DISPLAY_HELP_FLP.Controls.Add(BTN_HELP_BACK);

            // Добавить в основной дисплей:
            // Текст приветствия на дисплее
            DISPLAY_Help.Controls.Add(DISPLAY_HELP_FLP);
            // Изменяемый дисплей(панель) изменить на Основной дисплей
            Display = DISPLAY_Help;
        }

        /// <summary>
        /// Дисплей справки
        /// </summary>
        /// <param name="Display">Изменяемый дисплей(панель)</param>
        public void DisplayWithdraw(int Machine, ref Panel Display)
        {
            // Основной дисплей
            Panel DISPLAY_Withdraw = new Panel();
            DISPLAY_Withdraw.Name = "DISPLAY";
            DISPLAY_Withdraw.Location = new Point(0, 0);
            DISPLAY_Withdraw.Size = SETTINGS.DISPLAY_SIZE;
            DISPLAY_Withdraw.BorderStyle = BorderStyle.Fixed3D;
            DISPLAY_Withdraw.Tag = Machine.ToString();

            // Панель 
            TableLayoutPanel DISPLAY_WITHDRAW_TLP = new TableLayoutPanel();
            DISPLAY_WITHDRAW_TLP.Name = "DISPLAY_WITHDRAW_TLP";
            DISPLAY_WITHDRAW_TLP.AutoSize = true;
            DISPLAY_WITHDRAW_TLP.ColumnCount = 2;
            DISPLAY_WITHDRAW_TLP.RowCount = 8;
            DISPLAY_WITHDRAW_TLP.Padding = new Padding(10, 10, 10, 10);
            int currency = 50;
            // Кнопки валют(цифры 100-5000)
            for (int i = 0; i < 6; i++)
            {
                currency = currency * 2;
                if(i == 2 || i == 5)
                {
                    currency = currency + currency/4;
                }

                Button BTN_WITHDRAW_CURRENCY = new Button();
                BTN_WITHDRAW_CURRENCY.Name = "BTN_WITHDRAW_CURRENCY" + currency.ToString(); // KEYBOARD_BTN_1 ... KEYBOARD_BTN_9
                BTN_WITHDRAW_CURRENCY.Size = new Size(87, 30);
                BTN_WITHDRAW_CURRENCY.Text = currency.ToString();
                BTN_WITHDRAW_CURRENCY.Tag = Machine;
                BTN_WITHDRAW_CURRENCY.Click += new EventHandler(Events[4]);
                DISPLAY_WITHDRAW_TLP.Controls.Add(BTN_WITHDRAW_CURRENCY);
            }

            Button BTN_WITHDRAW_BACK = new Button();
            BTN_WITHDRAW_BACK.Name = "BTN_WITHDRAW_BACK";
            BTN_WITHDRAW_BACK.Size = new Size(87, 30);
            BTN_WITHDRAW_BACK.Text = "НАЗАД";
            BTN_WITHDRAW_BACK.ForeColor = Color.Red;
            BTN_WITHDRAW_BACK.Tag = Machine;
            BTN_WITHDRAW_BACK.Click += new EventHandler(Events[3]);
            DISPLAY_WITHDRAW_TLP.Controls.Add(BTN_WITHDRAW_BACK);

            Button BTN_WITHDRAW_ANOTHER = new Button();
            BTN_WITHDRAW_ANOTHER.Name = "BTN_WITHDRAW_ANOTHER";
            BTN_WITHDRAW_ANOTHER.Size = new Size(87, 30);
            BTN_WITHDRAW_ANOTHER.Text = "ДРУГАЯ";
            BTN_WITHDRAW_ANOTHER.ForeColor = Color.Green;
            BTN_WITHDRAW_ANOTHER.Tag = Machine;
            BTN_WITHDRAW_ANOTHER.Click += new EventHandler(Events[5]);
            DISPLAY_WITHDRAW_TLP.Controls.Add(BTN_WITHDRAW_ANOTHER);

            // Добавить в основной дисплей:
            // Текст приветствия на дисплее
            DISPLAY_Withdraw.Controls.Add(DISPLAY_WITHDRAW_TLP);
            // Изменяемый дисплей(панель) изменить на Основной дисплей
            Display = DISPLAY_Withdraw;
        }


        /// <summary>
        /// Дисплей с введением другой суммы и снятию этой суммы
        /// </summary>
        /// <param name="Display">Изменяемый дисплей(панель)</param>
        public void DisplayAnotherAmount(int Machine, ref Panel Display)
        {
            // Основной дисплей
            Panel Display_Another_Amount = new Panel();
            Display_Another_Amount.Name = "DISPLAY";
            Display_Another_Amount.Location = new Point(0, 0);
            Display_Another_Amount.Size = SETTINGS.DISPLAY_SIZE;
            Display_Another_Amount.BorderStyle = BorderStyle.Fixed3D;
            Display_Another_Amount.Tag = Machine.ToString();

            // Панель для кнопок с основными операциями
            FlowLayoutPanel Display_ANOTHER_AMOUNT_FLP = new FlowLayoutPanel();
            Display_ANOTHER_AMOUNT_FLP.Name = "Display_ANOTHER_AMOUNT_FLP";
            Display_ANOTHER_AMOUNT_FLP.FlowDirection = FlowDirection.TopDown;
            Display_ANOTHER_AMOUNT_FLP.AutoSize = true;
            Display_ANOTHER_AMOUNT_FLP.Padding = new Padding(10, 10, 10, 10);

            // Текстовый блок для ввода
            TextBox DISPLAY_Another_Amount_InputText = new TextBox();
            DISPLAY_Another_Amount_InputText.Name = "DISPLAY_Another_Amount_InputText";
            DISPLAY_Another_Amount_InputText.ReadOnly = true;
            DISPLAY_Another_Amount_InputText.Size = new Size(150, 100);
            DISPLAY_Another_Amount_InputText.Anchor = AnchorStyles.None;

            // Кнопка для снятия суммы
            Button BTN_ANOTHER_AMOUNT_WITHDRAW = new Button();
            BTN_ANOTHER_AMOUNT_WITHDRAW.Name = "BTN_ANOTHER_AMOUNT_WITHDRAW";
            BTN_ANOTHER_AMOUNT_WITHDRAW.Size = new Size(180, 30);
            BTN_ANOTHER_AMOUNT_WITHDRAW.Text = "СНЯТЬ СУММУ";
            BTN_ANOTHER_AMOUNT_WITHDRAW.Tag = Machine;
            // TODO
            //Поменять ивент
            BTN_ANOTHER_AMOUNT_WITHDRAW.Click += new EventHandler(Events[3]);
            Display_ANOTHER_AMOUNT_FLP.Controls.Add(DISPLAY_Another_Amount_InputText);
            Display_ANOTHER_AMOUNT_FLP.Controls.Add(BTN_ANOTHER_AMOUNT_WITHDRAW);

            // Добавить в основной дисплей:
            // Дисплей меню
            Display_Another_Amount.Controls.Add(Display_ANOTHER_AMOUNT_FLP);
            // Изменяемый дисплей(панель) изменить на Основной дисплей
            Display = Display_Another_Amount;
        }

        /// <summary>
        /// Дисплей перевода между счетами 
        /// </summary>
        /// <param name="Display">Изменяемый дисплей(панель)</param>
        public void DisplayTransfer(int Machine, ref Panel Display)
        {
            // Основной дисплей
            Panel DISPLAY_Transfer = new Panel();
            DISPLAY_Transfer.Name = "DISPLAY";
            DISPLAY_Transfer.Location = new Point(0, 0);
            DISPLAY_Transfer.Size = SETTINGS.DISPLAY_SIZE;
            DISPLAY_Transfer.BorderStyle = BorderStyle.Fixed3D;
            DISPLAY_Transfer.Tag = Machine.ToString();

            // Панель 
            TableLayoutPanel DISPLAY_TRANSFER_TLP = new TableLayoutPanel();
            DISPLAY_TRANSFER_TLP.Name = "DISPLAY_TRANSFER_TLP";
            DISPLAY_TRANSFER_TLP.AutoSize = true;
            DISPLAY_TRANSFER_TLP.ColumnCount = 2;
            DISPLAY_TRANSFER_TLP.RowCount = 4;
            DISPLAY_TRANSFER_TLP.Padding = new Padding(10, 10, 10, 10);

            // Текст с первым счетом
            Label DISPLAY_Pin_FirstAccount_Label = new Label();
            DISPLAY_Pin_FirstAccount_Label.Name = "DISPLAY_Pin_FirstAccount_Label";
            DISPLAY_Pin_FirstAccount_Label.Text = "Счет списания";
            DISPLAY_Pin_FirstAccount_Label.AutoSize = true;
            DISPLAY_Pin_FirstAccount_Label.Anchor = AnchorStyles.None;
            DISPLAY_TRANSFER_TLP.Controls.Add(DISPLAY_Pin_FirstAccount_Label);

            // Текстовый блок для ввода первого счета
            TextBox DISPLAY_Pin_FirstAccount_InputText = new TextBox();
            DISPLAY_Pin_FirstAccount_InputText.Name = "DISPLAY_Pin_FirstAccount_InputText";
            DISPLAY_Pin_FirstAccount_InputText.ReadOnly = true;
            DISPLAY_Pin_FirstAccount_InputText.Size = new Size(150, 100);
            DISPLAY_Pin_FirstAccount_InputText.Anchor = AnchorStyles.None;
            DISPLAY_TRANSFER_TLP.Controls.Add(DISPLAY_Pin_FirstAccount_InputText);

            // Текст со вторым счетом
            Label DISPLAY_Pin_SecondAccount_Label = new Label();
            DISPLAY_Pin_SecondAccount_Label.Name = "DISPLAY_Pin_SecondAccount_Label";
            DISPLAY_Pin_SecondAccount_Label.Text = "Счет пополнения";
            DISPLAY_Pin_SecondAccount_Label.AutoSize = true;
            DISPLAY_Pin_SecondAccount_Label.Anchor = AnchorStyles.None;
            DISPLAY_TRANSFER_TLP.Controls.Add(DISPLAY_Pin_SecondAccount_Label);

            // Текстовый блок для ввода
            TextBox DISPLAY_Pin_SecondAccount_InputText = new TextBox();
            DISPLAY_Pin_SecondAccount_InputText.Name = "DISPLAY_Pin_SecondAccount_InputText";
            DISPLAY_Pin_SecondAccount_InputText.ReadOnly = true;
            DISPLAY_Pin_SecondAccount_InputText.Size = new Size(150, 100);
            DISPLAY_Pin_SecondAccount_InputText.Anchor = AnchorStyles.None;
            DISPLAY_TRANSFER_TLP.Controls.Add(DISPLAY_Pin_SecondAccount_InputText);

            // Текст с суммой переводы
            Label DISPLAY_Pin_TransferAmount_Label = new Label();
            DISPLAY_Pin_TransferAmount_Label.Name = "DISPLAY_Pin_TransferAmount_Label";
            DISPLAY_Pin_TransferAmount_Label.Text = "Введите сумму";
            DISPLAY_Pin_TransferAmount_Label.AutoSize = true;
            DISPLAY_Pin_TransferAmount_Label.Anchor = AnchorStyles.None;
            DISPLAY_TRANSFER_TLP.Controls.Add(DISPLAY_Pin_TransferAmount_Label);

            // Текстовый блок для ввода суммы перевода
            TextBox DISPLAY_Pin_TransferAmount_InputText = new TextBox();
            DISPLAY_Pin_TransferAmount_InputText.Name = "DISPLAY_Pin_TransferAmount_InputText";
            DISPLAY_Pin_TransferAmount_InputText.ReadOnly = true;
            DISPLAY_Pin_TransferAmount_InputText.Size = new Size(150, 100);
            DISPLAY_Pin_TransferAmount_InputText.Anchor = AnchorStyles.None;
            DISPLAY_Pin_TransferAmount_InputText.Click += Events[7];
            DISPLAY_TRANSFER_TLP.Controls.Add(DISPLAY_Pin_TransferAmount_InputText);

            Button BTN_TRANSFER_BACK = new Button();
            BTN_TRANSFER_BACK.Name = "BTN_WITHDRAW_BACK";
            BTN_TRANSFER_BACK.Size = new Size(87, 30);
            BTN_TRANSFER_BACK.Text = "НАЗАД";
            BTN_TRANSFER_BACK.ForeColor = Color.Red;
            BTN_TRANSFER_BACK.Tag = Machine;
            BTN_TRANSFER_BACK.Click += new EventHandler(Events[3]);
            DISPLAY_TRANSFER_TLP.Controls.Add(BTN_TRANSFER_BACK);

            Button BTN_TRANSFER_TRANSFER = new Button();
            BTN_TRANSFER_TRANSFER.Name = "BTN_WITHDRAW_ANOTHER";
            BTN_TRANSFER_TRANSFER.Size = new Size(87, 30);
            BTN_TRANSFER_TRANSFER.Text = "ВЫПОЛНИТЬ";
            BTN_TRANSFER_TRANSFER.ForeColor = Color.Green;
            BTN_TRANSFER_TRANSFER.Tag = Machine;
            BTN_TRANSFER_TRANSFER.Click += new EventHandler(Events[6]);
            DISPLAY_TRANSFER_TLP.Controls.Add(BTN_TRANSFER_TRANSFER);

            // Добавить в основной дисплей:
            // Текст приветствия на дисплее
            DISPLAY_Transfer.Controls.Add(DISPLAY_TRANSFER_TLP);
            // Изменяемый дисплей(панель) изменить на Основной дисплей
            Display = DISPLAY_Transfer;
        }

        /// <summary>
        /// Клавиатура банкомата
        /// </summary>
        /// <param name="Machine">Банкомат клавиатуры</param>
        public Panel DisplayKeyboard(int Machine)
        {
            // Основной дисплей
            Panel DISPLAY_KEYBOARD = new Panel();
            DISPLAY_KEYBOARD.Name = "KEYBOARD";
            DISPLAY_KEYBOARD.Location = new Point(0, 200);
            DISPLAY_KEYBOARD.Size = SETTINGS.KEYBOARD_SIZE;
            DISPLAY_KEYBOARD.BorderStyle = BorderStyle.Fixed3D;
            DISPLAY_KEYBOARD.Tag = Machine;

            // Панель для элементов клавиатуры 
            TableLayoutPanel DISPLAY_KEYB_TLP = new TableLayoutPanel();
            DISPLAY_KEYB_TLP.Name = "DISPLAY_KEYB_TLP";
            DISPLAY_KEYB_TLP.AutoSize = true;
            DISPLAY_KEYB_TLP.ColumnCount = 4;
            DISPLAY_KEYB_TLP.RowCount = 4;
            DISPLAY_KEYB_TLP.Padding = new Padding(10, 10, 10, 10);

            // Кнопки клавиатуры(цифры 1-9)
            for (int i = 1; i<=9; i++)
            {
                Button BTN_KEYB_NUM = new Button();
                BTN_KEYB_NUM.Name = "BTN_KEYB_NUM" + i.ToString(); // KEYBOARD_BTN_1 ... KEYBOARD_BTN_9
                BTN_KEYB_NUM.Size = new Size(30, 30);
                BTN_KEYB_NUM.Text = i.ToString();
                BTN_KEYB_NUM.Tag = Machine;
                BTN_KEYB_NUM.Click += new EventHandler(Events[0]);
                DISPLAY_KEYB_TLP.Controls.Add(BTN_KEYB_NUM);
            }
            // Кнопки клавиатуры(0, Пустые)
            Button BTN_KEYB_NULL = new Button();
            BTN_KEYB_NULL.Name = "BTN_KEYB_NULL";
            BTN_KEYB_NULL.Size = new Size(30, 30);
            BTN_KEYB_NULL.Text = " ";
            BTN_KEYB_NULL.Tag = Machine;
            DISPLAY_KEYB_TLP.Controls.Add(BTN_KEYB_NULL);

            Button BTN_KEYB_0 = new Button();
            BTN_KEYB_0.Name = "BTN_KEYB_0";
            BTN_KEYB_0.Size = new Size(30, 30);
            BTN_KEYB_0.Text = "0";
            BTN_KEYB_0.Tag = Machine;
            BTN_KEYB_0.Click += new EventHandler(Events[0]);
            DISPLAY_KEYB_TLP.Controls.Add(BTN_KEYB_0);

            Button BTN_KEYB_NULL2 = new Button();
            BTN_KEYB_NULL2.Name = "BTN_KEYB_NULL2";
            BTN_KEYB_NULL2.Size = new Size(30, 30);
            BTN_KEYB_NULL2.Text = " ";
            BTN_KEYB_NULL2.Tag = Machine;
            DISPLAY_KEYB_TLP.Controls.Add(BTN_KEYB_NULL2);

            // Кнопки клавиатуры(CANCEL, CLEAR, ENTER, Пустая)
            Button BTN_KEYB_CANCEL = new Button();
            BTN_KEYB_CANCEL.Name = "BTN_KEYB_CANCEL";
            BTN_KEYB_CANCEL.Size = new Size(60, 30);
            BTN_KEYB_CANCEL.Text = "CANCEL";
            BTN_KEYB_CANCEL.Tag = Machine;
            BTN_KEYB_CANCEL.Click += new EventHandler(Events[0]);
            DISPLAY_KEYB_TLP.Controls.Add(BTN_KEYB_CANCEL, 3, 0);

            Button BTN_KEYB_CLEAR = new Button();
            BTN_KEYB_CLEAR.Name = "BTN_KEYB_CLEAR";
            BTN_KEYB_CLEAR.Size = new Size(60, 30);
            BTN_KEYB_CLEAR.Text = "CLEAR";
            BTN_KEYB_CLEAR.Tag = Machine;
            BTN_KEYB_CLEAR.Click += new EventHandler(Events[0]);
            DISPLAY_KEYB_TLP.Controls.Add(BTN_KEYB_CLEAR, 3, 1);

            Button BTN_KEYB_ENTER = new Button();
            BTN_KEYB_ENTER.Name = "BTN_KEYB_ENTER";
            BTN_KEYB_ENTER.Size = new Size(60, 30);
            BTN_KEYB_ENTER.Text = "ENTER";
            BTN_KEYB_ENTER.Tag = Machine;
            BTN_KEYB_ENTER.Click += new EventHandler(Events[0]);
            DISPLAY_KEYB_TLP.Controls.Add(BTN_KEYB_ENTER, 3, 2);

            Button BTN_KEYB_NULL3 = new Button();
            BTN_KEYB_NULL3.Name = "BTN_KEYB_NULL3";
            BTN_KEYB_NULL3.Size = new Size(60, 30);
            BTN_KEYB_NULL3.Text = " ";
            BTN_KEYB_NULL3.Tag = Machine;
            BTN_KEYB_NULL3.Click += new EventHandler(Events[0]);
            DISPLAY_KEYB_TLP.Controls.Add(BTN_KEYB_NULL3, 3, 3);

            DISPLAY_KEYBOARD.Controls.Add(DISPLAY_KEYB_TLP);

            return DISPLAY_KEYBOARD;
        }

        /// <summary>
        /// Дополнительная панель к банкомату
        /// </summary>
        /// <param name="Machine">Банкомат дополнительной панели</param>
        /// <param name="Additional">Изменяемая дополнительная панель</param>
        public void DisplayAdditional(int Machine, ref Panel Additional)
        {
            // Основная панель для дополнительного
            Panel DISPLAY_ADDITIONAL = new Panel();
            DISPLAY_ADDITIONAL.Name = "ADDITIONAL";
            DISPLAY_ADDITIONAL.Location = new Point(210, 200);
            DISPLAY_ADDITIONAL.Size = new Size(0, 0);
            DISPLAY_ADDITIONAL.Tag = Machine.ToString();
            DISPLAY_ADDITIONAL.AutoSize = true;
            DISPLAY_ADDITIONAL.BorderStyle = BorderStyle.Fixed3D;

            // Кнопка (Вставить карту)
            Button BTN_ADDITIONAL_INCARD = new Button();
            BTN_ADDITIONAL_INCARD.Name = "BTN_ADDITIONAL_INCARD";
            BTN_ADDITIONAL_INCARD.Size = new Size(100, 30);
            BTN_ADDITIONAL_INCARD.Text = "Вставить карту";
            BTN_ADDITIONAL_INCARD.Left = 5;
            BTN_ADDITIONAL_INCARD.Top = 5;
            BTN_ADDITIONAL_INCARD.Tag = Machine.ToString();
            BTN_ADDITIONAL_INCARD.Click += new EventHandler(Events[1]);
            DISPLAY_ADDITIONAL.Controls.Add(BTN_ADDITIONAL_INCARD);

            // Кнопка (Забрать карту)
            Button BTN_ADDITIONAL_OUTCARD = new Button();
            BTN_ADDITIONAL_OUTCARD.Name = "BTN_ADDITIONAL_OUTCARD";
            BTN_ADDITIONAL_OUTCARD.Size = new Size(100, 30);
            BTN_ADDITIONAL_OUTCARD.Text = "Забрать карту";
            BTN_ADDITIONAL_OUTCARD.Left = 5;
            BTN_ADDITIONAL_OUTCARD.Top = 40;
            BTN_ADDITIONAL_OUTCARD.Tag = Machine.ToString();
            BTN_ADDITIONAL_OUTCARD.Enabled = false;
            BTN_ADDITIONAL_OUTCARD.Click += new EventHandler(Events[1]);
            DISPLAY_ADDITIONAL.Controls.Add(BTN_ADDITIONAL_OUTCARD);

            Additional = DISPLAY_ADDITIONAL;
        }

        /// <summary>
        /// Дополнительная панель к банкомату от лица оператора
        /// </summary>
        /// <param name="Machine">Банкомат дополнительной панели</param>
        /// <param name="Additional">зменяемая дополнительная панель</param>
        public void DisplayAdditionalOperator(int Machine, ref Panel Additional)
        {
            // Основная панель для дополнительного
            Panel DISPLAY_ADDITIONAL = new Panel();
            DISPLAY_ADDITIONAL.Name = "ADDITIONAL";
            DISPLAY_ADDITIONAL.Tag = Machine.ToString();
            DISPLAY_ADDITIONAL.Location = new Point(210, 200);
            DISPLAY_ADDITIONAL.Size = new Size(0, 0);
            DISPLAY_ADDITIONAL.AutoSize = true;
            DISPLAY_ADDITIONAL.BorderStyle = BorderStyle.Fixed3D;

            // Кнопка (Включить)
            Button BTN_ADDITIONAL_OnATM = new Button();
            BTN_ADDITIONAL_OnATM.Name = "BTN_ADDITIONAL_OnATM";
            BTN_ADDITIONAL_OnATM.Size = new Size(130, 30);
            BTN_ADDITIONAL_OnATM.Location = new Point(0, 0);
            BTN_ADDITIONAL_OnATM.Text = "Включить";
            BTN_ADDITIONAL_OnATM.Left = 5;
            BTN_ADDITIONAL_OnATM.Top = 5;
            BTN_ADDITIONAL_OnATM.Tag = Machine.ToString();
            BTN_ADDITIONAL_OnATM.Click += new EventHandler(Events[1]);
            DISPLAY_ADDITIONAL.Controls.Add(BTN_ADDITIONAL_OnATM);

            // Кнопка (Выключить)
            Button BTN_ADDITIONAL_OffATM = new Button();
            BTN_ADDITIONAL_OffATM.Name = "BTN_ADDITIONAL_OffATM";
            BTN_ADDITIONAL_OffATM.Size = new Size(130, 30);
            BTN_ADDITIONAL_OffATM.Text = "Выключить";
            BTN_ADDITIONAL_OffATM.Left = 5;
            BTN_ADDITIONAL_OffATM.Top = 35;
            BTN_ADDITIONAL_OffATM.Tag = Machine.ToString();
            BTN_ADDITIONAL_OffATM.Click += new EventHandler(Events[1]);
            DISPLAY_ADDITIONAL.Controls.Add(BTN_ADDITIONAL_OffATM);

            // Кнопка (Внести наличные)
            Button BTN_ADDITIONAL_AddMoney = new Button();
            BTN_ADDITIONAL_AddMoney.Name = "BTN_ADDITIONAL_AddMoney";
            BTN_ADDITIONAL_AddMoney.Size = new Size(130, 30);
            BTN_ADDITIONAL_AddMoney.Text = "Внести наличные";
            BTN_ADDITIONAL_AddMoney.Left = 5;
            BTN_ADDITIONAL_AddMoney.Top = 65;
            BTN_ADDITIONAL_AddMoney.Tag = Machine.ToString();
            BTN_ADDITIONAL_AddMoney.Click += new EventHandler(Events[1]);
            DISPLAY_ADDITIONAL.Controls.Add(BTN_ADDITIONAL_AddMoney);

            Additional = DISPLAY_ADDITIONAL;
        }
    }
}
