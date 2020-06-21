using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class TitleScreen : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private Button creditsButton;
    [SerializeField] private Button emailButton;

    private void Awake() {
        startButton.onClick.AddListener(StartGame);
        quitButton.onClick.AddListener(QuitGame);
        creditsButton.onClick.AddListener(Credits);
        emailButton.onClick.AddListener(Email);
    }

    private void Email()
    {
        SceneManager.LoadScene("G.A.M.E_Register");
    }

    private void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    private void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    private void StartGame()
    {
        SceneManager.LoadScene("CountDown");
    }
}
