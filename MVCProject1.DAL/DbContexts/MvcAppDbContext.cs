using Microsoft.EntityFrameworkCore;
using MVCProject1.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCProject1.DAL.DbContexts
{
    public class MvcAppDbContext :DbContext
    {
        public MvcAppDbContext(DbContextOptions<MvcAppDbContext> options):base(options)
        {
            
        }

        public DbSet<Department> Departments { get; set; }

    }
}
