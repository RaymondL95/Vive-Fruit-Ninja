using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suction : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter(Collision collision)
    {
        collision.rigidbody.isKinematic = true;
        collision.rigidbody.useGravity = false;
        //  collision.transform.position = Vector3.Lerp(collision.transform.position, Vector3.zero,0.03f);
        collision.transform.position = new Vector3(Random.Range(-0.5f,1.0f), 1f, 9f);
          StartCoroutine(UnFreeze(collision));
    }
    private void  OnCollisionExit(Collision collision)
    {
        collision.rigidbody.isKinematic = false;
        collision.rigidbody.useGravity = true;
    }
    IEnumerator UnFreeze(Collision collision)
    {
        yield return new WaitForSeconds(10f);
        transform.gameObject.SetActive(false);
        
    }


}
