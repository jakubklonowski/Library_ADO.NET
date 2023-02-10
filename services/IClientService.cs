using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Library.services
{
    internal interface IClientService
    {
        public static BindingSource getClientsData()
        {
            return repositories.IClientRepository.getClientsData();
        }

        public static List<string> getClientsId()
        {
            return repositories.IClientRepository.getClientsId();
        }

        public static void addClient(string clientName)
        {
            repositories.IClientRepository.addCLient(clientName);
        }

        public static void modifyClient(string clientId, string clientName)
        {
            repositories.IClientRepository.modifyClient(clientId, clientName);
        }

        public static void deleteClient(string idClient) {
            repositories.IClientRepository.deleteClient(idClient);
        }
    }
}
