using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YourScore : MonoBehaviour {
    SliceScoreManager slicecounttracker;
    GameObject SliceManager;
    Text scoretxt;
    int finalslicecount;
	// Use this for initialization
	void Start () {
        if (GameObject.Find("SliceCountTracker"))
        {
            SliceManager = GameObject.Find("SliceCountTracker");
        }
        slicecounttracker = SliceManager.GetComponent<SliceScoreManager>();
        finalslicecount = slicecounttracker.getFinalSliceCount();
        scoretxt = GetComponent<Text>();
        WhatsMyScore(finalslicecount);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void WhatsMyScore(int finalscore)
    {
        Debug.Log("Whats my score running");
        if(finalslicecount <= 100)
        {
            scoretxt.text = "You sliced " + finalslicecount + " times. You can do better than that!";
        }
        else if(finalslicecount >100 && finalslicecount < 500)
        {
            scoretxt.text = "You sliced " + finalslicecount + " times. Hey that's pretty good!";
        }
        else
        {
            scoretxt.text = "You sliced " + finalslicecount + " times. ARE YOU A BLENDER?";
        }
    }
    
}
