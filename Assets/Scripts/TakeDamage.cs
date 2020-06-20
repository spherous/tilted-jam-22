using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour, IDamagable
{
    public int HitPoints = 2;

    void IDamagable.TakeDamage(int amount)
    {
        HitPoints--;
        if (HitPoints <= 0) Destroy(this);
    }
}
