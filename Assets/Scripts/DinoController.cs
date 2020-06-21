using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DinoController : MonoBehaviour, IDamagable, IHealth
{
    GameManager gm => GameManager.Instance;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Collider2D cl;
    [SerializeField] private Transform firePointLeft;
    [SerializeField] private Transform firePointRight;
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float rotateSpeed = 5f;
    [SerializeField] private float timeBetweenAttacks = 0.2f;
    private float nextAttackTime = 0;
    private Vector2 moveInput;
    private float rotateInput;

    private bool shootInput => Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0);
    private bool firePointToggle = false;

    [SerializeField] private int maxHealth;
    private int currentHealth;
    public int MaxHealth {get {return maxHealth;} set{}}
    public int CurrentHealth {get{return currentHealth;} set{}}
    public delegate void OnHealthChanged(int newHealth);
    public OnHealthChanged onHealthChanged;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip deathSound;

    void Start()
    {
        if(rb == null)
            rb = GetComponent<Rigidbody2D>();
        if(cl == null)
            cl = GetComponent<Collider2D>();
        
        FullHeal();
    }

    void Update()
    {
        moveInput = (transform.up * Input.GetAxis("Vertical")) + ((-transform.right) * GetStrafeInput());
        rotateInput = -Input.GetAxis("Horizontal");

        if(shootInput)
            Shoot();

        // if(Input.GetKeyDown(KeyCode.G))
        //     FullHeal();
    }

    private void Shoot()
    {
        if(EventSystem.current.IsPointerOverGameObject())
            return;

        if(Time.timeSinceLevelLoad >= nextAttackTime)
        {
            GameObject newGO = firePointToggle
                ? Instantiate(laserPrefab, firePointLeft.position, firePointLeft.rotation)
                : Instantiate(laserPrefab, firePointRight.position, firePointRight.rotation);
            
            Physics2D.IgnoreCollision(cl, newGO.GetComponent<Collider2D>());

            newGO?.GetComponent<Laser>()?.Fire();

            firePointToggle = !firePointToggle;
            nextAttackTime = Time.timeSinceLevelLoad + timeBetweenAttacks;
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private float GetStrafeInput()
    {
        float val = 0;
        if(Input.GetKey(KeyCode.Q))
            val++;
        if(Input.GetKey(KeyCode.E))
            val--;
        return val;
    }

    private void Move()
    {
        rb.velocity = moveInput * speed;
        rb.angularVelocity = rotateInput * rotateSpeed;
    }

    public void TakeDamage(int amount) => LoseHealth(amount);
    public void LoseHealth(int amount)
    {
        currentHealth = Mathf.Max(0, CurrentHealth - amount);
        onHealthChanged.Invoke(CurrentHealth);
        if(CurrentHealth == 0)
        {
            audioSource.PlayOneShot(deathSound);
            gm.EndGame();
        }
    }

    public void GainHealth(int amount)
    {
        currentHealth = Mathf.Min(MaxHealth, CurrentHealth + amount);
        onHealthChanged.Invoke(CurrentHealth);
    }
    public void FullHeal()
    {
        currentHealth = MaxHealth;
        onHealthChanged.Invoke(CurrentHealth);
    }
}