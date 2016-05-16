namespace Dateitransfer.vNext.Lib.Migrations
{
    using Model;
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Dateitransfer.vNext.Lib.Data.DateitransferContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Dateitransfer.vNext.Lib.Data.DateitransferContext context)
        {
            //  This method will be called after migrating to the latest version.

            context.Inputs.AddOrUpdate(i => i.Id,
                new Input { Id = 1, Name = "Input 1", Directory = @"c:\temp\Dateitransfer.vNext\Input1", FileMask = "*.*", JobId = 1 }
                );

            context.Jobs.AddOrUpdate(j => j.Id,
                new Job { Id = 1,  Name = "Job 1", IsEnabled = true, LastRun = new DateTime(2016, 01, 01), Cron = "0/10 * * * * ?", InputId = 1 }
                );

            context.Outputs.AddOrUpdate(o => o.Id,
                new Output { Id = 1, Directory = @"c:\temp\Dateitransfer.vNext\Output1", InputId = 1 }
                );
        }
    }
}
