using RPSBackendLogic.DomainPrimitives;
using RPSBackendLogic.Entities;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace RPSBackendLogic.Data
{
    public interface IDataStoreAsyncRepo : IRepoService<Roshambo>, IRepoService<Log>
    {
        Task<ObservableCollection<Roshambo>> GetAllRoshambosAsync();
        Task<ObservableCollection<Log>> GetAllLogEntriesAsync();
    }
}
