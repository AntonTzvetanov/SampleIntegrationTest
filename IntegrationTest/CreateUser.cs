using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NUnit.Framework;
using RestSharp;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace IntegrationTest
{
    class CreateUser
    {

        [SetUp]
        public void Setup()
        {

        }

        
        

        [Test]
        public async Task CopyCodeFromPostmanForAddingUser()
        {

            var client = new RestClient("http://localhost:3000/users/");
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Connection", "keep-alive");
            request.AddHeader("Content-Length", "107");
            request.AddHeader("Accept-Encoding", "gzip, deflate");
            request.AddHeader("Host", "localhost:3000");
            request.AddHeader("Postman-Token", "a23130fa-9de1-4344-af1f-8d593517cb45,a8bc76d3-e44f-43ab-9ca0-ea618d888e22");
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Accept", "*/*");
            request.AddHeader("User-Agent", "PostmanRuntime/7.19.0");
            request.AddHeader("Content-Type", "application/json,application/json");
            request.AddHeader("G-Token", "ROM831ESV");
            request.AddParameter("undefined", "{\n\t\n\n    \"email\":\"Personal\",\n    \"firstName\":\"Anton\",\n    \"lastName\":\"Tsvetanov\",\n    \"householdId\":\"3\"\n\t\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request); 
             var status = response.StatusCode;
        }
    }



    public partial class CreateNewUser
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("householdId")]
        public long HouseholdId { get; set; }

        [JsonProperty("wishlistId")]
        public long WishlistId { get; set; }

        [JsonProperty("updatedAt")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("links")]
        public Link[] Links { get; set; }
    }

    public partial class Test
    {
        [JsonProperty("rel")]
        public string Rel { get; set; }

        [JsonProperty("href")]
        public Uri Href { get; set; }
    }

    public partial class AddUser
    {
        public static SomeTest FromJson(string json) => JsonConvert.DeserializeObject<SomeTest>(json, Converter.Settings);
    }

    public static class AddUser1
    {
        public static string ToJson(this SomeTest self) => JsonConvert.SerializeObject(self,Converter.Settings);
    }

    internal static class ConverterjSON
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}

