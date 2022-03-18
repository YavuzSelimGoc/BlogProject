using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.DataAccessLayer
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-540G9TR\\SQLEXPRESS; database=BlogProjectApiDb; " +
                "integrated security=true;");

        }
        public DbSet<Employer> Employers { get; set; }
    }
}
