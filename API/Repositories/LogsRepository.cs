using API.Data;
using API.Data.Models;
using API.RepositoryContracts;
using API.UoW;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class LogsRepository : ILogsRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public LogsRepository(ApplicationDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }


        public async Task<Log?> GetLogAsync(int logId)
        {
            return await _context.Logs.FindAsync(logId);
        }

        public async Task<List<Log>> GetAllLogsAsync()
        {
            return await _context.Logs.ToListAsync();
        }

        public async Task<List<Log>> GetLogsByCardAsync(int cardId)
        {
            return await _context.Logs.Where(log => log.CardID == cardId).ToListAsync();
        }

        public async Task<Log> AddLogAsync(Log log)
        {
            _context.Logs.Add(log);
            await _unitOfWork.SaveChangesAsync();
            return log;
        }

        public async Task<Log?> UpdateLogAsync(Log log)
        {
            var existingLog = await _context.Logs.FindAsync(log.ID);

            if (existingLog == null)
            {
                return null;
            }

            _context.Entry(existingLog).CurrentValues.SetValues(log);
            await _unitOfWork.SaveChangesAsync();

            return existingLog;
        }

        public async Task<bool> DeleteLogAsync(int logId)
        {
            var log = await _context.Logs.FindAsync(logId);
            if (log == null)
                return false;

            _context.Logs.Remove(log);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
