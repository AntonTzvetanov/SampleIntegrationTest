using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
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
            request.AddHeader("Content-Length", "8");
            request.AddHeader("Accept-Encoding", "gzip, deflate");
            request.AddHeader("Host", "localhost:3000");
            request.AddHeader("Postman-Token", "14ff2541-c7d4-4ad9-be68-1791c0edca47,f031cb49-6ac8-45e2-9451-edc82acaba20");
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Accept", "*/*");
            request.AddHeader("User-Agent", "PostmanRuntime/7.19.0");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("G-Token", "ROM831ESV");
            request.AddParameter("undefined", "{\n\t\n\t\n}\n", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

        }
    }
}


    public partial class GetWishlist
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public Name Name { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTimeOffset UpdatedAt { get; set; }
    }

    public enum Name { AntonSList, MadlenSList, NullSList, SlaviSList, UndefinedSList };

    public partial class GetWishlist
    {
        public static GetWishlist[] FromJson(string json) => JsonConvert.DeserializeObject<GetWishlist[]>(json, QuickType.Converter.Settings);
    }

    public static class SerializeWishlist
    {
        public static string ToJson(this GetWishlist[] self) => JsonConvert.SerializeObject(self, QuickType.Converter.Settings);
    }

    internal static class ConverterWishlist
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                NameConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class NameConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Name) || t == typeof(Name?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Anton's List":
                    return Name.AntonSList;
                case "Madlen's List":
                    return Name.MadlenSList;
                case "Slavi's List":
                    return Name.SlaviSList;
                case "null's List":
                    return Name.NullSList;
                case "undefined's List":
                    return Name.UndefinedSList;
            }
            throw new Exception("Cannot unmarshal type Name");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Name)untypedValue;
            switch (value)
            {
                case Name.AntonSList:
                    serializer.Serialize(writer, "Anton's List");
                    return;
                case Name.MadlenSList:
                    serializer.Serialize(writer, "Madlen's List");
                    return;
                case Name.SlaviSList:
                    serializer.Serialize(writer, "Slavi's List");
                    return;
                case Name.NullSList:
                    serializer.Serialize(writer, "null's List");
                    return;
                case Name.UndefinedSList:
                    serializer.Serialize(writer, "undefined's List");
                    return;
            }
            throw new Exception("Cannot marshal type Name");
        }

        public static readonly NameConverter Singleton = new NameConverter();
    }


