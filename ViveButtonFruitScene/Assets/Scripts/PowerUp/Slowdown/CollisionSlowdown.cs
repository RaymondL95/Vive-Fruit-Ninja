using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSlowdown : MonoBehaviour {
    public Slowdown slowdown;
    public float DestroyFruitTime = 3f;
    AudioSource slowdownsound;
    private void Start()
    {
        slowdownsound = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Test");
        if(collision.gameObject.tag != "Fruit")
        {
            Debug.Log("Tomato has been struck");
            slowdown.SlowMotion();
            slowdownsound.Play();
            Destroy(gameObject, DestroyFruitTime);
        }


    }
}
