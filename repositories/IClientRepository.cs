using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.repositories
{
    internal interface IClientRepository
    {
        const string connectionString = "Data Source=DESKTOP-JH1VST5\\SQLEXPRESS;Initial Catalog=Library;User ID=sa;Password=papaja";

        public static BindingSource getClientsData()
        {
            using (SqlConnection connection = new(connectionString))
            {
                string queryClients = "SELECT ID, Name FROM Client";
                SqlCommand commandGetClients = new(queryClients, connection);
                SqlDataAdapter sqlDataAdapterClients = new(commandGetClients);
                DataTable dataTableClients = new();
                sqlDataAdapterClients.Fill(dataTableClients);
                BindingSource bindingSourceClients = new();
                bindingSourceClients.DataSource = dataTableClients;
                return bindingSourceClients;
            }
        }

        public static List<string> getClientsId()
        {
            List<string> ids = new List<string>();
            using (SqlConnection connection = new(connectionString))
            {
                string queryClientsId = "SELECT ID FROM Client";
                SqlCommand commandClientsId = new(queryClientsId, connection);
                try
                {
                    connection.Open();
                    SqlDataReader readerClientId = commandClientsId.ExecuteReader();
                    while (readerClientId.Read())
                    {
                        ids.Add(readerClientId.GetString(0));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return ids;
        }

        public static void addCLient(string clientName)
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

        public static void modifyClient(string clientId, string clientName)
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

        public static void deleteClient(string clientId)
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
    }
}
