using RPSBackendLogic.Data;
using RPSBackendLogic.DomainPrimitives;
using RPSBackendLogic.Entities;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace RPSDataStorage.Data
{
    public class DataStoreAsyncRepo : IDataStoreAsyncRepo
    {
        private readonly IDbAsyncRepo dataStore;
        public IDbAsyncRepo DataStore => dataStore;

        public DataStoreAsyncRepo()
        {
            dataStore = new CosmosDataStore();
        }

        public void Add(Roshambo c)
        {
            DataStore.AddAsync(Convert(c));
        }

        public void Update(Roshambo c)
        {
            DataStore.Update(Convert(c));
        }

        public void Remove(Roshambo c)
        {
            DataStore.RemoveAsync(Convert(c));
        }

        public async Task<ObservableCollection<Roshambo>> GetAllRoshambosAsync()
        {
            var list = new ObservableCollection<Roshambo>();
            try
            {
                foreach (var cur in await DataStore.GetAllRoshamboAsync())
                    list.Add(new Roshambo(cur.Id, cur.Country, new Rock(cur.RockQuantity), new Paper(cur.PaperQuantity), new Scissors(cur.ScissorQuantity), cur.Enemy));
            } catch(Exception e)
            {
                Console.WriteLine(e);
            }
            return list;

        }

        public async Task<ObservableCollection<Log>> GetAllLogEntriesAsync()
        {
            var list = new ObservableCollection<Log>();
            try
            {
                foreach (var cur in await DataStore.GetAllLogEntriesAsync())
                    list.Add(new Log(cur.Id, cur.Entry, cur.DateTime));
            }catch(Exception e)
            {
                Console.WriteLine(e);
            }
            return list;
        }

        public void Add(Log c)
        {
            DataStore.AddAsync(Convert(c));
        }

        public void Update(Log c)
        {
            DataStore.Update(Convert(c));
        }

        public void Remove(Log c)
        {
            DataStore.RemoveAsync(Convert(c));
        }

        private RPSDataStorage.Models.Roshambo Convert(Roshambo c)
        {
            var rosh = new RPSDataStorage.Models.Roshambo();
            if (c.Id != "0")
                rosh.Id = c.Id.Value;
            rosh.Country = c.Name.Value;
            rosh.RockQuantity = c.Rock.Quantity.Value;
            rosh.PaperQuantity = c.Paper.Quantity.Value;
            rosh.ScissorQuantity = c.Scissors.Quantity.Value;
            rosh.Enemy = c.Enemy;
            return rosh;
        }

        private RPSDataStorage.Models.Log Convert(Log c)
        {
            var rosh = new RPSDataStorage.Models.Log();
            if (c.Id != "0")
                rosh.Id = c.Id.Value;
            rosh.Entry = c.Entry.Value;
            rosh.DateTime = c.DateTime;
            return rosh;
        }
    }
}
