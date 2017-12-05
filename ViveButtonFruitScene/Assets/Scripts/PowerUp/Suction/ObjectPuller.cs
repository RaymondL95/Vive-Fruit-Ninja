  using UnityEngine;
     using System.Collections;

  

public class ObjectPuller : MonoBehaviour
{
		public float pullRadius = 2;
		public float pullForce = 1;

		public void FixedUpdate() {
		foreach (Collider collider in Physics.OverlapSphere(transform.position, pullRadius)) {
				// calculate direction from target to me
            if(collider.gameObject.tag == "Fruit")
            {
                Vector3 forceDirection = transform.position - collider.transform.position;
                Renderer rend = collider.GetComponent<Renderer>();

                if (collider.GetComponent<Rigidbody>() != null && rend.bounds.size.x > 0.3f)
                {
                    // apply force on target towards me

                    collider.GetComponent<Rigidbody>().AddForce(forceDirection.normalized * pullForce * Time.fixedDeltaTime);
                }
            }
				



			//get the squared distance between the objects
//			float magsqr = offset.sqrMagnitude;
//
//			//check distance is more than 0 (to avoid division by 0) and then apply a gravitational force to the object
//			//note the force is applied as an acceleration, as acceleration created by gravity is independent of the mass of the object
//			if(magsqr > 0.0001f)
//				rigidbody2D.AddForce(strengthOfAttraction * offset.normalized / magsqr, ForceMode.Acceleration);

//			
			}
				}
				}
