using AutoMapper;
using Dateitransfer.vNext.Lib.Model;
using Dateitransfer.vNext.Lib.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Dateitransfer.vNext.Service
{
    public class ManagementController : ApiController
    {
        private MapperConfiguration mapperConfiguration;

        public ManagementController(MapperConfiguration mapperConfiguration)
        {
            this.mapperConfiguration = mapperConfiguration;
        }
        
        // GET api/values 
        public IEnumerable<Dateitransfer.vNext.Service.Dto.Job> Get()
        {
            var mapper = mapperConfiguration.CreateMapper();

            JobService jobService = new JobService();
            var jobEntities = jobService.GetAllJobs();

            return mapper.Map<IEnumerable<Dateitransfer.vNext.Service.Dto.Job>>(jobEntities);
        }

        // GET api/values/5 
        public string Get(int id)
        {
            return "value";
        }
    }
}
