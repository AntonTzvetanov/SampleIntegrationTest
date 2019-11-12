using NUnit.Framework;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTest.Models
{
    class GetUser
    {
        private HttpClient _client;
        private object LastName;

        [SetUp]
        public void Setup()
        {
            _client = new HttpClient();
             _client.BaseAddress = new Uri("http://localhost:3000");
        }

        [Test]

        public async Task GetUserPositiveTest()
        {

            var expectedAuthor = new PostUser
            {

                FirstName =  null,
                LastName = null,
                HouseholdId = 1,

            };
            var response = await _client.GetAsync("/users/1");
         
            var responseAsString = response.Content.ReadAsStringAsync().Result;

            response.EnsureSuccessStatusCode();

            var authors = PostUser.FromJson(responseAsString);

            Assert.AreEqual(expectedAuthor.FirstName,authors);
            Assert.AreEqual(expectedAuthor.LastName, authors);

            Assert.AreEqual(expectedAuthor.HouseholdId, authors);

        }

        [Test]
        public async Task GetUserNegative()
        {

            var response = await _client.GetAsync("/users/10");

            Assert.AreEqual(HttpStatusCode.Forbidden,response.StatusCode); 

        }

        [Test]

        public async Task PostUserPositiveTest()
        {

            var expectedAuthor = new PostUser
            {

                FirstName = null,
                LastName = "test2",
                HouseholdId = 1,

            };
          
            var content = new  StringContent(expectedAuthor.ToJson(),Encoding.UTF8,"application/json");


            var response = await _client.PostAsync("/users",content);
            response.EnsureSuccessStatusCode();
            var responseAsString = response.Content.ReadAsStringAsync().Result;
        }
    }
}
