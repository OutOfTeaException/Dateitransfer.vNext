using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dateitransfer.vNext.Api.Dto
{
    public class Input
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Directory { get; set; }
        public string FileMask { get; set; }

        public virtual ICollection<Output> Outputs { get; set; }

        public int JobId { get; set; }
    }
}
