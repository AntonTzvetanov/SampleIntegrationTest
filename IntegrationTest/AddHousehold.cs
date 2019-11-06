using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NUnit.Framework;
using RestSharp;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace IntegrationTest.Models
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task AddHouseHold()
        {
            var client = new RestClient("http://localhost:3000/households/");
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Connection", "keep-alive");
            //request.AddHeader("Content-Length", "23");
            request.AddHeader("Accept-Encoding", "gzip, deflate");
            request.AddHeader("Host", "localhost:3000");
            request.AddHeader("Postman-Token", "b9f0b977-7ddd-4a61-bb5c-6030d2a0f0d5,9118e2be-2ed0-466c-a2ee-9a19a200e77f");
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Accept", "*/*");
            request.AddHeader("User-Agent", "PostmanRuntime/7.19.0");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Conten-Type", "application/x-www-form-urlencoded");
            request.AddHeader("G-Token", "ROM831ESV");
            request.AddParameter("undefined", "{\n\t\n\t\"name\":\"Pleven*\"\n\t\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            var status = response.StatusCode;
        }
    }
}



namespace QuickType
{

    public partial class AddHouseHold
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("updatedAt")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("links")]
        public Link[] Links { get; set; }
    }

    public partial class Link
    {
        [JsonProperty("rel")]
        public string Rel { get; set; }

        [JsonProperty("href")]
        public Uri Href { get; set; }
    }

    public partial class AddHouseHold
    {
        public static AddHouseHold FromJson(string json) => JsonConvert.DeserializeObject<AddHouseHold>(json, QuickType.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this AddHouseHold self) => JsonConvert.SerializeObject(self, QuickType.Converter.Settings);
    }

    internal static class Converter
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


