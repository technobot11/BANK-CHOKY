using BNIWebServiceTest.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BNIWebServiceTest.Services
{
    public class GetSummaryWikipediaAPI
    {
        public SummaryWikipediaAPI GetDeskripsiKota(string namaKota)
        {
            string urlPath = "https://id.wikipedia.org/api/rest_v1/page/";

            RestClient client = new RestClient(urlPath);
            RestRequest request = new RestRequest($"summary/{namaKota}?redirect=true", Method.GET);
            IRestResponse<SummaryWikipediaAPI> response = client.Execute<SummaryWikipediaAPI>(request);

            return response.Data;
        }
    }
}