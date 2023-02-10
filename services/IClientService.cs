using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Library.models;

namespace Library.services
{
    internal interface IClientService
    {
        public static BindingSource getClientsData()
        {
            return repositories.IClientRepository.getClientsData();
        }

        public static List<ClientResponse> getClientsId()
        {
            return repositories.IClientRepository.getClientsId();
        }

        public static void addClient(ClientRequest clientRequest)
        {
            repositories.IClientRepository.addClient(clientRequest);
        }

        public static void modifyClient(ClientModel client)
        {
            repositories.IClientRepository.modifyClient(client);
        }

        public static void deleteClient(ClientResponse clientResponse) {
            repositories.IClientRepository.deleteClient(clientResponse);
        }
    }
}
