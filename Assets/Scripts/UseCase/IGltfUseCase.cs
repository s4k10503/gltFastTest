using System.Threading;
using Cysharp.Threading.Tasks;
using Domain.Models;
using GLTFast;

namespace UseCase.Interfaces
{
    public interface IGltfLoadUseCase
    {
        UniTask<GltfImport> LoadGltfAsync(GltfModel model, CancellationToken token);
    }
}
