using UnityEngine;
using Zenject;
using Zenject.SpaceFighter;

public class LocationInstaller : MonoInstaller
{
    private const string _playerPath = "Player";
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Player _playerPrefab;

    public override void InstallBindings()
    {
        BindWeaponFactory();
        BindWeaponCreator();
        BindPlayer();
    }

    private void BindPlayer()
    {
        Container
            .Bind<IPlayer>()
            .To<Player>()
            .FromComponentInNewPrefabResource(_playerPath)
            .AsSingle()
            .NonLazy();
    }

    private void BindWeaponFactory()
    {
        Container
            .Bind<WeaponFactory>()
            .AsSingle();
    }

    private void BindWeaponCreator()
    {
        Container
            .Bind<WeaponCreator>()
            .AsSingle();
    }
}
