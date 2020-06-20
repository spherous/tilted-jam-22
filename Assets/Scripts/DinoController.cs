using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Collider2D collider;
    [SerializeField] private Transform firePointLeft;
    [SerializeField] private Transform firePointRight;
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float rotateSpeed = 5f;
    [SerializeField] private float timeBetweenAttacks = 0.2f;
    private float nextAttackTime = 0;
    private Vector2 moveInput;
    private float rotateInput;
    private bool shootInput;
    private bool firePointToggle = false;

    void Start()
    {
        if(rb == null)
            rb = GetComponent<Rigidbody2D>();
        if(collider == null)
            collider = GetComponent<Collider2D>();
    }

    void Update()
    {
        moveInput = transform.up * Input.GetAxis("Vertical");
        rotateInput = -Input.GetAxis("Horizontal");
        shootInput = Input.GetKey(KeyCode.Space);

        if(shootInput)
            Shoot();
    }

    private void Shoot()
    {
        if(Time.timeSinceLevelLoad >= nextAttackTime)
        {
            GameObject newGO = firePointToggle
                ? Instantiate(laserPrefab, firePointLeft.position, firePointLeft.rotation)
                : Instantiate(laserPrefab, firePointRight.position, firePointRight.rotation);
            
            Physics2D.IgnoreCollision(collider, newGO.GetComponent<Collider2D>());

            newGO?.GetComponent<Laser>()?.Fire();

            firePointToggle = !firePointToggle;
            nextAttackTime = Time.timeSinceLevelLoad + timeBetweenAttacks;
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb.velocity = moveInput * speed;
        rb.angularVelocity = rotateInput * rotateSpeed;
    }
}