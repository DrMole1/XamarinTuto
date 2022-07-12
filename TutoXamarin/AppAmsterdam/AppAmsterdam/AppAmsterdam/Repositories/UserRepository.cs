using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using AppAmsterdam.Models;
using System.Threading.Tasks;

namespace AppAmsterdam.Repositories
{
    public class UserRepository
    {

        private SQLiteAsyncConnection _connection;

        public string StatusMessage { get; set; }

        public UserRepository(string _dbPath)
        {
            _connection = new SQLiteAsyncConnection(_dbPath);

            // Create Table if not exist
            _connection.CreateTableAsync<User>();
        }

        public async Task AddNewUserAsync(string _name)
        {
            int result = 0;

            try
            {
                result = await _connection.InsertAsync(new User { Name = _name });

                StatusMessage = $"{result}  utilisateur(s) ajouté(s) : {_name}.";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Impossible d'ajouter l'utilisateur : {_name}.\n Erreur : {ex.Message}";
            }
        }

        public async Task<List<User>> GetUsersAsync()
        {
            try
            {
                return await _connection.Table<User>().ToListAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = $"Impossible de récupérer la liste d'utilisateur.\n Erreur : {ex.Message}";
            }

            return new List<User>();
        }
    }
}
