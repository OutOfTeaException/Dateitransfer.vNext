using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dateitransfer.vNext.Api.Dto
{
    public class Output
    {
        public int Id { get; set; }
        public string Directory { get; set; }

        public int InputId { get; set; }
    }
}
