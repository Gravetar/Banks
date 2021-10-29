using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banks
{
    class SETTINGS
    {
        /// <summary>
        /// Текущий пользователь приложения
        /// </summary>
        public static User CURRENT_USER = User.Client;
    }

    /// <summary>
    /// Пользователь
    /// -Клиент
    /// -Оператор банка
    /// </summary>
    public enum User
    {
        Client,
        Operator
    }
}
