using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject lazerShot;//чем стрелять
    public GameObject lazerGun;// откуда стрелять
    public GameObject playerExplosion;
    public float shotDelay; // задержку между выстрелами
    public float speed;
    public float xMin, xMax, yMin, yMax;
    public float zMin, zMax;
    public float tilt;
    Rigidbody playerShip;
    float nextShotTime;
    // Start is called before the first frame update
    void Start()
    {
        playerShip = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

        float moveHorizontal = Input.GetAxis("Horizontal"); //-1...+1
        float moveVertical = Input.GetAxis("Vertical"); //-1...+1
        //playerShip.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed;
        playerShip.velocity = new Vector3(moveHorizontal, moveVertical, -1) * speed;

        float xPosition = Mathf.Clamp(playerShip.position.x, xMin, xMax);
        //float zPosition = Mathf.Clamp(playerShip.position.z, zMin, zMax);
        float yPosition = Mathf.Clamp(playerShip.position.y, yMin, yMax);
        float zPosition = Mathf.Clamp(playerShip.position.z, zMin, zMax);

        //playerShip.position = new Vector3(xPosition,0,zPosition);
        // playerShip.position = new Vector3(xPosition, yPosition, 0);
        playerShip.position = new Vector3(xPosition, yPosition, zPosition);

        playerShip.rotation = Quaternion.Euler(-playerShip.velocity.y * tilt, 180, -playerShip.velocity.x * tilt);

        //Vector3 wantedPosition = new Vector3(0, 0, zPosition - cumDistance);
        //mainCamTransform.position = Vector3.Lerp(mainCamTransform.position, wantedPosition, Time.deltaTime * 5.0f);
       
        if (Time.time > nextShotTime)
        {
            Instantiate(lazerShot, lazerGun.transform.position, Quaternion.identity);
            nextShotTime = Time.time + shotDelay;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Emitter")
        {
            return;
        }
        if (other.tag == "Lazer")
        {
            GameController.instance.incrementScore(10);
            Instantiate(playerExplosion, transform.position, Quaternion.identity);
            Destroy(gameObject); // уничтожаем текущий игровой объект
            Destroy(other.gameObject); // уничтожаем выстрел 
        }
    }
}
