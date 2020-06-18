using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class ScrollerScript : MonoBehaviour
{
    public float speed;
    Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float zMovement = Mathf.Repeat(Time.time*speed,150);//0....100
        transform.position = startPosition + Vector3.back * zMovement;
    }
}
