using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    static public GameManager Instance;

    public Text timer;
    public Text score;

    public Text gameOverText;
    public GameObject gameOverBanner;

    float secondsLeft = 30;

    internal bool isGameRunning = false;
    bool isGameOver = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("More than 1 GameManager in the scene!");
            Destroy(this);
        }
    }

	void Start() {
        score.text = "0";
        timer.text = "00:00";
        StartCoroutine(StartGameDelayed(2f));
	}
    IEnumerator StartGameDelayed(float time)
    {
        yield return new WaitForSeconds(time);
        isGameRunning = true;
    }
	
	void Update() {
        timer.text = (Mathf.RoundToInt(secondsLeft) / 60).ToString("N0") + ":" + (Mathf.RoundToInt(secondsLeft) % 60).ToString("N0");
        if (isGameRunning)
        {
            secondsLeft -= Time.deltaTime;
        }
        if (secondsLeft <= 0)
        {
            isGameRunning = false;
            gameOverText.text = "Out of Time!";
            gameOverBanner.SetActive(true);
            isGameOver = true;
        }

        if (isGameOver)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                SceneManager.LoadScene("Game");
            }
        }
	}

    public void OnExitMall()
    {
        isGameRunning = false;
        gameOverText.text = "Merry Christmas!";
        gameOverBanner.SetActive(true);
        isGameOver = true;
    }

    public void OnGuardCaught()
    {
        isGameRunning = false;
        gameOverText.text = "Busted!";
        gameOverBanner.SetActive(true);
        isGameOver = true;
    }

    public void UpdateScore(int newScore)
    {
        score.text = newScore.ToString();
    }
}
