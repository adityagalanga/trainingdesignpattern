using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject asteroid;

    private void Update()
    {
        if (Random.Range(0,100) < 1)
        {
            GameObject a = Pool.singleton.Get("Asteroid");
            if(a != null)
            {
                a.transform.position = this.transform.position + new Vector3(Random.Range(-10, 10), 0, 0);
                a.SetActive(true);
            }
        }
    }
}
