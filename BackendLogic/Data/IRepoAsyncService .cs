using System.Threading.Tasks;

namespace RPSBackendLogic.Data
{
    public interface IRepoAsyncService<T>
    {
        Task AddAsync(T c);
        Task Update(T c);
        Task RemoveAsync(T c);
    }
}
