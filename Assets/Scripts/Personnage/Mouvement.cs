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
    private float controllerHeight = 0f;
    private float controllerCenter = 0.66f;

    Vector2 currentMovement;
    bool movementPressed;
    
    [Header("Animations")]
    // public Animator animPorte;
    private Animator animatorPerso;

    [Header("Hotspots")]
    // public HotSpot scriptHot;

    
    //Limites de jeu
    private float limiteXPos = 5.8f;
    private float limiteXNeg = -5.7f;
    private float limiteZPos = 4.8f;
    private float limiteZNeg = -4.8f;

    int marcherHash;

    // void Awake()
    // {
    //     playerInput = new PlayerControlsBeta();
    //     playerInput.Player.Move.performed += ctx => Debug.Log(ctx.ReadValueAsObject());
    // }

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        marcherHash = Animator.StringToHash("marcher");
        controller = gameObject.AddComponent<CharacterController>();
        
        animatorPerso = GetComponent<Animator>();
        controller.height = controllerHeight;
        
        controller.center = new Vector3(0, controllerCenter, 0);
       
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

        // Calculer limites de jeu
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

        if (input.x != 0 || input.y != 0) {
            animatorPerso.SetBool("marcher", true);
        } else {
            animatorPerso.SetBool("marcher", false);
        }
    }

    void handleMovement() {
        bool marcher = animatorPerso.GetBool(marcherHash);
    }
    // void OnEnable(){
    //     playerInput.Player.Enable();
    // }

    // void OnDisable(){
    //     playerInput.Player.Disable();
    // }


    // public void Ouvrir(InputAction.CallbackContext context)
    // {

    //     //À modifier pour les animations finales

    //     // if (context.performed && scriptHot.anim == true)
    //     // {
            
    //     //     animPorte.SetTrigger("Play");
            
    //     // }else if(context.performed && scriptHot2.anim == true){
            
            
    //     //     animStove.SetTrigger("Play");
    //     // }
    //     // else if(context.performed && scriptHot3.anim == true){
            
            
    //     //     animFour.SetTrigger("Play");
    //     // }     
        
    // }

    
}
