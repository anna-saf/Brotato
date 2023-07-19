using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour 
{
    [SerializeField] protected int _damage;
    [SerializeField] protected float _damageRadius;

    public abstract void FindEnemy();
    public abstract void Attack();
}
