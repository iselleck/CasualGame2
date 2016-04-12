using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerCollision : MonoBehaviour {


	List<string> phrases = new List<string> ();

	public GameObject myCanvas;

	private string str;

	void Start(){

		phrases.Add ("Every day my metal friend shakes my bed at six AM");
		phrases.Add ("Don’t tell the bank I’m out here.");
		phrases.Add ("Things are looking up!");
		phrases.Add ("Didn’t count on becoming what I am today");
		phrases.Add ("A little off center and I’m out of tune, but I’m alright");
		phrases.Add ("Suit’s too hot, be too cold without it.");
		phrases.Add ("Working on growing a garden here.");
		phrases.Add ("95% cotton 5% polyester, tumble dry only.");
		phrases.Add ("A little too little, a little too late.");
		phrases.Add ("All music made past the year 1969 is rap.");
		phrases.Add ("First you have democrats and republicans. Then you have green party and uh, the whigs.");

	}

	void OnTriggerEnter(Collider col){

		if(col.gameObject.name == "spaceman"){

			if (myCanvas.GetComponent<Text> () != null) {
				Destroy (myCanvas.GetComponent<Text> ());
			} else {

				int ran = Random.Range (0, 10);

				StartCoroutine (AnimateText(phrases[ran]));

					//phrases [ran];
		
			}

		};
	}

	void OnTriggerExit(Collider col){

		if (col.gameObject.name == "spaceman") {

			if (myCanvas.GetComponent<Text> () != null) {
				Destroy (myCanvas.GetComponent<Text> ());
			} 
		}
		
	}

	IEnumerator AnimateText(string strComplete){
		int i = 0;
		str = "";
		while( i < strComplete.Length ){

			if (myCanvas.GetComponent<Text> () != null) {
				Destroy (myCanvas.GetComponent<Text> ());
			} else {
				str += strComplete [i++];
				Text chng = myCanvas.AddComponent<Text> ();

				chng.text = str;
				chng.alignment = TextAnchor.MiddleCenter;

				Font ArialFont = (Font)Resources.GetBuiltinResource (typeof(Font), "Arial.ttf");
				chng.font = ArialFont;
				chng.material = ArialFont.material;
			}

			yield return new WaitForSeconds(0.01F);

		}
	}
}






















