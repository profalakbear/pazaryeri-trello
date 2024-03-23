using API.Data.Models;

namespace API.RepositoryContracts
{
    public interface ILogsRepository
    {
        Task<Log?> GetLogAsync(int logId);
        Task<List<Log>> GetAllLogsAsync();
        Task<List<Log>> GetLogsByCardAsync(int cardId);
        Task<Log> AddLogAsync(Log log);
        Task<Log?> UpdateLogAsync(Log log);
        Task<bool> DeleteLogAsync(int logId);
    }
}
