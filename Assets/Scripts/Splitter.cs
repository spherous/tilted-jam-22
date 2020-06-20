using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splitter : MonoBehaviour, IDamagable
{
    public GameObject[] whole;
    public GameObject[] halves;
    public GameObject[] quarters;


    // Start is called before the first frame update
    void Start()
    {
        Instantiate(whole[Random.Range(0,whole.Length-1)], new Vector3(0, 0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int amount)
    {
        Instantiate(halves[Random.Range(0, whole.Length - 1)], new Vector3(0, 0, 0), Quaternion.identity);
        Instantiate(halves[Random.Range(0, whole.Length - 1)], new Vector3(0, 0, 0), Quaternion.identity);
    }
}
