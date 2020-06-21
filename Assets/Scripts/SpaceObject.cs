using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceObject : MonoBehaviour, IDamagable, IHealth {

    public int MaxHealth {get; set;}
    public int CurrentHealth {get; set;}

    [SerializeField] int StartingHealth = 5;
    [SerializeField] GameObject explosion;

    private void Awake() {
        MaxHealth = CurrentHealth = StartingHealth;
        if (!explosion) {
            Debug.Log("Missing explosion asset on " + gameObject.name);
        }
    }



    public void LoseHealth(int amount) {
        CurrentHealth = Mathf.Clamp(CurrentHealth - amount, 0, MaxHealth);
        if (CurrentHealth <= 0) {
            Die();
        }
    }

    public void GainHealth(int amount) {
        CurrentHealth = Mathf.Clamp(CurrentHealth + amount, 0, MaxHealth);
    }

    public void FullHeal() {
        CurrentHealth = MaxHealth;
    }

    public void TakeDamage(int damage) {
        CurrentHealth = Mathf.Clamp(CurrentHealth - damage, 0, MaxHealth);
        if (CurrentHealth <= 0) {
            Die();
        }
    }

    private void Die() {
        GameObject explosionGO = Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(explosionGO, 1.0f);
        Destroy(this.gameObject, 0f);
    }

}