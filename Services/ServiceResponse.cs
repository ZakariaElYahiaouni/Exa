using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DTOs;
using backend.models;

namespace backend.Services
{
    public class ServiceResponse : IServiceResponse
    {
        private static List<UserModel> users;
        private static ClassConnection connectionInstance = new ClassConnection(@"Data Source=DESKTOP-32BGAT9\MSSQLSERVER01;Initial Catalog=ExaWebsite;Integrated Security=True");

        public ServiceResponse()
        {
            // Inizializza la lista users nel costruttore se non è stata inizializzata in precedenza
            if (users == null)
            {
                users = new List<UserModel>();

                // Aggiungi alcuni dati di esempio alla lista users
                users.Add(new UserModel
                {
                    Id = 0,
                    Name = "Alice",
                    LastName = "Johnson",
                    SchoolName = "XYZ School",
                    UserComment = "Hello, World!"
                });
            }
        }

        public async Task<List<UserModel>> AddUserComment(AddComment user)
        {
            try
            {
                // Calcola l'Id per il nuovo utente
                int newUserId = users.Count > 0 ? users.Max(c => c.Id) + 1 : 1;

                var newUser = new UserModel
                {
                    Id = newUserId,
                    Name = user.Name,
                    LastName = user.LastName,
                    SchoolName = user.SchoolName,
                    UserComment = user.UserComment
                };

                users.Add(newUser);

                // Inserisci il nuovo utente nel database
                connectionInstance.InsertUser(newUser);

                return users;
            }
            catch (Exception ex)
            {
                // Gestisci l'eccezione in modo appropriato o registra l'errore
                throw new Exception("Errore durante l'aggiunta del commento dell'utente.", ex);
            }
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            try
            {
                return users;
            }
            catch (Exception ex)
            {
                // Gestisci l'eccezione in modo appropriato o registra l'errore
                throw new Exception("Errore durante il recupero degli utenti.", ex);
            }
        }
    }
}
