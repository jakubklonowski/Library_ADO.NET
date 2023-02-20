using Library.models;
using Library.repositories;
using Library.services;

namespace Library
{
    public partial class Client : Form
    {
        readonly ClientService service;

        public Client()
        {
            InitializeComponent();
            service = new ClientService(new ClientRepository("Data Source=DESKTOP-JH1VST5\\SQLEXPRESS;Initial Catalog=library;User Id=sa;Password=papaja"));
            fetchData();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string clientName = textBoxClientName.Text;
            ClientRequest clientRequest = new()
            {
                Name = clientName
            };
            addClient(clientRequest);
            clearForms();
            fetchData();
        }

        private void buttonModify_Click(object sender, EventArgs e)
        {
            string clientId = comboBoxClientId.SelectedItem.ToString();
            string clientName = textBoxClientName.Text;
            ClientModel client = new()
            {
                Id = clientId,
                Name = clientName
            };
            modifyClientData(client);
            clearForms();
            fetchData();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string clientId = comboBoxClientId.SelectedItem.ToString();
            ClientResponse clientResponse = new()
            {
                Id = clientId
            };
            deleteClient(clientResponse);
            clearForms();
            fetchData();
        }

        private void fetchData()
        {
            // populates dataGridViewClients from database
            dataGridViewClients.DataSource = service.getClientsData();

            // clears & populates comboBoxClientId from database
            comboBoxClientId.Items.Clear();
            List<ClientResponse> list = service.getClientsId();
            foreach (ClientResponse item in list)
            {
                comboBoxClientId.Items.Add(item.Id.ToString());
            }
        }

        private void addClient(ClientRequest clientRequest)
        {
            service.addClient(clientRequest);
        }

        private void modifyClientData(ClientModel client)
        {
            service.modifyClient(client);
        }

        private void deleteClient(ClientResponse clientResponse)
        {
            service.deleteClient(clientResponse);
        }

        private void clearForms()
        {
            comboBoxClientId.SelectedItem = null;
            textBoxClientName.Clear();
        }
    }
}
