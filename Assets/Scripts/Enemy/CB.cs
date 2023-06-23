using UnityEngine;

public class CB : MonoBehaviour
{
    GameObject player;
    public float speed=10;
    Vector3 dir;
    
    void Awake()
    {
        player = GameObject.Find("Player");

        dir = player.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime, Space.Self);

        if(transform.position.y < -5)
        {
            Destroy(gameObject);
        }
    }
}
