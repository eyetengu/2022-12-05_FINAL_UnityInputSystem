using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Player : MonoBehaviour
{
    [SerializeField] private Player _player;
    private GameInputs _input;

    void Start()
    {
        InitializeInputs();
    }
    void InitializeInputs()
    {
        _input = new GameInputs();
        _input.Player.Enable();

        _input.Player.FireProjectile.performed += FireProjectile_performed;
    }

    private void FireProjectile_performed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        _player.FireProjectile();
    }

    void Update()
    {
        var move = _input.Player.Movement.ReadValue<Vector2>();
        //Debug.Log(move);
        _player.MovePlayer(move);
    }

}
