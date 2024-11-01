using System.Threading;
using Cysharp.Threading.Tasks;
using GLTFast;

namespace Presentation.Interfaces
{
    public interface IGltfView
    {
        UniTask DisplayGltfModel(GltfImport gltfImport, CancellationToken token);
    }
}
