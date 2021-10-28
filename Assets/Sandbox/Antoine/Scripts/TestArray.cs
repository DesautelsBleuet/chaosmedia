using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TestArray : MonoBehaviour
{
    string[] contentArray = new string[] {"fromage", "pain", "viande", "laitue", "tomate"};
    Dictionary<string, string[]> repasArray = new Dictionary<string, string[]>();

    //----------Repas
    //Brochette
    string[] brochetteArray = new string[] {"viande", "laitue", "tomate"};
    string[] burgerArray = new string[] {"fromage", "pain", "viande", "laitue", "tomate"};
    string[] croqueMonsieurArray = new string[] {"fromage", "pain", "viande"};
    string[] jelloArray = new string[] {"jello"};
    string[] platViandeArray = new string[] {"viande"};
    string[] saladeArray = new string[] {"laitue", "tomate"};

    void Start()
    {
        //Ajout repas
        repasArray.Add("brochette", brochetteArray);
        repasArray.Add("burger", burgerArray);
        repasArray.Add("croqueMonsieur", croqueMonsieurArray);
        repasArray.Add("jello", jelloArray);
        repasArray.Add("platViande", platViandeArray);
        repasArray.Add("salade", saladeArray);
       
       for (int i = 0; i < repasArray.Count; i++)
       {
            string repas = repasArray.ElementAt(i).Key;
            Debug.Log(repas);
            
        }
        
        
    }

}
