using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundScript : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip song;
    public AudioClip songMenu;
    public AudioClip victoryClip1;
    public AudioClip victoryClip2;
    public AudioClip deathClip;
    public bool play;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Level Loaded");
        Debug.Log(scene.name);
        Debug.Log(mode);

        //PlayMusic(play, scene);
        ChangeSongMenu(scene);
    }

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void ChangeSongMenu(Scene scene)
    {
        if (scene.name == "Round1")
        {
            audioSource.Stop();
            audioSource.loop = true;
            audioSource.clip = song;
            audioSource.Play();
        }
        else if(scene.name == "MainMenu" && audioSource.clip != songMenu)
        {
            audioSource.Stop();
            audioSource.loop = true;
            audioSource.clip = songMenu;
            audioSource.Play();
        }
        else if (scene.name == "Victory")
        {
            StartCoroutine(victoryClipAudio());
        }
        else if (scene.name == "Death")
        {
            audioSource.Stop();
            audioSource.clip = deathClip;
            audioSource.loop = false;
            audioSource.Play();
        }
    }

    IEnumerator victoryClipAudio()
    {
        audioSource.Stop();
        audioSource.clip = victoryClip1;
        audioSource.loop = false;
        audioSource.Play();
        yield return new WaitForSeconds(victoryClip1.length);
        audioSource.Stop();
        audioSource.clip = victoryClip2;
        audioSource.Play();
        yield break;
    }
}
