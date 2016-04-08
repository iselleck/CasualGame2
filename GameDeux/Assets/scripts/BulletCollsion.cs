using UnityEngine;
using System.Collections;

public class BulletCollsion : MonoBehaviour {

	public float pauseAmnt;


	void Start(){
		Destroy (this.gameObject, 5f);
	}

	void OnCollisionEnter(Collision col){

		if(col.gameObject.tag == "Asteroid"){
			Destroy (col.gameObject, pauseAmnt);
				Destroy (this.gameObject);
		
		}
	}
		
}
