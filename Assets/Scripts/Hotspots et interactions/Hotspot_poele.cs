using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotspot_poele : MonoBehaviour
{
    private Collider other;
        
    void OnTriggerStay(Collider other) {
        if (other.tag == "Player" && !other.GetComponent<Objets>().isOccupied) {
            other.GetComponent<Objets>().isOccupied = true;
            Debug.Log("is carrying?" + other.GetComponent<Objets>().isCarrying + "; is clicking? " + other.GetComponent<Objets>().click);
        }
    }  

    void OnTriggerExit(Collider other){
        if(other.tag == "Player" && !other.GetComponent<Objets>().isOccupied)
        {
           other.GetComponent<Objets>().isOccupied = false;
        }
    }

}
