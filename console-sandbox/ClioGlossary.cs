using System;
using System.Text.Json.Serialization;

namespace console_sandbox
{
    public class ClioGlossary
    {
        public string? title { get; set; }
        public string? bodytext { get; set; }
        public string? word_title { get; set; }
        public string? link { get; set; }
        [JsonPropertyName("imageData")]
        public ClioImage? image { get; set; }
    }

}

