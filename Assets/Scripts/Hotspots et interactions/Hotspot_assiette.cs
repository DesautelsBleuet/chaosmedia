using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotspot_assiette : MonoBehaviour
{
    [ShowOnly] public GameObject ingredient;
    [ShowOnly] public Collider player;
    public GameObject GameManager;
    private bool repos; //Temps avant de

    void OnTriggerStay(Collider other) {
        if (other.tag == "Player" && other.GetComponent<Objets>().click) {
            if (other.GetComponent<Objets>().isCarrying) {
                GameManager.SendMessage("ajoutIngredient", other.GetComponent<Objets>().ingredient.tag);
                other.GetComponent<Objets>().isCarrying = false;
                Destroy(ingredient);
            } else {
                GameManager.SendMessage("enleverIngredient", "viandeCrue");
            }
        }
    }



}
