using System.Collections.Generic;
using RestSharp;
using Dateitransfer.vNext.Api.Dto;


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

        public Job GetJob(int jobId)
        {
            RestClient client = new RestClient("http://localhost:12345");
            var request = new RestRequest("api/Management/{jobId}", Method.GET);
            request.AddParameter("jobId", jobId);
            var response = client.Execute<Job>(request);

            return response.Data;
        }

        public void Update(Job job)
        {

        }
    }
}