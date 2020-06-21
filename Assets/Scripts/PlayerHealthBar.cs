using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    GameManager gm => GameManager.Instance;
    [SerializeField] public Image bar;
    void Start()
    {
        gm.player.onHealthChanged += UpdateBar;
    }

    private void UpdateBar(int newHealth)
    {
        bar.fillAmount = (float)newHealth / (float)gm.player.MaxHealth;
    }
}
