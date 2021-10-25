using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public void DebutPartie()
    {
        SceneManager.LoadScene("scene_alpha"); //charger la scène alpha
    }
}
