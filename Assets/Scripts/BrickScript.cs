using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class BrickScript : MonoBehaviour
{
    public int point;
    public bool hasPowerUp = false;

    public GameObject explosion;
    public GameObject powerUp;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void createExplosion()
    {
        Transform newExplosion = Instantiate(explosion.transform, this.transform.position, this.transform.rotation);
        Destroy(newExplosion.gameObject,2.5f);
        Destroy(this.gameObject);
    }

    public void createPowerUp()
    {
        Random rnd = new Random();
        int randomNumber = rnd.Next(1, 101);
        if (randomNumber < 20)
        {
            hasPowerUp = true;
        }
        if (hasPowerUp)
        {
            Transform newPowerUp = Instantiate(powerUp.transform, this.transform.position, this.transform.rotation);
            Destroy(newPowerUp.gameObject,5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
