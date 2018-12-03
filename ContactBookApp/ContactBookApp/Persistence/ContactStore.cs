using ContactBookApp.Models;
using ContactBookApp.ViewModels;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ContactBookApp.Persistence
{
    public class ContactStore : IContactStore
    {
        private SQLiteAsyncConnection _connection;

        public ContactStore(ISQLiteDb Db)
        {
            _connection = Db.GetConnection();
            _connection.CreateTableAsync<Contact>();
        }
        public async Task AddContact(Contact contact)
        {
            await _connection.InsertAsync(contact);
        }

        public async Task DeleteContact(Contact contact)
        {
            await _connection.DeleteAsync(contact);   
        }

        public async Task<Contact> GetContact(int id)
        {
            return await _connection.FindAsync<Contact>(id);
        }

        public async Task<IEnumerable<Contact>> GetContactsAsync()
        {
            return await _connection.Table<Contact>().ToListAsync();
        }

        public async Task UpdateContact(Contact contact)
        {
            await _connection.UpdateAsync(contact);
        }
    }
}
