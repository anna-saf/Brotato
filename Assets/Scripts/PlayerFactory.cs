using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerFactory
{
    private Object _playerPrefab;
    private readonly DiContainer _diContainer;

    [Inject]
    public PlayerFactory(DiContainer diContainer)
    {
        _diContainer = diContainer;
    }

    public void Load()
    {
        //_playerPrefab = Resources.Load(_playerPath);
    }

    public void Create(WeaponType weaponType, Vector3 at, Transform player)
    {
        _diContainer.InstantiatePrefab(_playerPrefab, at, Quaternion.identity, player);
    }
}
