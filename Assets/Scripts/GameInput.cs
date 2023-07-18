using System;
using UnityEngine;

public sealed class GameInput 
{
    public PlayerInputActions _inputActions;

    public event Action<MovementVectorEventArgs> OnMove;
    public event Action OnMoveEnd;
    public class MovementVectorEventArgs : EventArgs
    {
        public Vector2 movementVector;
    }

    public GameInput()
    {
        _inputActions = new PlayerInputActions();
        _inputActions.Player.Enable();
        _inputActions.Player.Move.performed += Move_performed;
        _inputActions.Player.Move.canceled += Move_canceled;
    }

    private void Move_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnMoveEnd?.Invoke();
    }

    private void Move_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Vector2 movementVector = GetMovementVectorNormalized();
        OnMove?.Invoke(new MovementVectorEventArgs { movementVector = movementVector });
    }      

    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = _inputActions.Player.Move.ReadValue<Vector2>();

        inputVector = inputVector.normalized;

        return inputVector;
    }
}
