using Library.models;
using Library.repositories;

namespace Library.services
{
    public class ClientService
    {
        readonly ClientRepository _repository;

        public ClientService(ClientRepository repository)
        {
            _repository = repository;
        }

        public BindingSource getClientsData()
        {
            return _repository.getClientsData();
        }

        public List<ClientResponse> getClientsId()
        {
            return _repository.getClientsId();
        }

        public void addClient(ClientRequest clientRequest)
        {
            _repository.addClient(clientRequest);
        }

        public void modifyClient(ClientModel client)
        {
            _repository.modifyClient(client);
        }

        public void deleteClient(ClientResponse clientResponse)
        {
            _repository.deleteClient(clientResponse);
        }
    }
}
