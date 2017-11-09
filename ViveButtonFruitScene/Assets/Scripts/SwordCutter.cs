using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class SwordCutter : MonoBehaviour {

    public Text collisionCounter;
    public Slider slider;
    public Material capMaterial;
    int slicecount = 0;
    bool haveSpecialAbility = false;
    private void Awake()
    {
        slider.onValueChanged.AddListener(delegate { OnFruitSliced(); });
    }
    private void OnDestroy()
    {
        slider.onValueChanged.RemoveListener(delegate { OnFruitSliced(); });
    }
    void OnFruitSliced()
    {
        Debug.Log(slider.value);
        if (slider.value == 1)
        {
            haveSpecialAbility = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
        UpdateFruitCount();
        GameObject victim = collision.collider.gameObject;

        GameObject[] pieces = BLINDED_AM_ME.MeshCut.Cut(victim, transform.position, transform.right, capMaterial);
        if(!pieces[1].GetComponent<Rigidbody>())
        {
            pieces[1].AddComponent<Rigidbody>();
            MeshCollider temp = pieces[1].AddComponent<MeshCollider>();
            temp.convex = true;
        }

        Destroy(pieces[1], 1);
    }
    void UpdateFruitCount()
    {
        slicecount++;
        collisionCounter.text = "Fruits Sliced: " + slicecount;
        slider.value += .15f;
    }
    private void Update()
    {
        if(haveSpecialAbility)
        {        
            if (Input.GetKeyDown("space"))
            {
                haveSpecialAbility = !haveSpecialAbility;
                slider.value = 0;
                
                Debug.Log("Hello");
            }
        }
    }

    
}
