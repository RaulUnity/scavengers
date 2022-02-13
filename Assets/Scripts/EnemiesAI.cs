using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesAI : MonoBehaviour
{


    //Variables Assignment
    //Var Health
    int healthI = 2;
    int healthII = 4;
    int healthIII = 8;
    int healthIV = 16;

    public int currentHealth;


    //Var Shield
    public int shield = 8;


    //Var Components
    Animator enemiesAnim;
    AudioSource audioSourceEnemies;

    //AudioClips
    public AudioClip basicShootSound;
    public AudioClip misileSound;
    public AudioClip enemiesDeath;


    //Var Enemies Basic Attack
    public Transform firePositionEnemies;
    
    public GameObject bulletEnemiesPrefab;
    public float bulletForce = 5;
    
    public GameObject misileEnemiesPrefab;
    public float misileForce = 2.5f;

    public GameObject shieldObject;

    public GameObject group;

    //Enemies Booleans
    bool canBeAttacked = false;
    bool shieldDisable = false;
    bool playActivationEnemy;
    public bool canAttack;

    //External Scripts
    PlayerHealth playerScript;






    //Health assignment
    private void Start()
    {

        if(gameObject.tag == "IBasic")
        {
            currentHealth = healthI;
            StartCoroutine(WaitingForAimBasicShoot());
        }
        if(gameObject.tag == "IIMisile")
        {
            currentHealth = healthII;
            StartCoroutine(WaitingForAimMisile());
        }
        if(gameObject.tag == "IIShield")
        {
            currentHealth = healthII;
        }
        if(gameObject.tag == "IIIMisile")
        {
            currentHealth = healthIII;
            StartCoroutine(WaitingForAimBasicShoot());
            StartCoroutine(WaitingForAimMisile());
        }
        if(gameObject.tag == "IIIShield")
        {
            currentHealth = healthIII;
            StartCoroutine(WaitingForAimBasicShoot());
        }
        if(gameObject.tag == "Boss")
        {
            currentHealth = healthIV;
            StartCoroutine(WaitingForAimBasicShoot());
            StartCoroutine(WaitingForAimMisile());
        }


        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        enemiesAnim = GetComponent<Animator>();
        audioSourceEnemies = GetComponent<AudioSource>();

        canAttack = true;
    }




    //Assignment for Enemy Death
    private void Update()
    {
        if(currentHealth <= 0)
        {
            GetComponent<AudioSource>().volume = 0.15f;
            GetComponent<AudioSource>().PlayOneShot(enemiesDeath);
            Destroy(gameObject, 0.8f);
        }
    }

    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 0.4f), -Vector2.up);

        if(hit.collider == null)
        {
            return;
        }
        else if(hit.collider.CompareTag("IBasic") || hit.collider.CompareTag("IIShield") || hit.collider.CompareTag("IIMisile") || hit.collider.CompareTag("IIIShield") || hit.collider.CompareTag("IIIMisile") || hit.collider.CompareTag("Boss"))
        {
            Debug.DrawRay(new Vector2(transform.position.x, transform.position.y - 0.4f), -Vector2.up, Color.red);
            canAttack = false;
        }
        else
        {
            canAttack = true;
        }
    }





    //Assignment for Aim&Shoot
    IEnumerator WaitingForAimBasicShoot()
    {
        while (true)
        {
            firePositionEnemies.up = (GameObject.FindGameObjectWithTag("Player").transform.position - firePositionEnemies.position) * -1;
            BasicShoot();
            yield return new WaitForSeconds(Random.Range(2, 10));
        }
    }

    IEnumerator WaitingForAimMisile()
    {
        while (true)
        {
            firePositionEnemies.up = (GameObject.FindGameObjectWithTag("Player").transform.position - firePositionEnemies.position) * -1;
            MisileShoot();
            yield return new WaitForSeconds(Random.Range(2, 10));
        }
    }




    //Collision to enemies
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canBeAttacked)
        {
            if (collision.tag == "Bullet")
            {
                if (gameObject.tag == "IIShield" || gameObject.tag == "IIIShield" || gameObject.tag == "Boss" && shieldObject != null)
                {
                    if (shield >= 1)
                    {
                        shield -= 1;
                        playerScript.playerPoints++;
                        playerScript.playerShieldPoints++;
                        shieldObject.GetComponent<Animator>().SetTrigger("ShieldOnDamage");
                    }
                    else if (shield <= 0 && !shieldDisable)
                    {
                        shieldObject.GetComponent<Animator>().SetTrigger("ShieldOff");
                        shieldDisable = true;
                    }
                    else
                    {
                        currentHealth -= 1;
                        playerScript.playerPoints++;
                        playerScript.playerShieldPoints++;
                        enemiesAnim.SetTrigger("DamageOn");
                    }

                }
                else
                {
                    currentHealth -= 1;
                    playerScript.playerPoints++;
                    playerScript.playerShieldPoints++;
                    enemiesAnim.SetTrigger("DamageOn");
                }

            }


            if (collision.tag == "Rocket")
            {
                if (gameObject.tag == "IIShield" || gameObject.tag == "IIIShield" || gameObject.tag == "Boss" && shieldObject != null)
                {
                    if (shield >= 1)
                    {
                        shield -= 3;
                        playerScript.playerPoints++;
                        playerScript.playerShieldPoints++;
                        shieldObject.GetComponent<Animator>().SetTrigger("ShieldOnDamage");
                    }
                    else if (shield <= 0 && !shieldDisable)
                    {
                        shieldObject.GetComponent<Animator>().SetTrigger("ShieldOff");
                        shieldDisable = true;
                    }
                    else
                    {
                        currentHealth -= 3;
                        playerScript.playerPoints++;
                        playerScript.playerShieldPoints++;
                        enemiesAnim.SetTrigger("DamageOn");
                    }

                }
                else
                {
                    currentHealth -= 3;
                    playerScript.playerPoints++;
                    playerScript.playerShieldPoints++;
                    enemiesAnim.SetTrigger("DamageOn");
                }

            }
        }
    }



    private void OnEnable()
    {
        if (shieldObject != null)
        {
            StartCoroutine(shieldWait());
        }
        else
        {
            StartCoroutine(attackWait());
        }
    }

    IEnumerator shieldWait()
    {
        yield return new WaitForSeconds(0.5f);
        shieldObject.GetComponent<Animator>().SetTrigger("ShieldOn");
        yield return new WaitForSeconds(0.27f);
        canBeAttacked = true;
    }

    IEnumerator attackWait()
    {
        yield return new WaitForSeconds(0.5f);
        canBeAttacked = true;
    }







    //Asignment for Enemies Attacks
    void BasicShoot()
    {
        if (canAttack)
        {
            GameObject bullet = Instantiate(bulletEnemiesPrefab, firePositionEnemies.position, firePositionEnemies.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(-firePositionEnemies.up * bulletForce, ForceMode2D.Impulse);
            audioSourceEnemies.volume = 1f;
            audioSourceEnemies.PlayOneShot(basicShootSound);
        }
    }


    void MisileShoot()
    {
        if (canAttack)
        {
            GameObject misile = Instantiate(misileEnemiesPrefab, firePositionEnemies.position, firePositionEnemies.rotation);
            Rigidbody2D rb = misile.GetComponent<Rigidbody2D>();
            rb.AddForce(-firePositionEnemies.up * misileForce, ForceMode2D.Force);
            audioSourceEnemies.PlayOneShot(misileSound);
        }
    }





}
