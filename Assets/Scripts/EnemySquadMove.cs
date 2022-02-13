using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySquadMove : MonoBehaviour
{
    public GameObject[] enemies;

    private void Update()
    {
        if(GameObject.FindGameObjectsWithTag("IBasic").Length == 0 && GameObject.FindGameObjectsWithTag("IIShield").Length == 0 && GameObject.FindGameObjectsWithTag("IIMisile").Length == 0 && GameObject.FindGameObjectsWithTag("IIIShield").Length == 0 && GameObject.FindGameObjectsWithTag("IIIMisile").Length == 0 && GameObject.FindGameObjectsWithTag("Boss").Length == 0)
        {
            SceneManager.LoadScene(3);
        }
    }
}
