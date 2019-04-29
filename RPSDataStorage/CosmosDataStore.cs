using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using Microsoft.EntityFrameworkCore;
using RPSDataStorage.Data;
using RPSDataStorage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSDataStorage
{
    public class CosmosDataStore : IDbAsyncRepo
    {
        static CosmosDataStore defaultInstance = new CosmosDataStore();

        const string accountURL = @"https://securecoding.documents.azure.com:443/";
        const string accountKey = @"AYJJZwhw4l6EeEF4EUfnt5nsECo3OmgPLe7oTiS1T54PzlxHsJMYMeiLapRUC7JFP0EP0hcxSBJNCaWPKzL0IA==";
        const string databaseId = @"roshambo";
        const string collectionId = @"roshambo";
        const string collectionId2 = @"logs";

        private Uri RoshamboLink = UriFactory.CreateDocumentCollectionUri(databaseId, collectionId);
        private Uri LogLink = UriFactory.CreateDocumentCollectionUri(databaseId, collectionId2);
        private DocumentClient client;
        public List<Roshambo> Roshambos { get; private set; }
        public List<Log> Logs { get; private set; }

        public CosmosDataStore()
        {
            client = new DocumentClient(new System.Uri(accountURL), accountKey);
        }

        public static CosmosDataStore DefaultManager
        {
            get
            {
                return defaultInstance;
            }
            private set
            {
                defaultInstance = value;
            }
        }

        public async Task<IEnumerable<Log>> GetAllLogEntriesAsync()
        {
            try
            {
                // The query excludes completed TodoItems
                var query = client.CreateDocumentQuery<Log>(LogLink, new FeedOptions { MaxItemCount = -1 })
                    .AsDocumentQuery();

                Logs = new List<Log>();
                while (query.HasMoreResults)
                {
                    Logs.AddRange(await query.ExecuteNextAsync<Log>());
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(@"ERROR {0}", e.Message);
                return null;
            }
            return Logs;
        }

        public async Task<IEnumerable<Roshambo>> GetAllRoshamboAsync()
        {
            try
            {
                // The query excludes completed TodoItems
                var query = client.CreateDocumentQuery<Roshambo>(RoshamboLink, new FeedOptions { MaxItemCount = -1 })
                    .AsDocumentQuery();

                Roshambos = new List<Roshambo>();
                while (query.HasMoreResults)
                {
                    Roshambos.AddRange(await query.ExecuteNextAsync<Roshambo>());
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(@"ERROR {0}", e.Message);
                return null;
            }

            return Roshambos;
        }

        public async Task AddAsync(Roshambo c)
        {
            try
            {
                var result = await client.CreateDocumentAsync(RoshamboLink, c);
                c.Id = result.Resource.Id;
                Roshambos.Add(c);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(@"ERROR {0}", e.Message);
            }
            //return c;
        }

        public Task Update(Roshambo c)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveAsync(Roshambo c)
        {
            try
            {
                //var query = client.CreateDocumentQuery<Roshambo>(RoshamboLink, new FeedOptions { MaxItemCount = 1 })
                //      .Where(item => item.Id == c.Id)
                //      .AsDocumentQuery();
                //await client.DeleteDocumentAsync(UriFactory.CreateDocumentUri(databaseId, collectionId, c.Id));
                //await client.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(databaseId, collectionId, c.Id), new Roshambo());
                await client.DeleteDocumentAsync(UriFactory.CreateDocumentUri(databaseId, collectionId, c.Id));
                Roshambos.Remove(c);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(@"ERROR {0}", e.Message);
            }
        }

        public async Task AddAsync(Log c)
        {
            try
            {
                var result = await client.CreateDocumentAsync(LogLink, c);
                c.Id = result.Resource.Id;
                Logs.Add(c);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(@"ERROR {0}", e.Message);
            }
            //return todoItem;
        }

        public Task Update(Log c)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveAsync(Log c)
        {
            try
            {
                await client.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(databaseId, collectionId2, c.Id), c);
                Logs.Remove(c);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(@"ERROR {0}", e.Message);
            }
        }
    }
}
