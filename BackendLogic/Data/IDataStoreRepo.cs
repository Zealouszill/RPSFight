using RPSBackendLogic.DomainPrimitives;
using RPSBackendLogic.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace RPSBackendLogic.Data
{
    public interface IDataStoreRepo : IRepoService<Roshambo>, IRepoService<Log>
    {
        ObservableCollection<Roshambo> GetAllRoshambos();
        ObservableCollection<Log> GetAllLogEntries();
    }
}
