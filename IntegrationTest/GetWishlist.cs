using NUnit.Framework;
using RestSharp;
using System.Threading.Tasks;

namespace IntegrationTest
{
    class GetWishlist
    {

        [SetUp]
        public void Setup()
        {

        }

        [Test]

        public async Task Wishlist()
        {
            var client = new RestClient("http://localhost:3000/wishlists/");
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Connection", "keep-alive");
         
            request.AddHeader("Accept-Encoding", "gzip, deflate");
            request.AddHeader("Host", "localhost:3000");
            request.AddHeader("Postman-Token", "b75300e8-45d9-441f-b5e8-af4d0d83b9a8,4cae41d4-e3de-4931-a727-9c58b60f0370");
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Accept", "*/*");
            request.AddHeader("User-Agent", "PostmanRuntime/7.19.0");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("G-Token", "ROM831ESV");
            request.AddParameter("undefined", "{\n\t\n\t\n}\n", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            var status = response.StatusCode;
            

        }
    }
}


