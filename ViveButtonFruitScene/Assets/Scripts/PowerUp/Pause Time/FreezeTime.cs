using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeTime : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Katana")
        {
            Debug.Log("Collision On SlowDown Object");
            Time.timeScale = 0.0f;
        }
        
    }
}
