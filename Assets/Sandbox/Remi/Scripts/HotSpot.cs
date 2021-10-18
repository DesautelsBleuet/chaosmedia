using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotSpot : MonoBehaviour
{
    public Animator animPorte;
    
    public bool anim;

    
    void OnTriggerExit(Collider other){
if(other.tag == "Player"){
            anim = false;
            animPorte.SetBool("Touche", false); 
        }   
    }
    void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            anim = true;
            animPorte.SetBool("Touche", true); 
        }
    }

}
