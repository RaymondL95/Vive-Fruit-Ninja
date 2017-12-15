using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleFruit : MonoBehaviour {
    public float DoubleFruitDuration = 5f;
    public FruitSpawner fruitspawner;
    bool StartAction = false;
    float SingleFruitTimer = 0f;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Fruit")
        {
            SingleFruitTimer = 0f;
            Debug.Log("Banana Collision");
            StartAction = true;
            fruitspawner.setDoubleFruit(StartAction);
            StartCoroutine(BuffDuration());
        }
    }
    IEnumerator BuffDuration()
    {
        yield return new WaitForSeconds(DoubleFruitDuration);
        StartAction = false;
        fruitspawner.setDoubleFruit(StartAction);
    }
   
        
    
  

}
