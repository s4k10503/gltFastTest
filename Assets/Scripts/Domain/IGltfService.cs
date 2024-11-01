using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using GLTFast;

namespace Domain.Interfaces
{
    public interface IGltfService
    {
        UniTask<GltfImport> LoadGltfFromUrlAsync(string url, CancellationToken token);
        UniTask<GltfImport> LoadGltfFromBinaryAsync(byte[] data, Uri fileUri, CancellationToken token);
    }
}
