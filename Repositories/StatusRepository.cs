using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RetailAPI.Models;

namespace RetailAPI.Repositories
{
    public class StatusRepository : IStatusRepository
    {
        private readonly AppDbContext appDbContext;

        public StatusRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Status>> GetStatus()
        {
            return await appDbContext.Statuses.ToListAsync();
        }
    }
}
