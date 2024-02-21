using csharpBeginner.Database.Entity;
using MySql.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace csharpBeginner.Database
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class JourneyContext : DbContext
    {
        public DbSet<Dtgen> Dtgens { get; set; }

        public JourneyContext()
          : base()
        {

        }

        public JourneyContext(DbConnection existingConnection, bool contextOwnsConnection)
          : base(existingConnection, contextOwnsConnection)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Dtgen>().ToTable("dt_gen");
            modelBuilder.Entity<Dtgen>().HasKey(d => d.genId);
            modelBuilder.Entity<Dtgen>().Property(d => d.genUserId).IsRequired();



        }
    }
}
