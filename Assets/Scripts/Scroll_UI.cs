using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scroll_UI : MonoBehaviour
{
    public Sprite[] sprites;
    public GameObject GameObjectToAnimate;
    public float animationSpeed = 0.1f;
    private Image image;

    public void Start()
    {
        image = GameObjectToAnimate.GetComponent<Image>();
        StartCoroutine(nukeMethod());
    }

    public IEnumerator nukeMethod()
    {
        //destroy all game objects
        while (true)
        {
            for (int i = 0; i < sprites.Length; i++)
            {
                image.sprite = sprites[i];
                yield return new WaitForSeconds(animationSpeed);
            }
        }
    }
    // Update is called once per frame
    private void Update()
    {
        float speed = Input.GetAxis("Vertical");
        if ( speed > 0.5f )
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 200f * Time.deltaTime, gameObject.transform.position.z);
        }
        else if (speed < -0.5f)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 200f * Time.deltaTime, gameObject.transform.position.z);
        }

    }

    public void FollowLink(string link)
    {
        Application.OpenURL(link);
    }

    public void SceneManagerLoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
