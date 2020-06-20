using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IDamagable, IHealth
{
    [SerializeField] private int maxHealth;
    private int currentHealth;
    public int MaxHealth {get {return maxHealth;} set{}}
    public int CurrentHealth {get{return currentHealth;} set{}}

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