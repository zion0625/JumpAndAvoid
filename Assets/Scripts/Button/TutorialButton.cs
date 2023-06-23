using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialButton : MonoBehaviour
{
    int page = 0;

    public GameObject lArrow;
    public GameObject rArrow;
    public GameObject page1;
    public GameObject page2;
    public GameObject page3;

    private void FixedUpdate()
    {
        switch (page)
        {
            case 0:
                page1.gameObject.SetActive(true);
                page2.gameObject.SetActive(false);
                page3.gameObject.SetActive(false);
                lArrow.gameObject.SetActive(false);
                break;
            case 1:
                page1.gameObject.SetActive(false);
                page2.gameObject.SetActive(true);
                page3.gameObject.SetActive(false);
                lArrow.gameObject.SetActive(true);
                rArrow.gameObject.SetActive(true);
                break;
            case 2:
                page1.gameObject.SetActive(false);
                page2.gameObject.SetActive(false);
                page3.gameObject.SetActive(true);
                rArrow.gameObject.SetActive(false);
                break;
        }
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Game()
    {
        SceneManager.LoadScene("Game");
    }

    public void prevPage()
    {
        if (page != 0) page--;
    }
    public void nextPage()
    {
        if (page != 2) page++;
    }
}
