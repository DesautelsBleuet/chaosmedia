using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotspot_assiette : MonoBehaviour
{
    [ShowOnly] public GameObject ingredient;
    [ShowOnly] public Collider player;
    public GameObject GameManager;
    public GameObject plate;
    private bool canInteract = true;
    private int nbIngredients = 0;
    private List<Transform> ingredients = new List<Transform>();
    private Transform ingredientTransform;

    void Awake() {
        plate = GameObject.Find("Plate");
    }

    void OnTriggerStay(Collider other) {
        player = other;
        if (other.tag == "Player" && other.GetComponent<Objets>().click && canInteract) {
            canInteract = false;
            if (other.GetComponent<Objets>().isCarrying) {
                ingredient = other.GetComponent<Objets>().ingredient;
                Debug.Log(ingredient.transform.localScale);
                ajoutIngredient(ingredient);
                other.GetComponent<Objets>().isCarrying = false;
                Destroy(ingredient);
            } else {
                enleverIngredient();
            }
        }
    }

    void OnTriggerExit(Collider other) {
        canInteract = true;
    }

    void ajoutIngredient(GameObject ingredient) {
        GameManager.SendMessage("ajoutIngredient", player.GetComponent<Objets>().ingredient.tag);
        ingredientTransform = Instantiate(ingredient.transform, new Vector3(0, 0, 0), Quaternion.identity, plate.transform);
        ingredientTransform.localPosition = new Vector3(0,0, 0.017f*(nbIngredients+1));
        ingredientTransform.localScale = new Vector3(0.5f,0.5f,2);
        ingredientTransform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        nbIngredients ++;
        ingredients.Add(ingredientTransform);
    }

    void enleverIngredient() {
        if (nbIngredients > 0) {
            nbIngredients--;
            GameManager.SendMessage("enleverIngredient");
        }
    }
}
