using UnityEngine;

public class CrossB : MonoBehaviour
{
    public float min=10, max=15, spawn = 10;
    public GameObject CB;
    public GameObject player;
    void Awake()
    {
        Invoke(nameof(Think), spawn);
    }
    void Think()
    {
        Instantiate(CB, new Vector3(Random.Range(-18, 19) + player.transform.position.x, 4, 0), Quaternion.identity);
        Invoke(nameof(Think), Random.Range(min, max));
    }
}
