using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedButton : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            GameManager gameManager = FindAnyObjectByType<GameManager>();
            gameManager.EndGame();
        }
    }
}
