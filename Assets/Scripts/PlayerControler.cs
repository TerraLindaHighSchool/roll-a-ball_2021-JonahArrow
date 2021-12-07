using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    private Rigidbody rb;
<<<<<<< HEAD
    private float movementX;
    private float movementY;
    private bool isOnGround = false;
    [SerializeField] private float jumpForce = 400;
=======
>>>>>>> 0504f153e8ace0c3c07bb9d158c377c358b659e5

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

<<<<<<< HEAD
    private void Update()
    {
        
    }

    private void OnMove(InputValue movementValue)
=======
    private void OnAnimatorMove(InputValue movementValue)
>>>>>>> 0504f153e8ace0c3c07bb9d158c377c358b659e5
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Jumpable"))
        {
            isOnGround = true;
        }
    }

    private void OnJump()
    {
        if(isOnGround)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0));
            isOnGround = false;
        }
    }
}
