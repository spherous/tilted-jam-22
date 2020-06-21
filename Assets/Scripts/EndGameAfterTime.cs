using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameAfterTime : MonoBehaviour
{
    GameManager gm => GameManager.Instance;

    [SerializeField] private float timeToWait;
    private float timeToEnd;

    private void Start()
    {
        timeToEnd = Time.timeSinceLevelLoad + timeToWait;    
    }
    private void Update()
    {
        if(Time.timeSinceLevelLoad >= timeToEnd)
            gm.EndGame();
    }
}