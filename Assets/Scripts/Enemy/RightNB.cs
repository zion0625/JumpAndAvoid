using UnityEngine;

public class RightNB : MonoBehaviour
{
    public float speed = 6;
    CapsuleCollider2D col;
    GameObject player;

    private void Awake()
    {
        col = GetComponent<CapsuleCollider2D>();
        player = GameObject.Find("Player");
    }

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        if (col.bounds.center.x < -14 + player.transform.position.x)
        {
            Destroy(gameObject);
        }
    }
}
