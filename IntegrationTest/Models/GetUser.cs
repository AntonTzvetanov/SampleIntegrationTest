

namespace IntegrationTest.Models

{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System;
    using System.Globalization;

    public partial class Authors
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("wishlistId")]
        public long WishlistId { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("householdId")]
        public long HouseholdId { get; set; }
    }

    public partial class Authors
    {
        public static Authors[] FromJson(string json) => JsonConvert.DeserializeObject<Authors[]>(json, QuickType.Converter.Settings);
    }

    public static class SerializeAuthor
    {
        public static string ToJson(this Authors[] self) => JsonConvert.SerializeObject(self, QuickType.Converter.Settings);
    }

    internal static class ConverterAuthor
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
