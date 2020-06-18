using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BigEnemyScript : MonoBehaviour
{
    public GameObject lazerGun1, lazerGun2, lazerGun3, lazerGun4, lazerGun5, lazerGun6, lazerGun7;// откуда стрелять
    public GameObject lazerShot,BigShot;//чем стрелять
    public GameObject playerExplosion;
    public float shotDelay; // задержку между выстрелами
    public float speed;
    public float xMin, xMax, yMin, yMax;
    public float tilt;
    public float lives;
    Rigidbody Ship;
    float nextShotTime1, nextShotTime2, nextShotTime3, nextShotTime4, nextBigShotTime;
    // Start is called before the first frame update
    void Start()
    {
        Ship = GetComponent<Rigidbody>();
        GameController.instance.scoreLabel.text = "Жизни: " + lives;
        GameController.instance.scoreLabel.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); //-1...+1
        float moveVertical = Input.GetAxis("Vertical"); //-1...+1
        //playerShip.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed;
        Ship.velocity = new Vector3(moveHorizontal, moveVertical, 0) * speed;

        float xPosition = Mathf.Clamp(Ship.position.x, xMin, xMax);
        //float zPosition = Mathf.Clamp(playerShip.position.z, zMin, zMax);
        float yPosition = Mathf.Clamp(Ship.position.y, yMin, yMax);
        float zPosition = transform.position.z;

        //playerShip.position = new Vector3(xPosition,0,zPosition);
        // playerShip.position = new Vector3(xPosition, yPosition, 0);
        Ship.position = new Vector3(xPosition, yPosition, zPosition);

        Ship.rotation = Quaternion.Euler(Ship.velocity.y * tilt, 0, -Ship.velocity.x * tilt);

        //Vector3 wantedPosition = new Vector3(0, 0, zPosition - cumDistance);
        //mainCamTransform.position = Vector3.Lerp(mainCamTransform.position, wantedPosition, Time.deltaTime * 5.0f);
        if (GameController.instance.stay == false)
        {
            return;
        }
        if (Time.time > nextShotTime1)
        {
            Instantiate(lazerShot, lazerGun1.transform.position, Quaternion.identity);
           // Instantiate(lazerShot, lazerGun2.transform.position, Quaternion.identity);
            nextShotTime1 = Time.time + shotDelay;
        }
        if (Time.time > nextShotTime2)
        {
            Instantiate(lazerShot, lazerGun3.transform.position, Quaternion.identity);
            Instantiate(lazerShot, lazerGun4.transform.position, Quaternion.identity);
            Instantiate(lazerShot, lazerGun2.transform.position, Quaternion.identity);
            nextShotTime2 = Time.time + shotDelay*(float)5;
        }
        if (Time.time > nextShotTime3)
        {
            Instantiate(lazerShot, lazerGun5.transform.position, Quaternion.identity);
            Instantiate(lazerShot, lazerGun6.transform.position, Quaternion.identity);
            nextShotTime3 = Time.time + shotDelay * (float)6;
        }
        if (Time.time > nextShotTime4)
        {
            Instantiate(BigShot, lazerGun7.transform.position, Quaternion.identity);
            nextShotTime4 = Time.time + shotDelay * (float)3;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Lazer")
        {
           // GameController.instance.incrementScore(5);
            lives--;
            GameController.instance.scoreLabel.text = "Жизни: " + lives;
            if (lives <= 0)
            {
                GameController.instance.stay = false;
                Instantiate(playerExplosion, transform.position, Quaternion.identity);
                Destroy(gameObject); // уничтожаем текущий игровой объект
            }

            Destroy(other.gameObject); // уничтожаем выстрел 
        }

    }
}
