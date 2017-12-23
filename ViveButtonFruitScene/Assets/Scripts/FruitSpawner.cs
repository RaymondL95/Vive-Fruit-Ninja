using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour {

    public GameObject[] fruitPrefab;
    public float spawn_range = 1f;
    private bool doubleFruit = false;
    AudioSource _Audi;
	// Use this for initialization
	void Start () {
        _Audi = GetComponent<AudioSource>();
        StartCoroutine(SpawnFruit());
	}
	

    IEnumerator SpawnFruit()
    {
        while (true)
        {
            if (doubleFruit)
            {
                Debug.Log("Double Fruit Started");
                GameObject go1 = Instantiate(fruitPrefab[Random.Range(0, fruitPrefab.Length)]);
                Rigidbody temp1 = go1.GetComponent<Rigidbody>();

                temp1.velocity = new Vector3(0f, Random.Range(5f,5.2f), Random.Range(-1.2f,-1.5f));
                temp1.angularVelocity = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
                temp1.useGravity = true;

                Vector3 pos1 = transform.position;
                pos1.x += Random.Range(-spawn_range, spawn_range);
                go1.transform.position = pos1;

                SpawnExplosion();

                GameObject go2 = Instantiate(fruitPrefab[Random.Range(0, fruitPrefab.Length)]);
                Rigidbody temp2 = go2.GetComponent<Rigidbody>();

                temp2.velocity = new Vector3(0f, Random.Range(5f, 5.2f), Random.Range(-1.2f,-1.5f));
                temp2.angularVelocity = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
                temp2.useGravity = true;

                Vector3 pos2 = transform.position;
                pos2.x += Random.Range(-spawn_range, spawn_range);
                go2.transform.position = pos2;

                SpawnExplosion();
            }
            else
            {
                GameObject go = Instantiate(fruitPrefab[Random.Range(0, fruitPrefab.Length)]);
                Rigidbody temp = go.GetComponent<Rigidbody>();

                temp.velocity = new Vector3(0f, Random.Range(5f, 5.2f), Random.Range(-1.2f,-1.5f));
                temp.angularVelocity = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
                temp.useGravity = true;

                Vector3 pos = transform.position;
                pos.x += Random.Range(-spawn_range, spawn_range);
                go.transform.position = pos;
                SpawnExplosion();
            }
            yield return new WaitForSeconds(Random.Range(1f,3f));
        }

    }
    void SpawnExplosion()
    {
        GameObject instance1 = Instantiate(Resources.Load("Fire_Explosion_01") as GameObject);
        instance1.transform.position = transform.position;
        Destroy(instance1, 1f);
        _Audi.Play();
    }
    public void setDoubleFruit(bool newFruit)
    {
        Debug.Log("Called doublefruit set");
        Debug.Log(newFruit);
        doubleFruit = newFruit;
    }
    public bool getDoubelFruit()
    {
        return doubleFruit;
    }
	// Update is called once per frame
	void Update () {
		
	}
}
