using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    UIManager ui => UIManager.Instance;
    public DinoController player;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject bossPrefab;
    private bool bossSpawned = false;
    [SerializeField] private float bossSpawnDelay = 60f;
    private float bossSpawnTime = 0;
    [SerializeField] private GameObject endGameTimerPrefab;

    private void Awake()
    {
        Instance = this;
        player = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity)?.GetComponent<DinoController>();
    }

    private void Start()
    {
        Time.timeScale = 1;
        bossSpawnTime = Time.timeSinceLevelLoad + bossSpawnDelay;
    }

    private void Update()
    {
        if(!bossSpawned)
        {
            if(Time.timeSinceLevelLoad >= bossSpawnTime)
            {
                Instantiate(bossPrefab, new Vector3(0,5,0), Quaternion.identity);
                bossSpawned = true;
            }
        }
    }

    public void EndGame()
    {
        Time.timeScale = 0;
        ui?.EndGame();
    }

    public void EndAfterTime()
    {
        Instantiate(endGameTimerPrefab);
    }
}
