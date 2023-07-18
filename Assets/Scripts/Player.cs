using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour, IPlayer
{
    private Movement _movement;
    private IEnumerator _moveCoroutine;

    [Inject]
    void Construct(Movement movement)
    {
       _movement = movement;
       _movement.Init(this);
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
