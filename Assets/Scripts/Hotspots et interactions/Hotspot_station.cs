using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotspot_station : MonoBehaviour
{
    [ShowOnly] public GameObject ingredient;
    [ShowOnly] public Collider player;

    public string ingredientNeeded;
    public GameObject ingredientOutput;
    private GameObject ingredientCarry;
    public Vector3 offset;

    private bool waitForOutput = false;
    public bool miniJeuReussi = true; //Résultat du mini-jeu, false par défaut mais true pour tester
        
    void OnTriggerStay(Collider other) {
        if (other.tag == "Player" && other.GetComponent<Objets>().isCarrying) {
            player = other;
            ingredient = other.GetComponent<Objets>().ingredient;
            if (ingredient.tag == ingredientNeeded) {
                if (other.GetComponent<Objets>().click) {
                    other.GetComponent<Objets>().isCarrying = false;
                    Destroy(ingredient);
                    //Mini-jeu
                    output();
                }
            }
        }
    }  

    void output() {
        waitForOutput = true;
    }

    void Update() {
        if (waitForOutput) {
            if (miniJeuReussi) {
                Debug.Log("Réussi!");
                waitForOutput = false;
                player.GetComponent<Mouvement>().peutBouger = true;
                ingredientCuit();
            } else {
                Debug.Log("En attente");
                player.GetComponent<Mouvement>().peutBouger = false;
            }
        }
    }

    void ingredientCuit() {
        var pos = player.transform.position;
        ingredientCarry = Instantiate(ingredientOutput, new Vector3(pos.x, pos.y, pos.z), Quaternion.identity);
        ingredientCarry.SetActive(true);
        player.GetComponent<Objets>().isCarrying = true;
        player.GetComponent<Objets>().ingredient = ingredientCarry;
        player.GetComponent<Objets>().offset = offset;
        player.GetComponent<Objets>().currentParent = this.gameObject;
    }

}
