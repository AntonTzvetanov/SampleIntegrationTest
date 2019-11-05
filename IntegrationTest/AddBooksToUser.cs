using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTest
{
    class AddBooksToUser
    {


        [SetUp]
        public void Setup()
        {

        }

        [Test]

        public async Task AddBooksToUsers()
        {
            var client = new RestClient("http://localhost:3000/wishlists/2/books/4");
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Connection", "keep-alive");
            request.AddHeader("Content-Length", "0");
            request.AddHeader("Accept-Encoding", "gzip, deflate");
            request.AddHeader("Host", "localhost:3000");
            request.AddHeader("Postman-Token", "4e742f48-0b86-4034-81f6-065215ebdf3e,01ce90a8-6a8e-4ec5-ad0c-dba9dcd6b802");
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Accept", "*/*");
            request.AddHeader("User-Agent", "PostmanRuntime/7.19.0");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("G-Token", "ROM831ESV");
            IRestResponse response = client.Execute(request);
            var status = response.StatusCode;

        }

    }
}
