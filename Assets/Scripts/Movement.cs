using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Movement 
{
    private GameInput _gameInput;
    private GlobalModel _globalModel;

    private IPlayer _player; 

    [Inject]
    public Movement(GameInput gameInput, GlobalModel globalModel)
    {
        _gameInput = gameInput;
        _globalModel = globalModel;

        _gameInput.OnMove += OnMove;
        _gameInput.OnMoveEnd += OnMoveEnd;
    }   

    public void Init(IPlayer player)
    {
        _player = player;
    }

    private void OnMove(GameInput.MovementVectorEventArgs obj)
    {
        var dir = new Vector3 (obj.movementVector.x*0.01f * _globalModel.MoveSpeed, obj.movementVector.y * 0.01f * _globalModel.MoveSpeed, 0F);

        _player.Move(dir);
    }

    private void OnMoveEnd()
    {
        _player.MoveEnd();
    }
}
