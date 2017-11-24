using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour {
    public static AudioManager instance;
    AudioSource _audio;
    public AudioClip[] list;
    private Object[] items;
    bool pressedPause = false;
    
    private void Awake()
    {
        if(instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        //Resources.LoadAll returns a Object[] cast as AudioClip
        items = Resources.LoadAll("Sound", typeof(AudioClip));
         _audio.clip = (AudioClip)items[Random.Range(0, items.Length)];
         _audio.Play();
        
    }
   public void PlayRandom()
    {
        _audio.clip = (AudioClip)items[Random.Range(0, items.Length)];
        _audio.Play();
    }
    public void StopMusic()
    {
        pressedPause = true;
        _audio.Pause();
    }
    public void PlayMusic()
    {
        pressedPause = false;
        _audio.UnPause();
    }
    private void Update()
    {
        if (!_audio.isPlaying && !pressedPause)
        {
            _audio.clip = (AudioClip)items[Random.Range(0, items.Length)];
            _audio.Play();
        }
    }

}
