//using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public GameObject asteroidExplosion;
    public GameObject playerExplosion;
    public float rotationSpeed;
    public float minSpeed, maxSpeed;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody asteroid = GetComponent<Rigidbody>();
        asteroid.angularVelocity = Random.insideUnitSphere * rotationSpeed;
        float zSpeed = Random.Range(minSpeed, maxSpeed);
        asteroid.velocity = new Vector3(0,0, -zSpeed);
    }
    //при начале столкновения 
    private void OnTriggerEnter (Collider other)
    {
        if (other.tag == "GameBoundary" || other.tag == "Asteroid" || other.tag == "Emitter")
        {
            return;
        }
        if(other.tag == "Lazer"&& GameController.instance.isAlive)
        {
            GameController.instance.incrementScore(7);
        }
        

        Destroy(gameObject); // уничтожаем текущий игровой объект
        Destroy(other.gameObject); // уничтожаем выстрел
        if(other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, Quaternion.identity);
            GameController.instance.isAlive = false;
            GameController.instance.resetScore( );
        }
        Instantiate(asteroidExplosion, transform.position, Quaternion.identity);
    }
}
