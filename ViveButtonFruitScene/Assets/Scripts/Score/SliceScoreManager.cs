using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceScoreManager : MonoBehaviour {
    public static SliceScoreManager instance;
    int _Slices = 0;
    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    private void OnEnable()
    {
        SwordCutter.onSliced += sliceTracker;
    }
    private void OnDisable()
    {
        SwordCutter.onSliced -= sliceTracker;
    }
    void sliceTracker()
    {
        //oncollision increment slices
        _Slices++;
    }
    public int getFinalSliceCount()
    {
        return _Slices;
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(_Slices);
	}
}
