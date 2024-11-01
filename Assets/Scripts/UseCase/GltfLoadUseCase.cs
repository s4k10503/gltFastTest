using System.Threading;
using Cysharp.Threading.Tasks;
using Domain.Models;
using Domain.Interfaces;
using UseCase.Interfaces;
using GLTFast;
using Zenject;

namespace UseCase.UseCases
{
    public class GltfLoadUseCase : IGltfLoadUseCase
    {
        private readonly IGltfService _gltfService;

        [Inject]
        public GltfLoadUseCase(IGltfService gltfService)
        {
            _gltfService = gltfService;
        }

        public async UniTask<GltfImport> LoadGltfAsync(GltfModel model, CancellationToken token)
        {
            if (model.BinaryData != null && model.FileUri != null)
            {
                return await _gltfService.LoadGltfFromBinaryAsync(model.BinaryData, model.FileUri, token);
            }
            else if (!string.IsNullOrEmpty(model.Url))
            {
                return await _gltfService.LoadGltfFromUrlAsync(model.Url, token);
            }
            else
            {
                UnityEngine.Debug.LogError("The data required for the model load is insufficient.");
                return null;
            }
        }
    }
}
