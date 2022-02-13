using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public GameObject explosionFx;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject hit = Instantiate(explosionFx, transform.position, transform.rotation);
        Destroy(hit, 1.6f);
        Destroy(gameObject);
    }





}
