using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class WeaponCreator 
{ 
    private IPlayer _player;
    private List<WeaponType> _weapons;

    private GlobalModel _globalModel;
    private WeaponFactory _weaponFactory;

    [Inject]
    public WeaponCreator(GlobalModel globalModel, WeaponFactory weaponFactory)
    {
        _globalModel = globalModel;
        _weaponFactory = weaponFactory;
    }

    public void Init(IPlayer player)
    {
        _player = player;
        _weapons = _globalModel.Weapons;
        CreateWeapons();
    }

    public void CreateWeapons()
    {
        _weaponFactory.Load();
        float radius = _globalModel.WeaponsRadius;
        int counter = 1;
        foreach (var weapon in _weapons)
        {
            float xCos = Mathf.Round(Mathf.Cos((Mathf.PI / 180) * (360 * counter / _weapons.Count))*100)/100;
            float ySin = Mathf.Round(Mathf.Sin((Mathf.PI / 180) * (360 * counter / _weapons.Count)) * 100) / 100;
            float x = radius * xCos;
            float y = radius * ySin;
            _weaponFactory.Create(weapon, new Vector3 ( x, y, 0f ), _player.playerTransform);
            counter++;
        }
    }
}
