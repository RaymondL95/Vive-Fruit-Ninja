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
            fruitspawner.setDoubleFruit(true);
        }
    }
    private void Update()
    {
        if (StartAction)
        {
            SingleFruitTimer += Time.time;
            Debug.Log(SingleFruitTimer);
            if(SingleFruitTimer >= DoubleFruitDuration)
            {
            //    StartAction = !StartAction;
                fruitspawner.setDoubleFruit(false);
            }
        }
        
    }

}
