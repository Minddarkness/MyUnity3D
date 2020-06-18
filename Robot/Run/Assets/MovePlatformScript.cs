using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatformScript : MonoBehaviour
{
    public float minZ, maxZ;
    public float speed;
    Rigidbody platform;
    //Vector3 speedVector;
    // Start is called before the first frame update
    void Start()
    {
        platform = GetComponent<Rigidbody>();
        //speedVector = new Vector3(0, 0, speed);
        platform.velocity = new Vector3(0, 0, speed); 

    }

    // Update is called once per frame
    void Update()
    {
        if (platform.position.z <= minZ || platform.position.z >= maxZ)
        {
            speed *= -1;
            platform.velocity = new Vector3(0, 0, speed);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        other.transform.parent = transform;
    }
    private void OnTriggerExit(Collider other)
    {
        other.transform.parent = null;
    }
}
