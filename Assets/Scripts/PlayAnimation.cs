using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite[] spriteFrames;
    [SerializeField] private float timeBetweenFrames;
    private float nextUpdateTime = 0;
    private int index;

    private void Start()
    {
        nextUpdateTime = Time.timeSinceLevelLoad + timeBetweenFrames;    
    }
    private void Update()
    {
        if(Time.timeSinceLevelLoad >= nextUpdateTime)
        {
            index = index + 1 >= spriteFrames.Length -1 
                ? 0 : index + 1;
            spriteRenderer.sprite = spriteFrames[index];
        }
    }
}
