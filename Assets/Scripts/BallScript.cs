using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;


public class BallScript : MonoBehaviour
{
    // Start is called before the first frame update
    public PaddleScript paddle;
    public Rigidbody2D rb;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManagement.IsBallMove)
        {
            InitializeBall();
        }
        if (Input.GetMouseButtonDown(0) && GameManagement.IsBallMove == false)
        {
            GameManagement.IsBallMove = true;
            AddForceToBall();
        }
    }
    void InitializeBall()
    {
        Vector3 paddlePos = paddle.transform.position;
        Vector3 ballPos = new Vector3(paddlePos.x, paddlePos.y + 0.5f, paddlePos.z);
        this.transform.position = ballPos;
    }

    void AddForceToBall()
    {
        Random rnd = new Random();
        int horizontalForce = rnd.Next(100, 300);
        if (rnd.Next(0, 1) % 2 == 0)
        {
            horizontalForce = horizontalForce * -1;
        }
        int verticalForce = rnd.Next(100, 300);
        rb.AddForce(transform.up * verticalForce + transform.right * horizontalForce);
        rb.velocity = new Vector2(GameManagement.currentLevel, GameManagement.currentLevel);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DeathZone"))
        {
            GameManagement.IsBallMove = false;
            InitializeBall();
        }
    }
}
