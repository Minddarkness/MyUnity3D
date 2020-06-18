using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject lazerShot;//чем стрелять
    public GameObject lazerGun, lazerGun1;// откуда стрелять
    public Camera mainCamera;
    public GameObject playerExplosion;
    public float cumDistance;
    public float shotDelay; // задержку между выстрелами
    public float speed;
    public float xMin, xMax,  yMin, yMax;
    public float zMin, zMax;
    public float tilt;
    Rigidbody playerShip;
    Transform mainCamTransform;
    float nextShotTime;
    // Start is called before the first frame update
    void Start()
    {
        playerShip = GetComponent<Rigidbody>();
        //playerShip.velocity = new Vector3(10, 0 ,5);
        mainCamTransform = mainCamera.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float moveZ = 1; //-1...+1
        //if (Input.GetButton("Jump")) GameController.instance.stay = false;
        if (GameController.instance.stay == true && playerShip.position.z >= 30 )
        {
            moveZ = 0;
        }
        else moveZ = 1;
        float moveHorizontal = Input.GetAxis("Horizontal"); //-1...+1
        float moveVertical = Input.GetAxis("Vertical"); //-1...+1

        //playerShip.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed;
        playerShip.velocity = new Vector3(moveHorizontal, moveVertical, moveZ) * speed;

        float xPosition = Mathf.Clamp(playerShip.position.x, xMin, xMax);
        //float zPosition = Mathf.Clamp(playerShip.position.z, zMin, zMax);
        float yPosition = Mathf.Clamp(playerShip.position.y, yMin, yMax);
        float zPosition = Mathf.Clamp(playerShip.position.z, zMin, zMax);

        //playerShip.position = new Vector3(xPosition,0,zPosition);
        // playerShip.position = new Vector3(xPosition, yPosition, 0);
        playerShip.position = new Vector3(xPosition, yPosition, zPosition);

        playerShip.rotation = Quaternion.Euler(-playerShip.velocity.y*tilt, 0, - playerShip.velocity.x*tilt);

        Vector3 wantedPosition = new Vector3(0, 0, zPosition - cumDistance);
        mainCamTransform.position = Vector3.Lerp(mainCamTransform.position, wantedPosition, Time.deltaTime * 5.0f);



        if (Time.time > nextShotTime && Input.GetButton("Fire1"))
        {
            Instantiate(lazerShot, lazerGun.transform.position, Quaternion.identity);
            Instantiate(lazerShot, lazerGun1.transform.position, Quaternion.identity);
            nextShotTime = Time.time + shotDelay;
        }

        /*if (Input.GetButton("Fire2"))
        {
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Asteroid");
            foreach (GameObject asteroid in gameObjects)
            {
                Destroy(asteroid);
            }
        }*/

    }

    //при начале столкновения 
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Emitter")
        {
            return;
        }
        if (other.tag == "EnemyLazer" || other.tag == "Enemy")
        {
            GameController.instance.isAlive = false;
            GameController.instance.resetScore();
            if(other.tag == "Enemy") Instantiate(playerExplosion, other.transform.position, Quaternion.identity);
            Instantiate(playerExplosion, transform.position, Quaternion.identity);
            Destroy(gameObject); // уничтожаем текущий игровой объект
            Destroy(other.gameObject); // уничтожаем выстрел или врага
        }
    }
}
