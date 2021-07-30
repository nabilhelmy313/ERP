using Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ERPDbContext _dbContext;

        public UnitOfWork(ERPDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> CommitAsync()
        {
           return await _dbContext.SaveChangesAsync();
        }
    }
}
