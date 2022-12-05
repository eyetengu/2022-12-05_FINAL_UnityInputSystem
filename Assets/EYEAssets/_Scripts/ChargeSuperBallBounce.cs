using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeSuperBallBounce : MonoBehaviour
{
    private BouncingBallInput _ballInput;
    private Rigidbody rb;
    private bool _jumped;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _ballInput = new BouncingBallInput();
        _ballInput.Ball.Enable();

        _ballInput.Ball.ChargedBounce.performed += ChargedBounce_performed;
        _ballInput.Ball.ChargedBounce.canceled += ChargedBounce_canceled;
        Debug.Log("Hello there");
    }

    private void ChargedBounce_canceled(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        var forceMultiplier = context.duration;
        GetComponent<Rigidbody>().AddForce(Vector3.up * (25 * (float)forceMultiplier), ForceMode.Impulse);
    }

    private void ChargedBounce_performed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        Debug.Log("Bounce, damn you");
        _jumped = true;
        rb.AddForce(Vector3.up * 25f, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
