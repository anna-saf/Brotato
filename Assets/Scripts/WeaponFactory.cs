using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class WeaponFactory 
{
    private const string pistolPath = "Pistol";
    private const string mashineGunPath = "MashineGun";
    private Object pistolPrefab;
    private Object mashineGunPrefab;
    private readonly DiContainer _diContainer;

    [Inject]
    public WeaponFactory(DiContainer diContainer)
    {
        _diContainer = diContainer;
    }

    public void Load()
    {
        pistolPrefab = Resources.Load(pistolPath);
        mashineGunPrefab = Resources.Load(mashineGunPath);
    }

    public void Create(WeaponType weaponType, Vector3 at, Transform player)
    {
        switch (weaponType) 
        {
            case WeaponType.MashineGun:
                _diContainer.InstantiatePrefab(mashineGunPrefab, at, Quaternion.identity, player);
                break;
            case WeaponType.Pistol:
                _diContainer.InstantiatePrefab(pistolPrefab, at, Quaternion.identity, player);
                break;
        }
    }
}
