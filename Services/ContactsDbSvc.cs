using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tandem.Interfaces;
using Tandem.Models;

namespace Tandem.Services
{
    /// <summary>
    /// Implements methods and properties necessary to manage Contacts schema
    /// </summary>
    public class ContactsDbService : IContactsDbService
    {
        private Container _container;

        /// <summary>
        /// Initializes controller with contacts database service
        /// </summary>
        /// <param name="dbClient"></param>
        /// <param name="databaseName"></param>
        /// <param name="containerName"></param>
        public ContactsDbService(CosmosClient dbClient, string databaseName, string containerName)
        {
            //get database client service
            this._container = dbClient.GetContainer(databaseName, containerName);
        }

        /// <summary>
        /// Returns with collection of all contacts available in datastore; if exists
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Contact>> GetContactsAsync(string query)
        {
            //needless to validate query as we are going to support query strings created within
            //this solution
            var queryResults = this._container.GetItemQueryIterator<Contact>(new QueryDefinition(query));
            List<Contact> results = new List<Contact>();

            //prepare return collection with all results
            while (queryResults.HasMoreResults)
            {
                var response = await queryResults.ReadNextAsync();

                results.AddRange(response.ToList());
            }
            return results;
        }

        public async Task AddContactAsync(Contact contact)
        {
            await this._container.CreateItemAsync<Contact>(contact, new PartitionKey(contact.Id));
        }

        public async Task<Contact> GetContactAsync(string email)
        {
            Contact result = new Contact();
            QueryDefinition queryDefinition = new QueryDefinition(@"select * from Contacts where Contacts.emailaddress = @email")
                                                 .WithParameter("@email", email);
            FeedIterator<Contact> feedIterator = this._container.GetItemQueryIterator<Contact>(queryDefinition);

            while (feedIterator.HasMoreResults)
            {
                var response = await feedIterator.ReadNextAsync();
                return response.FirstOrDefault();
            }
            return result;
        }
    }
}
