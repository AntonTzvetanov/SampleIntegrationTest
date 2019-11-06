
namespace IntegrationTest
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System;
    using System.Globalization;

    public partial class PostUser
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

    public partial class Link
    {
        [JsonProperty("rel")]
        public string Rel { get; set; }

        [JsonProperty("href")]
        public Uri Href { get; set; }
    }

    public partial class PostUser
    {
        public static PostUser FromJson(string json) => JsonConvert.DeserializeObject<PostUser>(json, IntegrationTest.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this PostUser self) => JsonConvert.SerializeObject(self, IntegrationTest.Converter.Settings);
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
