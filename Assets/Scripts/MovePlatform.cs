using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public GameObject player;

    void FixedUpdate()
    {
        if (transform.position.x < -10.6f + player.transform.position.x)
        {
            R_Reposition();
        }
        else if (transform.position.x > 10.6f + player.transform.position.x)
        {
            L_Reposition();
        }
    }

    void R_Reposition()
    {
        transform.position = new Vector2(10.6f + player.transform.position.x, Random.Range(-2f, 0));
    }
    void L_Reposition()
    {
        transform.position = new Vector2(-10.6f + player.transform.position.x, Random.Range(-2f, 0));
    }
}
