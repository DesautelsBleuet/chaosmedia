using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    //pain, viande, fromage, tomate, laitue, jus
    List<string> ingredientsChoisis = new List<string>();
    Dictionary<string, string[]> repasArray = new Dictionary<string, string[]>();

    //----------Repas
    string[] burgerArray = new string[] {"fromage", "pain", "viande", "laitue", "tomate"};
    string[] platViandeArray = new string[] {"viande","laitue"};
    string[] brochetteArray = new string[] {"viande", "laitue", "tomate"};
    string[] sandwichArray = new string[] {"pain", "viande", "tomate", "laitue"};
    string[] saladeArray = new string[] {"laitue", "tomate", "fromage"};
    string[] croqueMonsieurArray = new string[] {"fromage", "pain", "viande"};
    string[] jelloArray = new string[] {"jus"};

    void Start() {
        //Ajout repas
        repasArray.Add("burger", burgerArray);
        repasArray.Add("platViande", platViandeArray);
        repasArray.Add("brochette", brochetteArray);
        repasArray.Add("sandwich", sandwichArray);
        repasArray.Add("salade", saladeArray);
        repasArray.Add("croqueMonsieur", croqueMonsieurArray);
        repasArray.Add("jello", jelloArray);
    }

    void ajoutIngredient(string ingredient) {
        ingredientsChoisis.Add(ingredient);
        verifierRepas();
    }

    void verifierRepas()
    {
      
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
            
            if (ingredientsChoisis.Count() > 0) {
                foreach (var ingredient in ingredientsChoisis)
                    {
                    if (!ingredientsNeeded.Contains(ingredient)) {
                            done = "false";
                            break;
                        } else {
                            done = "pasComplete";
                            allNeeded.Remove(ingredient);
                            if (allNeeded.Count == 0) {
                                done = "true";
                            }
                        }
                    }
            } else {
            done = "pasComplete";
            }

        if (done == "false")
            {
                Debug.Log(repas + " ne peut pas être fait"); //Changer pour output
            } else if (done == "pasComplete") {
                
                Debug.Log(repas + " n'est pas terminé, il manque:");
                foreach (var item in allNeeded)
                {
                    Debug.Log(item); //Changer pour output
                }
            } else if (done == "true") {
                Debug.Log(repas + "est terminé"); //Changer pour output
            }
        }

    }

}
