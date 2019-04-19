using RPSBackendLogic.DomainPrimitives;
using RPSBackendLogic.Entities;
using System.Collections.ObjectModel;

namespace RPSBackendLogic.Data
{
    public interface IDataStoreRepo : IRepoService<Roshambo>, IRepoService<Log>
    {
        ObservableCollection<Roshambo> GetAllRoshambos();
        ObservableCollection<Log> GetAllLogEntries();
    }
}
