using RPSBackendLogic.Data;
using RPSDataStorage.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPSDataStorage.Data
{
    public interface IDbRepo : IRepoService<Roshambo>, IRepoService<Log>
    {
        IEnumerable<Roshambo> GetAllRoshambo();
        IEnumerable<Log> GetAllLogEntries();
    }
}
