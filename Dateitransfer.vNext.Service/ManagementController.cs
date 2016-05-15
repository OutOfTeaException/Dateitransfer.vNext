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
        private MapperConfiguration mapperConfig;
        // GET api/values 
        public IEnumerable<Dateitransfer.vNext.Service.Dto.Job> Get()
        {
           

            if (mapperConfig == null)
            {
                mapperConfig = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Dateitransfer.vNext.Lib.Model.Input, Dateitransfer.vNext.Service.Dto.Input>();
                    cfg.CreateMap<Dateitransfer.vNext.Lib.Model.Output, Dateitransfer.vNext.Service.Dto.Output>();
                    cfg.CreateMap<Dateitransfer.vNext.Lib.Model.Job, Dateitransfer.vNext.Service.Dto.Job>();
                });
            }

            var mapper = mapperConfig.CreateMapper();

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
