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
    bool usingSpecialAbility = false;
    [SerializeField] private GameObject Sphere;
    private void Awake()
    {
        slider.onValueChanged.AddListener(delegate { OnFruitSliced(); });
    }
    private void OnDestroy()
    {
        slider.onValueChanged.RemoveListener(delegate { OnFruitSliced(); });
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
        //Increase SLider if sphere is not active.
        if(usingSpecialAbility == false)
        {
            slicecount++;
            collisionCounter.text = "Fruits Sliced: " + slicecount;
            slider.value += .15f;
        }
    }
    void OnFruitSliced()
    {
        if (slider.value == 1)
        {
            haveSpecialAbility = true;
        }
    }
    private void Update()
    {
        if(haveSpecialAbility)
        {        
            if (Input.GetKeyDown("space"))
            {
                haveSpecialAbility = !haveSpecialAbility;
                slider.value = 0;
                StartCoroutine(SpawnSphere());
               // Sphere.SetActive(false);
            }
        }
    }
    IEnumerator SpawnSphere()
    {
        usingSpecialAbility = true;
        Sphere.SetActive(true);
        Debug.Log("Before Wait For Seconds" + usingSpecialAbility);
        yield return new WaitForSeconds(10f);
        Sphere.SetActive(false);
        usingSpecialAbility = false;
        Debug.Log("after Wait For Seconds" + usingSpecialAbility);
    }

    
}
