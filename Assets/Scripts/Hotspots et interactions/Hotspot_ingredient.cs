using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotspot_ingredient : MonoBehaviour
{
    protected GameObject player;
 
    public Transform ingredient;
    private Transform ingredientCarry;
 
    protected GameObject main;
    public Vector3 offset;
    private bool isActive = false;

    void Start() {
        main = GameObject.Find("Arm.R_end");
        player = GameObject.Find("Dona disco");
    }

    void FixedUpdate()  {
        if (isActive) {
            ingredientCarry.transform.position = main.transform.position + offset;
        }
    }

    void OnTriggerEnter(Collider other){
        if (other.tag == "Player" && !player.GetComponent<Objets>().isCarrying && !player.GetComponent<Objets>().isOccupied)
        {
                ingredientCarry = Instantiate(ingredient, new Vector3(0, 0, 0), Quaternion.identity);
                player.GetComponent<Objets>().isCarrying = true;
                isActive = true;
        }
    }

    void OnTriggerStay(Collider other){
        if(other.tag == "Player" && !player.GetComponent<Objets>().isOccupied)
        {
           player.GetComponent<Objets>().isOccupied = true;
        }
    }

    void OnTriggerExit(Collider other){
        if(other.tag == "Player" && !player.GetComponent<Objets>().isOccupied)
        {
           player.GetComponent<Objets>().isOccupied = false;
        }
    }
}
