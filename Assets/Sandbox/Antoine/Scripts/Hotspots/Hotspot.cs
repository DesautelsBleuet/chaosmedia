using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotspot : MonoBehaviour
{
    protected string objectName;

    protected void OnTriggerEnter(Collider other) //vérification de collision 
    {
        if (other.tag == "Player") //si collision avec joueur
        {
            other.SendMessage("Enter", objectName);
        }
    }
}
