using System;
using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float playerSpeed;
    public float turnSpeed;
    private Vector3 movement;
    private float playerY;
    private bool grounded = false;
    private float maxSpeed = 30f;
    private float sqrMaxSpeed;
    private float movementInputValue;
    private float turnInputValue;
    void Start()
    {
        playerY = transform.position.y;
        rb = GetComponent<Rigidbody>();
        maxSpeed = playerSpeed;
        SetMaxVelocity(maxSpeed);
    }

    void SetMaxVelocity(float velocity)
    {
        sqrMaxSpeed = maxSpeed * maxSpeed;
    }

    void Update()
    {
        movementInputValue = Input.GetAxis("Vertical");
        turnInputValue = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        //Move();
        Turn();
        Jump();
        //movement.x = Input.GetAxis("Horizontal");
        movement.z = Input.GetAxis("Vertical");
        //if (Input.GetKeyDown("space") && grounded)
        //{
        //    rb.AddForce(Vector3.up * 5f, ForceMode.Impulse);
        //}

        if (rb.velocity.sqrMagnitude > sqrMaxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }

        rb.AddForce(movement * playerSpeed);
    }

    void Move()
    {

        movement = transform.forward * movementInputValue * playerSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
    }

    void Turn()
    {
        float turn = turnInputValue*turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        //rb.rotation = rb.rotation*turnRotation;
        rb.transform.rotation = rb.transform.rotation * turnRotation;
        //rb.MoveRotation(rb.rotation*turnRotation);
    }

    void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            rb.AddForce(Vector3.up * 5f, ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        grounded = true;
    }

    void OnCollisionExit(Collision collision)
    {
        grounded = false;
    }
}
