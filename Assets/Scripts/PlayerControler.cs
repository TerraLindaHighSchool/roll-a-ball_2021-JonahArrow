using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerControler : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public bool dead = false;
    public Vector3 position;

    GameObject Player;


    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    [SerializeField] private bool isOnGround = false;
    [SerializeField] private float jumpForce = 400;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;

        SetCountText();
        winTextObject.SetActive(false);
        gameObject.tag = "Player";
    }

    void Update()
    {
        if(dead)
        {
            gameObject.transform.position = new Vector3(0, 1, 0);
            dead = false;
        }
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count:" + count.ToString();
        if (count >= 12)
        {
            winTextObject.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;

            SetCountText();
        }
        if (other.gameObject.CompareTag("Death"))
        {
            dead = true;
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Jumpable"))
        {
            isOnGround = true;
        }
        if (other.gameObject.CompareTag("DoubleJumpable"))
        {
            isOnGround = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Jumpable"))
        {
            isOnGround = false;
        }
        if (other.gameObject.CompareTag("DoubleJumpable"))
        {
            isOnGround = false;
        }
    }

    private void OnJump()
    {
        if (isOnGround)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0));
            isOnGround = false;
        }
    }
}