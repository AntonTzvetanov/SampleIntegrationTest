using IntegrationTest.Models.Users;
using NUnit.Framework;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTest.Models
{
    class CreateNewUser
    {
        private HttpClient _client;

        [SetUp]
        public void Setup()
        {

             _client = new HttpClient
             {

                 BaseAddress = new Uri("http://localhost:3000/"),
             };
             _client.DefaultRequestHeaders.Add("G-Token", "ROM831ESV");
        }

        
        

        [Test]
        public async Task PostUser()
        {

            var userToCreate = new CreateUser
            {
                Email = "Oryx",
                FirstName = "Anton",
                LastName = "Tsvetanov",
                HouseholdId = 3
            };


            var requestContent = new StringContent(userToCreate.ToJson(), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync($"/users", requestContent);
            var responseContent = await response.Content.ReadAsStringAsync();

            var actualUser = CreateUser.FromJson(responseContent);

            static bool userComparer(CreateUser expectedUser, CreateUser actualUser)
            {
                return actualUser.Id > 0 &&
                    expectedUser.FirstName == actualUser.FirstName &&
                    expectedUser.LastName == actualUser.LastName &&
                    expectedUser.Email == actualUser.Email &&
                    expectedUser.HouseholdId == actualUser.HouseholdId;
            }

            Assert.IsTrue(userComparer(userToCreate, actualUser));

        }
    }



}

