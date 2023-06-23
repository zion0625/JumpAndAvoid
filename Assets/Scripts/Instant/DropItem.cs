using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    public GameObject bubbleBucket;
    public GameObject redPotion;
    public GameObject player;

    int itemType;
    private void Awake()
    {
        Invoke(nameof(SelectItem), 30);
    }
    void SelectItem()
    {
        itemType = Random.Range(1, 3);
        switch (itemType)
        {
            case 1:
                Instantiate(bubbleBucket, new Vector3(Random.Range(-12, 13) + player.transform.position.x, 4, 0), Quaternion.identity);
                break;
            case 2:
                Instantiate(redPotion, new Vector3(Random.Range(-12, 13) + player.transform.position.x, 4, 0), Quaternion.identity);
                break;
        }
        Invoke(nameof(SelectItem), Random.Range(20, 31));
    }
}
