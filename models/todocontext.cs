using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.models
{
    public class todocontext : DbContext
    {
        public todocontext(DbContextOptions<todocontext> options) : base(options)
        {

        }

        public DbSet<todoModels> items { get; set; }
    }
}
