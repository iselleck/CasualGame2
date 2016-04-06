using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Astronaut : MonoBehaviour {

	public Canvas myCanvas;


	private List<string> phraseList = new List<string>();

	// Use this for initialization
	void Start () {

		myCanvas.enabled = false;
		phraseList.Add ("Every day my metal friend shakes my bed at six AM");
		phraseList.Add ("Don’t tell the bank I’m out here.");
		phraseList.Add ("Things are looking up!");
		phraseList.Add ("Didn’t count on becoming what I am today");
		phraseList.Add ("A little off center and I’m out of tune, but I’m alright");
		phraseList.Add ("Suit’s too hot, be too cold without it.");
		phraseList.Add ("Working on growing a garden here.");
		phraseList.Add ("95% cotton 5% polyester, tumble dry only.");
		phraseList.Add ("A little too little, a little too late.");
		phraseList.Add ("All music made past the year 1969 is rap.");
		phraseList.Add ("First you have democrats and republicans. Then you have green party and uh, the whigs.");
		phraseList.Add ("Got no beef with repetition.");
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider trigger){
		if(trigger.gameObject.name == "player"){

			int ran = Random.Range (0,11);
			Debug.Log (phraseList[ran]);

			myCanvas.enabled = true;

		}

	}

	void OnTriggerExit(Collider trig){

		myCanvas.enabled = false;
	}
}
