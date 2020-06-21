using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] private GameObject WinScreen;
    [SerializeField] private GameObject LoseScreen;
    private void Awake() 
    {
        Instance = this;
        LoseScreen.SetActive(false);
        WinScreen.SetActive(false);
    }

    public void EndGame(bool isWin = false)
    {
        if(isWin)
            WinScreen.SetActive(true);
        else
            LoseScreen.SetActive(true);
    }
}
