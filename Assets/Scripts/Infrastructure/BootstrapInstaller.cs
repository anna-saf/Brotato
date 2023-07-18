using Zenject;
using UnityEngine;

public class BootstrapInstaller : MonoInstaller
{
    [SerializeField] private GlobalModel _globalModel;

    public override void InstallBindings()
    {
        BindGlobalModel();
        BindGameInput();
        BindMovement();
    }

    private void BindGlobalModel()
    {
        GlobalModel globalModel = Container.InstantiatePrefabForComponent<GlobalModel>(_globalModel);

        Container
            .Bind<GlobalModel>()
            .FromInstance(globalModel)
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
