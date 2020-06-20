using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 5f;
    private Vector2 moveInput;

    void Start()
    {
        if(rb == null)
            rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb.velocity = moveInput * speed;
    }
}