using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NUnit.Framework;
using RestSharp;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace IntegrationTest
{
    public  class CreateNewUser1 
    {

        [SetUp]
        public void Setup()
        {


        }
        [Test]
        public async Task Test1()
        {
            var client = new RestClient("http://localhost:3000/households");
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Connection", "keep-alive");
            request.AddHeader("Content-Length", "29");
            request.AddHeader("Accept-Encoding", "gzip, deflate");
            request.AddHeader("Host", "localhost:3000");
            request.AddHeader("Postman-Token", "e2f5b135-00c2-4064-9196-c549dda88ac9,3371dc12-56e9-4bef-8651-385efb78ac69");
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Accept", "*/*");
            request.AddHeader("User-Agent", "PostmanRuntime/7.19.0");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Conten-Type", "application/x-www-form-urlencoded");
            request.AddHeader("G-Token", "ROM831ESV");
            request.AddParameter("undefined", "{\n\t\n\t\"name\":\"TestHousehold\"\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

        }

        
    }
}


    public partial class SomeTest
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

    public partial class SomeTest
    {
        public static SomeTest FromJson(string json) => JsonConvert.DeserializeObject<SomeTest>(json, QuickType.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this SomeTest self) => JsonConvert.SerializeObject(self, QuickType.Converter.Settings);
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
 


