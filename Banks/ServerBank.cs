using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banks
{
     /// <summary>
    /// Банк
    /// </summary>
    class ServerBank
    {
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
    }
}
