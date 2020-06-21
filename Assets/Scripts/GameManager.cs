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
    [SerializeField] private AudioSource audioSource;

    private void Awake()
    {
        Instance = this;
        player = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity)?.GetComponent<DinoController>();
    }

    private void Start()
    {
        Time.timeScale = 1;
    }

    public void EndGame()
    {
        Time.timeScale = 0;
        ui.EndGame();
    }
}
