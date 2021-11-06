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
    }
}
