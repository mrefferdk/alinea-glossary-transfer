using System;
namespace console_sandbox
{
    public class GlossaryDTO
    {
        public const string ClioTagName = "Clio";

        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ProductId { get; set; }
        public string? Category { get; set; }
        public string? Tags { get; set; }
        public string? ImageUrl { get; set; }
        public string? ImageTitle { get; set; }
        public string? ImageDescription { get; set; }
        public string? ImageCopyrightText { get; set; }
        public string? ImageTag { get; set; }

        public GlossaryDTO(ClioGlossary clioGlossary, string productId)
        {
            Title = clioGlossary.title;
            Description = clioGlossary.bodytext;
            ProductId = productId;
            Tags = "clio";
            Category = "Explanation";
        }

    }
}

