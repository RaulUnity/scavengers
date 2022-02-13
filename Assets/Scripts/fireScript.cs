using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fireScript : MonoBehaviour
{
    PlayerHealth playerHealthScript;
    AudioSource audioSourcePlayer;
    public Transform firePosition;
    public GameObject bulletPrefab;
    public GameObject rocketPrefab;
    public GameObject shieldObject;
    public float bulletForce = 5;
    public float rocketForce = 5;
    public AudioClip bulletSound;
    public AudioClip rocketSound;
    bool shieldActive = false;

    private void Start()
    {
        playerHealthScript = GetComponent<PlayerHealth>();
        audioSourcePlayer = GetComponent<AudioSource>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootBullet();
        }

        if(playerHealthScript.playerPoints >= 10 && playerHealthScript.playerPoints < 20)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                ShootRocket();
                playerHealthScript.playerPoints = 0;
            }
        }
        else if(playerHealthScript.playerPoints >= 20 && playerHealthScript.playerPoints < 30)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                ShootRocket();
                playerHealthScript.playerPoints = 10;
            }
        }
        else if(playerHealthScript.playerPoints == 30)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                ShootRocket();
                playerHealthScript.playerPoints = 20;
            }
        }
        

        if(playerHealthScript.playerShieldPoints == 20)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (!shieldActive)
                {
                    playerHealthScript.playerShieldPoints = 0;
                    activeShield();
                }
            }
        }
        /*else if (playerHealthScript.playerPoints == 30)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                if (playerHealthScript.GetDamage)
                {
                    activeShield();
                }
                playerHealthScript.playerPoints = 10;
            }
        }*/
        

    }

    void ShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePosition.position, firePosition.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePosition.up * bulletForce, ForceMode2D.Impulse);
        audioSourcePlayer.PlayOneShot(bulletSound);
    }


    void ShootRocket()
    {
        GameObject rocket = Instantiate(rocketPrefab, firePosition.position, firePosition.rotation);
        Rigidbody2D rb = rocket.GetComponent<Rigidbody2D>();
        rb.AddForce(firePosition.up * bulletForce, ForceMode2D.Impulse);
        audioSourcePlayer.volume = 0.7f;
        audioSourcePlayer.PlayOneShot(rocketSound);
    }

    void activeShield()
    {
        StartCoroutine(shieldTime());
    }

    IEnumerator shieldTime()
    {
        shieldActive = true;
        playerHealthScript.GetDamage = false;
        shieldObject.GetComponent<Animator>().SetTrigger("ShieldOn");
        yield return new WaitForSeconds(10);
        shieldObject.GetComponent<Animator>().SetTrigger("ShieldOff");
        playerHealthScript.GetDamage = true;
        shieldActive = false;
    }



}
