using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempAudio : MonoBehaviour
{
   public AudioSource audioData;

    void Start()
 {audioData = GetComponent<AudioSource>();}

   void test() {
     audioData.Play(0);
   }
}
