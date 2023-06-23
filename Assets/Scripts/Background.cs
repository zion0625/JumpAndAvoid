using UnityEngine;

public class Background : MonoBehaviour
{
    public float speed = 1f;
    public float width;
    public GameObject player;
    void Awake()
    {
        BoxCollider2D backgroundCollider = GetComponent<BoxCollider2D>();
        width = backgroundCollider.size.x;
    }

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        if (transform.position.x < -20.48 + player.transform.position.x)
        {
            Reposition();
        }
    }

    void Reposition()
    {
        Vector2 offset = new Vector2(width * 2f, 0);
        transform.position = (Vector2)transform.position + offset;
    }
}
