using Microsoft.EntityFrameworkCore;
using Requests.dal.Models;

namespace Reauests.dal
{
    public class RequestRepository : IRequestRepository
    {
        private readonly RequestDbContext _context;

        public RequestRepository(RequestDbContext context)
        {
            _context = context;
        }

        public async Task<List<Request>> GetAllRequestsAsync()
        {
            try
            {
                return await _context.Requests.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("שגיאה בקבלת נתונים ממסד הנתונים", ex);
            }
        }

        public async Task<Request> CreateRequestAsync(Request request)
        {
            try
            {
                _context.Requests.Add(request);
                await _context.SaveChangesAsync();
                return request;
            }
            catch (Exception ex)
            {
                throw new Exception("שגיאה בשמירת הבקשה במסד הנתונים", ex);
            }
        }
    }
}