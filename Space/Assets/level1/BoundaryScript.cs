using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryScript : MonoBehaviour
{
    //срабатывает при выходе объекта за границы текущего
    private void OnTriggerExit(Collider other)
    {
       
        Destroy(other.gameObject);
    }
}
