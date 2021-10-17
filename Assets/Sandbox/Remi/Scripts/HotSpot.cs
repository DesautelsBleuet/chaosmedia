using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotSpot : MonoBehaviour
{
    public Animator animPorte;
    
    public bool anim;

    
    
    private void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            animPorte.SetTrigger("Play");
            anim = true;
        }
    }
}
