using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameAfterTime : MonoBehaviour
{
    GameManager gm => GameManager.Instance;

    [SerializeField] private float timeToWait;
    private float timeToEnd;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip deathSound;

    private void Start()
    {
        timeToEnd = Time.timeSinceLevelLoad + timeToWait;    
        audioSource?.PlayOneShot(deathSound);
    }
    private void Update()
    {
        if(Time.timeSinceLevelLoad >= timeToEnd)
            gm.EndGame();
    }
}