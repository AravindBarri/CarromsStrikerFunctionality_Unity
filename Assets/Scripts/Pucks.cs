using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pucks : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Hole")
        {
            this.gameObject.SetActive(false);
        }
    }
}
