using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assiette : MonoBehaviour
{
    public Collider assiette;
    public GameObject GameManager;

    void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            GameManager.SendMessage("ajoutIngredient", other.GetComponent<Mouvement>().ingredient.tag);
            other.GetComponent<Mouvement>().ingredientScript.SendMessage("mettreAssiette", this.gameObject);
        }
    }
}
