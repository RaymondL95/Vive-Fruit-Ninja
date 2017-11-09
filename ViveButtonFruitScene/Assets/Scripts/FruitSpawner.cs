using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour {

    public GameObject[] fruitPrefab;
	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnFruit());
	}
	

    IEnumerator SpawnFruit()
    {
        while (true)
        {
            GameObject go = Instantiate(fruitPrefab[Random.Range(0, fruitPrefab.Length)]);
            Rigidbody temp = go.GetComponent<Rigidbody>();

            temp.velocity = new Vector3(0f, 5f, .5f);
            temp.angularVelocity = new Vector3(Random.Range(-5f, 5f), 0f, Random.Range(-5f, 5f));
            temp.useGravity = true;

            Vector3 pos = transform.position;
            pos.x += Random.Range(-1f, 1f);
            go.transform.position = pos;

            yield return new WaitForSeconds(1f);
        }

    }
	// Update is called once per frame
	void Update () {
		
	}
}
