using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public CrossB crossB;
    public GameObject nShooter;
    public GameObject cShooter;
    public GameObject lShooter;

    public bool ifdied = false;

    public Text score;
    float time = 1;

    public float sCount = 4f;
    public Text startCount;
    
    public PlayerScript player;

    public static int BestScore=0;
    public Text status;
    public GameObject yourScore;
    public Text yScore;

    public int health = 3;

    public GameObject BGM;
    new AudioSource audio;

    AudioSource bucket;

    public bool isStarted = false;

    public bool isBubbled = false;

    private void Awake()
    {
        audio = BGM.gameObject.GetComponent<AudioSource>();
        bucket = this.gameObject.GetComponent<AudioSource>();
    }

    private void Start()
    {
        switch (DifficultyButton.difficulty)
        {
            case 1:
                nShooter.SetActive(true);
                cShooter.SetActive(false);
                lShooter.SetActive(false);
                break;
            case 2:
                nShooter.SetActive(true);
                cShooter.SetActive(true);
                lShooter.SetActive(false);
                break;
            case 3:
                crossB.spawn = 3;
                crossB.min = 0.5f;
                crossB.max = 1.5f;
                nShooter.SetActive(false);
                cShooter.SetActive(true);
                lShooter.SetActive(false);
                break;
            case 4:
                nShooter.SetActive(true);
                cShooter.SetActive(true);
                lShooter.SetActive(true);
                break;
        }

        Invoke(nameof(start), 3);
    }

    void Update()
    {
        if (Mathf.RoundToInt(sCount) >= 1)
        {
            sCount -= Time.deltaTime;
            startCount.text = sCount.ToString("0");
        }
        else
        {
            startCount.gameObject.SetActive(false);
        }

        if (isStarted)
        {
            time += Time.deltaTime;
            score.text = string.Format("{0:0000}", (int)time);
        }

        if (health <= 0)
        {
            audio.Stop();
            Invoke(nameof(Died), 1);
        }

        if (ifdied)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Time.timeScale = 1;
                SceneManager.LoadScene("Menu");
            }
        }
    }

    void Died()
    {
        Time.timeScale = 0;
        yScore.text = score.text;
        yourScore.gameObject.SetActive(true);
        status.gameObject.SetActive(true);
        if(BestScore < (int)time) BestScore = (int)time;
        ifdied = true;
    }

    void start()
    {
        isStarted = true;
    }

    public void playBucket()
    {
        bucket.Play();
    }

    public void HealthDown()
    {
        if (health > 0)
        {
            health--;

            if (health <= 0)
            {
                // player die effect
                player.OnDie();
            }
        }
    }
}
