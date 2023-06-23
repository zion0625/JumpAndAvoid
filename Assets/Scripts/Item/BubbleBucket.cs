using UnityEngine;

public class BubbleBucket : MonoBehaviour
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
            gameManager.GetComponent<GameManager>().playBucket();
            Destroy(gameObject);
            gameManager.GetComponent<GameManager>().isBubbled = true;   
        }
    }
}
