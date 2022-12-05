using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Manager_Input : MonoSingleton<Manager_Input>
{
    /// <summary>
    /// This class is dedicated to taking inputs in, reading inputs, enable/disable action maps and running functions
    /// Player
    /// Interact With Laptop
    /// </summary>

    //SUBSCRIPTIONS
    //-------------
    //INTERACT KEY
    //basic interaction
    public delegate void EnvironmentalInteraction();
    public static event EnvironmentalInteraction interactWithEnvironment;
    //hold interaction
    public delegate void PressHoldFalseState();
    public static event PressHoldFalseState pressHoldFalseState;
    //---

    //DRONE
    //drone tilt
    public delegate void DroneTilt();
    public static event DroneTilt droneTilt;
    //drone altitude
    public delegate void DroneAltitude();
    public static event DroneAltitude droneAltitude;
    //drone rotate
    public delegate void DroneRotation();
    public static event DroneRotation droneRotation;
    //drone exit
    public delegate void ExitDroneMode();
    public static event ExitDroneMode exitDroneMode;

    //---

    //FORKLIFT



    //ACTION MAPS
    private FINAL_InputActions _input;       
        

    void Start()
    {
        InitializeInputs();
    }

    public void InitializeInputs()
    {
        //declare & enable Interact.Interact input
        _input = new FINAL_InputActions();
        _input.Interaction.Enable();
        _input.Drone.Enable();

        //Interactions 'E' Button
        _input.Interaction.Interact.performed += Interact_performed;
        _input.Interaction.PressHoldInteraction.performed += PressHoldInteraction_performed1;

        //Drone Input
        //_input.Drone.AscendDescend.performed += AscendDescend_performed;
        //_input.Drone.Rotate.performed += Rotate_performed;
        //_input.Drone.Tilt.performed += Tilt_performed;
    }

   

    //Press Hold 'E' Interaction
    private void PressHoldInteraction_performed1(InputAction.CallbackContext obj)
    {
        if (pressHoldFalseState != null)
            pressHoldFalseState();
    }
    
    //Universal Interaction Key (keycode E)
    private void Interact_performed(InputAction.CallbackContext context)
    {
        if (interactWithEnvironment != null)
            interactWithEnvironment();
    }

    void Update()
    {

    }
    
}
