using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace GrafoLibary.UI.Models
{
    public class CustomMultipartFormDataStreamProvider : MultipartFormDataStreamProvider
    {
        public CustomMultipartFormDataStreamProvider(string rootPath)
            : base(rootPath) { }

        public override string GetLocalFileName(HttpContentHeaders headers)
        {
            var filename = headers.ContentDisposition.FileName;

            return !string.IsNullOrWhiteSpace(filename) ?
                        filename.Replace("\"", string.Empty) :
                        Guid.NewGuid().ToString();
        }
    }
}