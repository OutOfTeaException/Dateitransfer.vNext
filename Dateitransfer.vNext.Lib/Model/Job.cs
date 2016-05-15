using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dateitransfer.vNext.Lib.Model
{
    public class Job
    {
        public int Id { get; set; }
        public string Cron { get; set; }
        public virtual Input Input { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime LastRun { get; set; }
    }
}
