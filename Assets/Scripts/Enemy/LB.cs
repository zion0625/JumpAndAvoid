using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LB : MonoBehaviour
{
    GameObject gameManager;
    GameObject player;
    SpriteRenderer spriteRenderer;
    BoxCollider2D boxCol;
    Vector3 dir;
    float time = 0;

    void Awake()
    {
        gameManager = GameObject.Find("GameManager");

        player = GameObject.Find("Player");

        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCol = GetComponent<BoxCollider2D>();

        dir = player.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    void Update()
    {
        time += Time.deltaTime;
        if (time > 1.5)
        {
            boxCol.isTrigger = false;
            spriteRenderer.color = new Color(1, 1, 1, 1);
        }
        if(time > 5) Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.GetComponent<GameManager>().health = 0;
            gameManager.GetComponent<GameManager>().player.OnDie();
        }
    }
}
