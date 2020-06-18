//using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EmitterScript : MonoBehaviour
{
    public GameObject asteroid;
    public float minDelay, maxDelay;//задержка между запусками
    float nextLaunchTime;//время следующего запуска
    bool stop = false;

    // Update is called once per frame
    void Update()
    {
       /* if (GameController.instance.isStarted == false)
        {
            return;
        }*/
        if ((Time.time > nextLaunchTime) && !stop)
        {
            //запустить астероид
            float xPosition = Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2);
            float yPosition = Random.Range(-transform.localScale.y / 2, transform.localScale.y / 2);
            float zPosition = transform.position.z;
            Vector3 asteroidPosition = new Vector3(xPosition, yPosition, zPosition);
            Instantiate(asteroid, asteroidPosition, Quaternion.identity);
            nextLaunchTime = Time.time + Random.Range(minDelay, maxDelay);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            stop = true;
        }
    }
    //срабатывает при выходе объекта за границы текущего
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            stop = false;
        }
    }
}