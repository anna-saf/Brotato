using Zenject;
using UnityEngine;

public class BootstrapInstaller : MonoInstaller
{
    private const string _globalModel = "GlobalModel";
    public override void InstallBindings()
    {
        BindGlobalModel();
        BindGameInput();
        BindMovement();
    }

    private void BindGlobalModel()
    {
        Container
            .Bind<GlobalModel>()
            .FromComponentInNewPrefabResource(_globalModel)
            .AsSingle();
    }

    private void BindMovement()
    {
        Container
                .Bind<Movement>()
                    .AsSingle();
    }

    private void BindGameInput()
    {
        Container
                .Bind<GameInput>()
                    .AsSingle();
    }
}
