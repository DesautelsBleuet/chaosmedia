using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tag : MonoBehaviour
{
    public Collider tagItem;
    public GameObject assiette;

    void OnTriggerEnter(Collider other){
       assiette.SendMessage("addIngredient", tagItem.tag);
    }
}
