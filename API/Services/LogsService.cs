using API.Data.Models;
using API.RepositoryContracts;
using API.ServiceContracts;

namespace API.Services
{
    public class LogsService : ILogsService
    {
        private readonly ILogsRepository _logsRepository;

        public LogsService(ILogsRepository logsRepository)
        {
            _logsRepository = logsRepository;
        }

        public Task<Log?> GetLogAsync(int logId)
        {
            return _logsRepository.GetLogAsync(logId);
        }

        public Task<List<Log>> GetAllLogsAsync()
        {
            return _logsRepository.GetAllLogsAsync();
        }

        public Task<List<Log>> GetLogsByCardAsync(int cardId)
        {
            return _logsRepository.GetLogsByCardAsync(cardId);
        }

        public Task<Log> AddLogAsync(Log log)
        {
            return _logsRepository.AddLogAsync(log);
        }

        public Task<Log?> UpdateLogAsync(Log log)
        {
            return _logsRepository.UpdateLogAsync(log);
        }

        public Task<bool> DeleteLogAsync(int logId)
        {
            return _logsRepository.DeleteLogAsync(logId);
        }

    }
}
