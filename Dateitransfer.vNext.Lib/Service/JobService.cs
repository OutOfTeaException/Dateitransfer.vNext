using Dateitransfer.vNext.Lib.Data;
using Dateitransfer.vNext.Lib.Model;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace Dateitransfer.vNext.Lib.Service
{
    public class JobService
    {
        public IEnumerable<Job> GetAllJobs()
        {
            using (var db = new DateitransferContext())
            {
                var jobs = db.Jobs.Include(j => j.Input).Include(j => j.Input.Outputs);

                return jobs.ToList();
            }
        }
    }
}
