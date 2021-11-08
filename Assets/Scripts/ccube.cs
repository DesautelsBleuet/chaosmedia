using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ccube : MonoBehaviour
{
    public Transform objectToFollow;
    public Vector3 offset;
    
    void FixedUpdate(){
       transform.position = objectToFollow.position + offset;
    }

}
