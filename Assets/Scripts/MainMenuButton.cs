﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButton : MonoBehaviour
{
    [SerializeField] private Button button;
    private void Awake() => button.onClick.AddListener(RestartScene);
    private void RestartScene() => SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
}