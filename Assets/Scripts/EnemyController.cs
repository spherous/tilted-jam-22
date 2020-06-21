using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IDamagable, IHealth
{
    GameManager gm => GameManager.Instance;
    [SerializeField] private float speed;
    private float strafeDirection = 1;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Collider2D cl;
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float timeBetweenAttacks;
    private float nextAttackTime = 0;
    [SerializeField] private int maxHealth;
    private int currentHealth;
    public int MaxHealth {get {return maxHealth;} set{}}
    public int CurrentHealth {get{return currentHealth;} set{}}
    
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip hitSound;

    [SerializeField] private bool isBoss = false;

    private void Start()
    {
        if(cl == null)
            cl = GetComponent<Collider2D>();
        if(rb == null)
            rb = GetComponent<Rigidbody2D>();

        FullHeal();
        nextAttackTime = Time.timeSinceLevelLoad + timeBetweenAttacks;
    }

    private void Update()
    {
        if(gm.player == null)
            return;
            
        if(Time.timeSinceLevelLoad >= nextAttackTime)
        {
            Shoot();
            nextAttackTime = Time.timeSinceLevelLoad + timeBetweenAttacks;
        }

        transform.up = -(gm.player.transform.position - transform.position).normalized;
    }
    private void LateUpdate() => Move();

    private void Move()
    {
        rb.velocity = -transform.right * strafeDirection * speed;
    }

    private void Shoot()
    {
        GameObject newGO = Instantiate(laserPrefab, firePoint.position, firePoint.rotation);
        Physics2D.IgnoreCollision(cl, newGO.GetComponent<Collider2D>());
        Laser laser = newGO?.GetComponent<Laser>();
        if(laser != null)
        {
            laser.SlowDown(.45f);
            laser.Fire(transform.localScale.x);
        }
    }

    public void TakeDamage(int amount) => LoseHealth(amount);
    public void LoseHealth(int amount)
    {
        currentHealth = Mathf.Max(0, CurrentHealth - amount);
        if(CurrentHealth == 0)
        {
            Die();
            return;
        }
        audioSource.PlayOneShot(hitSound);
    }

    public void GainHealth(int amount) => currentHealth = Mathf.Min(MaxHealth, CurrentHealth + amount);
    public void FullHeal() => currentHealth = MaxHealth;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.GetComponent<Laser>() == null)
            strafeDirection *= -1;
    }

    private void Die()
    {
        if(isBoss)
            gm.EndAfterTime(true);
        GameObject explosionGO = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Debug.Log("Created explosion " + explosionGO.name);
        Destroy(explosionGO, 1.0f);
        Destroy(this.gameObject, 0f);
    }
}