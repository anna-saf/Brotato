using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalModel : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    public float MoveSpeed { get { return _moveSpeed; } }

    [SerializeField] private float _weaponsRadius;

    public float WeaponsRadius { get { return _weaponsRadius; } }

    [SerializeField] private List<WeaponType> _weapons;

    public List<WeaponType> Weapons { get { return _weapons; } }
}
