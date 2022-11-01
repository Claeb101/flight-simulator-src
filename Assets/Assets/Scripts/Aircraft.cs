using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aircraft : MonoBehaviour
{
    public float pitchTorque = 1f;
    public float rollTorque = 1f;
    
    public float thrust = 1.0f;
    public float drag = 0.5f;
    
    private Rigidbody _rb;
    
    [SerializeField]
    private float _rollInput, _pitchInput, _thrustInput;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _rollInput = Input.GetAxisRaw("Horizontal");
        _pitchInput = Input.GetAxisRaw("Vertical");
        _thrustInput = Input.GetAxisRaw("Jump");
    }

    private void FixedUpdate()
    {
        Debug.DrawRay(transform.position, transform.right, Color.red);
        Debug.DrawRay(transform.position, transform.forward, Color.blue);
        
        _rb.AddRelativeTorque(transform.forward*-_rollInput*rollTorque);
        _rb.AddRelativeTorque(transform.right*_pitchInput*pitchTorque);
        
        _rb.AddRelativeForce(transform.forward*_thrustInput*thrust);
        _rb.AddRelativeForce(-_rb.velocity.normalized*drag);
    }
}
