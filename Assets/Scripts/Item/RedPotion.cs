using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPotion : MonoBehaviour
{
    GameObject gameManager;
    private void Awake()
    {
        gameManager = GameObject.Find("GameManager");
    }
    private void Update()
    {
        if (transform.position.y < -3.5) Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (gameManager.GetComponent<GameManager>().health < 3)
            {
                gameManager.GetComponent<GameManager>().health += 1;
            }
            Destroy(gameObject);
        }
    }
}
