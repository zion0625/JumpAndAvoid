using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalB : MonoBehaviour
{
    public GameObject LNB;
    public GameObject RNB;
    int spawnPos;
    public GameObject player;
    // Start is called before the first frame update
    void Awake()
    {
        Invoke(nameof(Think), 3.5f);
    }
    void Think()
    {
        spawnPos = Random.Range(1, 3);
        switch (spawnPos)
        {
            case 1:
                Instantiate(LNB, new Vector3(-18 + player.transform.position.x, Random.Range(-1f, 2.6f), 0), Quaternion.identity);
                break;
            case 2:
                Instantiate(RNB, new Vector3(18 + player.transform.position.x, Random.Range(-1f, 2.6f), 0), Quaternion.identity);
                break;
        }
        Invoke(nameof(Think), Random.Range(1.2f, 4));
    }
}
