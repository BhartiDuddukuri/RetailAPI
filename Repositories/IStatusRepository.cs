using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RetailAPI.Models;

namespace RetailAPI.Repositories
{
    public interface IStatusRepository
    {
        Task<IEnumerable<Status>> GetStatus();
    }
}
