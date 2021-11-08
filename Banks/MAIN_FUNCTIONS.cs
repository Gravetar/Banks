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
        /// <param name="_VISUALIZER">Главный визуализатор проекта</param>
        /// <param name="Controls">Компоненты формы</param>
        /// <param name="Display">На какой дисплей сменить</param>
        public static Displays ChangeDisplay(int Machine, VISUALIZER _VISUALIZER, Control.ControlCollection Controls, Displays Display)
        {
            Panel CurrentDisplay = Controls.Find("DISPLAY", true).FirstOrDefault() as Panel;

            RemoveItemByName<Panel>(Machine, "DISPLAY", Controls);   // Удалить старый дисплей
            Panel DISPLAY = new Panel();    // Новый дисплей


            if (Display == Displays.Welcome) // Если тип дисплей, на который надо поменять = Welcome (Дисплей приветствия)
                _VISUALIZER.DisplayWelcome(Machine, ref DISPLAY); // Сменить дисплей на Welcome
            else if(Display == Displays.InputPIN) // Если тип дисплей, на который надо поменять = InputPIN (Дисплей для ввода пин-кода)
                _VISUALIZER.DisplayInputPIN(Machine, ref DISPLAY); // Сменить дисплей на InputPIN
            else
                _VISUALIZER.DisplayClear(ref DISPLAY); // Сменить дисплей на пустой

            Controls.Add(DISPLAY); // Добавить дисплей на форму

            return Display;
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
        /// Сменить доступность банкоматов
        /// </summary>
        /// <param name="Controls">Компоненты формы</param>
        /// <param name="Bank">Главный банк</param>
        /// <param name="CurrentIdUser">Текущий пользователь</param>
        public static void ChangeEnabledATMs(Control.ControlCollection Controls, ServerBank Bank, int CurrentIdUser)
        {
            // Массив всех банкоматов (На поле)
            var ATMs = Controls.Find("ATM", true);
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
                        if (Bank.AtmMachines[i].CurrentClient == CurrentIdUser || // У текущей машины текущий клиент или:
                            (Bank.Clients[CurrentIdUser]._ATM == -1 && Bank.AtmMachines[i].CurrentClient == -1)) // У текущей машины нет клиента и у текущего клиента нет машины
                        {
                            ATMs[j].Enabled = true; // Активировать для клиента банкомат
                        }
                        else // Иначе:
                        {
                            ATMs[j].Enabled = false; // Диактивировать для клиента банкомат
                        }
                    }
                }
            }
        }
    }
}
