using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject cubeprefab;
    public GameObject sphereprefab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Random.Range(0,100) < 10)
            Instantiate(cubeprefab, this.transform.position, Quaternion.identity);
        if (Random.Range(0, 100) < 10)
            Instantiate(sphereprefab, this.transform.position, Quaternion.identity);
    }
}
