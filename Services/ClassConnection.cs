using System;
using System.Data;
using System.Data.SqlClient;
using backend.models;

namespace backend
{
    public class ClassConnection
    {
        private string connectionString; // Stringa di connessione al database

        public ClassConnection(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void InsertUser(UserModel user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Query SQL per l'inserimento dei dati nella tabella comment_table
                string insertQuery = "INSERT INTO comment_table (Id, Name, LastName, SchoolName, Comment) " +
                                     "VALUES (@Id, @Name, @LastName, @SchoolName, @Comment)";

                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    // Parametri per la query SQL
                    command.Parameters.AddWithValue("@Id", user.Id);
                    command.Parameters.AddWithValue("@Name", user.Name);
                    command.Parameters.AddWithValue("@LastName", user.LastName);
                    command.Parameters.AddWithValue("@SchoolName", user.SchoolName);
                    command.Parameters.AddWithValue("@Comment", user.UserComment);

                    command.ExecuteNonQuery(); // Esegui l'operazione di inserimento
                }

                connection.Close(); // Chiudi la connessione dopo l'inserimento
            }
        }
    }
}
