using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    public Text BestScore;

    public Text diff;

    int page = 0;
    public static int difficulty;

    public GameObject lArrow;
    public GameObject rArrow;

    public GameObject[] ui;

    private void Start()
    {
        UI();
        BestScore.text = string.Format("{0:0000}", GameManager.BestScore);
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    public void Show()
    {
        ui[page].SetActive(true);
        if(page == 0) ui[page + 1].SetActive(false);
        else if(page == 3) ui[page - 1].SetActive(false);
        else
        {
            ui[page - 1].SetActive(false);
            ui[page + 1].SetActive(false);
        }

    }

    public void UI()
    {
        switch (page)
        {
            case 0:
                diff.color = Color.cyan;
                diff.text = "easy";
                difficulty = 1;
                lArrow.gameObject.SetActive(false);
                Show();
                break;
            case 1:
                diff.color = Color.green;
                diff.text = "normal";
                difficulty = 2;
                lArrow.gameObject.SetActive(true);
                Show();
                break;
            case 2:
                diff.color = Color.yellow;
                diff.text = "hard";
                difficulty = 3;
                rArrow.gameObject.SetActive(true);
                Show();
                break;
            case 3:
                diff.color = Color.red;
                diff.text = "hell";
                difficulty = 4;
                rArrow.gameObject.SetActive(false);
                Show();
                break;
        }
    }

    public void prevPage()
    {
        if (page != 0) page--;
        UI();
    }
    public void nextPage()
    {
        if (page != 3) page++;
        UI();
    }
}