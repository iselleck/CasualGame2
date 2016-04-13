using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BulletCollsion : MonoBehaviour {

	public float pauseAmnt;

	private GameObject player;
	void Start(){
		Destroy (this.gameObject, 5f);
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void OnCollisionEnter(Collision col){

		if(col.gameObject.tag == "Asteroid"){
			Destroy (col.gameObject, pauseAmnt);
				Destroy (this.gameObject);
		
		}

		if(col.gameObject.tag == "spaceman"){
			PlayerOxygen playOxy = player.GetComponent<PlayerOxygen> ();
			playOxy.currentOx += 5;
			Destroy (col.gameObject);
			Destroy(this.gameObject);
		}
	}
		
}
