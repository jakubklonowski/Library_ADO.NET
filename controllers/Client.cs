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
            addClient(clientName);
            clearForms();
            fetchData();
        }

        private void buttonModify_Click(object sender, EventArgs e)
        {
            string clientId = comboBoxClientId.SelectedItem.ToString();
            string clientName = textBoxClientName.Text;
            modifyClientData(clientId, clientName);
            clearForms();
            fetchData();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string clientId = comboBoxClientId.SelectedItem.ToString();
            deleteClient(clientId);
            clearForms();
            fetchData();
        }

        private void fetchData()
        {
            // populates dataGridViewClients from database
            dataGridViewClients.DataSource = services.IClientService.getClientsData();

            // populates comboBoxClientId from database
            comboBoxClientId.Items.Clear();
            comboBoxClientId.Items.Add(services.IClientService.getClientsId());
        }

        private void addClient(string clientName)
        {
            services.IClientService.addClient(clientName);
        }

        private void modifyClientData(string clientId, string clientName)
        {
            services.IClientService.modifyClient(clientId, clientName);
        }

        private void deleteClient(string clientId)
        {
            services.IClientService.deleteClient(clientId);
        }

        private void clearForms()
        {
            comboBoxClientId.SelectedItem = null;
            textBoxClientName.Clear();
        }
    }
}
