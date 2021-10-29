using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banks
{
    class DebitCard
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID;
        /// <summary>
        /// Пин-код
        /// </summary>
        public string PIN;
        /// <summary>
        /// Дата начала
        /// </summary>
        public DateTime DateStart;
        /// <summary>
        /// Дата окончания
        /// </summary>
        public DateTime DateEnd;
        /// <summary>
        /// Состояние
        /// </summary>
        public CardStatus Card_Status;
        /// <summary>
        /// Лимит
        /// </summary>
        public double Limit;
        /// <summary>
        /// Итого
        /// </summary>
        public double Total;

        /// <summary>
        /// Номер счета
        /// </summary>
        public string NumberAccount;
    }

    /// <summary>
    /// Состояния карточки
    /// </summary>
    public enum CardStatus
    {
        /// <summary>
        /// Заблокирована
        /// </summary>
        Block,
        /// <summary>
        /// Действительна
        /// </summary>
        Valid
    }
}
