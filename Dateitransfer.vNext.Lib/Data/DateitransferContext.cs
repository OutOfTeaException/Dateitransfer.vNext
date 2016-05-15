using Dateitransfer.vNext.Lib.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dateitransfer.vNext.Lib.Data
{
    public class DateitransferContext : DbContext
    {
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Input> Inputs { get; set; }
        public DbSet<Output> Outputs { get; set; }

        public DateitransferContext() : base("DateitransferContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Input>()
                        .HasOptional(i => i.Job)
                        .WithRequired(j => j.Input);
        }
    }
}
