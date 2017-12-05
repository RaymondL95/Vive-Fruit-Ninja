using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeTime : MonoBehaviour {
    bool isHit;
	// Use this for initialization
	void Start () {
        isHit = false;
	}

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.tag != "Fruit")
        {
            isHit = true;
            if(isHit)
            {

            }
            Time.timeScale = 0f;
            StartCoroutine(SlowTime());
        }
        
    }
    IEnumerator SlowTime()
    {
        yield return new WaitForSeconds(5f);
        Time.timeScale = 1.0f;
    }
}
