using Microsoft.EntityFrameworkCore;
using GBook.Models;

namespace GBook.Repository
{
    public class GBookRepository : IRepository
    {
        private readonly UserContext _context;
        public GBookRepository(UserContext context)
        {
            _context = context;
        }

        public async Task<List<Messages>> GetMessageList()
        {
            return await _context.Messages.Include(p => p.User).ToListAsync();

        }
    }
}
