using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text.RegularExpressions;

public class AudioDelegates : MonoBehaviour {
    [SerializeField] private Slider VolumeSlider;
    [SerializeField] private Button StartMusic;
    [SerializeField] private Button StopMusic;
    [SerializeField] private Dropdown dropdown;
    [SerializeField] private Button PlayRandomMusic;
    AudioSource Audi;
    private Object[] items;
    private void OnEnable()
    {
        PlayRandomMusic.onClick.AddListener(delegate { onPlayRandomMusic(); });
        StartMusic.onClick.AddListener(delegate { onPlayMusic(); });
        StopMusic.onClick.AddListener(delegate { onStopMusic(); });
        VolumeSlider.onValueChanged.AddListener(delegate { onVolumeChanged(); });
        dropdown.onValueChanged.AddListener(delegate { onDropDown(); });
    }
    public void onDropDown()
    {
        Debug.Log(dropdown.value);
        items = Resources.LoadAll("Sound", typeof(AudioClip));
        Audi.clip = (AudioClip)items[dropdown.value];
        Audi.Play();
    }
    public void onPlayMusic()
    {
        AudioManager.instance.PlayMusic();
    }
    public void onStopMusic()
    {
        AudioManager.instance.StopMusic();
    }
    public void onVolumeChanged()
    {
       Audi.volume = VolumeSlider.value;
    }
    public void onPlayRandomMusic()
    {
        AudioManager.instance.PlayRandom();
    }
    // Use this for initialization
    void Start () {
        if(GameObject.Find("Audio Manager") != null)
        {
            Debug.Log("Found Audio Manager");
            GameObject _Audi = GameObject.Find("Audio Manager");
            Debug.Log("Attempting To Connect To Audio Source");
            Audi = _Audi.GetComponent<AudioSource>();
        }
        else
        {
            Debug.Log("Audio Manager Not Found!");
        }    
            
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
