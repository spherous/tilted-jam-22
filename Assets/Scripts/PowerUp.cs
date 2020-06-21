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
                case Type.Shield:
                    // TODO: ADD SHIELD ABILITY
                    break;
                case Type.Speed:
                    // TODO: ADD SPEED ABILITY
                    break;
                case Type.Heal:
                    dinoController.GainHealth(healthGainAmt);
                    break;
                case Type.Weapon1:
                    // TODO: ADD WEAPON 1 ABILITY
                    break;
                case Type.Weapon2:
                    // TODO: ADD WEAPON 2 ABILITY
                    break;
                case Type.Weapon3:
                    // TODO: ADD WEAPON 3 ABILITY
                    break;                                                            
                default:
                    Debug.Log("No type selected");
                    break;
            }
            Destroy(gameObject);
        }
    }
}