using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float playerSpeed = 4;
    Rigidbody2D rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * playerSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.D))
        {
            rigidbody.AddForce(Vector2.right * playerSpeed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rigidbody.AddForce(-Vector2.right * playerSpeed);
        }

    }



}
