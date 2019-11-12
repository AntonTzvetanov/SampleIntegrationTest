using NUnit.Framework;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace IntegrationTest.Models
{
    public class AddHouseHold

    {

        private HttpClient _client;

        [SetUp]
        public void Setup()
        {

            var test = Guid.Empty.ToString();
            _client = new HttpClient
            {

                BaseAddress = new Uri("http://localhost:3000/")

            };
        }

        [Test]
        public async Task PostHold()
        {
           
            var expectedHousehold = new PostHousehold
            {
                Id = 26,
                Name= "TestHousehold",
                
            };


            var requestContent = new StringContent(expectedHousehold.ToJson());

            var response = await _client.PostAsync("/households", requestContent);


            var responseAsString = response.Content.ReadAsStringAsync().Result;

            var actualAuthor = PostHousehold.FromJson(responseAsString);


            Assert.IsNotNull(expectedHousehold.Id);


        }
    }
}






