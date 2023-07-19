using UnityEngine;

public interface IPlayer
{
    public Transform playerTransform { get; }

    public void Move(Vector3 dir);

    public void MoveEnd();
} 
