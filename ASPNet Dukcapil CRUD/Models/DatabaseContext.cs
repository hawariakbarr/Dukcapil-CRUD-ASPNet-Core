using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNet_Dukcapil_CRUD.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {

        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
        {

        }

        public DbSet<Dukcapil> Dukcapils { get; set; }
        public DbSet<Religion> Religions { get; set; }
        public DbSet<Marital> Maritals { get; set; }

        public DbSet<DukcapilResult> DukcapilResults { get; set; }
    }
}
