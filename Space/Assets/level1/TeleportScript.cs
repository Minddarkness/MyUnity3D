using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    //срабатывает при выходе объекта за границы текущего
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(other.gameObject);
            GameController.instance.isWin = true;
        }
            
    }
}
