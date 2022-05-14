using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance = null;
    public Text scoreText;
    public Text bestScoreText;
    public Text bestText;
    public Text CurrentScoreText;
    public Text CurrentScore;
    public Button playButton;
    public GameObject gameOverText;
    public bool gameOver = false;
    private int score = 0;
    private AudioSource source;
    public AudioClip point;

    public float speedLeft = 2f;
    public bool isGameStarted;

    private void Awake()
    {
        Instance = this;
        Screen.SetResolution(1080, 1920, false);
    }
    // Use this for initialization

    void Start()
    {
        source = GetComponent<AudioSource>();
        isGameStarted = false;
        bestScoreText.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
    }

    public void Play()
    {
        isGameStarted = true;
        playButton.gameObject.SetActive(false);
        PlayerMovement.Instance.rb.isKinematic = false;
        scoreText.gameObject.SetActive(true);
    }

    public void BirdScore()
    {
        if (gameOver)
        {
            return;
        }
        score++;
        scoreText.text = score.ToString();
        source.PlayOneShot(point, 1f);
    }
    public void BirdDied()
    {
        CurrentScore.text = score.ToString();
        int bestScore = PlayerPrefs.GetInt("BestScore", 0);
        if (score > bestScore)
        {
            PlayerPrefs.SetInt("BestScore", score);
        }
        bestScoreText.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
        //gameOverText.SetActive(true);
        //scoreText.gameObject.SetActive(false);
        gameOver = true;
        StartCoroutine("WaitToGameOverMenu");
    }


    public void Retry()
    {
        SceneManager.LoadScene(0);
    }
    IEnumerator WaitToGameOverMenu()
    {
        yield return new WaitForSeconds(1);
        gameOverText.SetActive(true);
        scoreText.gameObject.SetActive(false);

    }
}
