using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    static public SoundManager Instance;

    public AudioSource music;
    public AudioSource walkingSfx;
    public AudioSource otherSfx;

    public AudioClip lose, win, pickup, part1, part2loop;

    bool isWalkingSoundPlaying = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("More than 1 SoundManager in the scene!");
            Destroy(this);
        }
    }

    public void StartMusic() {
        StartCoroutine(PlayMusic());
    }

    IEnumerator PlayMusic()
    {
        music.clip = part1;
        music.Play();
        music.loop = false;
        yield return new WaitForSeconds(part1.length);
        music.clip = part2loop;
        music.Play();
        music.loop = true;
    }

    public void OnBusted()
    {
        otherSfx.PlayOneShot(lose);
        music.Stop();
    }

    public void OnWin()
    {
        otherSfx.PlayOneShot(win);
        music.Stop();
    }

    public void OnTimesUp()
    {
        otherSfx.PlayOneShot(lose);
        music.Stop();
    }

    public void OnPickup()
    {
        otherSfx.PlayOneShot(pickup);
    }

    public void SetIsWalking(bool isWalking)
    {
        if (isWalking && !isWalkingSoundPlaying)
        {
            float maxVolume = 1f;
            float minVolume = 0.3f;
            float percent = Player.Instance.numCollectibles * 1.0f / (GameManager.Instance.maxCollectibles / 2);
            float volume = Mathf.Clamp(minVolume + 0.7f * percent, minVolume, maxVolume);
            walkingSfx.volume = volume;
            isWalkingSoundPlaying = true;
            walkingSfx.Play();
        }
        else if (!isWalking && isWalkingSoundPlaying)
        {
            isWalkingSoundPlaying = false;
            walkingSfx.Stop();
        }
    }
}
