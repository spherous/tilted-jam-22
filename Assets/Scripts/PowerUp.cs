using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    public enum Type { Shield, Speed, Heal, Weapon1, Weapon2, Weapon3 };

    [SerializeField] Type type;
    private int healthGainAmt = 5;


    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player") {
            DinoController dinoController = other.gameObject.GetComponent<DinoController>();
            switch (type) {
                case Type.Heal:
                    dinoController.GainHealth(healthGainAmt);
                    break;
                default:
                    break;
            }
        }
    }
}