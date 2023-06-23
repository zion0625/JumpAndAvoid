using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{ 
    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void Play()
    {
        SceneManager.LoadScene("Difficulty");
    }
}
