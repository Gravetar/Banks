using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banks
{
     /// <summary>
    /// Главный Банк
    /// </summary>
    class ServerBank
    {
        /// <summary>
        /// Конструктор банка
        /// </summary>
        /// <param name="Name">Название банка</param>
        /// <param name="Address">Адрес банка</param>
        public ServerBank(string Name, string Address)
        {
            _Name = Name;
            _Adress = Address;
        }
        /// <summary>
        /// Название банка
        /// </summary>
        public string _Name;
        /// <summary>
        /// Адрес банка
        /// </summary>
        public string _Adress;

        /// <summary>
        /// Дебетовые карточки, обслуживаемые банком
        /// </summary>
        public List<DebitCard> DebitCards = new List<DebitCard>();
        /// <summary>
        /// Банкоматы банка
        /// </summary>
        public List<AtmMachine> AtmMachines = new List<AtmMachine>();
        /// <summary>
        /// Клиенты банка
        /// </summary>
        public List<Client> Clients = new List<Client>();

        /// <summary>
        /// Оператор банка
        /// </summary>
        public Operator Operator = new Operator();
    }
}
