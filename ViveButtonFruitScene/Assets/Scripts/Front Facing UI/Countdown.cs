using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Countdown : MonoBehaviour {
    Text Countdown1;
    public int countfrom = 99;
	// Use this for initialization
	void Start () {
        Countdown1 = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        int time = (int)(countfrom - Time.time);
        if (time > 0)
        {
            Countdown1.text = time.ToString();
        }
        else if(time <= 0)
        {
            Countdown1.text = "Game over!";
            StartCoroutine(ShowScore());
        }
        else
        {

        }
	}

    IEnumerator ShowScore()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Score");
    }
}
