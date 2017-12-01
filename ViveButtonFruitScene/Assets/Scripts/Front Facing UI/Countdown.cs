using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Countdown : MonoBehaviour {
    Text Countdown1;
	// Use this for initialization
	void Start () {
        Countdown1 = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        float time = (99 - Time.time);
        if (time > 0)
        {
            Countdown1.text = time.ToString();
        }
        else if(time <= 0)
        {
            Countdown1.text = "Game over!";
        }
        else
        {

        }
	}
}
