using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CountDown : MonoBehaviour
{
    public TextMeshProUGUI CountDownText;
    public string NextScene;
    public int CountStart = 10;
    private int CountDownInt;

    // Start is called before the first frame update
    void Start()
    {
        CountDownInt = CountStart;
        StartCoroutine(CountDownThread());
    }

    private IEnumerator CountDownThread()
    {
        while(CountDownInt >= 0)
        {
            CountDownText.text = CountDownInt.ToString();
            yield return new WaitForSeconds(1f);
            CountDownInt--;
            // beep here
        }
        SceneManager.LoadScene(NextScene);
    }

}
