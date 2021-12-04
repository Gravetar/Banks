using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banks
{
    /// <summary>
    /// Все основные функции нужные для проекта
    /// </summary>
    class MAIN_FUNCTIONS
    {
        /// <summary>
        /// Поменять информацию на дисплее банкомата
        /// </summary>
        /// <param name="Machine">Банкомат, у которого меняется дисплей</param>
        /// <param name="VISUALIZER">Главный визуализатор проекта</param>
        /// <param name="Controls">Компоненты формы</param>
        /// <param name="Display">На какой дисплей сменить</param>
        public static Displays ChangeDisplay(int Machine, VISUALIZER VISUALIZER, Control.ControlCollection Controls, Displays Display)
        {
            RemoveItemByName<Panel>(Machine, "DISPLAY", Controls);   // Удалить старый дисплей
            Panel DISPLAY = new Panel();    // Новый дисплей


            if (Display == Displays.Welcome) // Если тип дисплей, на который надо поменять = Welcome (Дисплей приветствия)
            {
                VISUALIZER.DisplayWelcome(Machine, ref DISPLAY); // Сменить дисплей на Welcome
            }
            else if (Display == Displays.InputPIN) // Если тип дисплей, на который надо поменять = InputPIN (Дисплей для ввода пин-кода)
                VISUALIZER.DisplayInputPIN(Machine, ref DISPLAY); // Сменить дисплей на InputPIN
            else if (Display == Displays.Menu) 
                VISUALIZER.DisplayMenu(Machine, ref DISPLAY);
            else if (Display == Displays.Check)
                VISUALIZER.DisplayCheck(Machine, ref DISPLAY);
            else if (Display == Displays.Withdraw)
                VISUALIZER.DisplayWithdraw(Machine, ref DISPLAY);
            else if (Display == Displays.AnotherAmount)
                VISUALIZER.DisplayAnotherAmount(Machine, ref DISPLAY);
            else if (Display == Displays.Transfer)
                VISUALIZER.DisplayTransfer(Machine, ref DISPLAY);
            else if (Display == Displays.OutCard)
                VISUALIZER.DisplayOutCard(Machine, ref DISPLAY);
            else if (Display == Displays.SelectAccount)
                VISUALIZER.DisplaySelectAccount(Machine, ref DISPLAY);
            else 
                VISUALIZER.DisplayClear(ref DISPLAY); // Сменить дисплей на пустой

            Controls.Add(DISPLAY); // Добавить дисплей на форму

            return Display;
        }

        /// <summary>
        /// Сменить доступность банкоматов
        /// </summary>
        /// <param name="Controls">Компоненты формы</param>
        /// <param name="Bank">Главный банк</param>
        /// <param name="CurrentIdUser">Текущий пользователь</param>
        public static void ChangeEnabledATMs(Control.ControlCollection Controls, ServerBank Bank, int CurrentIdUser)
        {
            // Массив всех банкоматов (На поле)
            var ATMs = Controls.Find("ATM", true);
            var DISs = Controls.Find("DISPLAY", true);
            // Пройтись по всем банкоматам банка
            for (int i = 0; i < Bank.AtmMachines.Count; i++)
            {
                // Пройтись по всем банкоматам (На поле)
                for (int j = 0; j < ATMs.Length; j++)
                {
                    // Если тег банкомата (На поле) равен текущу-анализируемому банкомату банка
                    if ((ATMs[j] as Panel).Tag.ToString() == i.ToString())
                    {
                        // Если:
                        if (Bank.AtmMachines[i].stateAtm == StateAtm.on && // У текущей машины статус - включен и:
                            (
                            (Bank.AtmMachines[i].CurrentClient == CurrentIdUser) || // У текущей машины текущий клиент или:
                            (Bank.Clients[CurrentIdUser]._ATM == -1 && Bank.AtmMachines[i].CurrentClient == -1) // У текущей машины нет клиента и у текущего клиента нет машины
                            )
                            )
                        {
                            ATMs[j].Enabled = true; // Активировать банкомат
                        }
                        else // Иначе:
                        {
                            ATMs[j].Enabled = false; // Диактивировать банкомат
                        }
                    }
                    if (SETTINGS.CURRENT_USER == User.Operator) DISs[j].Enabled = false; // Текущий пользователь приложения-Оператор
                    else DISs[j].Enabled = true;
                }
            }
        }

        /// <summary>
        /// Сменить дополнительную панель банкомата
        /// </summary>
        /// <param name="Machine">Банкомат, у которого меняется дополнительная панель</param>
        /// <param name="VISUALIZER">Главный визуализатор</param>
        /// <param name="Controls">Главные компоненты формы</param>
        /// <param name="Additional">Тип дополнительной панели, на который надо сменить</param>
        /// <param name="Bank">Главный банк</param>
        /// <param name="CurrentClient">Текущий пользователь приложения</param>
        public static void ChangeAdditionalPanel (int Machine, VISUALIZER VISUALIZER, Control.ControlCollection Controls, AdditionalPanels Additional, ServerBank Bank, int CurrentClient)
        {
            RemoveItemByName<Panel>(Machine, "ADDITIONAL", Controls);   // Удалить старую дополнительную панель
            Panel ADDITIONAL = new Panel();    // Новая дополнительная панель

            if (Additional == AdditionalPanels.For_Client) // Если тип дополнительной панели, на которую надо поменять = For_Client (Дополнительная панель для клиента)
            {
                VISUALIZER.DisplayAdditional(Machine, ref ADDITIONAL); // Сменить дополнительную панель на For_Client
                if (Bank.AtmMachines[Machine].CurrentClient == CurrentClient) // Если у текущего банкомата клиент = текущему клиенту приложения:
                {
                    (ADDITIONAL.Controls.Find("BTN_ADDITIONAL_INCARD", true).FirstOrDefault() as Button).Enabled = false; // Деактивировать кнопку "Вставить карту"
                }
            }
            else if (Additional == AdditionalPanels.For_Operator) // Если тип дополнительной панели, на которую надо поменять = For_Operator (Дополнительная панель для оператора)
            {
                VISUALIZER.DisplayAdditionalOperator(Machine, ref ADDITIONAL); // Сменить дополнительную панель на For_Operator
                if (Bank.AtmMachines[Machine].stateAtm == StateAtm.on) // Если банкомат включен:
                    (ADDITIONAL.Controls.Find("BTN_ADDITIONAL_OnATM", true).FirstOrDefault() as Button).Enabled = false; // Диактивировать кнопку включения
                else // Иначе:
                    (ADDITIONAL.Controls.Find("BTN_ADDITIONAL_OffATM", true).FirstOrDefault() as Button).Enabled = false; // Диактивировать кнопку выключения
            }

            Controls.Add(ADDITIONAL); // Добавить дополнительную панель на форму
        }

        /// <summary>
        /// Удалить компонент с формы
        /// </summary>
        /// <typeparam name="T">Тип удаляемого компонента</typeparam>
        /// <param name="name">Имя удаляемого компонента</param>
        /// <param name="Controls">Компоненты формы</param>
        public static void RemoveItemByName<T>(int Machine, string name, Control.ControlCollection Controls)
        where T : Control   // Где тип является Control
        {
            foreach (T item in Controls.OfType<T>().ToList().Where( // Пройтись по объектам типа T в (Controls по типу T), где
             item => item.Name == name && item.Tag.ToString() == Machine.ToString()))    // Имя объекта = Параметру name
                Controls.Remove(item);  // Удалить объект из Controls
        }

        /// <summary>
        /// Блокирвоать дисплей
        /// </summary>
        /// <param name="Blocked">Блокировать дисплей?</param>
        /// <param name="Machine">Id машины</param>
        /// <param name="Controls">Элементы формы</param>
        public static void Block_UnBlockElement(bool Blocked, int Machine, string NameElement, Control.ControlCollection Controls)
        {
            if (Blocked) (Controls.Find(NameElement, true).Where(d => d.Tag.ToString() == Machine.ToString()).FirstOrDefault()).Enabled = false;
            else (Controls.Find(NameElement, true).Where(d => d.Tag.ToString() == Machine.ToString()).FirstOrDefault()).Enabled = true;
        }
    }
}
