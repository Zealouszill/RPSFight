using System;
using System.Collections.Generic;
using System.Text;

namespace RPSBackendLogic.Data
{
    public interface IRepoService<T>
    {
        void Add(T c);
        void Update(T c);
        void Remove(T c);
    }
}
