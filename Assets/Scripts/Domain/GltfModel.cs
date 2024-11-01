using System;

namespace Domain.Models
{
    public class GltfModel
    {
        public string Url { get; }
        public byte[] BinaryData { get; }
        public Uri FileUri { get; }

        public GltfModel(string url)
        {
            Url = url;
        }

        public GltfModel(byte[] binaryData, Uri fileUri)
        {
            BinaryData = binaryData;
            FileUri = fileUri;
        }
    }
}
