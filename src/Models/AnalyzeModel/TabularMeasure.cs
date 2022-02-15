﻿namespace Sqlbi.Bravo.Models.AnalyzeModel
{
    using System.Text.Json.Serialization;

    public class TabularMeasure
    {
        [JsonPropertyName("etag")]
        public string? ETag { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("tableName")]
        public string? TableName { get; set; }

        [JsonPropertyName("measure")]
        public string? Expression { get; set; }
    }
}