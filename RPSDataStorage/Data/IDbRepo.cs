using RPSBackendLogic.Data;
using RPSDataStorage.Models;
using System.Collections.Generic;

namespace RPSDataStorage.Data
{
    public interface IDbRepo : IRepoService<Roshambo>, IRepoService<Log>
    {
        IEnumerable<Roshambo> GetAllRoshambo();
        IEnumerable<Log> GetAllLogEntries();
    }
}
