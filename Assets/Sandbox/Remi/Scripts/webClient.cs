using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;

public class webClient : MonoBehaviour
{
    WebSocket ws;
    private bool isConnected = false;

    // TODO
    // - Ajouter la function pour quitter la partie
    // - Ajouter la function pour le bouton d'interaction
    // - Configurer le god pour bien recevoir les infos du jeu


    void Start()
    {
        ws = new WebSocket("ws://chaosmedia.herokuapp.com/socket/1");
        

        ws.OnOpen += (sender, e) => {
            Debug.Log("essaie de se connecter");
            ws.Send("__join__");
        };
        ws.OnMessage += (sender, e) => {
            // Debug.Log(e.Data);
            string data = e.Data;
            string[] infos = data.Split('|');

            string code = infos[0];

            if(code == "__joined__") {

                isConnected = true;
                InvokeRepeating("SendPing", 1.0f, 0.5f);
                Debug.Log("Connecté à la partie.");

            }else if(code == "__too_many_players__") {
                Debug.Log("Deja trop de joueur");
            }else{
                Debug.Log(data);
            }

        };

        ws.OnError += (sender, e) => {
            Debug.Log(e.Message);
        };

        ws.OnClose += (sender, e) => {
            Debug.Log(e.Code);
            Debug.Log(e.Reason);
        };

        ws.Connect();
    }

    void SendPing() {
        if(isConnected == true) {
            ws.Send("__ping__");
        }
    }

    public void HandleWSMovements(float x, float y) {
        if(isConnected == true) {
            ws.Send("__move__|x:"+x+";y:"+y);
        }
    }



    // Update is called once per frame
    void Update()
    {
        // string pos = "{\"x\":\"" + x + "\",\"y\":\"" + y + "\"}";
        // x++; y++;
        // string data = "{\"code\":\"__action__\",\"action\":\"move\",\"data\":\"" + pos + "\"}";
        // Debug.Log(data);
        // ws.Send(data);
        
    }
}
