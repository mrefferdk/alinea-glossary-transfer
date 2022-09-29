using System;
namespace console_sandbox
{
    class Portal
    {
        public string? Url { get; set; }
        public string? ProductId { get; set; }

        public Portal(string url, string productId)
        {
            Url = url;
            ProductId = productId;
        }

    }
}

