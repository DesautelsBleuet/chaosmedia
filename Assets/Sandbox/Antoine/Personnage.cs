using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class Personnage : MonoBehaviour
{
    [Header("Joueur")]
    //Personnage
    public GameObject joueur; //game object du joueur
    public CharacterController perso; //Contrôleur du personnage

    //Limites de jeu
    private float limiteXPos = 3.38f;
    private float limiteXNeg = -5.51f;
    private float limiteZPos = 3.21f;
    private float limiteZNeg = -5.71f;

    //Variables de movement
    public Vector2 valMov;
    public float vitesseMouvement;

    void OnMove(InputValue value)
    {
        //Obtenir la valeur de mouvement dans Unity
        valMov = value.Get<Vector2>();
    }

    void FixedUpdate() {
        //Bouger personnage
        perso.transform.Translate(new Vector3(valMov.x, 0, valMov.y) * vitesseMouvement * Time.deltaTime);
    }

    void Update()
    {
        //Calculer limites de jeu
        if (perso.transform.position.x >= limiteXPos) {
            perso.transform.position = new Vector3(limiteXPos, perso.transform.position.y, perso.transform.position.z);
        } 
        else if (perso.transform.position.x <= limiteXNeg) {
            perso.transform.position = new Vector3(limiteXNeg, perso.transform.position.y, perso.transform.position.z);
        }
    
        if (perso.transform.position.z >= limiteZPos) {
            perso.transform.position = new Vector3(perso.transform.position.x, perso.transform.position.y, limiteZPos);
        } 
        else if (perso.transform.position.z <= limiteZNeg) {
            perso.transform.position = new Vector3(perso.transform.position.x, perso.transform.position.y, limiteZNeg);
        }

    }
}