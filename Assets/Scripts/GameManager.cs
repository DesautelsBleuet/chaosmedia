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
    Dictionary<string, float> timersArray = new Dictionary<string, float>();

    [Header("Ingrédients des repas")]
    [ShowOnly] public string[] burgerIngredients = new string[] {"fromage", "pain", "viande", "laitue", "tomate"};
    private float burgerTimer = 30f;

    [ShowOnly] public string[] platViandeIngredients = new string[] {"viande","laitue"};
    private float platViandeTimer = 30f;

    [ShowOnly] public string[] brochetteIngredients = new string[] {"viande", "laitue", "tomate"};
    private float brochetteTimer = 30f;

    [ShowOnly] public string[] sandwichIngredients = new string[] {"pain", "viande", "tomate", "laitue"};
    private float sandwichTimer = 30f;

    [ShowOnly] public string[] saladeIngredients = new string[] {"laitue", "tomate", "fromage"};
    private float saladeTimer = 30f;

    [ShowOnly] public string[] croqueMonsieurIngredients = new string[] {"fromage", "pain", "viande"};
    private float croqueMonsieurTimer = 30f;

    [ShowOnly] public string[] jelloIngredients = new string[] {"jus"};
    private float jelloTimer = 30f;

    private float scoreTotal = 0f;
    private int repasChoisi;

    private float timer;
    private float timerTotal;
    private float scoreRepas;
    bool tempsEnCours = false;

    bool repasEstTermine = true;


    void Start() {
        //Ajout repas
        repasArray.Add("burger", burgerIngredients);
        timersArray.Add("burger", burgerTimer);

        repasArray.Add("platViande", platViandeIngredients);
        timersArray.Add("platViande", platViandeTimer);

        repasArray.Add("brochette", brochetteIngredients);
        timersArray.Add("brochette", brochetteTimer);

        repasArray.Add("sandwich", sandwichIngredients);
        timersArray.Add("sandwich", sandwichTimer);

        repasArray.Add("salade", saladeIngredients);
        timersArray.Add("salade", saladeTimer);

        repasArray.Add("croqueMonsieur", croqueMonsieurIngredients);
        timersArray.Add("croqueMonsieur", croqueMonsieurTimer);

        repasArray.Add("jello", jelloIngredients);
        timersArray.Add("jello", jelloTimer);



        //Choix du repas
        repasChoisi = Random.Range(1, repasArray.Count);
        scoreRepas = timersArray.ElementAt(repasChoisi).Value;
        timer = timersArray.ElementAt(repasChoisi).Value;
        timerTotal = timer;
        tempsEnCours = true;
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
                repasEstTermine = true;
            }
        }

    }

    void Juger() {
        float tempsCourant = timer/timerTotal;

        if (repasEstTermine) {
            if (tempsCourant > 0.5) {
                tempsEnCours = false;
                scoreTotal += scoreRepas*110;
                repasEstTermine = false;
                Debug.Log(scoreTotal);
            } 
            else if (tempsCourant > 0) {
                tempsEnCours = false;
                scoreTotal += scoreRepas*50;
                repasEstTermine = false;
                Debug.Log(scoreTotal);
            } 
            else {
                tempsEnCours = false;
                scoreTotal -= scoreRepas*110;
                repasEstTermine = false;
                Debug.Log(scoreTotal);
            }
        }
    }


    void Update()
    {
        //Timer
        if (tempsEnCours)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else {
                Juger();
                timer = 0;
                tempsEnCours = false;
            }
        }
    }

}
