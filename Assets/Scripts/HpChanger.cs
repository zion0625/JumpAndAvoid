using UnityEngine;
using UnityEngine.UI;

public class HpChanger : MonoBehaviour
{

    Image image;
    public Sprite[] sprites;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Awake()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        // show HP
        image.sprite = sprites[3 - gameManager.health];
    }
}
