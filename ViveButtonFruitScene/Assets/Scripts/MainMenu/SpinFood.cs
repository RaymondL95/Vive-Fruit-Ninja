using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinFood : MonoBehaviour {
    public float offset;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.right * Time.deltaTime * offset);
    }
}
