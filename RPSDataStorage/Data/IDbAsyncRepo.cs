using RPSBackendLogic.Data;
using RPSDataStorage.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RPSDataStorage.Data
{
    public interface IDbAsyncRepo : IRepoAsyncService<Roshambo>, IRepoAsyncService<Log>
    {
        Task<IEnumerable<Roshambo>> GetAllRoshamboAsync();
        Task<IEnumerable<Log>> GetAllLogEntriesAsync();
    }
}
