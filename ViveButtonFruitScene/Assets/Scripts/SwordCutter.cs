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
    private bool haveSpecialAbility = false;
	public float _PassiveRegen = 0.001f;
	bool usingSpecialAbility = false;

    private void Awake()
    {
    }
    private void OnDestroy()
    {
        slider.onValueChanged.RemoveListener(delegate { OnFruitSliced(); });
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Update the Fruit Count
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
        // On Collision Increase Fruit Count
        if(usingSpecialAbility == false)
        {
            slicecount++;
            collisionCounter.text = "Fruits Sliced: " + slicecount;
            slider.value += .10f;
        }
    }
    void OnFruitSliced()
    {
		//If a fruit is sliced check meter

        if (slider.value == 1)
        {
			//only have special ability if slider is MAX
			SetSpecialAbility(true);
        }
    }
    private void Update()
    {
       // Debug.Log(haveSpecialAbility);
		//Increase slider bar passively
		slider.value += _PassiveRegen * Time.deltaTime;
        
        if(slider.value == 1f)
        {
            SetSpecialAbility(true);
        }
        
    }
    IEnumerator SpawnSphere()
    {
        usingSpecialAbility = true;
      //  Sphere.SetActive(true);
        Debug.Log("Before Wait For Seconds" + usingSpecialAbility);
        yield return new WaitForSeconds(10f);
     //   Sphere.SetActive(false);
        usingSpecialAbility = false;
        Debug.Log("after Wait For Seconds" + usingSpecialAbility);
    }
	public void SetSpecialAbility(bool isSpecial){
		haveSpecialAbility = isSpecial;
	}
    
	public bool GetSpecialAbility(){
		return haveSpecialAbility;
	}
}
