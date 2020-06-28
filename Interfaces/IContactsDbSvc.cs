using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tandem.Models;

namespace Tandem.Interfaces
{
    /// <summary>
    /// Defines methods and properties necessary to manage Contacts schema
    /// </summary>
    public interface IContactsDbService
    {
        /// <summary>
        /// Returns contacts per query
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<IEnumerable<Contact>> GetContactsAsync(string query);

        /// <summary>
        /// Add new contact to datastore
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        Task AddContactAsync(Contact contact);
    }
}
