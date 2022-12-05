using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMover : MonoBehaviour
{
    private PlayerInputActions _input;
    public int playerSpeed;
    public MeshRenderer meshRenderer;
    public bool _isDriving;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        _input = new PlayerInputActions();
        _input.Player.Enable();

        _input.Player.ChangeCubeColor.performed += ChangeCubeColor_performed;

        _input.Driving.SwitchToPlayer.performed += SwitchToPlayer_performed;
        _input.Player.SwitchToDriving.performed += SwitchToDriving_performed;
    }

    private void SwitchToPlayer_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        EnableDriving();
    }

    private void ChangeCubeColor_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        meshRenderer.material.color = Random.ColorHSV();
    }

    private void SwitchToDriving_performed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        EnableDriving();
    }
    private void Update()
    {
        if (_isDriving)
            DriveCar();
    }
    void DriveCar()
    {
        Vector2 move = _input.Driving.DrivingCar.ReadValue<Vector2>();
        transform.Translate(new Vector3(move.x, 0, move.y) * Time.deltaTime);
    }

    void EnableDriving()
    {
        _isDriving = !_isDriving;
        if (_isDriving)
        {
            _input.Player.Disable();
            _input.Driving.Enable();            
        }
        else
        {
            _input.Player.Enable();
            _input.Driving.Disable();
        }
        Debug.Log("Player: " + _input.Player.enabled + " Driving: " + _input.Driving.enabled);

    }
    
}
