using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceCountTracker : MonoBehaviour {
    public int slices;
    SliceCountEvent _slices;
    // Use this for initialization
    private void OnEnable()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        slices= _slices.slicecount;
	}
}
