using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioTemplate : MonoBehaviour
{
    /*Placer les éléments suivant dans le script qui génère l'action
    *   GameManager.cs pour les sons généraux
    *   Mouvement.cs pour les sons générés par le personnage
    *   Voir programmeurs pour savoir où mettre les appels exactements
    */
    public GameObject musiqueFond; //Mettre ici tous les Game Ojects des sons

    void Méthode()
    {
        //Utiliser la ligne suivant pour appeller un son
        musiqueFond.SendMessage("Jouer"); //Répéter pour chaque Game Object
    }
}
