using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float playerHealth = 11;
    public bool GetDamage;
    bool playActivation;
    bool exitPoints;
    bool exitPoints2;
    bool exitPoints3;
    public Text lifeText;
    public int playerPoints = 0;
    public int playerShieldPoints = 0;
    public Image shoot1;
    public Image shoot2;
    public Image shoot3;
    public Image shield1;

    AudioSource playerAudiosource;
    public AudioClip rocketAvailable;
    public AudioClip shieldAvailable;

    private void Start()
    {
        playerAudiosource = GetComponent<AudioSource>();
        GetDamage = true;
        lifeText.text = "x" + playerHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GetDamage)
        {
            if (collision.tag == "BulletIBasic" && playerHealth >= 1)
            {
                playerHealth -= 1;
                lifeText.text = "x" + playerHealth;
                gameObject.GetComponent<Animator>().SetTrigger("DamagePlayerOn");
            }

            if (collision.tag == "Bullet_B" && playerHealth >= 1)
            {
                playerHealth -= 1;
                lifeText.text = "x" + playerHealth;
                gameObject.GetComponent<Animator>().SetTrigger("DamagePlayerOn");
            }

            if (collision.tag == "BulletIII" && playerHealth >= 1)
            {
                playerHealth -= 1;
                lifeText.text = "x" + playerHealth;
                gameObject.GetComponent<Animator>().SetTrigger("DamagePlayerOn");
            }
            if (collision.tag == "BulletBoss" && playerHealth >= 1)
            {
                playerHealth -= 1;
                lifeText.text = "x" + playerHealth;
                gameObject.GetComponent<Animator>().SetTrigger("DamagePlayerOn");
            }
            if (collision.tag == "Missile" && playerHealth >= 1)
            {
                playerHealth -= 3;
                lifeText.text = "x" + playerHealth;
                gameObject.GetComponent<Animator>().SetTrigger("DamagePlayerOn");
            }
        } 
    }

    private void Update()
    {
        if (playerHealth <= 0)
        {
            SceneManager.LoadScene(4);
        }

        Debug.Log(playerPoints);
        RocketActivation();
        ShieldActivation();

        /*if (playActivation)
        {
            if (playerAudiosource.isPlaying)
            {
                playerAudiosource.Stop();
                playerAudiosource.PlayOneShot(rocketAvailable);
                exitPoints = true;
                playActivation = false;
            }
            else
            {
                playerAudiosource.PlayOneShot(rocketAvailable);
                exitPoints = true;
                playActivation = false;
            }
        }*/
    }


    void RocketActivation()
    {
        if (playerPoints >= 30)
        {
            playerPoints = 30;
        }

        if (playerPoints <= 0)
        {
            playerPoints = 0;
            //exitPoints = false;
        }

        if (playerPoints == 10)
        {
            shoot1.color = Color.HSVToRGB(0, 0, 1);
            shoot2.color = Color.HSVToRGB(0, 0, 0);
            //playActivation = true;
            //exitPoints = true;
        }

        if (playerPoints == 20)
        {
            shoot2.color = Color.HSVToRGB(0, 0, 1);
            shoot3.color = Color.HSVToRGB(0, 0, 0);
            //playActivation = true;
            //exitPoints = true;
        }

        if (playerPoints == 30)
        {
            shoot3.color = Color.HSVToRGB(0, 0, 1);
            //playActivation = true;
            //exitPoints = true;
        }

        if (playerPoints == 0)
        {
            shoot1.color = Color.HSVToRGB(0, 0, 0);
            shoot2.color = Color.HSVToRGB(0, 0, 0);
            shoot3.color = Color.HSVToRGB(0, 0, 0);
        }
    }

    void ShieldActivation()
    {
        if (playerShieldPoints >= 20)
        {
            playerShieldPoints = 20;
        }

        if (playerShieldPoints <= 0)
        {
            playerShieldPoints = 0;
        }

        if (playerShieldPoints == 20)
        {
            shield1.color = Color.HSVToRGB(0, 0, 1);
        }

        if (playerShieldPoints == 0)
        {
            shield1.color = Color.HSVToRGB(0, 0, 0);
        }
    }
}
