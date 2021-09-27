using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class Personnage : MonoBehaviour
{
    [Header("Joueur")]
    public GameObject joueur; //game object du joueur
    public CharacterController controle; //Contrôleur du personnage

    [Header("Limites X")]
    public float limiteXBas = -0.27f;
    public float limiteXGauche = -5f;
    [Header("Limites Z")]
    public float limiteZGauche = -0.8f;
    public float limiteZHaut = 4f;

    // https://gamedevbeginner.com/input-in-unity-made-easy-complete-guide-to-the-new-system/#player_input_component_send_messages <-- Source du code ci-dessous

    public Vector2 moveVal;
    public float moveSpeed;

    void OnMove(InputValue value)
    {
        moveVal = value.Get<Vector2>();
    }

    void Update()
    {
        
        // Debug.Log("x: " + joueur.transform.position.x);
        // Debug.Log("z: " + joueur.transform.position.z);

        controle.transform.Translate(new Vector3(moveVal.x, 0, moveVal.y) * moveSpeed * Time.deltaTime);

        // if (joueur.transform.position.x < limiteXBas 
        // && joueur.transform.position.x > limiteXGauche
        // && joueur.transform.position.z > limiteZGauche
        // && joueur.transform.position.z < limiteZHaut) {
        //    controle.transform.Translate(new Vector3(moveVal.x, 0, moveVal.y) * moveSpeed * Time.deltaTime);
        // } else {
        //     Debug.Log("Out");
        // }
    }
}