﻿using RPSBackendLogic.Data;
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

        public void Add(Roshamo c)
        {
            DataStore.Add(Convert(c));
        }

        public void Update(Roshamo c)
        {
            DataStore.Update(Convert(c));
        }

        public void Remove(Roshamo c)
        {
            DataStore.Remove(Convert(c));
        }

        public ObservableCollection<Roshamo> GetAllRoshamos()
        {
            var list = new ObservableCollection<Roshamo>();
            var temp = DataStore.GetAllRoshamo().GetEnumerator();
            while(temp.MoveNext())
            {
                var cur = temp.Current;
                list.Add(new Roshamo(cur.Id, cur.Country, new Rock(cur.RockQuantity), new Paper(cur.PaperQuantity), new Scissors(cur.ScissorQuantity)));
            }
            return list;
        }

        private RPSDataStorage.Models.Roshamo Convert(Roshamo c)
        {
            var rosh = new RPSDataStorage.Models.Roshamo();
            if(c.Id != 0)
            {
                rosh.Id = c.Id;
            }
            rosh.Country = c.Name.Value;
            return rosh;
        }
    }
}
