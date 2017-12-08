using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MeterReset : MonoBehaviour {
    [SerializeField] private Slider SliderReference;
	// Use this for initialization
	void Start () {
        SliderReference = GetComponent<Slider>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter(Collision collision)
    {
        SliderReference.value = 0f;
    }
}
