
using Microsoft.EntityFrameworkCore;
using Proje.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Entities
{
    public class ProjectContext:DbContext
    {
        public ProjectContext()
        {
        }
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {

        }
        public DbSet<Bill> Bills { get; set; }

        public DbSet<BillType> Bill_Types { get; set; }


        public DbSet<Flat> Flats { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<User> Users{ get; set; }

    }
}
