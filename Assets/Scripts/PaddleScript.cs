using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    public Camera mainCamera;
    public GameManagement gm;

    float leftMax = 123;

    float rightMax = 896;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gameFreeze)
        {
            return;
        }
        Movement();
    }

    void Movement()
    {
        float movemnetValue = Mathf.Clamp(Input.mousePosition.x, leftMax, rightMax);
        float worldXPos = mainCamera.ScreenToWorldPoint(new Vector3(movemnetValue, 0f, 0f)).x;
        this.transform.position = new Vector3(worldXPos,-4f,0);        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ExtraLifePowerUp"))
        {
            gm.UpdateLives(1);
            Destroy(other.gameObject);
        }
    }
}
