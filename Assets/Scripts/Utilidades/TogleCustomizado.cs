using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogleCustomizado : MonoBehaviour
{
    public GameObject obj;
    void Start()
    {
        obj.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D c)
    {
       
        if(c.gameObject.tag=="Player")
        {
             Debug.Log("g");
            obj.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D c)
    {
        if(c.gameObject.tag=="Player")
        {
            obj.SetActive(false);
        }
    }
}
