using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SliceCountEvent : MonoBehaviour {
     int slicecount = 0;
    Text sliceText;
    private void OnEnable()
    {
        SwordCutter.onSliced += TextHandler;
    }
    private void OnDisable()
    {
        SwordCutter.onSliced -= TextHandler;
    }
    private void Start()
    {
        sliceText = GetComponent<Text>();
    }
    void TextHandler()
    {
        slicecount++;
        sliceText.text = "Slices: " + slicecount;
    }
}
