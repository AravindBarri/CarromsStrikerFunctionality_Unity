using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holes : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BluePuck")
        {
            collision.gameObject.SetActive(false);
            ScoreManager.scoreInstance.BluePuckUpdate();
        }
        else if (collision.gameObject.tag == "RedPuck")
        {
            collision.gameObject.SetActive(false);
            ScoreManager.scoreInstance.RedPuckUpdate();
        }
    }
}
