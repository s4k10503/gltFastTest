using Domain.Models;
using UseCase.Interfaces;
using Presentation.Interfaces;
using System.Threading;
using Cysharp.Threading.Tasks;
using GLTFast;
using UnityEngine;
using Zenject;
using System;

namespace Presentation.Presenter
{
    public class GltfPresenter : MonoBehaviour
    {
        private IGltfLoadUseCase _loadUseCase;
        private IGltfView _view;
        private CancellationTokenSource _cts;


        [Inject]
        public void Construct(
            IGltfLoadUseCase loadUseCase,
            IGltfView view)
        {
            _loadUseCase = loadUseCase;
            _view = view;
        }

        void Start()
        {
            _cts = new CancellationTokenSource();
            LoadModelAsync(
                "https://raw.githubusercontent.com/KhronosGroup/glTF-Sample-Models/master/2.0/Duck/glTF/Duck.gltf")
                .Forget();
        }

        async UniTask LoadModelAsync(string url = null, byte[] binaryData = null, Uri fileUri = null)
        {
            GltfModel model;
            if (binaryData != null && fileUri != null)
            {
                model = new GltfModel(binaryData, fileUri);
            }
            else if (!string.IsNullOrEmpty(url))
            {
                model = new GltfModel(url);
            }
            else
            {
                Debug.LogError("Specify the URL or binary data.");
                return;
            }

            GltfImport gltfImport = await _loadUseCase.LoadGltfAsync(model, _cts.Token);
            if (gltfImport != null)
            {
                await _view.DisplayGltfModel(gltfImport, _cts.Token);
            }
            else
            {
                Debug.LogError("The model road failed.");
            }
        }

        void OnDestroy()
        {
            _cts.Cancel();
            _cts.Dispose();
        }
    }
}
