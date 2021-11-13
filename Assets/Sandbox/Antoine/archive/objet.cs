// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class objet : MonoBehaviour
// {
//     public GameObject objectToFollow;
//     public GameObject objectToMove;
//     public Vector3 offset;

//     private bool isActive = false;
    
//     void FixedUpdate(){
//         if (isActive) {
//       objectToMove.transform.position = objectToFollow.transform.position + offset;
//     }
//     }

//     void OnTriggerEnter(Collider other){
//         if(other.tag == "Player")
//             {
//             isActive = true;
//             if (!other.GetComponent<Mouvement>().isCarryingObject) {
//             other.SendMessage("objectTaken", this.gameObject);
//             }
//         }
//     }

//     void mettreAssiette(GameObject assiette) {
//         objectToFollow = assiette;
//     }

// }
