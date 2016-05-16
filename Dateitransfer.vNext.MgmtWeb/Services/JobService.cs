using Dateitransfer.vNext.Api.Dto;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dateitransfer.vNext.MgmtWeb.Services
{
    public class JobService
    {
        public IEnumerable<Job> GetJobs()
        {
            RestClient client = new RestClient("http://localhost:12345");
            var request = new RestRequest("api/Management", Method.GET);
            var response = client.Execute<List<Job>>(request);

            return response.Data;
        }
    }
}