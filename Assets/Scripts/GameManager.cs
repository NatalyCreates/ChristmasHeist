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

    float secondsLeft;

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
        secondsLeft = GameDesign.Instance.totalTime;
        StartCoroutine(StartGameDelayed(2f));
	}
    IEnumerator StartGameDelayed(float time)
    {
        yield return new WaitForSeconds(time);
        isGameRunning = true;
    }
	
	void Update() {
        timer.text = (Mathf.RoundToInt(secondsLeft) / 60).ToString("00") + ":" + (Mathf.RoundToInt(secondsLeft) % 60).ToString("00");
        if (isGameRunning)
        {
            secondsLeft -= Time.deltaTime;
        }
        if (secondsLeft <= 0)
        {
            if (Player.Instance.transform.position.z >= 40)
            {
                SoundManager.Instance.OnWin();
                StopGame("You did it!");
            }
            else
            {
                SoundManager.Instance.OnTimesUp();
                StopGame("Out of Time!");
            }
        }

        if (isGameOver)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                SceneManager.LoadScene("Game");
            }
        }
	}

    public void Busted()
    {
        SoundManager.Instance.OnBusted();
        StopGame("Busted!");
    }

    void StopGame(string textToShow)
    {
        gameOverText.text = textToShow;
        gameOverBanner.SetActive(true);
        isGameRunning = false;
        isGameOver = true;
    }

    public void UpdateScore(int newScore)
    {
        score.text = newScore.ToString();
    }
}
