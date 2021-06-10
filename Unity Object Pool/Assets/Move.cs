using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Vector3 velocity;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Asteroid")
        {
            this.gameObject.SetActive(false);
        }
    }


    public void Update()
    {
        this.transform.Translate(velocity);
    }
}
