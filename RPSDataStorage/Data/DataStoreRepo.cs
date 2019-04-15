using RPSBackendLogic.Data;
using RPSBackendLogic.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace RPSDataStorage.Data
{
    public class DataStoreRepo : IDataStoreRepo
    {
        private readonly IDbRepo dataStore;
        public IDbRepo DataStore => dataStore;

        public DataStoreRepo(string dbPath)
        {
            dataStore = new SqliteDataStore(dbPath);
        }

        public void Add(Roshamo c)
        {
            var rosh = new RPSDataStorage.Models.Roshamo();
            rosh.Country = c.Name.Value;

            DataStore.Add(rosh);
        }

        public void Update(Roshamo c)
        {
            throw new NotImplementedException();
        }

        public void Remove(Roshamo c)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Roshamo> GetAllRoshamos()
        {
            throw new NotImplementedException();
        }
    }
}
