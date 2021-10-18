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
    private float playerSpeed = 150.0f;
    
    private float gravityValue = -9.81f;

    private float controllerHeight = 4.11f;
    
    public Animator animPorte;

    public HotSpot scriptHot;
    
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
    }

    
    public void Ouvrir(InputAction.CallbackContext context)
    {

        if (context.performed && scriptHot.anim == true)
        {
            Debug.Log("dasd");
            animPorte.SetTrigger("Play");
        }
            
        
    }

    
}
