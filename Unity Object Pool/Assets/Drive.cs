using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drive : MonoBehaviour
{
    public float speed = 10.0f;
    public GameObject bullet;
    public Slider healthbar;

    void Update()
    {
        float translation = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        transform.Translate(translation, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject b = Pool.singleton.Get("Bullet");
            if (b != null)
            {
                b.transform.position = this.transform.position;
                b.SetActive(true);
            }
        }

        Vector3 screenPos = Camera.main.WorldToScreenPoint(this.transform.position);
        healthbar.transform.position = screenPos;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            healthbar.value -= 10;
            if(healthbar.value <= 0)
            {
                Destroy(healthbar, 0.1f);
                Destroy(this.gameObject, 0.1f);
            }
        }
    }
}