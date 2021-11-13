using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banks
{
    /// <summary>
    /// Настройки проекта
    /// </summary>
    class SETTINGS
    {
        /// <summary>
        /// Количество банкоматов
        /// </summary>
        public static int ATM_COUNT = 3;
        /// <summary>
        /// Количество карт
        /// </summary>
        public static int CARDS_COUNT = 3;
        /// <summary>
        /// Текущий пользователь приложения
        /// </summary>
        public static User CURRENT_USER;
        /// <summary>
        /// Размер дисплея банкоматов
        /// </summary>
        public static Size DISPLAY_SIZE = new Size(210, 190);
        /// <summary>
        /// Размер клавиатуры банкоматов
        /// </summary>
        public static Size KEYBOARD_SIZE = new Size(210, 190);
        /// <summary>
        /// Сообщение приветствия
        /// </summary>
        public static string WELCOME_TEXT = "Добро Пожаловать\nВставьте пожалуйста вашу карту";
    }

    /// <summary>
    /// Пользователь
    /// -Клиент
    /// -Оператор банка
    /// </summary>
    public enum User
    {
        /// <summary>
        /// Пользователь-Клиент
        /// </summary>
        Client,
        /// <summary>
        /// Пользователь-Оператор
        /// </summary>
        Operator
    }
}
