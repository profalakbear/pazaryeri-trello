using API.Data.Models;

namespace API.ServiceContracts
{
    public interface ILogsService
    {
        Task<Log?> GetLogAsync(int logId);
        Task<List<Log>> GetAllLogsAsync();
        Task<List<Log>> GetLogsByCardAsync(int cardId);
        Task<Log> AddLogAsync(Log log);
        Task<Log?> UpdateLogAsync(Log log);
        Task<bool> DeleteLogAsync(int logId);
    }
}
