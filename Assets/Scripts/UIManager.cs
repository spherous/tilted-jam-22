using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] private GameObject endGameScreen;
    private void Awake() 
    {
        Instance = this;
        endGameScreen.SetActive(false);
    }

    public void EndGame()
    {
        endGameScreen.SetActive(true);
    }
}
