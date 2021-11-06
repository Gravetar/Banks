using System;
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
        public List<Panel> CreateAllATM(EventHandler EventClick, EventHandler EventClickInputCard)
        {
            List<Panel> Machines = new List<Panel>();


            for (int i = 0; i < SETTINGS.ATM_COUNT; i++)
            {
                Panel Display = new Panel();
                Panel Keyboard = new Panel();
                Panel Additional = new Panel();

                DisplayWelcome(i, ref Display);
                Keyboard = DisplayKeyboard(i, EventClick);
                Additional = DisplayAdditional(i, EventClickInputCard);
                Machines.Add(CreateATM(i, Display, Keyboard, Additional));
            }
            Machines[0].Location = new Point(100, 100);
            Machines[1].Location = new Point(400, 100);
            Machines[2].Location = new Point(700, 100);
            return Machines;
        }

        public Panel CreateATM(int Machine, Panel Display, Panel Keyboard, Panel Additional)
        {
            Panel ATM = new Panel();
            ATM.Name = "ATM";
            ATM.Location = new Point(100, 100);
            ATM.AutoSize = true;
            ATM.BorderStyle = BorderStyle.Fixed3D;
            ATM.Tag = Machine;
            // TODO сделать под все банкоматы, сейчас токо первый

            ATM.Controls.AddRange(new Control[] { Display, Keyboard, Additional});

            return ATM;
        }

        /// <summary>
        /// Чистый дисплей
        /// </summary>
        /// <param name="Display">Изменяемый дисплей(панель)</param>
        public void DisplayClear(ref Panel Display)
        {
            Panel DISPLAY_Clear = new Panel();
            DISPLAY_Clear.Name = "DISPLAY";
            DISPLAY_Clear.Location = new Point(100, 100);
            DISPLAY_Clear.Size = SETTINGS.DISPLAY_SIZE;
            DISPLAY_Clear.BorderStyle = BorderStyle.Fixed3D;

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

            //Добавить в Панель для элементов основного дисплея:
                // Текст с просьбой
            DISPLAY_Pin_TLP.Controls.Add(DISPLAY_Pin_MainText, 1, 1);
                // Текстовый блок для ввода
            DISPLAY_Pin_TLP.Controls.Add(DISPLAY_Pin_InputText, 1, 2);
            // Добавить в основной дисплей:
                // Панель для элементов основного дисплея
            DISPLAY_Pin.Controls.Add(DISPLAY_Pin_TLP);
            // Изменяемый дисплей(панель) изменить на Основной дисплей
            Display = DISPLAY_Pin;
        }

        /// <summary>
        /// Клавиатура банкомата
        /// </summary>
        /// <param name="EventClick">Событие нажатия кнопки с цифрами</param>
        public Panel DisplayKeyboard(int Machine, EventHandler EventClick)
        {
            // Основной дисплей
            Panel DISPLAY_KEYBOARD = new Panel();
            DISPLAY_KEYBOARD.Name = "KEYBOARD";
            DISPLAY_KEYBOARD.Location = new Point(0, 250);
            DISPLAY_KEYBOARD.Size = SETTINGS.KEYBOARD_SIZE;
            DISPLAY_KEYBOARD.BorderStyle = BorderStyle.Fixed3D;

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
                BTN_KEYB_NUM.Click += new EventHandler(EventClick);
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
            BTN_KEYB_0.Click += new EventHandler(EventClick);
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
            BTN_KEYB_CANCEL.Click += new EventHandler(EventClick);
            DISPLAY_KEYB_TLP.Controls.Add(BTN_KEYB_CANCEL, 3, 0);

            Button BTN_KEYB_CLEAR = new Button();
            BTN_KEYB_CLEAR.Name = "BTN_KEYB_CLEAR";
            BTN_KEYB_CLEAR.Size = new Size(60, 30);
            BTN_KEYB_CLEAR.Text = "CLEAR";
            BTN_KEYB_CLEAR.Tag = Machine;
            BTN_KEYB_CLEAR.Click += new EventHandler(EventClick);
            DISPLAY_KEYB_TLP.Controls.Add(BTN_KEYB_CLEAR, 3, 1);

            Button BTN_KEYB_ENTER = new Button();
            BTN_KEYB_ENTER.Name = "BTN_KEYB_ENTER";
            BTN_KEYB_ENTER.Size = new Size(60, 30);
            BTN_KEYB_ENTER.Text = "ENTER";
            BTN_KEYB_ENTER.Tag = Machine;
            BTN_KEYB_ENTER.Click += new EventHandler(EventClick);
            DISPLAY_KEYB_TLP.Controls.Add(BTN_KEYB_ENTER, 3, 2);

            Button BTN_KEYB_NULL3 = new Button();
            BTN_KEYB_NULL3.Name = "BTN_KEYB_NULL3";
            BTN_KEYB_NULL3.Size = new Size(60, 30);
            BTN_KEYB_NULL3.Text = " ";
            BTN_KEYB_NULL3.Tag = Machine;
            DISPLAY_KEYB_TLP.Controls.Add(BTN_KEYB_NULL3, 3, 3);

            DISPLAY_KEYBOARD.Controls.Add(DISPLAY_KEYB_TLP);

            return DISPLAY_KEYBOARD;
        }

        /// <summary>
        /// Дополнительная панель к банкомату
        /// </summary>
        /// <param name="EventClickInputCard">Событие нажатия кнопки "Вставить карту"</param>
        public Panel DisplayAdditional(int Machine,  EventHandler EventClickInputCard)
        {
            Panel DISPLAY_ADDITIONAL = new Panel();
            DISPLAY_ADDITIONAL.Name = "ADDITIONAL";
            DISPLAY_ADDITIONAL.Location = new Point(0, 200);
            DISPLAY_ADDITIONAL.Size = new Size(0, 0);
            DISPLAY_ADDITIONAL.AutoSize = true;

            Button BTN_ADDITIONAL_INCARD = new Button();
            BTN_ADDITIONAL_INCARD.Name = "BTN_ADDITIONAL_INCARD";
            BTN_ADDITIONAL_INCARD.Size = new Size(205, 30);
            BTN_ADDITIONAL_INCARD.Text = "Вставить карту";
            BTN_ADDITIONAL_INCARD.Left = 5;
            BTN_ADDITIONAL_INCARD.Top = 5;
            BTN_ADDITIONAL_INCARD.Tag = Machine.ToString();
            BTN_ADDITIONAL_INCARD.Click += new EventHandler(EventClickInputCard);
            DISPLAY_ADDITIONAL.Controls.Add(BTN_ADDITIONAL_INCARD);

            return DISPLAY_ADDITIONAL;
        }
    }
}
