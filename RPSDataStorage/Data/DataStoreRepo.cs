using RPSBackendLogic.Data;
using RPSBackendLogic.DomainPrimitives;
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

        public void Add(Roshambo c)
        {
            DataStore.Add(Convert(c));
        }

        public void Update(Roshambo c)
        {
            DataStore.Update(Convert(c));
        }

        public void Remove(Roshambo c)
        {
            DataStore.Remove(Convert(c));
        }

        public ObservableCollection<Roshambo> GetAllRoshambos()
        {
            var list = new ObservableCollection<Roshambo>();
            var temp = DataStore.GetAllRoshambo().GetEnumerator();
            while(temp.MoveNext())
            {
                var cur = temp.Current;
                list.Add(new Roshambo(cur.Id, cur.Country, new Rock(cur.RockQuantity), new Paper(cur.PaperQuantity), new Scissors(cur.ScissorQuantity), cur.Enemy));
            }
            return list;
        }

        private RPSDataStorage.Models.Roshambo Convert(Roshambo c)
        {
            var rosh = new RPSDataStorage.Models.Roshambo();
            if(c.Id != 0)
            {
                rosh.Id = c.Id;
            }
            rosh.Country = c.Name.Value;
            rosh.RockQuantity = c.Rock.Quantity.Value;
            rosh.PaperQuantity = c.Paper.Quantity.Value;
            rosh.ScissorQuantity = c.Scissors.Quantity.Value;
            rosh.Enemy = c.Enemy;
            return rosh;
        }
    }
}
