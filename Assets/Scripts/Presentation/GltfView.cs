using Cysharp.Threading.Tasks;
using GLTFast;
using UnityEngine;
using Presentation.Interfaces;
using System.Threading;

namespace Presentation.View
{
    public class GltfView : MonoBehaviour, IGltfView
    {
        public async UniTask DisplayGltfModel(GltfImport gltfImport, CancellationToken token)
        {
            GameObject gltfObject = new GameObject("GLTF Model");
            await gltfImport
                .InstantiateMainSceneAsync(gltfObject.transform)
                .AsUniTask()
                .AttachExternalCancellation(token);

            gltfObject.transform.SetParent(transform);
            gltfObject.SetActive(true);
        }
    }
}
