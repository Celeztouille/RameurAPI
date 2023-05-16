using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Concept2API;
using TMPro;


public class Test : MonoBehaviour
{
         private List<Concept2Device> devices = new List<Concept2Device>();

         private TextMeshProUGUI debug;


         private void Awake()
         {
             debug = GameObject.Find("Debug").GetComponent<TextMeshProUGUI>();
         }

         /* Initialise */
        void Start()
        {
            debug.text = "start";
            //Initialise connection(s)
            ushort deviceCount = Concept2Device.Initialize("Concept2 Performance Monitor 5 (PM5)", debug);
           // debug.text = "Monitoring " + deviceCount + " Concept2 devices!";

            //Start up API(s)
            for (ushort i = 0; i < deviceCount; i++)
            {
                devices.Add(new Concept2Device(i));
                devices[i].Reset();
            }
        }
        
        void Update()
        {
            for (int i = 0; i < devices.Count; i++)
            {
                devices[i].UpdateData();
                debug.text = "Device " + i + ":" +
                            "\n    Phase: " + devices[i].GetStrokePhase() +
                            "\n    Distance: " + devices[i].GetDistance() +
                            "\n    Drag: " + devices[i].GetDrag() +
                            "\n    Power: " + devices[i].GetPower() +
                            "\n    Time: " + devices[i].GetTime();
            }
        }
}
