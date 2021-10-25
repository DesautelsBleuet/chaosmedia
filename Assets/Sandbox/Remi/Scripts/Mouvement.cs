using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Mouvement : MonoBehaviour
{
    private CharacterController controller;
    private PlayerInput playerInput;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2f;
    
    private float gravityValue = -9.81f;

    private float controllerHeight = 4f;
    
    [Header("Animations")]
    public Animator animPorte;
    public Animator animStove;
    public Animator animFour;

    [Header("Hotspots")]
    public HotSpot scriptHot;
    public HotSpot scriptHot2;
    public HotSpot scriptHot3;

    
    //Limites de jeu
    private float limiteXPos = 18f;
    private float limiteXNeg = 7.7f;
    private float limiteZPos = -0.9f;
    private float limiteZNeg = -10f;


    private void Start()
    {
       
        controller = gameObject.AddComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        controller.height = controllerHeight;
    }

    void Update()
    {
        
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 input = playerInput.actions["Move"].ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0, input.y);
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

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

    
    public void Ouvrir(InputAction.CallbackContext context)
    {

        if (context.performed && scriptHot.anim == true)
        {
            
            animPorte.SetTrigger("Play");
            
        }else if(context.performed && scriptHot2.anim == true){
            
            
            animStove.SetTrigger("Play");
        }
        else if(context.performed && scriptHot3.anim == true){
            
            
            animFour.SetTrigger("Play");
        }     
        
    }

    
}
