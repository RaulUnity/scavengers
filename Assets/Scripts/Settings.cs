using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public GameObject objectActive;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        DontDestroyOnLoad(gameObject);

        KeepObjectActive();
    }

    void KeepObjectActive()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");
        if(objs.Length > 1)
        {
            Destroy(objectActive);
        }

        DontDestroyOnLoad(objectActive);
    }
}
