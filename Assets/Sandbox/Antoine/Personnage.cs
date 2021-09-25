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

    // https://gamedevbeginner.com/input-in-unity-made-easy-complete-guide-to-the-new-system/#player_input_component_send_messages <-- Source du code ci-dessous

    public Vector2 moveVal;
    public float moveSpeed;

    void OnMove(InputValue value)
    {
        moveVal = value.Get<Vector2>();
    }

    void Update()
    {
        controle.transform.Translate(new Vector3(moveVal.x, 0, moveVal.y) * moveSpeed * Time.deltaTime);
    }
}