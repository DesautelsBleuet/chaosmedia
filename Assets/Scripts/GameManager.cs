using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using NativeWebSocket;


public class GameManager : MonoBehaviour
{

    WebSocket websocket;

    

    

    public void Start(){


        websocket = new WebSocket("ws://chaosmedia.herokuapp.com/socket/4");

        websocket.OnOpen += () =>
        {
            
            websocket.SendText("dasdad­­");
        };
        websocket.OnMessage += (bytes) =>
    {
        var message = System.Text.Encoding.UTF8.GetString(bytes);
        Debug.Log(message); 
        // dynamic json = JsonConvert.DeserializeObject(message);

        // string code = (string)json.SelectToken("code");
        // json data = (json)json.SelectToken("data");

        // if(code == "__joined__") {
        //     Debug.Log("Vous avez rejoint la partie.");
        // }

    };
    }
    public void DebutPartie()
    {
        SceneManager.LoadScene("scene_alpha"); //charger la scène alpha
        
    }
}
