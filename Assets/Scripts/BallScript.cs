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
    public Transform explosion;
    public GameManagement gm;
    private AudioSource audio;
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gameFreeze)
        {
            return;
        }
        if (!GameManagement.IsBallMove)
        {
            InitializeBall();
        }
        if (Input.GetMouseButtonDown(0) && GameManagement.IsBallMove == false )
        {
            GameManagement.IsBallMove = true;
            AddForceToBall();
        }
    }
    public void InitializeBall()
    {
        Vector3 paddlePos = paddle.transform.position;
        Vector3 ballPos = new Vector3(paddlePos.x, paddlePos.y + 0.5f, paddlePos.z);
        this.transform.position = ballPos;
    }

    void AddForceToBall()
    {
        Random rnd = new Random();
        int horizontalForce = rnd.Next(100, 300);
        if (rnd.Next(0, 2) % 2 == 0)
        {
            horizontalForce = horizontalForce * -1;
        }
        int verticalForce = rnd.Next(100, 300);
        rb.AddForce(transform.up * verticalForce + transform.right * horizontalForce);
        rb.velocity = new Vector2(GameManagement.currentLevel * 2, GameManagement.currentLevel * 2);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DeathZone"))
        {
            GameManagement.IsBallMove = false;
            gm.UpdateLives(-1);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Brick"))
        {
            // Transform newExplosion = Instantiate(explosion, other.transform.position, other.transform.rotation);
            audio.Play();
            gm.UpdateScores(other.gameObject.GetComponent<BrickScript>().point);
            gm.UpdateNoBricks(-1);
            other.gameObject.GetComponent<BrickScript>().createPowerUp();
            other.gameObject.GetComponent<BrickScript>().createExplosion();
            // Destroy(other.gameObject);
            // Destroy(newExplosion.gameObject,2.5f);
        }
    }
}
