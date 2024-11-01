using Zenject;
using Domain.Interfaces;
using UseCase.Interfaces;
using UseCase.UseCases;
using Infra.Services;
using Presentation.Interfaces;
using Presentation.View;

namespace Installer
{
    public sealed class MainSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IGltfService>()
                .To<GltfService>()
                .AsSingle();

            Container
                .Bind<IGltfLoadUseCase>()
                .To<GltfLoadUseCase>()
                .AsSingle();

            Container
                .Bind<IGltfView>()
                .To<GltfView>()
                .FromComponentInHierarchy()
                .AsSingle();
        }
    }
}
