using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inputs : MonoBehaviour {
    [SerializeField] private Slider _slider;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("x"))
        {
            _slider.value = 1f;
        }
	}
}
