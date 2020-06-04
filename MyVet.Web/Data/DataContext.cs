using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sistema.Web.Data.Entities;

namespace Sistema.Web.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Sistema.Web.Data.Entities.Client_Classification> Client_Classification { get; set; }
        public DbSet<Sistema.Web.Data.Entities.Document> Document { get; set; }
        public DbSet<Sistema.Web.Data.Entities.Employee> Employee { get; set; }
        public DbSet<Sistema.Web.Data.Entities.Position> Position { get; set; }
    }
}
