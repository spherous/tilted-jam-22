using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IDamagable, IHealth
{
    GameManager gm => GameManager.Instance;
    [SerializeField] private Collider2D cl;
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float timeBetweenAttacks;
    private float nextAttackTime = 0;
    [SerializeField] private int maxHealth;
    private int currentHealth;
    public int MaxHealth {get {return maxHealth;} set{}}
    public int CurrentHealth {get{return currentHealth;} set{}}

    private void Start()
    {
        if(cl == null)
            cl = GetComponent<Collider2D>();

        FullHeal();
    }

    private void Update()
    {
        if(Time.timeSinceLevelLoad >= nextAttackTime)
        {
            Shoot();
            nextAttackTime = Time.timeSinceLevelLoad + timeBetweenAttacks;
        }

        transform.up = -(gm.player.transform.position - transform.position).normalized;
    }

    private void Shoot()
    {
        GameObject newGO = Instantiate(laserPrefab, firePoint.position, firePoint.rotation);
        Physics2D.IgnoreCollision(cl, newGO.GetComponent<Collider2D>());
        Laser laser = newGO?.GetComponent<Laser>();
        if(laser != null)
        {
            laser.SlowDown(.45f);
            laser.Fire();
        }
    }

    public void TakeDamage(int amount) => LoseHealth(amount);
    public void LoseHealth(int amount)
    {
        currentHealth = Mathf.Max(0, CurrentHealth - amount);
        if(CurrentHealth == 0)
            Destroy(gameObject);
    }

    public void GainHealth(int amount) => currentHealth = Mathf.Min(MaxHealth, CurrentHealth + amount);
    public void FullHeal() => currentHealth = MaxHealth;
}