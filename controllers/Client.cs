using Library.models;
using System.Data;
using System.Data.SqlClient;

namespace Library
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
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
            dataGridViewClients.DataSource = services.IClientService.getClientsData();

            // clears & populates comboBoxClientId from database
            comboBoxClientId.Items.Clear();
            List<ClientResponse> list = services.IClientService.getClientsId();
            foreach (ClientResponse item in list)
            {
                comboBoxClientId.Items.Add(item.Id.ToString());
            }
        }

        private void addClient(ClientRequest clientRequest)
        {
            services.IClientService.addClient(clientRequest);
        }

        private void modifyClientData(ClientModel client)
        {
            services.IClientService.modifyClient(client);
        }

        private void deleteClient(ClientResponse clientResponse)
        {
            services.IClientService.deleteClient(clientResponse);
        }

        private void clearForms()
        {
            comboBoxClientId.SelectedItem = null;
            textBoxClientName.Clear();
        }
    }
}
