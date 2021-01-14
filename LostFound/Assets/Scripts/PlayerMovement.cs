using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    public float groundLength;

    private float move;

    private Vector3 startScale;

    public LayerMask groundLayer;

    private Rigidbody2D rb;

    [SerializeField] private bool isGrounded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startScale = transform.localScale;
    }

    void Update()
    {
        move = Input.GetAxis("Horizontal");
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundLength, groundLayer);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }

        Move();
        Flip();

    }

    void Flip() 
    {
        if (move < 0)
        {
            transform.localScale = new Vector3(-startScale.x, startScale.y, startScale.z);
        }
        else if (move > 0)
        {
            transform.localScale = startScale;
        }
    }
    
    void Move()
    {
        transform.position += new Vector3(move, 0f, 0f) * (Time.deltaTime * speed);
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundLength);
    }
}
