using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class MiniJeux : MonoBehaviour
{

    public GameObject scriptMouvement;
    
    private Mouvement mouvement;
    void Start()
    {
      mouvement = scriptMouvement.GetComponent<Mouvement>();
      
    }

    
    void Update(){
        
    }
}
