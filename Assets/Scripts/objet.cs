using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objet : MonoBehaviour
{
    public Transform objectToFollow;
    public Vector3 offset;
    
    void FixedUpdate(){
       transform.position = objectToFollow.position + offset;
    }

}