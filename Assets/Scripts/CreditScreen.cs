using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreditScreen : MonoBehaviour
{
    [SerializeField] private Button menuButton;

    private void Awake() {
        menuButton.onClick.AddListener(StartGame);
    }

    private void StartGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
