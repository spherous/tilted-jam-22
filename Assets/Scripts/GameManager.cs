using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public DinoController player;
    [SerializeField] private GameObject playerPrefab;

    private void Awake()
    {
        Instance = this;
        player = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity)?.GetComponent<DinoController>();
    }

    public void EndGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }
}
