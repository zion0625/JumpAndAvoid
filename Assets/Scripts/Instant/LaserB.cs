using UnityEngine;

public class LaserB : MonoBehaviour
{
    public GameObject LB;
    public GameObject player;
    void Awake()
    {
        Invoke(nameof(Think), 11);
    }
    void Think()
    {
        Instantiate(LB, new Vector3(Random.Range(-18, 19) + player.transform.position.x, 4, 0), Quaternion.identity);
        Invoke(nameof(Think), Random.Range(10, 15));
    }
}
