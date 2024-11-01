using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Domain.Interfaces;
using GLTFast;

namespace Infra.Services
{
    public class GltfService : IGltfService
    {
        public async UniTask<GltfImport> LoadGltfFromUrlAsync(string url, CancellationToken token)
        {
            var gltfImport = new GltfImport();
            bool success = await gltfImport.Load(url)
                .AsUniTask()
                .AttachExternalCancellation(token);
            return success ? gltfImport : null;
        }

        public async UniTask<GltfImport> LoadGltfFromBinaryAsync(byte[] data, Uri fileUri, CancellationToken token)
        {
            var gltfImport = new GltfImport();
            bool success = await gltfImport.LoadGltfBinary(data, fileUri)
                .AsUniTask()
                .AttachExternalCancellation(token);
            return success ? gltfImport : null;
        }
    }
}
