using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 20f;
    [SerializeField] private float lifeTime = 2f;
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

    public void Fire() => fire = true;
}
