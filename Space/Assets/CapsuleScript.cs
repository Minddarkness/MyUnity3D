using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleScript : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
       // GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Player");
       // Vector3 shipPosition = gameObjects[0].position;
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -speed);
    }

}
