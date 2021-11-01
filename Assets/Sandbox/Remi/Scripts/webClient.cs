using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;

public class webClient : MonoBehaviour
{
    WebSocket ws;
    private int y = 0;
    private int x = 0;

    void Start()
    {
        ws = new WebSocket("ws://chaosmedia.herokuapp.com/socket/1");
        

        ws.OnOpen += (sender, e) => {
            ws.Send("{\"code\":\"__join__\",\"action\":\"\",\"data\":\"\"}");
        };
        ws.OnMessage += (sender, e) => {
            Debug.Log(e.Data);
        };

        ws.Connect();
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
