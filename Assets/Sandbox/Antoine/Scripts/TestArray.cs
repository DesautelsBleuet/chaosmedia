using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TestArray : MonoBehaviour
{
    string[] contentArray = new string[] {};
    Dictionary<string, string[]> repasArray = new Dictionary<string, string[]>();

    //----------Repas
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
            string[] ingredientsNeeded = repasArray.ElementAt(i).Value;
            List<string> allNeeded = new List<string>();
            string done = "false";

            foreach (var ingredient in ingredientsNeeded)
            {
                allNeeded.Add(ingredient);
            }   
            
            if (contentArray.Count() > 0) {
                foreach (var ingredient in contentArray)
                    {
                    if (!ingredientsNeeded.Contains(ingredient)) {
                            done = "false";
                            break;
                        } else {
                            done = "half";
                            allNeeded.Remove(ingredient);
                            if (allNeeded.Count == 0) {
                                done = "true";
                            }
                        }
                    }
            } else {
            done = "half";
            }

        if (done == "false")
            {
                Debug.Log(repas);
                Debug.Log("ne peut pas être fait");
            } else if (done == "half") {
                
                Debug.Log(repas);
                Debug.Log("n'est pas terminé");
                Debug.Log("il manque:");
                foreach (var item in allNeeded)
                {
                    Debug.Log(item);
                }
            } else if (done == "true") {
                Debug.Log(repas);
                Debug.Log("est terminé");
            }

            Debug.Log("---------Prochain repas-----------");
        }

    }
}
