using RPSBackendLogic.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace RPSBackendLogic.Data
{
    public interface IDataStoreRepo : IRepoService<Roshamo>
    {
        ObservableCollection<Roshamo> GetAllRoshamos();
    }
}
