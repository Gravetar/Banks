﻿using System;
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
        /// Текущий пользователь приложения
        /// </summary>
        public static User CURRENT_USER = User.Client;
        /// <summary>
        /// Размер дисплея банкоматов
        /// </summary>
        public static Size DISPLAY_SIZE = new Size(210, 190);
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
