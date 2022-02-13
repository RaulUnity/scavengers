using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXScript : MonoBehaviour
{
    PlayerHealth playerHealthScript;
    public AudioClip alternateClip;

    private void Start()
    {
        playerHealthScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    public void PlaySoundFXOnPlayer(AudioClip clip)
    {
        if (playerHealthScript.GetDamage)
        {
            GetComponent<AudioSource>().PlayOneShot(clip);
        }
        else
        {
            GetComponent<AudioSource>().PlayOneShot(alternateClip);
        }
    }

    public void PlaySoundFXOnEnemies(AudioClip clip)
    {
        if (transform.position.y >= 3.4)
        {
            GetComponent<AudioSource>().Stop();
        }
        else
        {
            GetComponent<AudioSource>().PlayOneShot(clip);
        }

    }
}
