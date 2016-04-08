using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public Rigidbody projectile; 
	public float speed = 20;
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetButtonDown("Fire1")){

			Rigidbody istantiatedProj = Instantiate (projectile, transform.position, transform.rotation)as Rigidbody;

			Physics.IgnoreCollision (istantiatedProj.GetComponent<Collider>(), GetComponent<Collider>());
			istantiatedProj.velocity = transform.TransformDirection (new Vector3(0,0,speed));

		}

	}

}
