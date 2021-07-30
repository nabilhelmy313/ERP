using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class ERPDbContext:IdentityDbContext
    {
        public ERPDbContext(DbContextOptions<ERPDbContext> options) : base(options)
        {

        }
    }
}
