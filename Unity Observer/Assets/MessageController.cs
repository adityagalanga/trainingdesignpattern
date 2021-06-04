using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MessageController : MonoBehaviour
{
    Text message;

    private void Start()
    {
        message = this.GetComponent<Text>();
        message.enabled = false;
    }

    
    public void SetMessage(GameObject go)
    {
        message.text = "You Picked up an Item !!!";
        message.enabled = true;
        Invoke("TurnOff", 2);

    }
    void TurnOff()
    {
        message.enabled = false;
    }
}
