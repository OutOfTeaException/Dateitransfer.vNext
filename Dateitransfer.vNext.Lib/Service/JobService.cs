using Dateitransfer.vNext.Lib.Data;
using Dateitransfer.vNext.Lib.Model;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System;

namespace Dateitransfer.vNext.Lib.Service
{
    public class JobService : IDisposable
    {
        private DateitransferContext dateitransferContext;

        public JobService(DateitransferContext dateitransferContext)
        {
            this.dateitransferContext = dateitransferContext;
        }

        public void Dispose()
        {
            dateitransferContext.Dispose();
        }

        public IEnumerable<Job> GetAllJobs()
        {
            var jobs = dateitransferContext.Jobs.Include(j => j.Input).Include(j => j.Input.Outputs);

            return jobs.ToList();
        }

        public Job GetJob(int jobId)
        {
            var job = dateitransferContext.Jobs.Include(j => j.Input).Include(j => j.Input.Outputs).Single(j => j.Id == jobId);

            return job;
        }

        public void SaveChanges()
        {
            dateitransferContext.SaveChanges();
        }
    }
}
