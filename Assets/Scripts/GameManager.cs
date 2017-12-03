using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static event System.Action OnGameStarted;

    static public GameManager Instance;

    public Text timer;
    public Text score;

    public Text gameOverText;
    public GameObject gameOverBanner;
    public GameObject gameIntroBanner;

    float secondsLeft;

    public GameObject collectiblesParent;

    internal bool isGameRunning = false;
    bool isGameOver = false;

    public int maxCollectibles;

    public Color timerNormalColor, timerEndColor;


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
        maxCollectibles = collectiblesParent.GetComponentsInChildren<Collectible>().Length;
        score.text = "0/" + maxCollectibles.ToString();
        secondsLeft = GameDesign.Instance.totalTime;
        //StartCoroutine(StartGameDelayed(3f));
	}
    /*
    IEnumerator StartGameDelayed(float time)
    {
        yield return new WaitForSeconds(time);
        gameIntroBanner.SetActive(false);
        isGameRunning = true;
    }
    */

    void StartGame() {
        SoundManager.Instance.StartMusic();
        gameIntroBanner.SetActive(false);
        isGameRunning = true;
        if (OnGameStarted != null) {
            OnGameStarted();
        }
    }

    bool timerFlashing = false;

    IEnumerator FlashTimer() {
        while (isGameRunning) {
            timer.color = timerEndColor;
            yield return new WaitForSeconds(0.5f);
            timer.color = timerNormalColor;
            yield return new WaitForSeconds(0.5f);
        }
    }

	void Update() {

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }

        timer.text = (Mathf.RoundToInt(secondsLeft) / 60).ToString("00") + ":" + (Mathf.RoundToInt(secondsLeft) % 60).ToString("00");
        
        if (isGameRunning)
        {
            secondsLeft -= Time.deltaTime;
            if (secondsLeft <= 0) {
                SoundManager.Instance.OnTimesUp();
                StopGame("Out of Time!");
            }
            if (secondsLeft <= 10 && !timerFlashing) {
                timerFlashing = true;
                StartCoroutine(FlashTimer());
            }
        }
        else {
            if (Input.GetKeyUp(KeyCode.Return)) {
                StartGame();
            }
        }

        if (isGameOver)
        {
            if (Input.GetKeyUp(KeyCode.Return))
            {
                SceneManager.LoadScene("Game");
            }
        }
	}

    public void ExitMall()
    {
        SoundManager.Instance.OnWin();
        if (Player.Instance.numCollectibles == maxCollectibles)
        {
            StopGame("AMAZING!");
        }
        else if (Player.Instance.numCollectibles == 0)
        {
            StopGame("Try Again!");
        }
        else if (Player.Instance.numCollectibles <= maxCollectibles / 2)
        {
            StopGame("Not Bad!");
        }
        else if (Player.Instance.numCollectibles > maxCollectibles / 2)
        {
            StopGame("Good Job!");
        }
    }

    public void Busted()
    {
        SoundManager.Instance.OnBusted();
        StopGame("Busted!");
    }

    void StopGame(string textToShow)
    {
        StopAllCoroutines();
        timer.color = timerNormalColor;
        SoundManager.Instance.SetIsWalking(false);
        gameOverText.text = textToShow;
        gameOverBanner.SetActive(true);
        isGameRunning = false;
        isGameOver = true;
    }

    public void UpdateScore(int newScore)
    {
        score.text = newScore.ToString() + "/" + maxCollectibles.ToString();
    }
}
