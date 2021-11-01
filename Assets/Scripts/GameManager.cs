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

    [Header("Ingrédients des repas")]
    [ShowOnly] private string[] burgerIngredients = new string[] {"fromage", "pain", "viande", "laitue", "tomate"};
   [ShowOnly] private string[] platViandeIngredients = new string[] {"viande","laitue"};
   [ShowOnly] private string[] brochetteIngredients = new string[] {"viande", "laitue", "tomate"};
   [ShowOnly] private string[] sandwichIngredients = new string[] {"pain", "viande", "tomate", "laitue"};
   [ShowOnly] private string[] saladeIngredients = new string[] {"laitue", "tomate", "fromage"};
   [ShowOnly] private string[] croqueMonsieurIngredients = new string[] {"fromage", "pain", "viande"};
   [ShowOnly] private string[] jelloIngredients = new string[] {"jus"};

    private float scoreTotal = 0;

    void Start() {
        //Ajout repas
        repasArray.Add("burger", burgerIngredients);
        repasArray.Add("platViande", platViandeIngredients);
        repasArray.Add("brochette", brochetteIngredients);
        repasArray.Add("sandwich", sandwichIngredients);
        repasArray.Add("salade", saladeIngredients);
        repasArray.Add("croqueMonsieur", croqueMonsieurIngredients);
        repasArray.Add("jello", jelloIngredients);
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
