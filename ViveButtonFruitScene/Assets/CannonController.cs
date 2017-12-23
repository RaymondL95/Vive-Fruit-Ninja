using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour {


    Transform spawnPoint;

    public Transform target;

    public float speed = 10f;
    Vector3 pivot_point;


    // Use this for initialization
    void Start () {
        spawnPoint = transform.FindChild("SpawnPoint") as Transform;

        pivot_point = (this.transform.position - target.position);
    }
	
	// Update is called once per frame
	void Update () {
        //// Point the object at the world origin
        //transform.LookAt(target.position);




        if (this.transform.position.x < 0)
        {
            transform.RotateAround(target.position, Vector3.up, speed * Time.deltaTime);
        }
        else
        {
            speed = -speed;
        }
            //float pivot_r = pivot_point.magnitude;

            //MoveToRadialPosition(pivot_r, Random.Range(0.1f, 0.4f));

            ////r_cannon = Mathf.Sqrt(x * x + y * y);

            ////r_target = Mathf.Sqrt(target.position.x * target.position.x + target.position.y * target.position.y);
            //// Lets rotate the cannon around an arc away from the player

            ////r_cannon.tra


            //if(this.transform.position == transform.position)
            //{
            //    Debug.Log("This is true");
            //}

        }

        //public void MoveToRadialPosition(float radius, float angle)
        //{

        //    float x = this.transform.position.x + radius*Mathf.Cos(angle);
        //    float y = this.transform.position.y + radius * Mathf.Sin(angle);
        //    float z = this.transform.position.z;

        //    this.transform.position = new Vector3(x, y, z);
        //}
    }
