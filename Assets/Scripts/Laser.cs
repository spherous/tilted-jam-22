using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] clips;
    [SerializeField] private float speed = 20f;
    [SerializeField] private float lifeTime = 2f;
    [SerializeField] private int damage = 1;
    private float timeToDestroy;
    
    private bool fire = false;

    private void Start()
    {
        if(rb == null)
            rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(Time.timeSinceLevelLoad >= timeToDestroy)
            Destroy(gameObject);
    }

    private void LateUpdate() {
        if(fire)
        {
            rb.velocity = transform.up * speed;
            fire = false;
            timeToDestroy = Time.timeSinceLevelLoad + lifeTime;
        }
    }

    public void Fire() 
    {
        audioSource.PlayOneShot(clips[Random.Range(0, clips.Length - 1)]);
        fire = true;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        IDamagable damagable = other.gameObject.GetComponent<IDamagable>();
        
        if(damagable != null)
        {
            damagable.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
    public void SlowDown(float percent = 1f) => speed *= percent;

}