using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    private int moveSpeed;
    private int jumpPower;
    private String groundTag = "Ground";
    private bool onGround;
    private bool inWater;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveSpeed = 3;
        jumpPower = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }

        if (Input.GetKey(KeyCode.Space) && (onGround || inWater))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals(groundTag))
        {
            onGround = true;
        }
    }
}