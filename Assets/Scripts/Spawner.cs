using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] SpawnObject;
    public float SpawnRateInSeconds = 5.0f;
    public float x_min = 0;
    public float x_max = 0;
    public float y_min = 0;
    public float y_max = 0;
    public float z_min = 0;
    public float z_max = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            Instantiate(SpawnObject[Random.Range(0, SpawnObject.Length)], 
                        new Vector3(Random.Range(x_min, x_max),
                                    Random.Range(y_min, y_max), 
                                    Random.Range(z_min, z_max)), 
                        Quaternion.identity);
            yield return new WaitForSeconds(SpawnRateInSeconds);
        }
    }
}
