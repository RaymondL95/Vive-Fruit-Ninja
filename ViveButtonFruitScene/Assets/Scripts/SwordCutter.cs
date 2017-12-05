using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class SwordCutter : MonoBehaviour {
    public delegate void SliceAction();
    public static event SliceAction onSliced;
    public Material capMaterial;

    private bool haveSpecialAbility = false;
	bool usingSpecialAbility = false;

    private void OnCollisionEnter(Collision collision)
    {
        //Check for all subscribed events
        onSliced.Invoke();

     
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

	public void SetSpecialAbility(bool isSpecial){
		haveSpecialAbility = isSpecial;
	}
    
	public bool GetSpecialAbility(){
		return haveSpecialAbility;
	}
}
