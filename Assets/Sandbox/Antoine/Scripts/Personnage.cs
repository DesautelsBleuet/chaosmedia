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
    public CharacterController controller; //Contrôleur du personnage
    bool canMove = true;

    //Limites de jeu
    private float limiteXPos = 4.6f;
    private float limiteXNeg = -3.5f;
    private float limiteZPos = 3.6f;
    private float limiteZNeg = -4.8f;

    //Variables de movement
    public Vector2 valMov;
    public float vitesseMouvement;

    void OnMove(InputValue value)
    {
        //Obtenir la valeur de mouvement dans Unity
        valMov = value.Get<Vector2>(); 
        
        //Rotation
        //        joueur.transform.Rotate(0.0f, 90.0f, 0.0f, Space.Self);
        if (valMov.x < 0) {
            Rotation(-90);
        }
        if (valMov.x > 0) {
            Rotation(90);
        }
        if (valMov.y < 0) {
            Rotation(180);
        }
        if (valMov.y > 0) {
            Rotation(0);
        }
    }

    void Rotation(float value) {
            joueur.transform.eulerAngles = new Vector3(
            joueur.transform.eulerAngles.x,
            value,
            joueur.transform.eulerAngles.z
        );
    }

    void FixedUpdate() {
        if (canMove) {
        //Bouger personnage
        controller.transform.Translate(new Vector3(valMov.x, 0, valMov.y) * vitesseMouvement * Time.deltaTime);
           
        }
    }

    void Update()
    {
        //Calculer limites de jeu
        if (controller.transform.position.x >= limiteXPos) {
            controller.transform.position = new Vector3(limiteXPos, controller.transform.position.y, controller.transform.position.z);
        } 
        else if (controller.transform.position.x <= limiteXNeg) {
            controller.transform.position = new Vector3(limiteXNeg, controller.transform.position.y, controller.transform.position.z);
        }
    
        if (controller.transform.position.z >= limiteZPos) {
            controller.transform.position = new Vector3(controller.transform.position.x, controller.transform.position.y, limiteZPos);
        } 
        else if (controller.transform.position.z <= limiteZNeg) {
            controller.transform.position = new Vector3(controller.transform.position.x, controller.transform.position.y, limiteZNeg);
        }
    }

    void Enter(string objectName) {
        Debug.Log(objectName);
    }

    void Stop() {
        canMove = false;
    }
}