using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using Dateitransfer.vNext.Lib.Service;

namespace Dateitransfer.vNext.Service.WebApi
{
    public class ManagementController : ApiController
    {
        private MapperConfiguration mapperConfiguration;
        private JobService jobService;

        public ManagementController(MapperConfiguration mapperConfiguration, JobService jobService)
        {
            this.mapperConfiguration = mapperConfiguration;
            this.jobService = jobService;
        }
        
        // GET api/values 
        public IEnumerable<Dateitransfer.vNext.Api.Dto.Job> Get()
        {
            var mapper = mapperConfiguration.CreateMapper();

            var jobEntities = jobService.GetAllJobs();

            return mapper.Map<IEnumerable<Dateitransfer.vNext.Api.Dto.Job>>(jobEntities);
        }

        // GET api/values/5 
        public string Get(int id)
        {
            return "value";
        }
    }
}
