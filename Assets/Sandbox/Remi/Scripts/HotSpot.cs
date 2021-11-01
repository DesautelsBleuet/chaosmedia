using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotSpot : MonoBehaviour
{
    public Animator animPorte;
    public Animator animStove;

    public Animator animFour;
    public bool anim;

    
    void OnTriggerExit(Collider other){
if(other.tag == "Player"){
            anim = false;
            animPorte.SetBool("Touche", false);
            animStove.SetBool("Touche", false); 
            animFour.SetBool("Touche", false);
        }   
    }
    void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            anim = true;
            animStove.SetBool("Touche", true);
            animPorte.SetBool("Touche", true); 
            animFour.SetBool("Touche", true);
        }
    }

}
