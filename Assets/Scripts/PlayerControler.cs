using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    public float speed = 0;

    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private bool isOnGround = true;
    [SerializeField] private float jumpForce = 400;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

<<<<<<< HEAD
=======
    private void Update()
    {
        
    }

>>>>>>> parent of e5379e2 (a)
    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
<<<<<<< HEAD
=======

        rb.AddForce(movement * speed);
    }
>>>>>>> parent of e5379e2 (a)

        rb.AddForce(movement * speed);
    }

    private void OnJump()
    {
        if(isOnGround)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0));
        }
    }
}
