using System.Data;
using System.Data.SqlClient;

namespace Library
{
    public partial class Client : Form
    {
        private string connectionString = "";

        public Client(string connectionString)
        {
            InitializeComponent();

            this.connectionString = connectionString;

            fetchData(connectionString);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string clientName = textBoxClientName.Text;
            addClient(clientName);
            clearForms();
            fetchData(connectionString);
        }

        private void buttonModify_Click(object sender, EventArgs e)
        {
            string clientId = comboBoxClientId.SelectedItem.ToString();
            string clientName = textBoxClientName.Text;
            modifyClientData(clientId, clientName);
            clearForms();
            fetchData(connectionString);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string clientId = comboBoxClientId.SelectedItem.ToString();
            deleteClient(clientId);
            clearForms();
            fetchData(connectionString);
        }

        private void fetchData(string connectionString)
        {
            using (SqlConnection connection = new(connectionString))
            {
                // populates dataGridViewClients from database
                string queryClients = "SELECT ID, Name FROM Client";
                SqlCommand commandGetClients = new(queryClients, connection);
                SqlDataAdapter sqlDataAdapterClients = new(commandGetClients);
                DataTable dataTableClients = new();
                sqlDataAdapterClients.Fill(dataTableClients);
                BindingSource bindingSourceClients = new();
                bindingSourceClients.DataSource = dataTableClients;
                dataGridViewClients.DataSource = bindingSourceClients;

                // populates comboBoxClientId from database
                string queryClientsId = "SELECT ID FROM Client";
                SqlCommand commandClientsId = new(queryClientsId, connection);
                try
                {
                    connection.Open();
                    SqlDataReader readerClientId = commandClientsId.ExecuteReader();
                    comboBoxClientId.Items.Clear();
                    while (readerClientId.Read())
                    {
                        comboBoxClientId.Items.Add(readerClientId[0]);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        // adds client to database
        private void addClient(string clientName)
        {
            using (SqlConnection connection = new(connectionString))
            {
                string queryInsert = "INSERT INTO Client (Name) VALUES (@name)";

                SqlCommand commandInsert = new(queryInsert, connection);
                try
                {
                    commandInsert.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = clientName;
                    connection.Open();
                    commandInsert.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        // modifies client record in database
        private void modifyClientData(string clientId, string clientName)
        {
            using (SqlConnection connection = new(connectionString))
            {
                string queryMod = "UPDATE Client SET Name=@name WHERE ID = @id";

                SqlCommand commandMod = new(queryMod, connection);
                try
                {
                    commandMod.Parameters.Add("@id", SqlDbType.Int).Value = clientId;
                    commandMod.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = clientName;
                    connection.Open();
                    commandMod.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        // erases client data from database
        private void deleteClient(string clientId)
        {
            using (SqlConnection connection = new(connectionString))
            {
                string queryDelete = "DELETE FROM Client WHERE ID = @id";

                SqlCommand commandDelete = new(queryDelete, connection);
                try
                {
                    commandDelete.Parameters.Add("@id", SqlDbType.Int).Value = clientId;
                    connection.Open();
                    commandDelete.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void clearForms()
        {
            comboBoxClientId.SelectedItem = null;
            textBoxClientName.Clear();
        }
    }
}
