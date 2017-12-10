using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderEvent : MonoBehaviour {
    Slider slider;
    float _PassiveRegen = 0.001f;
    public GameObject swordcutter;
    SwordCutter sword;
    private void OnEnable()
    {
        SwordCutter.onSliced += SliderAction;
    }

    private void OnDisable()
    {
        SwordCutter.onSliced -= SliderAction;
    }
    private void Start()
    {
        slider = GetComponent<Slider>();
        sword = swordcutter.GetComponent<SwordCutter>();
    }
    void SliderAction()
    {
        //oncollision with fruit increase slider.
        slider.value += .03f;
    }
    public void setSliderValue(float newslidervalue)
    {
        slider.value = newslidervalue;
    }
    public float getSliderValue()
    {
        return slider.value;
    }
    private void Update()
    {
        slider.value += _PassiveRegen * Time.deltaTime;
        if(slider.value == 1f)
        {
            sword.SetSpecialAbility(true);
        }
    }
 
}
