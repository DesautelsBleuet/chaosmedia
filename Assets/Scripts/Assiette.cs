using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assiette : MonoBehaviour
{
    public Collider assiette;
    public GameObject GameManager;

    void OnTriggerEnter(Collider other){
    if(other.tag == "Player"){
       GameManager.SendMessage("ajoutIngredient", assiette.tag);
    }
    }
}
