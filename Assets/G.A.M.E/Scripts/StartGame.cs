using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public string StartSceneName = "SceneName";

    public void StartGameMethod()
    {
        SceneManager.LoadScene(StartSceneName);
    }
}
