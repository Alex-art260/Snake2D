using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColWithBody : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Body")
        {
            Debug.Log("Body");
        }
    }
}
