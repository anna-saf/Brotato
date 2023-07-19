using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour, IPlayer
{

    private Movement _movement;
    private WeaponCreator _weaponCreator;
    private IEnumerator _moveCoroutine;

    public Transform playerTransform => transform;

    [Inject]
    public void Construct(Movement movement, WeaponCreator weaponCreator)
    {
       _movement = movement;
        _weaponCreator = weaponCreator;
       _movement.Init(this);
       _weaponCreator.Init(this);
    }

    public void Move(Vector3 dir)
    {
        if (_moveCoroutine != null)
        {
            StopCoroutine(_moveCoroutine);
        }
        _moveCoroutine = MoveCoroutine(dir);
        StartCoroutine(_moveCoroutine);                
    }

    public void MoveEnd()
    {
        if(_moveCoroutine != null)
        {
            StopCoroutine(_moveCoroutine);
        }
    }

    private IEnumerator MoveCoroutine(Vector3 dir)
    {
        while (true)
        {
            transform.position += dir;
            yield return new WaitForFixedUpdate();
        }
    }
}
